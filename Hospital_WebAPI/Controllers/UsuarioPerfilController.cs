using Hospital_WebAPI.Business;
using Hospital_WebAPI.RESPONSE;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioPerfilController : ControllerBase
    {
        BusinessLogicUsuarioPerfil businessLogicUsuarioPerfil = new BusinessLogicUsuarioPerfil();
        Response response = null;
        // GET: api/<UsuarioPerfilController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                response = await businessLogicUsuarioPerfil.LlamarAGetMapping();
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
            return Ok(response);
        }

        // GET api/<UsuarioPerfilController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                response = await businessLogicUsuarioPerfil.LlamarAGetByIdMapping(id);
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
            return Ok(response);
        }

        // POST api/<UsuarioPerfilController>
        [HttpPost]
        public async Task<IActionResult> Post(int idUusuario, int idPerfil)
        {
            try
            {
                response = await businessLogicUsuarioPerfil.LlamarAMappingPost(idUusuario, idPerfil);
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
            return Ok(response);
        }

        // PUT api/<UsuarioPerfilController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, int perfil, int usuario)
        {
            try
            {
                response = await businessLogicUsuarioPerfil.LlamarAMappingPut(id, perfil, usuario);
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
            return Ok(response);
        }

    }
}
