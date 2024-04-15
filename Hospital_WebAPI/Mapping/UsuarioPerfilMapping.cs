using Hospital_WebAPI.Database;
using Hospital_WebAPI.RESPONSE;
using System.Data.SqlClient;
using System.Data;

namespace Hospital_WebAPI.Mapping
{
    public class UsuarioPerfilMapping
    {
        public async Task<Response> GetUsuarioPerfilMapping()
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
                SqlCommand command = new("GetAllUsuarioPerfil", connection);
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
        public async Task<Response> GetUsuarioPerfilIDMapping(int IdUsuarioPerfil)
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
                SqlCommand command = new("GetUsuarioPerfilById", connection);

                command.Parameters.Add(new SqlParameter("@idUsuarioPerfil", SqlDbType.Int)).Value = IdUsuarioPerfil;

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
        public async Task<Response> PutUpdateUsuarioPerfilMapping(int id, int idPerfil, int idUsuario)
        {
            /*@id int,
            @usuario_id int,
            @perfil_id int
            */
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
                SqlCommand command = new("PutUsuarioPerfil", connection);//Para esto debo de hacer un stored Procedure en sql

                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
                command.Parameters.Add(new SqlParameter("@perfil_id", SqlDbType.Int)).Value = idPerfil;
                command.Parameters.Add(new SqlParameter("@usuario_id", SqlDbType.Int)).Value = idUsuario;

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
        public async Task<Response> PostAddUsuarioPerfilMapping(int usuarioId, int perfilId)
        {
            /*
             * @usuario_id int,
               @perfil_id
            */
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
                SqlCommand command = new("PostUsuarioPerfil", connection);//Para esto debo de hacer un stored Procedure en sql

                command.Parameters.Add(new SqlParameter("@usuario_id", SqlDbType.Int)).Value = usuarioId;
                command.Parameters.Add(new SqlParameter("@perfil_id", SqlDbType.Int)).Value = perfilId;

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
