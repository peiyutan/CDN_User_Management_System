using CDN_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CDN_MVC.Controllers
{
    public class UserController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44372/api");
        private readonly HttpClient _client;

        public UserController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<UserViewModel> productList = new List<UserViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/user/Get").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                productList = JsonConvert.DeserializeObject<List<UserViewModel>>(data);

            }
            return View(productList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/User/Post", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "User Created.";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                UserViewModel product = new UserViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/user/Get/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    product = JsonConvert.DeserializeObject<UserViewModel>(data);
                }
                return View(product);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }

        }

        [HttpPost]
        public IActionResult Edit(UserViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/User/Put", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "User details updated.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                UserViewModel product = new UserViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/user/Get/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    product = JsonConvert.DeserializeObject<UserViewModel>(data);
                }
                return View(product);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/user/Delete/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "User details deleted.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }

            return View();
        }
    }
}
