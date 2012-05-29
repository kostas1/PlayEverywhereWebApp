using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace PlayEv.Model.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        [HiddenInput(DisplayValue= false)]
        public string Password { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
