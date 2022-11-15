using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Common.Dto
{
    public class UserDTO
    {
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ProfilePhoto { get; set; }
        [Required]
        public System.DateTime CreateDate { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
    }
}
