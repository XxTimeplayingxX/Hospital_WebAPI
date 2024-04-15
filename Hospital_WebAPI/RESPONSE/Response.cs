namespace Hospital_WebAPI.RESPONSE
{
    public class Response
    {
        public ResponseType code { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
    public enum ResponseType
    {
        Success = 00,
        Error = 01
    }
}
