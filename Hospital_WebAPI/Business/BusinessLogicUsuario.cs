using Hospital_WebAPI.Mapping;
using Hospital_WebAPI.MODELS;
using Hospital_WebAPI.RESPONSE;
using Microsoft.AspNetCore.Mvc;
using System.Data;


namespace Hospital_WebAPI.Business
{
    public class BusinessLogicUsuario
    {
        UsuarioMapping usuarioMapping = new UsuarioMapping();
        Response response = null;
        public async Task<Response> LlamarAMappingUsuario()
        {
            try
            {
                List <usuario> usuarioList = new();
                response = await usuarioMapping.GetUsuariosMapping();
                if (response.code == ResponseType.Success)
                {
                    var dataSet = (DataSet)response.data;
                    foreach (DataRow rows in dataSet.Tables[0].Rows)
                    {
                        usuario Usuario = new usuario();
                        Usuario.id_usuario = int.Parse(rows["id"].ToString());
                        Usuario.username = rows["username"].ToString();
                        Usuario.password = rows["password"].ToString();
                        Usuario.persona_id = int.Parse(rows["persona_id"].ToString());
                        usuarioList.Add(Usuario);
                    }
                }
                response.data = usuarioList;
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
        public async Task<Response> LlamarAMapping(int ID)
        {
            try
            {
                usuario Usuario = null;
                response = await usuarioMapping.GetUsuarioIDMapping(ID);
                if(response.code == ResponseType.Success)
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
                            Usuario = new usuario();
                            Usuario.id_usuario = int.Parse(rows["id"].ToString());
                            Usuario.username = rows["username"].ToString();
                            Usuario.password = rows["password"].ToString();
                            Usuario.persona_id = int.Parse(rows["persona_id"].ToString());
                        }
                    }
                }
                response.data = Usuario;
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
        public async Task<Response> LlamarAMappingPutUsuario(int id, string usernme, string password)
        {
            try
            {
                response = await usuarioMapping.PutUsuarioMapping(id, usernme, password);
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
        public async Task<Response> LlamarAMappingPostUsuario(string usernme, string password)
        {
            try
            {
                response = await usuarioMapping.PostUsuarioMapping(usernme, password);
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
        public async Task<Response> LlamarAMappingDeleteUsuario(int id)
        {
            try
            {
                response = await usuarioMapping.DeleteUsuarioMapping(id);
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
        public async Task<Response> LlamarAMappingLoginUsuario(string usuario, string contraseña)
        {
            try
            {
                var res = "0";
                response = await usuarioMapping.LoginUsuarioMapping(usuario, contraseña);
                if (response.code == ResponseType.Success)
                {
                    var dataSet = (DataSet)response.data;
                    if (dataSet.Tables[0].Rows.Count == 0)
                    {
                        response = new Response()
                        {
                            code = ResponseType.Error,
                            message = "Error, Usuario/Contraseña mal escritos",
                            data = "Error"
                        };
                    }
                    else
                    {
                        foreach (DataRow rows in dataSet.Tables[0].Rows)
                        {
                            res = rows["UsuarioEncontrados"].ToString();
                        }
                    }
                }
                response.data = res;
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
