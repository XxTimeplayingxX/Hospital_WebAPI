namespace Hospital_WebAPI.MODELS
{
    public class Paciente :Persona
    {
        public int id_Paciente { get; set; }
        public string numero_historial { get; set; }
        public int persona_id { get; set; }
    }
}
