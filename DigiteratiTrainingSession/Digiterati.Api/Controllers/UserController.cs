using Core.ViewModel;
using Digiterati.Core.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Digiterati.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

       // [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        //public async Task<IActionResult> GetUser(string UserName)
        //{
        //    var result = await _userService.GetUser(UserName);
        //    if (result != null)
        //        return new OkObjectResult(result);
        //    else
        //        return new NoContentResult();
        //}

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SoftLock))]
        //public async Task<IActionResult> CreateUser(UserDto user)
        //{
        //    await _userService.CreateUser(user);
        //    return new OkObjectResult(user);
        //}

    }
}
