using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kitten_Pokedex;
using System.Security.Claims;

namespace Kitten_Pokedex.Controllers
{
    [Route("users")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly pokemonsContext _context;

        public UsersController(pokemonsContext context)
        {
            _context = context;
        }

        // GET: Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetTodoItems()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: Users/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("register")]
        public async Task<IActionResult> Create([Bind("Id,Name,Password,Killed,Death")] User user)
        {
            user.Killed = 0;
            user.Death = 0;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(Details), new { id = user.Id }, user);
        }
    }
}
