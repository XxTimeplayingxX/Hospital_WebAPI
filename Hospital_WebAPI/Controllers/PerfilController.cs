using Hospital_WebAPI.Business;
using Hospital_WebAPI.RESPONSE;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        BusinessLogicPerfil businessLogicPerfil = new BusinessLogicPerfil();
        Response response = null;
        // GET: api/<PerfilController>
        [HttpGet]
        public async Task<IActionResult> GetPerfil()
        {
            try
            {
                response = await businessLogicPerfil.LlamarAGetMapping();
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

        // GET api/<PerfilController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                response = await businessLogicPerfil.LlamarAGetMappingById(id);
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

        // POST api/<PerfilController>
        [HttpPost]
        public async Task<IActionResult> Post(string nombre)
        {
            try
            {
                response = await businessLogicPerfil.LlamarAPostMapping(nombre);
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

        // PUT api/<PerfilController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, string nombre)
        {
            try
            {
                response = await businessLogicPerfil.LlamarAPutMapping(id, nombre);
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
