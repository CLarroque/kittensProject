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
    public class PokemonsUsersController : Controller
    {
        private readonly pokemonsContext _context;

        public PokemonsUsersController(pokemonsContext context)
        {
            _context = context;
        }

        // GET: PokemonsUsers
        public async Task<IActionResult> Index()
        {
            var pokemonsContext = _context.PokemonsUsers.Include(p => p.IdItemNavigation).Include(p => p.IdPokemonNavigation).Include(p => p.IdUserNavigation);
            return View(await pokemonsContext.ToListAsync());
        }

        // GET: PokemonsUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemonsUser = await _context.PokemonsUsers
                .Include(p => p.IdItemNavigation)
                .Include(p => p.IdPokemonNavigation)
                .Include(p => p.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pokemonsUser == null)
            {
                return NotFound();
            }

            return View(pokemonsUser);
        }

        // GET: PokemonsUsers/Create
        public IActionResult Create()
        {
            ViewData["IdItem"] = new SelectList(_context.Items, "Id", "Nameenglish");
            ViewData["IdPokemon"] = new SelectList(_context.Pokedices, "Id", "Namechinese");
            ViewData["IdUser"] = new SelectList(_context.Users, "Id", "Name");
            return View();
        }

        // POST: PokemonsUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUser,IdPokemon,Slot,IdItem")] PokemonsUser pokemonsUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pokemonsUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdItem"] = new SelectList(_context.Items, "Id", "Nameenglish", pokemonsUser.IdItem);
            ViewData["IdPokemon"] = new SelectList(_context.Pokedices, "Id", "Namechinese", pokemonsUser.IdPokemon);
            ViewData["IdUser"] = new SelectList(_context.Users, "Id", "Name", pokemonsUser.IdUser);
            return View(pokemonsUser);
        }

        // GET: PokemonsUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemonsUser = await _context.PokemonsUsers.FindAsync(id);
            if (pokemonsUser == null)
            {
                return NotFound();
            }
            ViewData["IdItem"] = new SelectList(_context.Items, "Id", "Nameenglish", pokemonsUser.IdItem);
            ViewData["IdPokemon"] = new SelectList(_context.Pokedices, "Id", "Namechinese", pokemonsUser.IdPokemon);
            ViewData["IdUser"] = new SelectList(_context.Users, "Id", "Name", pokemonsUser.IdUser);
            return View(pokemonsUser);
        }

        // POST: PokemonsUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUser,IdPokemon,Slot,IdItem")] PokemonsUser pokemonsUser)
        {
            if (id != pokemonsUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pokemonsUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PokemonsUserExists(pokemonsUser.Id))
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
            ViewData["IdItem"] = new SelectList(_context.Items, "Id", "Nameenglish", pokemonsUser.IdItem);
            ViewData["IdPokemon"] = new SelectList(_context.Pokedices, "Id", "Namechinese", pokemonsUser.IdPokemon);
            ViewData["IdUser"] = new SelectList(_context.Users, "Id", "Name", pokemonsUser.IdUser);
            return View(pokemonsUser);
        }

        // GET: PokemonsUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemonsUser = await _context.PokemonsUsers
                .Include(p => p.IdItemNavigation)
                .Include(p => p.IdPokemonNavigation)
                .Include(p => p.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pokemonsUser == null)
            {
                return NotFound();
            }

            return View(pokemonsUser);
        }

        // POST: PokemonsUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pokemonsUser = await _context.PokemonsUsers.FindAsync(id);
            _context.PokemonsUsers.Remove(pokemonsUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PokemonsUserExists(int id)
        {
            return _context.PokemonsUsers.Any(e => e.Id == id);
        }
    }
}
