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
        public DBBoolResult LoginValidation(LoginModel loginModel)
        {
            var resultSP = _sprBusiness.LoginValidation(loginModel);
            var isAuthenticated = resultSP.Count > 0 && resultSP[0].result == 1;

            return new DBBoolResult
            {
                result = isAuthenticated ? 1 : 0,
                value = isAuthenticated ? "Autenticación verificada!" : "Usuario o contraseña incorrecta"
            };
        }


    }
}
