using System.Data;
using System.Data.SqlClient;
using TokenNet6.Interfaces;
using TokenNet6.Models;
namespace TokenNet6.Data.StoreProcedures
{
    public class StoredProcedureProducts : ISppBusiness
    {
        public List<ProductsModel> ListProducts()
        {
            var oList = new List<ProductsModel>();
            try
            {
                var cn = new DbConnection();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_ListAllProducts", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oList.Add(new ProductsModel()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Name = dr["Name"].ToString(),
                                Description = dr["Description"].ToString(),
                                Price = Convert.ToDecimal(dr["Price"]),
                                Quantity = Convert.ToInt32(dr["Quantity"]),
                                IsActive = Convert.ToBoolean(dr["IsActive"]),
                                CreatedDate = Convert.ToDateTime(dr["CreatedDate"]),

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
