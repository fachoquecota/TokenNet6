using System.Data;
using System.Data.SqlClient;
using TokenNet6.Interfaces;
using TokenNet6.Models;

namespace TokenNet6.Data.StoreProcedures
{
    public class StoredProcedureRepository : ISprBusiness
    {
        public List<DBBoolResult> LoginValitation(LoginModel loginModel)
        {
            //* Utilizamos DBBoolResult de tipo Models para recepcionar la información porque
            //* cabe la posibilidad de que se aumenten más columnas en la respuesta del procedimiento almacenado
            //* es posible usar otro método para aumentar las columnas sin necesida de cambiar este código
            var oList = new List<DBBoolResult>();
            try
            {
                var cn = new DbConnection();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_UserValidator", conexion);
                    cmd.Parameters.AddWithValue("@VCH_Username", loginModel.Username);
                    cmd.Parameters.AddWithValue("@VCH_Password", loginModel.Password);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oList.Add(new DBBoolResult()
                            {
                                result = Convert.ToInt32(dr["Result"]),
                            });
                        }
                    }
                }
                return oList;
            }
            catch (Exception ex)
            {
                ErrorResult.ErrorMessage = ex.Message;
                oList.Add(new DBBoolResult()
                {
                    result = 0,
                    value = ex.Message
                });
                return oList;
            }        
        }
    }
}
