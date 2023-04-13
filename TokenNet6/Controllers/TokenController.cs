using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using TokenNet6.Business;
using TokenNet6.Interfaces;
using TokenNet6.Models;

namespace TokenNet6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenNet _tokenNet;
        public TokenController(ITokenNet tokenNet)
        {
            _tokenNet = tokenNet;
        }


        [HttpGet]
        [Route("GetTokenLogin")]
        public dynamic GetToken(LoginModel loginModel)
        {
            var result = _tokenNet.LoginValitation(loginModel);

            return new
            {
                mensaje = result
            };
        }
    }
}
