using System;
using System.Collections.Generic;

#nullable disable

namespace Kitten_Pokedex
{
    public partial class User
    {
        public User()
        {
            PokemonsUsers = new HashSet<PokemonsUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Killed { get; set; }
        public int Death { get; set; }

        public virtual ICollection<PokemonsUser> PokemonsUsers { get; set; }
    }
}
