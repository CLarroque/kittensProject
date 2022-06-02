using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;

namespace Kitten_Pokedex
{
    public class Pokedex
    {
        public long id { get; set; }
        public string nameenglish { get; set; }
        public string namejapanese { get; set; }
        public string namefrench { get; set; }
        public string type0 { get; set; }
        public string type1 { get; set; }
        public long baseHP { get; set; }
        public long baseAttack { get; set; }
        public long baseDefense { get; set; }
        public long baseSp_Attack { get; set; }
        public long baseSp_Defense { get; set; }
        public long baseSpeed { get; set; }

    }
}
