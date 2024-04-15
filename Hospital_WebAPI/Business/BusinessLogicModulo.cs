using Hospital_WebAPI.Mapping;
using Hospital_WebAPI.MODELS;
using Hospital_WebAPI.RESPONSE;
using System.Data;

namespace Hospital_WebAPI.Business
{
    public class BusinessLogicModulo
    {
        ModuloMapping mapping = new ModuloMapping();
        Response response = new Response();
        public async Task<Response> LlamarAMappingGetModulo()
        {
            try
            {
                List<Modulo> moduloList = new List<Modulo>();
                response = await mapping.GetAllModulo();
                if (response.code == ResponseType.Success)
                {
                    var dataset = (DataSet)response.data;
                    foreach (DataRow rows in dataset.Tables[0].Rows)
                    {
                        Modulo modulo = new Modulo();
                        modulo.Nombre = rows["nombre"].ToString();
                        moduloList.Add(modulo);
                    }
                    response.data = moduloList;
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
        public async Task<Response> LlamarAMappingGetModuloById(int Id)
        {
            try
            {
                response = await mapping.GetModuloIDMapping(Id);
                if (response.code == ResponseType.Success)
                {
                    var dataset = (DataSet)response.data;
                    Modulo modulo = new Modulo();
                    foreach (DataRow rows in dataset.Tables[0].Rows)
                    {
                        modulo.Nombre = rows["nombre"].ToString();
                    }
                    response.data = modulo;
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
