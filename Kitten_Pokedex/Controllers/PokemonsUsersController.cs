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
    [Route("equipe")]
    [ApiController]
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

        public async Task<ActionResult<PokemonsUser>> GetEquipe(long id)
        {
            var pokemon = await _context.PokemonsUsers.FindAsync(id);

            if (pokemon == null)
            {
                return NotFound();
            }

            return pokemon;
        }

        // GET: PokemonsUsers/Details/5
        [HttpGet("{id}")]
        public async Task<Object> Details(int? id)
        {

            var query = from p in _context.Pokedices
                        join pu in _context.PokemonsUsers on p.Id equals pu.IdPokemon
                        where pu.IdUser == id
                        select new
                        {
                            id = pu.Id,
                            name = p.Nameenglish,
                            slot = pu.Slot
                        };

            return await query.ToListAsync();
        }

        // POST: PokemonsUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult<PokemonsUser>> Create([Bind("Id,IdUser,IdPokemon,Slot,IdItem")] PokemonsUser pokemonsUser)
        {
            if(pokemonsUser.Slot < 1 || pokemonsUser.Slot > 6)
            {
                 return NotFound();
            }

            _context.PokemonsUsers.Add(pokemonsUser);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetEquipe), new { id = pokemonsUser.Id }, pokemonsUser);
        }

        // POST: PokemonsUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("{id}")]
        public async Task<ActionResult<PokemonsUser>> Edit(int id, [Bind("Id,IdUser,IdPokemon,Slot,IdItem")] PokemonsUser pokemonsUser)
        {

            var pokemon = await _context.PokemonsUsers.FindAsync(id);
            if(pokemon == null)
            {
                return NotFound();
            }

            pokemon.IdPokemon = pokemonsUser.IdPokemon;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!PokemonsUserExists(id))
            {
                return NotFound();
            }

            return pokemon;
        }
     

        private bool PokemonsUserExists(int id)
        {
            return _context.PokemonsUsers.Any(e => e.Id == id);
        }
    }
}
