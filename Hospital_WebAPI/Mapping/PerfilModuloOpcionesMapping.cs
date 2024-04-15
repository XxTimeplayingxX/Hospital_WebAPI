using Hospital_WebAPI.Database;
using Hospital_WebAPI.RESPONSE;
using System.Data.SqlClient;
using System.Data;

namespace Hospital_WebAPI.Mapping
{
    public class PerfilModuloOpcionesMapping
    {
        public async Task<Response> GetPerfilModuloOpcionesMapping()
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
                SqlCommand command = new("GetPerfil_Modulo_Opciones", connection);
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
        public async Task<Response> PutUpdateCitasMedicasMapping(int id, int perfilId, int moduloId, int opcionesId)
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
                SqlCommand command = new("PutPerfil_Modulo_Opciones", connection);//Para esto debo de hacer un stored Procedure en sql

                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
                command.Parameters.Add(new SqlParameter("@perfil_id", SqlDbType.Int)).Value = perfilId;
                command.Parameters.Add(new SqlParameter("@modulo_id", SqlDbType.Int)).Value = moduloId;
                command.Parameters.Add(new SqlParameter("@opciones_id", SqlDbType.Int)).Value = opcionesId;

                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataAdapter = new(command);

                int result = await command.ExecuteNonQueryAsync();
                response = new Response()
                {
                    code = ResponseType.Success,
                    message = "Respuesta exitosa",
                    data = null
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
        public async Task<Response> PostAddCitaMedicaMapping(int perfilId, int moduloId, int opcionesId)
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
                SqlCommand command = new("PostPerfil_Modulo_Opciones", connection);//Para esto debo de hacer un stored Procedure en sql

                command.Parameters.Add(new SqlParameter("@perfil_id", SqlDbType.Int)).Value = perfilId;
                command.Parameters.Add(new SqlParameter("@modulo_id", SqlDbType.Int)).Value = moduloId;
                command.Parameters.Add(new SqlParameter("@opciones_id", SqlDbType.Int)).Value = opcionesId;

                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataAdapter = new(command);
                int result = await command.ExecuteNonQueryAsync();
                response = new Response()
                {
                    code = ResponseType.Success,
                    message = "Respuesta exitosa",
                    data = null
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
