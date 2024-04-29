using Hospital_WebAPI.MODELS;
using Hospital_WebAPI.RESPONSE;
using System.Data.SqlClient;
using System.Data;
using Hospital_WebAPI.Database;

namespace Hospital_WebAPI.Mapping
{
    public class MedicoMapping
    {
        public async Task<Response> GetMedicosMapping()
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
                SqlCommand command = new("GetAllMedicos", connection);//Para esto debo de hacer un stored Procedure en sql

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
        public async Task<Response> GetMedicoIDMapping(string cedulaMedico)
        {
            //Conexión con la base de datos
            HospitalDb hospitalDb = new HospitalDb();
            DataSet dataSet = new();
            SqlConnection connection = null;
            //Respuesta
            Response response = null;
            response = hospitalDb.DatabaseConnection();

            if (response.code == ResponseType.Error)
            {
                return response;
            }
            connection = (SqlConnection)response.data;
            try
            {
                SqlCommand command = new("GetMedicoByCedula", connection);

                command.Parameters.Add(new SqlParameter("@cedula", SqlDbType.VarChar, 10)).Value = cedulaMedico;

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
        public async Task<Response> UpdateMedicooMapping(string cedula, string nombre, string apellido, string telefono, string correo, string espcialidad, string cargo)
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
                SqlCommand command = new("UpdateMedico", connection);//Para esto debo de hacer un stored Procedure en sql

                command.Parameters.Add(new SqlParameter("@cedula", SqlDbType.VarChar, 10)).Value = cedula;
                command.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = nombre;
                command.Parameters.Add(new SqlParameter("@apellido", SqlDbType.VarChar, 50)).Value = apellido;
                command.Parameters.Add(new SqlParameter("@telefono", SqlDbType.VarChar, 50)).Value = telefono;
                command.Parameters.Add(new SqlParameter("@correo", SqlDbType.VarChar, 100)).Value = correo;
                command.Parameters.Add(new SqlParameter("@especialidad", SqlDbType.VarChar, 50)).Value = espcialidad;
                command.Parameters.Add(new SqlParameter("@cargo", SqlDbType.VarChar, 50)).Value = cargo;


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
        public async Task<Response> AddMedicoMapping(string cedula, string nombre, string apellido, string telefono, string correo, string especialidad, string cargo)
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
                SqlCommand command = new("sp_InsertarMedicoYPersona", connection);//Para esto debo de hacer un stored Procedure en sql

                command.Parameters.Add(new SqlParameter("@cedula", SqlDbType.VarChar, 10)).Value = cedula;
                command.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = nombre;
                command.Parameters.Add(new SqlParameter("@apellido", SqlDbType.VarChar, 50)).Value = apellido;
                command.Parameters.Add(new SqlParameter("@telefono", SqlDbType.VarChar, 10)).Value = telefono;
                command.Parameters.Add(new SqlParameter("@correo", SqlDbType.VarChar, 100)).Value = correo;
                command.Parameters.Add(new SqlParameter("@especialidad", SqlDbType.VarChar, 50)).Value = especialidad;
                command.Parameters.Add(new SqlParameter("@cargo", SqlDbType.VarChar, 50)).Value = cargo;

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
        public async Task<Response> DeleteMedicoIDMapping(string cedulaMedico)
        {
            //Conexión con la base de datos
            HospitalDb hospitalDb = new HospitalDb();
            DataSet dataSet = new();
            SqlConnection connection = null;
            //Respuesta
            Response response = null;
            response = hospitalDb.DatabaseConnection();

            if (response.code == ResponseType.Error)
            {
                return response;
            }
            connection = (SqlConnection)response.data;
            try
            {
                SqlCommand command = new("LogicDelete", connection);

                command.Parameters.Add(new SqlParameter("@cedula", SqlDbType.VarChar, 10)).Value = cedulaMedico;

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
