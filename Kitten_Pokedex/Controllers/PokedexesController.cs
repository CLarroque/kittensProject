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
                        join t2 in _context.Types on p.Type1 equals t2.Id
                        select new
                        {
                              id = p.Id,
                              name = p.Namefrench,
                              type0 = t.French,
                              type1 = t2.French,
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
                            join t2 in _context.Types on p.Type1 equals t2.Id
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
                        join t2 in _context.Types on p.Type1 equals t2.Id
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
                        join t2 in _context.Types on p.Type1 equals t2.Id
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

       
        // GET: Pokedexes/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<int>> GetTodoItem(int? id)
        {
            return id;
           
        }

        // GET: Pokedexes/Create
        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pokedexes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nameenglish,Namejapanese,Namechinese,Namefrench,Type0,Type1,BaseHp,BaseAttack,BaseDefense,BaseSpAttack,BaseSpDefense,BaseSpeed")] Pokedex pokedex)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pokedex);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pokedex);
        }


        // GET: Pokedexes/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokedex = await _context.Pokedices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pokedex == null)
            {
                return NotFound();
            }

            return View(pokedex);
        }

        private bool PokedexExists(int id)
        {
            return _context.Pokedices.Any(e => e.Id == id);
        }
    }
}
