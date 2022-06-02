using System;
using System.Collections.Generic;

#nullable disable

namespace Kitten_Pokedex
{
    public partial class Move
    {
        public int? Accuracy { get; set; }
        public string Category { get; set; }
        public string Cname { get; set; }
        public string Ename { get; set; }
        public int Id { get; set; }
        public string Jname { get; set; }
        public int? Power { get; set; }
        public int? Pp { get; set; }
        public string Type { get; set; }
        public int? Tm { get; set; }
        public int? MaxPp { get; set; }
    }
}
