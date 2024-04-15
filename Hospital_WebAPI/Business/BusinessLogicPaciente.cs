using Hospital_WebAPI.Database;
using Hospital_WebAPI.Mapping;
using Hospital_WebAPI.MODELS;
using Hospital_WebAPI.RESPONSE;
using System.Data;
using System.Data.SqlClient;

namespace Hospital_WebAPI.Business
{
    public class BusinessLogicPaciente
    {
        PacienteMapping pacienteMapping = new PacienteMapping();
        Response response = null;
        public async Task<Response> LlamarAPacientesMapping()
        {
            try
            {
                List<Paciente> pacienteList = new();
                response = await pacienteMapping.GetPacientesMapping();
                if (response.code == ResponseType.Success)
                {
                    var dataSet = (DataSet)response.data;
                    foreach (DataRow rows in dataSet.Tables[0].Rows)
                    {
                        Paciente _paciente = new Paciente();

                        _paciente.nombre = rows["nombre"].ToString();
                        _paciente.apellido = rows["apellido"].ToString();
                        _paciente.cedula = rows["cedula"].ToString();
                        _paciente.telefono = rows["telefono"].ToString();
                        _paciente.numero_historial = rows["numero_historial"].ToString();
                        pacienteList.Add(_paciente);
                    }
                }
                response.data = pacienteList;
            }
            catch (Exception ex)
            {
                response = new Response()
                {
                    code = ResponseType.Error,
                    message = ex.Message,
                    data = ex.InnerException
                };
            }

            return response;

        }
        public async Task<Response> LlamarAPacienteCedulaMapping(string cedula)
        {
            try
            {
                Paciente _paciente = null;
                response = await pacienteMapping.GetPacienteCedulaMapping(cedula);
                if (response.code == ResponseType.Success)
                {
                    var dataSet = (DataSet)response.data;
                    if (dataSet.Tables[0].Rows.Count == 0)
                    {
                        response = new Response()
                        {
                            code = ResponseType.Error,
                            message = "Error, valor no encontrado",
                            data = "Error, valor no encontrado"
                        };
                    }
                    else
                    {
                        foreach (DataRow rows in dataSet.Tables[0].Rows)
                        {
                            _paciente = new Paciente();
                            _paciente.nombre = rows["nombre"].ToString();
                            _paciente.apellido = rows["apellido"].ToString();
                            _paciente.cedula = rows["cedula"].ToString();
                            _paciente.telefono = rows["telefono"].ToString();
                            _paciente.correo = rows["correo"].ToString();
                            _paciente.numero_historial = rows["numero_historial"].ToString();
                        }
                    }
                }
                response.data = _paciente;
            }
            catch (Exception ex)
            {
                response = new Response()
                {
                    code = ResponseType.Error,
                    message = ex.Message,
                    data = ex.InnerException
                };
            }

            return response;

        }
        public async Task<Response> LlamarAMappingAddPaciente(string nombre, string apellido, string cedula, string telefono, string correo, string numeroHistorial)
        {
            try
            {
                response = await pacienteMapping.AddPacienteMapping(nombre, apellido, cedula,telefono, correo, numeroHistorial);
                response.data = null;
            }
            catch (Exception ex)
            {
                response = new Response()
                {
                    code = ResponseType.Error,
                    message = ex.Message,
                    data = ex.InnerException
                };
            }

            return response;

        }
        public async Task<Response> LlamarAMappingUpdatePacienteMapping(string cedula, string nombre, string apellido, string telefono, string correo, string numHistorial)
        {
            try
            {
                response = await pacienteMapping.UpdateUsuarioMapping(cedula, nombre, apellido, telefono, correo, numHistorial);
                response.data = null;
            }
            catch (Exception ex)
            {
                response = new Response()
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
