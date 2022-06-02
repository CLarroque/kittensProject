using System;
using System.Collections.Generic;

#nullable disable

namespace Kitten_Pokedex
{
    public partial class PokemonsUser
    {
        public int Id { get; set; }
        public int? IdUser { get; set; }
        public int? IdPokemon { get; set; }
        public int? Slot { get; set; }
        public int? IdItem { get; set; }

        public virtual Item IdItemNavigation { get; set; }
        public virtual Pokedex IdPokemonNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
