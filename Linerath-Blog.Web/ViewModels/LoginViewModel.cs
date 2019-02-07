using System;
using System.ComponentModel.DataAnnotations;

namespace Linerath_Blog.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public String Username { get; set; }
        [Required]
        public String Password { get; set; }
    }
}