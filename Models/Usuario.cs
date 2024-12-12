namespace ADSWebApi.Models
{
    public class Usuario
    {
        public string email { get; set; }
        public string password { get; set; }    
        public string provider { get; set; }    
        public bool habilitado { get; set; }    

    }
}
