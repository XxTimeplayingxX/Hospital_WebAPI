using Hospital_WebAPI.Database;
using Hospital_WebAPI.RESPONSE;
using System.Data.SqlClient;
using System.Data;

namespace Hospital_WebAPI.Mapping
{
    public class CitaMedicaMapping
    {
        public async Task<Response> GetCitasMedicasMapping()
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
                SqlCommand command = new("GetAllCitasMedicas", connection);//Para esto debo de hacer un stored Procedure en sql

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
        public async Task<Response> GetCitaMedicaByCedulaMapping(string cedula)
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
                SqlCommand command = new("GetCitaMedicaByCedulaCliente", connection);//Para esto debo de hacer un stored Procedure en sql

                command.Parameters.Add(new SqlParameter("@cedulaPaciente", SqlDbType.VarChar, 10)).Value = cedula;

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
        public async Task<Response> PutUpdateCitasMedicasMapping(int idConsulta,DateTime FechaIngreso,
            string observaciones, string especialidad, string cedulaPaciente)
        {
            /* @idConsulta int,
                @fechaIngreso datetime,
                @observaciones varchar(50),
                @especialidad varchar(50),
                @cedulaPaciente varchar(10)
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
                SqlCommand command = new("UpdateCitaMedica", connection);//Para esto debo de hacer un stored Procedure en sql

                command.Parameters.Add(new SqlParameter("@idConsulta", SqlDbType.Int)).Value = idConsulta;
                command.Parameters.Add(new SqlParameter("@fechaIngreso", SqlDbType.DateTime)).Value = FechaIngreso;
                command.Parameters.Add(new SqlParameter("@observaciones", SqlDbType.VarChar, 50)).Value = observaciones;
                command.Parameters.Add(new SqlParameter("@especialidad", SqlDbType.VarChar, 50)).Value = especialidad;
                command.Parameters.Add(new SqlParameter("@cedulaPaciente", SqlDbType.VarChar, 10)).Value = cedulaPaciente;

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
        public async Task<Response> PostAddCitaMedicaMapping(DateTime FechaIngreso, 
            string observaciones, string especialidad, string cedulaPaciente)
        {
            /* @fechaIngreso datetime,
               @observaciones varchar(50),
               @especialidad varchar(50),
               @cedulaPaciente varchar(10)
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
                SqlCommand command = new("PostCitaMedica", connection);//Para esto debo de hacer un stored Procedure en sql

                command.Parameters.Add(new SqlParameter("@fechaIngreso", SqlDbType.DateTime)).Value = FechaIngreso;
                command.Parameters.Add(new SqlParameter("@observaciones", SqlDbType.VarChar, 50)).Value = observaciones;
                command.Parameters.Add(new SqlParameter("@especialidad", SqlDbType.VarChar, 50)).Value = especialidad;
                command.Parameters.Add(new SqlParameter("@cedulaPaciente", SqlDbType.VarChar, 10)).Value = cedulaPaciente;

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
