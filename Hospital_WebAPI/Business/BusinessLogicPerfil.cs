using Hospital_WebAPI.Mapping;
using Hospital_WebAPI.MODELS;
using Hospital_WebAPI.RESPONSE;
using System.Data;

namespace Hospital_WebAPI.Business
{
    public class BusinessLogicPerfil
    {
        PerfilMapping PerfilMapping =new PerfilMapping();
        Response Response = null;
        public async Task<Response> LlamarAGetMapping()
        {
            try
            {
                List<Perfil> perfilList = new List<Perfil>();
                Response = await PerfilMapping.GetPerfilMapping();
                if (Response.code == ResponseType.Success)
                {
                    var dataSet = (DataSet)Response.data;
                    foreach (DataRow rows in dataSet.Tables[0].Rows)
                    {
                        Perfil perfil = new Perfil();
                        perfil.id_Perfil = int.Parse(rows["id"].ToString());
                        perfil.Nombre = rows["nombre"].ToString();
                        perfilList.Add(perfil);
                    }
                }
                Response.data = perfilList;
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
        public async Task<Response> LlamarAGetMappingById(int id)
        {
            try
            {
                Perfil perfil = null;
                Response = await PerfilMapping.GetPerfilIDMapping(id);
                if (Response.code == ResponseType.Success)
                {
                    var dataSet = (DataSet)Response.data;
                    foreach (DataRow rows in dataSet.Tables[0].Rows)
                    {
                        perfil = new Perfil();  
                        perfil.id_Perfil = int.Parse(rows["id"].ToString());
                        perfil.Nombre = rows["nombre"].ToString();
                    }
                }
                Response.data = perfil;
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
        public async Task<Response> LlamarAPostMapping(string nombre)
        {
            try
            {
                Response = await PerfilMapping.PostAddCitaMedicaMapping(nombre);
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
        public async Task<Response> LlamarAPutMapping(int id, string nombre)
        {
            try
            {
                Response = await PerfilMapping.PutPerfilMapping(id, nombre);
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
