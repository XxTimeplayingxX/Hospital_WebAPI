using Hospital_WebAPI.Business;
using Hospital_WebAPI.MODELS;
using Hospital_WebAPI.RESPONSE;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        BusinessLogicUsuario businessLogicUsuario = new BusinessLogicUsuario();
        Response response = new Response();
        
        // GET: api/<UserController>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                response = await businessLogicUsuario.LlamarAMapping(id);
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

        // GET api/<UserController>/5
        [HttpGet]
        public async Task<IActionResult> GetAllUsuario()
        {
            try
            {
                response = await businessLogicUsuario.LlamarAMappingUsuario();
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
        [HttpPost]
        public async Task<IActionResult> Post(string username, string password,
            string nombre, string apellido, string cedula, string telefono, string correo)
        {
            try
            {
                response = await businessLogicUsuario.LlamarAMappingPostUsuario(username, password
                    ,nombre, apellido, cedula, telefono, correo);
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

        // PUT api/<UserController>/5
        //Actualizar
        [HttpPut("{id}")]
        public async Task<IActionResult>  Put(int id, string username, string password)
        {
            try
            {
                response = await businessLogicUsuario.LlamarAMappingPutUsuario(id, username, password);
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

        //// DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult>  Delete(int id)
        {
            try
            {
                response = await businessLogicUsuario.LlamarAMappingDeleteUsuario(id);
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
