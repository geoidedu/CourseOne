using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkOne.DbAccess.Services;
using WorkOne.Models.UserModels;

namespace WorkOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody] RegisterUserModel modal)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    return new JsonResult(await _userService.Register(modal));
                }
                catch (Exception ex)
                {
                    return new JsonResult(ex);
                }
            }
            return BadRequest(ModelState);
        }
    }
}
