using Hospital_WebAPI.Business;
using Hospital_WebAPI.RESPONSE;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpcionesController : ControllerBase
    {
        Response response = new Response();
        BusinessLogicOpciones businessLogicOpciones = new BusinessLogicOpciones();
        // GET: api/<OpcionesController>
        [HttpGet]
        public async Task<IActionResult> GetAllOpciones()
        {
            try
            {
                response = await businessLogicOpciones.LlamarAGetOpciones();
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

        // GET api/<OpcionesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByOpcioId(int id)
        {
            try
            {
                response = await businessLogicOpciones.LlamarAGetOpcionesById(id);
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
