namespace Hospital_WebAPI.MODELS
{
    public class CitaMedica : Medico
    {
        public int id_CitaMedica { get; set; }
        public DateTime fecha_Ingreso { get; set; }
        public string Observaciones { get; set; }
        public string numeroHistorial { get; set; }
        public string NombreC { get; set; }
        public string ApellidoC { get; set; }
        public string CedulaC { get; set; }
        public string telefonoC { get; set; }
        public string correoC { get; set; }

    }
}
