using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TokenNet6.Interfaces;

namespace TokenNet6.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISppBusiness _sppBusiness;
        public ProductsController(ISppBusiness sppBusiness)
        {
            _sppBusiness = sppBusiness;
        }
        [HttpGet]
        [Route("GetProducts")]
        public dynamic GetProducts()
        {
            var result = _sppBusiness.ListProducts();

            if (result is null)
                return BadRequest(new { message = "Credenciales incorrectas" });

            return new
            {
                //message = jwtToken
                message = result
            };
        }
    }
}
