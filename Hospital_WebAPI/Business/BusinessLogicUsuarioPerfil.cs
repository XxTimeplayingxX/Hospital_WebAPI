using Hospital_WebAPI.Mapping;
using Hospital_WebAPI.MODELS;
using Hospital_WebAPI.RESPONSE;
using System.Data;

namespace Hospital_WebAPI.Business
{
    public class BusinessLogicUsuarioPerfil
    {
        UsuarioPerfilMapping usuarioPerfilMapping = new UsuarioPerfilMapping();
        Response response = null;
        public async Task<Response> LlamarAGetMapping()
        {
            try
            {
                List<Usuario_Perfil> usuarioPerfilList = new List<Usuario_Perfil> ();
                response = await usuarioPerfilMapping.GetUsuarioPerfilMapping();
                if (response.code == ResponseType.Success)
                {
                    var dataSet = (DataSet)response.data;
                    foreach (DataRow rows in dataSet.Tables[0].Rows)
                    {
                        Usuario_Perfil usuario_Perfil = new Usuario_Perfil();
                        usuario_Perfil.idUsuario_Perfil = int.Parse(rows["id"].ToString());
                        usuario_Perfil.idUsuario = int.Parse(rows["usuario_id"].ToString());
                        usuario_Perfil.Perfilnombre = rows["nombre"].ToString();
                        usuario_Perfil.idPerfil = int.Parse(rows["perfil_id"].ToString());
                        usuario_Perfil.Username = rows["username"].ToString();
                        usuarioPerfilList.Add(usuario_Perfil);
                    }
                }
                response.data = usuarioPerfilList;
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
        public async Task<Response> LlamarAGetByIdMapping(int id)
        {
            try
            {
                Usuario_Perfil usuario_Perfil = new Usuario_Perfil();
                response = await usuarioPerfilMapping.GetUsuarioPerfilIDMapping(id);
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
                            usuario_Perfil.idUsuario_Perfil = int.Parse(rows["id"].ToString());
                            usuario_Perfil.idUsuario = int.Parse(rows["usuario_id"].ToString());
                            usuario_Perfil.Username = rows["username"].ToString();
                            usuario_Perfil.idPerfil = int.Parse(rows["perfil_id"].ToString());
                            usuario_Perfil.Perfilnombre = rows["nombre"].ToString();
                        }
                    } 
                }
                response.data = usuario_Perfil;
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
        public async Task<Response> LlamarAMappingPut(int id, int perfil, int usuario)
        {
            try
            {
                response = await usuarioPerfilMapping.PutUpdateUsuarioPerfilMapping(id, perfil, usuario);
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
        public async Task<Response> LlamarAMappingPost(int idUsuario, int idPerfil)
        {
            try
            {
                response = await usuarioPerfilMapping.PostAddUsuarioPerfilMapping(idUsuario, idPerfil);
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
