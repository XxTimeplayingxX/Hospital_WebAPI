using Hospital_WebAPI.RESPONSE;
using System.Data.SqlClient;

namespace Hospital_WebAPI.Database
{
    public class HospitalDb
    {
        private string connectionString = Environment.GetEnvironmentVariable("ConnectionString");
        Response response = null;
        

        public Response DatabaseConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                response = new Response()
                {
                    code = ResponseType.Success,
                    message = "Conexión Exitosa",
                    data = connection
                };
            }
            catch (Exception ex)
            {
                return response = new Response()
                {
                    code = ResponseType.Error,
                    message = ex.Message,
                    data = ex.InnerException
                };
            }
            return response;

        }

    }

}
