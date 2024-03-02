using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CDN_MVC.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        
        [Required]
        [DisplayName("User Name")]
        public string Username { get; set; }
        
        [Required]
        public string Mail { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; }

        public string Skillsets { get; set; }

        public string Hobby { get; set; }
    }
}
