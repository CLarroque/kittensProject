using System;
using System.Collections.Generic;

#nullable disable

namespace Kitten_Pokedex
{
    public partial class Pokedex
    {
        public Pokedex()
        {
            PokemonsUsers = new HashSet<PokemonsUser>();
        }

        public int Id { get; set; }
        public string Nameenglish { get; set; }
        public string Namejapanese { get; set; }
        public string Namechinese { get; set; }
        public string Namefrench { get; set; }
        public int Type0 { get; set; }
        public int? Type1 { get; set; }
        public int BaseHp { get; set; }
        public int BaseAttack { get; set; }
        public int BaseDefense { get; set; }
        public int BaseSpAttack { get; set; }
        public int BaseSpDefense { get; set; }
        public int BaseSpeed { get; set; }

        public virtual ICollection<PokemonsUser> PokemonsUsers { get; set; }
    }
}
