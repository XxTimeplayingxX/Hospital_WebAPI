using Hospital_WebAPI.Business;
using Hospital_WebAPI.Mapping;
using Hospital_WebAPI.MODELS;
using Hospital_WebAPI.RESPONSE;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        BusinessLogicPaciente BusinessLogicPaciente = new BusinessLogicPaciente();
        Response response = new Response();
        //// GET: api/<PacienteController>
        [HttpGet]
        public async Task<IActionResult> GetAllPaciente()
        {
            try
            {
                response = await BusinessLogicPaciente.LlamarAPacientesMapping();
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

        // GET api/<PacienteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPacienteByCedula(string cedula)
        {
            try
            {
                response = await BusinessLogicPaciente.LlamarAPacienteCedulaMapping(cedula);
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

        // POST api/<PacienteController>
        [HttpPost]
        public async Task<IActionResult> AddNewPaciente(string nombre, string apellido, string cedula, string telefono, string correo, string numeroHistorial)
        {
            try
            {
                response = await BusinessLogicPaciente.LlamarAMappingAddPaciente(nombre, apellido, cedula, telefono, correo, numeroHistorial);
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

        //// PUT api/<PacienteController>/5
        [HttpPut]
        public async Task<IActionResult> UpdatePaciente(string cedula, string nombre, string apellido, string telefono, string correo, string numHistorial)
        {
            try
            {
                response = await BusinessLogicPaciente.LlamarAMappingUpdatePacienteMapping(cedula, nombre, apellido, telefono, correo, numHistorial);
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

        // DELETE api/<PacienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string cedula)
        {
            try
            {
                response = await BusinessLogicPaciente.LlamarAMappingDeletePacienteMapping(cedula);
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
