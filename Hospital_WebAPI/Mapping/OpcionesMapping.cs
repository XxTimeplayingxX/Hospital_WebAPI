using Hospital_WebAPI.Database;
using Hospital_WebAPI.RESPONSE;
using System.Data.SqlClient;
using System.Data;

namespace Hospital_WebAPI.Mapping
{
    public class OpcionesMapping
    {
        public async Task<Response> GetOpcionesMapping()
        {
            //Conexión con base de Datos
            HospitalDb hospitalDb = new HospitalDb();
            DataSet dataSetUsuario = new();
            SqlConnection connection = null;
            //Response
            Response response = null;
            response = hospitalDb.DatabaseConnection();

            if (response.code == ResponseType.Error)
            {
                return response;
            }
            connection = (SqlConnection)response.data;
            try
            {
                SqlCommand command = new("GetAllOpciones", connection);

                SqlDataAdapter dataAdapter = new(command);

                dataAdapter.Fill(dataSetUsuario);
                response = new Response()
                {
                    code = ResponseType.Success,
                    message = "Respuesta exitosa",
                    data = dataSetUsuario
                };
            }
            catch (Exception ex)
            {
                response = new Response() { code = ResponseType.Error, message = ex.Message, data = ex.InnerException };
            }
            finally
            {
                if (connection.State > 0)//Significa que esta abierta la conexión con la base de datos
                {
                    await connection.CloseAsync();
                }
            }
            return response;
        }

        public async Task<Response> GetOpcioneByIDMapping(int IdOpciones)
        {
            //Conexión con base de Datos
            HospitalDb hospitalDb = new HospitalDb();
            DataSet dataSet = new();
            SqlConnection connection = null;
            //Response: Respuesta
            Response response = null;
            response = hospitalDb.DatabaseConnection();

            if (response.code == ResponseType.Error)
            {
                return response;
            }
            connection = (SqlConnection)response.data;
            try
            {
                SqlCommand command = new("GetOpcionesById", connection);

                command.Parameters.Add(new SqlParameter("@idOpciones", SqlDbType.Int)).Value = IdOpciones;

                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataAdapter = new(command);

                dataAdapter.Fill(dataSet);
                response = new Response()
                {
                    code = ResponseType.Success,
                    message = "Respuesta exitosa",
                    data = dataSet
                };
            }
            catch (Exception ex)
            {
                response = new Response() { code = ResponseType.Error, message = ex.Message, data = ex.InnerException };
            }
            finally
            {
                if (connection.State > 0)//Significa que esta abierta la conexión con la base de datos
                {
                    await connection.CloseAsync();
                }
            }
            return response;
        }


        
       
    }
}
