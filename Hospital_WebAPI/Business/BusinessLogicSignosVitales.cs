using Hospital_WebAPI.Mapping;
using Hospital_WebAPI.MODELS;
using Hospital_WebAPI.RESPONSE;
using System.Data;

namespace Hospital_WebAPI.Business
{
    public class BusinessLogicSignosVitales
    {
        SignosVitalesMapping signosVitalesMapping = new SignosVitalesMapping();
        Response Response = null;
        public async Task<Response> LlamarAMappingGetAllSignosVitales()
        {
            try
            {
                List<SignosVitales> signosVitalesList = new();
                Response = await signosVitalesMapping.GetSignosVitalesMapping();
                if (Response.code == ResponseType.Success)
                {
                    var dataSet = (DataSet)Response.data;
                    foreach (DataRow rows in dataSet.Tables[0].Rows)
                    {
                        SignosVitales signosVitales = new SignosVitales();
                        signosVitales.nombre = rows["nombre"].ToString();
                        signosVitales.apellido = rows["apellido"].ToString();
                        signosVitales.cedula = rows["cedula"].ToString();
                        signosVitales.telefono = rows["telefono"].ToString();
                        signosVitales.correo = rows["correo"].ToString();
                        signosVitales.numero_historial = rows["numero_historial"].ToString();
                        signosVitales.Temperatura = rows["temperatura"].ToString();
                        signosVitales.Pulso = rows["pulso"].ToString();
                        signosVitales.FrecuenciaRespiratoria = rows["frecuenciaRespiratoria"].ToString();
                        signosVitales.PresionArterial = rows["presionArterial"].ToString();
                        signosVitales.Observaciones = rows["observaciones"].ToString();
                        signosVitales.fecha = DateTime.Parse(rows["fecha"].ToString());
                        signosVitalesList.Add(signosVitales);
                    }
                }
                Response.data = signosVitalesList;
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
        public async Task<Response> LlamarAMappingGetSignosVitalesByCedula(string cedula)
        {
            try
            {
                SignosVitales signosVitales = null;
                Response = await signosVitalesMapping.GetSignosVitalesByCedulaMapping(cedula);
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
                            signosVitales = new SignosVitales();
                            signosVitales.nombre = rows["nombre"].ToString();
                            signosVitales.apellido = rows["apellido"].ToString();
                            signosVitales.cedula = rows["cedula"].ToString();
                            signosVitales.telefono = rows["telefono"].ToString();
                            signosVitales.correo = rows["correo"].ToString();
                            signosVitales.numero_historial = rows["numero_historial"].ToString();
                            signosVitales.Temperatura = rows["temperatura"].ToString();
                            signosVitales.FrecuenciaRespiratoria = rows["frecuenciaRespiratorio"].ToString();
                            signosVitales.PresionArterial = rows["presionArterial"].ToString();
                            signosVitales.Observaciones = rows["observaciones"].ToString();
                            signosVitales.fecha = DateTime.Parse(rows["fecha"].ToString());
                        }
                    }
                }
                Response.data = signosVitales;
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
        public async Task<Response> LlamarAMappingUpdateSignosVitales(string cedula, string temperatura,
            string pulso, string frecuenciaRespiratoria, string presionArterial, string observaciones, DateTime fecha)
        {
            try
            {
                Response = await signosVitalesMapping.PutUpdateSignosVitalesMapping(cedula, temperatura, pulso, frecuenciaRespiratoria, presionArterial, observaciones, fecha);
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
        public async Task<Response> LlamarAMappingAddSignosVitales(string cedula, string temperatura,
            string pulso, string frecuenciaRespiratoria, string presionArterial, string observaciones, DateTime fecha)
        {
            try
            {
                Response = await signosVitalesMapping.PostAddSignosVitalesMapping(cedula, temperatura, pulso, frecuenciaRespiratoria, presionArterial, observaciones, fecha);
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
