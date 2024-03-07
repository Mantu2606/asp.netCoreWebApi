﻿using System.ComponentModel.DataAnnotations; 

namespace WebPocHub.Models
{
    public class User
    {
        public int UserId { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Email Id is a required field!")]
        public string Email { get; set; } = string.Empty;

        [MaxLength(200)]
        [Required(ErrorMessage = "Password Id is a required field!")]
        public string Password { get; set; } = string.Empty;
        
        public int RoleId { get; set; }    
        
        public Role? Role  { get; set; }

    }
}
