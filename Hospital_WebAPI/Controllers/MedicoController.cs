using Hospital_WebAPI.Business;
using Hospital_WebAPI.Mapping;
using Hospital_WebAPI.RESPONSE;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        BusinessLogicMedico businessLogicMedico = new BusinessLogicMedico();
        Response response = new Response();
        // GET: api/<MedicoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                response = await businessLogicMedico.LlamarAMappingGetMedico();
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

        // GET api/<MedicoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllMedicos(string cedula)
        {
            try
            {
                response = await businessLogicMedico.LlamarAMappingGetMedicoByCedula(cedula);
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

        // POST api/<MedicoController>
        [HttpPost]
        public async Task<IActionResult> AddMedic(string cedula, string nombre, string apellido, string telefono, string correo, string especialidad, string cargo)
        {
            try
            {
                response = await businessLogicMedico.LlamarAMappingAddMedico(cedula, nombre, apellido, telefono, correo, especialidad, cargo);
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

        // PUT api/<MedicoController>/5
        [HttpPut]
        public async Task<IActionResult> Put(string cedula, string nombre, string apellido, string telefono, string correo, string espcialidad, string cargo)
        {
            try
            {
                response = await businessLogicMedico.LlamarAMappingUpdateMedico(cedula, nombre, apellido, telefono, correo,  espcialidad, cargo);
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

        //DELETE api/<MedicoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string cedula)
        {
            try
            {
                response = await businessLogicMedico.LlamarAMappingDeleteMedico(cedula);
            }
            catch(Exception ex)
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
