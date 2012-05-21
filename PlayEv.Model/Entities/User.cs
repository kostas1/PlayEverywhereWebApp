using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayEv.Model.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
