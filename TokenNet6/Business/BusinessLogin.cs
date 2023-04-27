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
        public DBBoolResult LoginValitation(LoginModel loginModel)
        {
            var oList = new DBBoolResult();
            var resultSP = _sprBusiness.LoginValitation(loginModel);
            bool dataSPBool = resultSP.Count > 0 && resultSP[0].result.Equals(1);
            if (dataSPBool == false)
            {
                oList.result = 0;
                oList.value = "Usuario o contraseña incorrecta";
                return oList;
            }
            else
            {
                oList.result = 1;
                oList.value = "Autenticación verificada!";
                return oList;
            }
        }

    }
}
