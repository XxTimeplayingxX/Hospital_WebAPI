using Hospital_WebAPI.Business;
using Hospital_WebAPI.RESPONSE;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaMedicaController : ControllerBase
    {
        BusinessLogicCitaMedica businessLogicCitaMedica = new BusinessLogicCitaMedica();
        Response response = new Response();
        // GET: api/<CitaMedicaController>
        [HttpGet]
        public async Task<IActionResult> GetAllCitaMedica()
        {
            try
            {
                response = await businessLogicCitaMedica.LlamarAMappingGetAllCitasMedicas();
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

        // GET api/<CitaMedicaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByCedula(string cedula)
        {
            try
            {
                response = await businessLogicCitaMedica.LlamarAMappingGetCitaMedicaByCedula(cedula);
            }catch(Exception ex)
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

        // POST api/<CitaMedicaController>
        [HttpPost]
        public async Task<IActionResult> Post(DateTime FechaIngreso,
            string observaciones, string especialidad, string cedulaPaciente)
        {
            try
            {
                response = await businessLogicCitaMedica.LlamarAMappingAddCitaMedica(FechaIngreso, observaciones, especialidad, cedulaPaciente);
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

        // PUT api/<CitaMedicaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int idConsulta, DateTime FechaIngreso,
            string observaciones, string especialidad, string cedulaPaciente)
        {
            try
            {
                response = await businessLogicCitaMedica.LlamarAMappingUpdateCitaMedica(idConsulta, FechaIngreso, observaciones, especialidad, cedulaPaciente);
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

        // DELETE api/<CitaMedicaController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
