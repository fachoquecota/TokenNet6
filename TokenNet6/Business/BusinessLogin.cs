using TokenNet6.Data.StoreProcedures;
using TokenNet6.Interfaces;
using TokenNet6.Models;
namespace TokenNet6.Business
{
    public class BusinessLogin : ITokenNet
    {
        StoredProcedureRepository SPR = new StoredProcedureRepository();

        public string LoginValitation(LoginModel loginModel)
        {
            string result = "Ocurrió un error al procesar la solicitud.";

            var resultSP = SPR.LoginValitation(loginModel);
            bool dataSPBool = resultSP[0].result.Equals(1);
            //bool dataSPBool = bool.Parse(resultSP[0].result);
            if (dataSPBool is true)
            {
                result = "Sesión exitosa!";
            }
            else
            {
                result = "Usuario o contraseña incorrecta.";
            }
            return result;
        }
    }
}
