using Hospital_WebAPI.Business;
using Hospital_WebAPI.RESPONSE;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilModuloOpcionesController : ControllerBase
    {
        BusinessLogicPerfilModuloOpciones businessLogicPerfilModuloOpciones = new BusinessLogicPerfilModuloOpciones();
        Response response = null;
        // GET: api/<PerfilModuloOpcionesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                response = await businessLogicPerfilModuloOpciones.LlamarAGetMapping();
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

        // POST api/<PerfilModuloOpcionesController>
        [HttpPost]
        public async Task<IActionResult> Post(int perfilId, int moduloId, int opcionesId)
        {
            try
            {
                response = await businessLogicPerfilModuloOpciones.llamarAPostMapping(perfilId, moduloId, opcionesId);
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

        // PUT api/<PerfilModuloOpcionesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, int perfilId, int moduloId, int opcionesId)
        {
            try
            {
                response = await businessLogicPerfilModuloOpciones.LlamarAPutMapping(id, perfilId, moduloId, opcionesId);
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
