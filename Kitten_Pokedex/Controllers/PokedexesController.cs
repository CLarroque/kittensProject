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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pokedex>>> GetTodoItems()
        {
            return await _context.Pokedices.ToListAsync();
        }

        // GET: Pokedexes/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pokedex>> GetTodoItem(int? id)
        {
            var todoItem = await _context.Pokedices.FindAsync(id);

            if(todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
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
