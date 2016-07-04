using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JAPhotography.Models
{
    public class AuthenticationModel
    {
        
        //public string Username { get; set; }
        [Required(ErrorMessage = "Email Address is required.", AllowEmptyStrings = false)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //public bool RememberMe { get; set; }

        [HiddenInput]
        public string ReturnUrl { get; set; }

        //public int ID { get; set; }
        //public string Name { get; set; }
        //public byte[] ProfileImage { get; set; }
        //public string Bio { get; set; }
        //public string EmailAddress { get; set; }
        //public string Password { get; set; }
    }
}
