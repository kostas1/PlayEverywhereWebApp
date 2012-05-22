using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayEv.Model.Entities
{
    public class Game
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public byte[] Icon { get; set; }
        public byte[] SourceCode { get; set; }
    }
}
