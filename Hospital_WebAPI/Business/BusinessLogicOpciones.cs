using Hospital_WebAPI.Mapping;
using Hospital_WebAPI.MODELS;
using Hospital_WebAPI.RESPONSE;
using System.Data;

namespace Hospital_WebAPI.Business
{
    public class BusinessLogicOpciones
    {
        OpcionesMapping opcionesMapping = new OpcionesMapping();
        Response response = null;
        public async Task<Response> LlamarAGetOpciones()
        {
            try
            {
                List<Opciones> opcionesList = new List<Opciones>();
                response = await opcionesMapping.GetOpcionesMapping();
                if(response.code == ResponseType.Success)
                {
                    var dataset = (DataSet)response.data;
                    foreach (DataRow rows in dataset.Tables[0].Rows)
                    {
                        Opciones opciones = new Opciones();
                        opciones.Nombre = rows["nombre"].ToString();
                        opcionesList.Add(opciones);
                    }
                    response.data = opcionesList;
                }
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
        public async Task<Response> LlamarAGetOpcionesById(int Id)
        {
            try
            {
                response = await opcionesMapping.GetOpcioneByIDMapping(Id);
                if (response.code == ResponseType.Success)
                {
                    var dataset = (DataSet)response.data;
                    Opciones opciones = new Opciones();
                    foreach (DataRow rows in dataset.Tables[0].Rows)
                    {
                        opciones.Nombre = rows["nombre"].ToString();
                    }
                    response.data = opciones;
                }
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
