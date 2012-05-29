using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PlayEv.Model.Entities
{
    class FriendRelation
    {
        [Key]
        public int Myid { get; set; }
        public int Friendid { get; set; }
    }
}
