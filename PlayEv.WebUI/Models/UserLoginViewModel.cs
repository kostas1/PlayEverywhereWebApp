using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PlayEv.WebUI.Models
{
    public class UserLoginViewModel
    {
        [Required]
        public string Username { get; set; }
        // MD5 encoded
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}