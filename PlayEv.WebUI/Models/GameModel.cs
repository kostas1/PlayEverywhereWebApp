using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PlayEv.WebUI.Models
{
    public class GameModel
    {

        [Required(ErrorMessage="Please enter the name of game")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage="Write some description about the game")]
        [StringLength(250)]
        public string Description { get; set; }
        [Required(ErrorMessage="Specify game's category")]
        [StringLength(50)]
        public string Category { get; set; }
    }
}