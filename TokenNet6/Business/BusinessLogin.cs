using TokenNet6.Data.StoreProcedures;
using TokenNet6.Interfaces;
using TokenNet6.Models;
namespace TokenNet6.Business
{
    public class BusinessLogin : ITokenNet
    {
        private readonly ISprBusiness _sprBusiness;

        public BusinessLogin(ISprBusiness sprBusiness)
        {
            _sprBusiness = sprBusiness;
        }
        public LoginModel LoginValitation(LoginModel loginModel)
        {
            var resultSP = _sprBusiness.LoginValitation(loginModel);
            bool dataSPBool = resultSP.Count > 0 && resultSP[0].result.Equals(1);
            return dataSPBool ? loginModel : default(LoginModel);
        }

    }
}
