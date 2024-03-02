using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CDN_Web_API.DAL;
using CDN_Web_API.Models;

namespace CDN_Web_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyAppDbContext _context;

        public UserController(MyAppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var users = _context.Users.ToList();

                if (users.Count == 0)
                {
                    return NotFound("users not available.");
                }
                return Ok(users);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var user = _context.Users.Find(id);
                if (user == null)
                {
                    return NotFound($"User details not found with id {id}");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(User model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return Ok("User created.");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(User model)
        {
            if (model == null || model.Id == 0)
            {
                if (model == null)
                {
                    return BadRequest("Model data is invalid.");

                }
                else if (model.Id == 0)
                {
                    return BadRequest($"User Id {model.Id} is invalid.");
                }
            }

            try
            {
                var user = _context.Users.Find(model.Id);

                if (user == null)
                {
                    return NotFound($"User not found with id {model.Id}");
                }

                user.Username = model.Username;
                user.Mail = model.Mail;
                user.PhoneNumber = model.PhoneNumber;
                user.Skillsets = model.Skillsets;
                user.Hobby = model.Hobby;
                _context.SaveChanges();
                return Ok("User details updated");
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var user = _context.Users.Find(id);
                if (user == null)
                {
                    return NotFound($"User not found with id {id}");
                }
                _context.Users.Remove(user);
                _context.SaveChanges();
                return Ok("User details deleted.");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
