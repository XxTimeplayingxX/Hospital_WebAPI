namespace Hospital_WebAPI.MODELS
{
    public class PerfilModuloOpciones
    {
        public int ID { get; set; }
        public int perfil_id { get; set; }
        public string nombrePerfil { get; set; }
        public int modulo_id { get; set; }
        public string nombreModulo { get; set; }
        public int opciones_id { get; set; }
        public string nombreOpciones { get; set; }
    }
}
