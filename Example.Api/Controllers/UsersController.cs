using Example.Core.DTOs;
using Example.Core.Configurations;
using Example.Core.Interfaces;
using Example.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(UsersService usersService) : ControllerBase
    {
        [HttpPost]
        [Route("auth")]
        public ActionResult<string> AuthenticateUser(AuthenticationRequest request)
        {
            var token = usersService.Authenticate(request.UserName, request.Password);

            if (token == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(new { Token = token });
        }
    }
}
