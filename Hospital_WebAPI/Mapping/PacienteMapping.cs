using Hospital_WebAPI.Business;
using Hospital_WebAPI.Database;
using Hospital_WebAPI.MODELS;
using Hospital_WebAPI.RESPONSE;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;

namespace Hospital_WebAPI.Mapping
{
    public class PacienteMapping 
    {
        public async Task<Response> GetPacientesMapping()
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
                SqlCommand command = new("GetAllPaciente", connection);
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
        public async Task<Response> GetPacienteCedulaMapping(string cedula)
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
                SqlCommand command = new("GetPacienteByCedula", connection);//Para esto debo de hacer un stored Procedure en sql

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
        //Duda: Use la herencia para poder agregar los campos que no estaba usando, pero me salen campos de más
        //¿Como se puede arrglar eso?
        public async Task<Response> UpdateUsuarioMapping(string cedula, string nombre, string apellido, string telefono, string correo, string numHistorial)
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
                SqlCommand command = new("UpdatePaciente", connection);//Para esto debo de hacer un stored Procedure en sql

                command.Parameters.Add(new SqlParameter("@cedula", SqlDbType.VarChar, 10)).Value = cedula;
                command.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = nombre;
                command.Parameters.Add(new SqlParameter("@apellido", SqlDbType.VarChar, 50)).Value = apellido;
                command.Parameters.Add(new SqlParameter("@telefono", SqlDbType.VarChar, 50)).Value = telefono;
                command.Parameters.Add(new SqlParameter("@correo", SqlDbType.VarChar, 50)).Value = correo;
                command.Parameters.Add(new SqlParameter("@numeroHistorial", SqlDbType.VarChar, 50)).Value = numHistorial;

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
        public async Task<Response> AddPacienteMapping(string nombre, string apellido, string cedula, string telefono, string correo, string numeroHistorial)
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
                SqlCommand command = new("sp_InsertarPersonaYPaciente", connection);//Para esto debo de hacer un stored Procedure en sql

                command.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 50)).Value = nombre;
                command.Parameters.Add(new SqlParameter("@Apellido", SqlDbType.VarChar, 50)).Value = apellido;
                command.Parameters.Add(new SqlParameter("@Cedula", SqlDbType.VarChar, 50)).Value = cedula;
                command.Parameters.Add(new SqlParameter("@Telefono", SqlDbType.VarChar, 10)).Value = telefono;
                command.Parameters.Add(new SqlParameter("@Correo", SqlDbType.VarChar, 100)).Value = correo;
                command.Parameters.Add(new SqlParameter("@NumeroHistorial", SqlDbType.VarChar, 50)).Value = numeroHistorial;


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
