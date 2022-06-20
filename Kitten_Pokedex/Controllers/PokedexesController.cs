using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kitten_Pokedex;

namespace Kitten_Pokedex.Controllers
{
    [Route("pokemons")]
    [ApiController]
    public class PokedexesController : Controller
    {
        private readonly pokemonsContext _context;

        public PokedexesController(pokemonsContext context)
        {
            _context = context;
        }

        // GET: Pokedexes
        [HttpGet("language/{lang}")]
        public async Task<Object> GetTodoItems(string lang)
        {
            var query = from p in _context.Pokedices
                        join t in _context.Types on p.Type0 equals t.Id
                        join t2 in _context.Types on p.Type1 equals t2.Id into ct2
                        from t2 in ct2.DefaultIfEmpty()
                        select new
                        {
                              id = p.Id,
                              name = p.Namefrench,
                              type0 = t.French,
                              type1 = t2.French == null ? "null" : t2.French,
                              baseHP = p.BaseHp,
                              baseAttack = p.BaseAttack,
                              baseDefense = p.BaseDefense,
                              baseSp_Attack = p.BaseSpAttack,
                              baseSp_Defense = p.BaseSpDefense,
                              baseSpeed = p.BaseSpeed
                          };
            if (lang.Equals("english"))
            {
                query = from p in _context.Pokedices
                            join t in _context.Types on p.Type0 equals t.Id
                            join t2 in _context.Types on p.Type1 equals t2.Id into ct2
                            from t2 in ct2.DefaultIfEmpty()
                            select new
                            {
                                id = p.Id,
                                name = p.Nameenglish,
                                type0 = t.English,
                                type1 = t2.English,
                                baseHP = p.BaseHp,
                                baseAttack = p.BaseAttack,
                                baseDefense = p.BaseDefense,
                                baseSp_Attack = p.BaseSpAttack,
                                baseSp_Defense = p.BaseSpDefense,
                                baseSpeed = p.BaseSpeed
                            };
            }
            else if (lang.Equals("chinese"))
            {
                query = from p in _context.Pokedices
                        join t in _context.Types on p.Type0 equals t.Id
                        join t2 in _context.Types on p.Type1 equals t2.Id into ct2
                        from t2 in ct2.DefaultIfEmpty()
                        select new
                        {
                            id = p.Id,
                            name = p.Namechinese,
                            type0 = t.Chinese,
                            type1 = t2.Chinese,
                            baseHP = p.BaseHp,
                            baseAttack = p.BaseAttack,
                            baseDefense = p.BaseDefense,
                            baseSp_Attack = p.BaseSpAttack,
                            baseSp_Defense = p.BaseSpDefense,
                            baseSpeed = p.BaseSpeed
                        };
            }
            else if (lang.Equals("japanese"))
            {
                query = from p in _context.Pokedices
                        join t in _context.Types on p.Type0 equals t.Id
                        join t2 in _context.Types on p.Type1 equals t2.Id into ct2
                        from t2 in ct2.DefaultIfEmpty()
                        select new
                        {
                            id = p.Id,
                            name = p.Namejapanese,
                            type0 = t.Japanese,
                            type1 = t2.Japanese,
                            baseHP = p.BaseHp,
                            baseAttack = p.BaseAttack,
                            baseDefense = p.BaseDefense,
                            baseSp_Attack = p.BaseSpAttack,
                            baseSp_Defense = p.BaseSpDefense,
                            baseSpeed = p.BaseSpeed
                        };
            }
          
            return await query.ToListAsync();
        }


        private bool PokedexExists(int id)
        {
            return _context.Pokedices.Any(e => e.Id == id);
        }
    }
}
