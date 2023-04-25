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
        public dynamic GetToken([FromQuery] LoginModel loginModel)
        {
            var result = _tokenNet.LoginValitation(loginModel);

            if (result is null)
                return BadRequest(new { message = "Credenciales incorrectas" });

            string jwtToken = _tokenService.GenerateToken(result);

            return new
            {
                message = jwtToken
            };
        }      
    }
}
