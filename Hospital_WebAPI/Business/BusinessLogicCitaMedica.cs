using Hospital_WebAPI.Mapping;
using Hospital_WebAPI.MODELS;
using Hospital_WebAPI.RESPONSE;
using System.Data;

namespace Hospital_WebAPI.Business
{
    public class BusinessLogicCitaMedica
    {
        CitaMedicaMapping citaMedicaMapping = new CitaMedicaMapping();
        Response Response = null;
        public async Task<Response> LlamarAMappingGetAllCitasMedicas()
        {
            try
            {
                List<CitaMedica> citaMedicaList = new();
                Response = await citaMedicaMapping.GetCitasMedicasMapping();
                if (Response.code == ResponseType.Success)
                {
                    var dataSet = (DataSet)Response.data;
                    foreach (DataRow rows in dataSet.Tables[0].Rows)
                    {
                        CitaMedica citaMedica = new CitaMedica();
                        citaMedica.fecha_Ingreso = (DateTime)rows["fecha_Ingreso"];
                        citaMedica.Observaciones = rows["observaciones"].ToString();
                        citaMedica.numeroHistorial = rows["numero_historial"].ToString();
                        citaMedica.NombreC = rows["nombre"].ToString();
                        citaMedica.ApellidoC = rows["apellido"].ToString();
                        citaMedica.CedulaC = rows["cedula"].ToString();
                        citaMedica.telefonoC = rows["telefono"].ToString();
                        citaMedica.correoC = rows["correo"].ToString();
                        citaMedica.especialidad = rows["especialidad"].ToString();
                        citaMedica.cargo = rows["cargo"].ToString();
                        citaMedica.nombre = rows["nombreMedico"].ToString();
                        citaMedica.apellido = rows["apellidoMedico"].ToString();
                        citaMedica.cedula = rows["cedulaMedico"].ToString();
                        citaMedica.correo = rows["CorreoMedico"].ToString();
                        citaMedicaList.Add(citaMedica);
                    }
                }
                Response.data = citaMedicaList;
            }
            catch (Exception ex)
            {
                Response = new Response()
                {
                    code = ResponseType.Error,
                    message = ex.Message,
                    data = ex.InnerException
                };
            }

            return Response;
        }
        public async Task<Response> LlamarAMappingGetCitaMedicaByCedula(string cedula)
        {
            try
            {
                List<CitaMedica> citaMedicaList = new();
                CitaMedica citaMedica = null;
                Response = await citaMedicaMapping.GetCitaMedicaByCedulaMapping(cedula);
                if (Response.code == ResponseType.Success)
                {
                    var dataSet = (DataSet)Response.data;
                    if (dataSet.Tables[0].Rows.Count == 0)
                    {
                        Response = new Response()
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
                            citaMedica = new CitaMedica();
                            citaMedica.fecha_Ingreso = (DateTime)rows["fecha_Ingreso"];
                            citaMedica.Observaciones = rows["observaciones"].ToString();
                            citaMedica.numeroHistorial = rows["numero_historial"].ToString();
                            citaMedica.NombreC = rows["nombre"].ToString();
                            citaMedica.ApellidoC = rows["apellido"].ToString();
                            citaMedica.CedulaC = rows["cedula"].ToString();
                            citaMedica.telefonoC = rows["telefono"].ToString();
                            citaMedica.especialidad = rows["especialidad"].ToString();
                            citaMedica.cargo = rows["cargo"].ToString();
                            citaMedica.nombre = rows["nombreMedico"].ToString();
                            citaMedica.apellido = rows["apellidoMedico"].ToString();
                            citaMedica.cedula = rows["cedulaMedico"].ToString();
                            citaMedica.correo = rows["CorreoMedico"].ToString();
                            citaMedicaList.Add(citaMedica);
                        }
                    }
                }
                Response.data = citaMedicaList;
            }
            catch (Exception ex)
            {
                Response = new Response()
                {
                    code = ResponseType.Error,
                    message = ex.Message,
                    data = ex.InnerException
                };
            }

            return Response;

        }
        public async Task<Response> LlamarAMappingUpdateCitaMedica(int idConsulta, DateTime FechaIngreso,
            string observaciones, string especialidad, string cedulaPaciente)
        {
            try
            {
                Response = await citaMedicaMapping.PutUpdateCitasMedicasMapping(idConsulta, FechaIngreso, observaciones, especialidad, cedulaPaciente);
                Response.data = null;
            }
            catch (Exception ex)
            {
                Response = new Response()
                {
                    code = ResponseType.Error,
                    message = ex.Message,
                    data = ex.InnerException
                };
            }

            return Response;

        }
        public async Task<Response> LlamarAMappingAddCitaMedica(DateTime FechaIngreso,
            string observaciones, string especialidad, string cedulaPaciente)
        {
            try
            {
                Response = await citaMedicaMapping.PostAddCitaMedicaMapping(FechaIngreso, observaciones, especialidad, cedulaPaciente);
                Response.data = null;
            }
            catch (Exception ex)
            {
                Response = new Response()
                {
                    code = ResponseType.Error,
                    message = ex.Message,
                    data = ex.InnerException
                };
            }

            return Response;

        }
    }
}
