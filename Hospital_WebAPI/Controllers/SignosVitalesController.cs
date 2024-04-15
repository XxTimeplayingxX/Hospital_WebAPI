using Hospital_WebAPI.Business;
using Hospital_WebAPI.RESPONSE;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignosVitalesController : ControllerBase
    {
        BusinessLogicSignosVitales businessLogicSignosVitales = new BusinessLogicSignosVitales();
        Response response = new Response();
        // GET: api/<SignosVitalesController>
        [HttpGet]
        public async Task<IActionResult> GetAllSignosVitales()
        {
            try
            {
                response = await businessLogicSignosVitales.LlamarAMappingGetAllSignosVitales();
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

        // GET api/<SignosVitalesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSignoVitalesByCedula(string cedula)
        {
            try
            {
                response = await businessLogicSignosVitales.LlamarAMappingGetSignosVitalesByCedula(cedula);
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

        // POST api/<SignosVitalesController>
        [HttpPost]
        public async Task<IActionResult> AddNewSignosVitales(string cedula, string temperatura,
            string pulso, string frecuenciaRespiratoria, string presionArterial, string observaciones, DateTime fecha)
        {
            try
            {
                response = await businessLogicSignosVitales.LlamarAMappingAddSignosVitales(cedula, temperatura, pulso, frecuenciaRespiratoria, presionArterial, observaciones, fecha);
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

        // PUT api/<SignosVitalesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSignosVitales(string cedula, string temperatura,
            string pulso, string frecuenciaRespiratoria, string presionArterial, string observaciones, DateTime fecha)
        {
            try
            {
                response = await businessLogicSignosVitales.LlamarAMappingUpdateSignosVitales(cedula, temperatura, pulso, frecuenciaRespiratoria, presionArterial, observaciones, fecha);
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

        // DELETE api/<SignosVitalesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
