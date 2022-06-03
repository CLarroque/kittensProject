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
        public IQueryable<Object> GetTodoItems()
        {
            return from p in _context.Pokedices
                   join t in _context.Types on p.Type0 equals t.Id into type0Poke
                   select new
                   {
                       name = p.Namefrench,
                   };
        }

        // GET: Pokedexes/Details/5
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pokedexes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
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

        // GET: Pokedexes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokedex = await _context.Pokedices.FindAsync(id);
            if (pokedex == null)
            {
                return NotFound();
            }
            return View(pokedex);
        }

        // POST: Pokedexes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nameenglish,Namejapanese,Namechinese,Namefrench,Type0,Type1,BaseHp,BaseAttack,BaseDefense,BaseSpAttack,BaseSpDefense,BaseSpeed")] Pokedex pokedex)
        {
            if (id != pokedex.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pokedex);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PokedexExists(pokedex.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pokedex);
        }

        // GET: Pokedexes/Delete/5
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

        // POST: Pokedexes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pokedex = await _context.Pokedices.FindAsync(id);
            _context.Pokedices.Remove(pokedex);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PokedexExists(int id)
        {
            return _context.Pokedices.Any(e => e.Id == id);
        }
    }
}
