using Hospital_WebAPI.Mapping;
using Hospital_WebAPI.MODELS;
using Hospital_WebAPI.RESPONSE;
using System.Data;

namespace Hospital_WebAPI.Business
{
    public class BusinessLogicPerfilModuloOpciones
    {
        PerfilModuloOpcionesMapping perfilModuloOpcionesMapping = new PerfilModuloOpcionesMapping();
        Response response = new Response();
        public async Task<Response> LlamarAGetMapping()
        {
            try
            {
                List<PerfilModuloOpciones> perfilModuloOpcionesList = new List<PerfilModuloOpciones>();
                response = await perfilModuloOpcionesMapping.GetPerfilModuloOpcionesMapping();
                if (response.code == ResponseType.Success)
                {
                    var dataSet = (DataSet)response.data;
                    foreach (DataRow rows in dataSet.Tables[0].Rows)
                    {
                        PerfilModuloOpciones perfilModuloOpciones = new PerfilModuloOpciones();
                        perfilModuloOpciones.ID = int.Parse(rows["id"].ToString());
                        perfilModuloOpciones.perfil_id = int.Parse(rows["pefil_id"].ToString());
                        perfilModuloOpciones.nombrePerfil = rows["nombrePerfil"].ToString();
                        perfilModuloOpciones.modulo_id = int.Parse(rows["modulo_id"].ToString());
                        perfilModuloOpciones.nombreModulo = rows["moduloNombre"].ToString();
                        perfilModuloOpciones.opciones_id = int.Parse(rows["opciones_id"].ToString());
                        perfilModuloOpciones.nombreOpciones = rows["opcionesNombre"].ToString();
                        perfilModuloOpcionesList.Add(perfilModuloOpciones);
                    }
                }
                response.data = perfilModuloOpcionesList;
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
        public async Task<Response> LlamarAPutMapping(int id, int perfilId, int moduloId, int opcionesId)
        {
            try
            {
                response = await perfilModuloOpcionesMapping.PutUpdateCitasMedicasMapping(id, perfilId, moduloId, opcionesId);
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
        public async Task<Response> llamarAPostMapping(int perfilId, int moduloId, int opcionesId)
        {
            try
            {
                response = await perfilModuloOpcionesMapping.PostAddCitaMedicaMapping(perfilId, moduloId, opcionesId);
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
