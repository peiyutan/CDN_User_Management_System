using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDN_Web_API.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]

        public string PhoneNumber { get; set; }
        [Required]
        public string Skillsets { get; set; }

        public string Hobby { get; set; }
    }
}
