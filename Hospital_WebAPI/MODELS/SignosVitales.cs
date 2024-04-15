namespace Hospital_WebAPI.MODELS
{
    public class SignosVitales : Paciente
    {
        public int id_SignosVitales { get; set; }
        public string Temperatura { get; set; }
        public string Pulso { get; set; }
        public string FrecuenciaRespiratoria { get; set; }
        public string PresionArterial { get; set; }
        public string Observaciones { get; set; }
        public DateTime fecha { get; set; }
    }
}
