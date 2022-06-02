﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Kitten_Pokedex
{
    public partial class Item
    {
        public Item()
        {
            PokemonsUsers = new HashSet<PokemonsUser>();
        }

        public int Id { get; set; }
        public string Nameenglish { get; set; }
        public string Namejapanese { get; set; }
        public string Namechinese { get; set; }

        public virtual ICollection<PokemonsUser> PokemonsUsers { get; set; }
    }
}
