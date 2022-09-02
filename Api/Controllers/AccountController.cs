using Microsoft.AspNetCore.Mvc;
using Api.Auth.Common;

namespace TokenApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        readonly IJwtService jwtService;
        public AccountController(IJwtService jwtService)
        {
            this.jwtService = jwtService;
        }
        [HttpPost("/token")]
        public IActionResult Token(string username, string password)
        {
            var token = jwtService.GetToken(username, password);
            return token == null ? BadRequest("Can't get token") : Ok(token);
        }
    }
}