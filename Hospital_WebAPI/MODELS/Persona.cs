namespace Hospital_WebAPI.MODELS
{
    public class Persona
    {
        public int id_Persona { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string cedula { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public bool estado { get; set; }
    }
}
