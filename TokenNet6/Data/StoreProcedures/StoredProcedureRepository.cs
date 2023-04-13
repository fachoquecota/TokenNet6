using System.Data;
using System.Data.SqlClient;
using TokenNet6.Models;

namespace TokenNet6.Data.StoreProcedures
{
    public class StoredProcedureRepository
    {
        public List<DBBoolResult> LoginValitation(LoginModel loginModel)
        {
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
                                result = dr["Result"].ToString(),
                            });
                        }
                    }
                }
                return oList;
            }
            catch (Exception ex)
            {
                ErrorResult.ErrorMessage = ex.Message;
                return oList;
            }        
        }
    }
}
