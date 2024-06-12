using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TokenNet6.Interfaces;
using TokenNet6.Models;

namespace TokenNet6.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenNet _tokenNet;
        private readonly ITokenService _tokenService;

        public TokenController(ITokenNet tokenNet, IConfiguration configuration, ITokenService tokenService)
        {
            _tokenNet = tokenNet;
            _tokenService = tokenService;          
        }

        [HttpPost]
        [Route("GetTokenLogin")]
        public IActionResult GetToken([FromBody] LoginModel loginModel)
        {
            if (loginModel == null)
            {
                return BadRequest(new { message = "Invalid login model" });
            }

            var result = _tokenNet.LoginValidation(loginModel);
            if (result == null)
            {
                return BadRequest(new { message = "Login validation failed" });
            }

            if (result.result == 1)
            {
                var token = _tokenService.GenerateToken(loginModel);
                return Ok(new
                {
                    Result = result.value,
                    Token = token
                });
            }

            return Unauthorized(new
            {
                Result = result.value,
                message = "Invalid login credentials"
            });
        }


    }
}
