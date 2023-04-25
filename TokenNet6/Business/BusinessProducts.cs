using TokenNet6.Data.StoreProcedures;
using TokenNet6.Interfaces;
using TokenNet6.Models;
namespace TokenNet6.Business
{
    public class BusinessProducts : IProducts
    {
        private readonly ISppBusiness _sppBusiness;

        public BusinessProducts(ISppBusiness sppBusiness)
        {
            _sppBusiness = sppBusiness;
        }
        public List<ProductsModel> ListProducts()
        {
            var resultSP = _sppBusiness.ListProducts();
            return resultSP;
        }
    }
}
