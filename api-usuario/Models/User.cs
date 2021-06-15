using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api_usuario.Controllers;

namespace api_usuario.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }


        [MaxLength(50, ErrorMessage = "Exceeded 60 character limit")]
        [MinLength(6, ErrorMessage = "Requires at least 6 characters")]
        public string Name { get; set; }

        //TODO: Validar senha forte

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }










    }
}
