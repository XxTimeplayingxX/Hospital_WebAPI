namespace Hospital_WebAPI.MODELS
{
    public class Medico : Persona
    {
        public int id_Medico { get; set; }
        public string especialidad { get; set; }
        public string cargo { get; set; }
    }
}
