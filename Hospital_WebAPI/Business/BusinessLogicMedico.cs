using Hospital_WebAPI.Mapping;
using Hospital_WebAPI.MODELS;
using Hospital_WebAPI.RESPONSE;
using System.Data;

namespace Hospital_WebAPI.Business
{
    public class BusinessLogicMedico
    {
        MedicoMapping medicoMapping = new MedicoMapping();
        Response response = null;
        public async Task<Response> LlamarAMappingGetMedico()
        {
            try
            {
                List<Medico> medicoList = new();
                response = await medicoMapping.GetMedicosMapping();
                if (response.code == ResponseType.Success)
                {
                    var dataSet = (DataSet)response.data;
                    foreach (DataRow rows in dataSet.Tables[0].Rows)
                    {
                        Medico medico = new Medico();
                        medico.nombre = rows["nombre"].ToString();
                        medico.apellido = rows["apellido"].ToString();
                        medico.cedula = rows["cedula"].ToString();
                        medico.telefono = rows["telefono"].ToString();
                        medico.correo = rows["correo"].ToString();
                        medico.estado = bool.Parse(rows["estado"].ToString());
                        medico.especialidad = rows["especialidad"].ToString();
                        medico.cargo = rows["cargo"].ToString();
                        medicoList.Add(medico);
                    }
                }
                response.data = medicoList;
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
        public async Task<Response> LlamarAMappingGetMedicoByCedula(string cedula)
        {
            try
            {
                Medico medico = null;
                response = await medicoMapping.GetMedicoIDMapping(cedula);
                if (response.code == ResponseType.Success)
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
                            medico = new Medico();
                            medico.nombre = rows["nombre"].ToString();
                            medico.apellido = rows["apellido"].ToString();
                            medico.cedula = rows["cedula"].ToString();
                            medico.telefono = rows["telefono"].ToString();
                            medico.correo = rows["correo"].ToString();
                            medico.estado = bool.Parse(rows["estado"].ToString());
                            medico.especialidad = rows["especialidad"].ToString();
                            medico.cargo = rows["cargo"].ToString();
                        }
                    }
                }
                response.data = medico;
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
        public async Task<Response> LlamarAMappingUpdateMedico(string cedula, string nombre, string apellido, string telefono, string correo, string espcialidad, string cargo)
        {
            try
            {
                response = await medicoMapping.UpdateMedicooMapping(cedula, nombre, apellido, telefono, correo, espcialidad, cargo);
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
        public async Task<Response> LlamarAMappingAddMedico(string cedula, string nombre, string apellido, string telefono, string correo,string especialidad, string cargo)
        {
            try
            {
                response = await medicoMapping.AddMedicoMapping(cedula, nombre, apellido, telefono, correo, especialidad, cargo);
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
        public async Task<Response> LlamarAMappingDeleteMedico(string cedula)
        {
            try
            {
                response = await medicoMapping.DeleteMedicoIDMapping(cedula);
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

    }
}
