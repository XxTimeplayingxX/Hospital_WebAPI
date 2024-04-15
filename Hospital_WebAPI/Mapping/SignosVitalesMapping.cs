using Hospital_WebAPI.Database;
using Hospital_WebAPI.RESPONSE;
using System.Data.SqlClient;
using System.Data;

namespace Hospital_WebAPI.Mapping
{
    public class SignosVitalesMapping
    {
        public async Task<Response> GetSignosVitalesMapping()
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
                SqlCommand command = new("GetAllSignosVitales", connection);//Para esto debo de hacer un stored Procedure en sql

                //command.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int)).Value = IdUsuario;

                //command.CommandType = CommandType.StoredProcedure;
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
        public async Task<Response> GetSignosVitalesByCedulaMapping(string cedula)
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
                SqlCommand command = new("GetSignosVitalesByCedula", connection);//Para esto debo de hacer un stored Procedure en sql

                command.Parameters.Add(new SqlParameter("@cedula", SqlDbType.VarChar, 10)).Value = cedula;

                command.CommandType = CommandType.StoredProcedure;
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
        public async Task<Response> PutUpdateSignosVitalesMapping(string cedula, string temperatura, 
            string pulso, string frecuenciaRespiratoria, string presionArterial,string observaciones, DateTime fecha)
        {
            /* @cedulaPaciente varchar(10),
               @temperatura varchar(50),
               @pulso varchar(50),
               @frecuenciaRespiratoria varchar(50),
               @presionArterial varchar(50),
               @observaciones text, 
               @fecha datetime
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
                SqlCommand command = new("UpdateSignosVitales", connection);//Para esto debo de hacer un stored Procedure en sql

                command.Parameters.Add(new SqlParameter("@cedula", SqlDbType.VarChar, 10)).Value = cedula;
                command.Parameters.Add(new SqlParameter("@temperatura", SqlDbType.VarChar, 50)).Value = temperatura;
                command.Parameters.Add(new SqlParameter("@pulso", SqlDbType.VarChar, 50)).Value = pulso;
                command.Parameters.Add(new SqlParameter("@frecuenciaRespiratoria", SqlDbType.VarChar, 50)).Value = frecuenciaRespiratoria;
                command.Parameters.Add(new SqlParameter("@presionArterial", SqlDbType.VarChar, 50)).Value = presionArterial;
                command.Parameters.Add(new SqlParameter("@observaciones", SqlDbType.Text)).Value = observaciones;
                command.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime)).Value = fecha;

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
        public async Task<Response> PostAddSignosVitalesMapping(string cedula, string temperatura,
            string pulso, string frecuenciaRespiratoria, string presionArterial, string observaciones, DateTime fecha)
        {
            /* @cedulaPaciente varchar(10),
            @temperatura varchar(50),
            @pulso varchar(50),
            @frecuenciaRespiratoria varchar(50),
            @presionArterial varchar(50),
            @observaciones text, 
            @fecha datetime
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
                SqlCommand command = new("sp_InsertarSignosVitales", connection);//Para esto debo de hacer un stored Procedure en sql

                command.Parameters.Add(new SqlParameter("@cedulaPaciente", SqlDbType.VarChar, 10)).Value = cedula;
                command.Parameters.Add(new SqlParameter("@temperatura", SqlDbType.VarChar, 50)).Value = temperatura;
                command.Parameters.Add(new SqlParameter("@pulso", SqlDbType.VarChar, 50)).Value = pulso;
                command.Parameters.Add(new SqlParameter("@frecuenciaRespiratoria", SqlDbType.VarChar, 50)).Value = frecuenciaRespiratoria;
                command.Parameters.Add(new SqlParameter("@presionArterial", SqlDbType.VarChar, 50)).Value = presionArterial;
                command.Parameters.Add(new SqlParameter("@observaciones", SqlDbType.Text)).Value = observaciones;
                command.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime)).Value = fecha;

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
