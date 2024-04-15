namespace Hospital_WebAPI.MODELS
{
    public class Usuario_Perfil 
    { 
        public int idUsuario_Perfil { get; set; }
        public int idPerfil { get; set; }
        public string Perfilnombre { get; set; }
        public int idUsuario { get; set; }
        public string Username { get; set; }
    }
}
