// Web service using Entity Framework that handles queries to the sql server database that manages users

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyManagerServices.Data;
using MyManagerShared.Models;

namespace MyManagerServices.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MMServicesContext _context;

        public UsersController(MMServicesContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser() // Get list of all users
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id) // Get specific user by id
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // GET: api/Users/email
        [HttpGet("login/{email}")]
        public async Task<ActionResult<User>> GetUserByEmail(string email) // Get a user by their email or return an empty user if their isn't one
        {
            var theUser = _context.User.Where(user => user.Email.Equals(email));

            return theUser.Any() ? theUser.First() : new User { FirstName = "", LastName = "", Email = "", Password = ""};
        }

        // GET: api/Users/banknumber
        [HttpGet("transaction/{bankNumber}")]
        public async Task<ActionResult<User>> GetUserByBankNumber(int bankNumber) // Get user by their bank number or return back an empty one
        {
            var theUser = _context.User.Where(user => user.BankNumber == bankNumber);

            return theUser.Any() ? theUser.First() : new User { FirstName = "", LastName = "", Email = "", Password = "", BankNumber = 0 };
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user) // Update an existing user
        {
            if (id != user.userID)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user) // Create a new user
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.userID }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id) // Remove a user by their id
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id) // Check to see whether a user exists with a certain id
        {
            return _context.User.Any(e => e.userID == id);
        }
    }
}
