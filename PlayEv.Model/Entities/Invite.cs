using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace PlayEv.Model.Entities
{
    public class Invite
    {
        [Key]
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public int SessionId { get; set; }
        public int GameId { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
    }
}
