using TokenNet6.Data.StoreProcedures;
using TokenNet6.Models;
namespace TokenNet6.Business
{
    public class BusinessLogin
    {
        StoredProcedureRepository SPR = new StoredProcedureRepository();
        public string Get(LoginModel loginModel)
        {
            string result = "Ocurrió un error al procesar la solicitud.";
            try
            {
                var resultSP = SPR.LoginValitation(loginModel);
                bool dataSPBool = bool.Parse(resultSP[0].result);
                if (dataSPBool is true)
                {
                    result = "Sesión exitosa!";
                }
                else if (dataSPBool is false)
                {
                    result = "Usuario o contraseña incorrecta.";
                }
                return result;
            }
            catch (Exception ex)
            {
                return result + ex.Message;
            }
        }
    }
}
