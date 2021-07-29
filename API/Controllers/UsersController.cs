using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        // this is Synchronous request/response, 
        // another request can be made only after the prior request is fulfilled
        //List has more features, such as sorting
        // public ActionResult<IEnumerable<AppUser>> GetUers()
        // {
        //     return _context.Users.ToList();
        // }

        // api/users/3
        // [HttpGet("{id}")]
        // public ActionResult<AppUser> GetUers(int id)
        // {
        //     return _context.Users.Find(id);
        // }

        
        // below is asynchronous
        // api/users
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUers()
        {
            return await _context.Users.ToListAsync();
        }

        // api/users/3
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUers(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}