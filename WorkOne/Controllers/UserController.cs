using Domain;
using Microsoft.AspNetCore.Mvc;
using WorkOne.DbAccess;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private AppDbContext _db;

        public UserController(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_db.AppUsers.ToList());
        }

    }
}
