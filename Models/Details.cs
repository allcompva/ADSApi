namespace ADSWebApi.Models
{
    public class Details
    {
        public string cuit { get; set; }
        public string titulo { get; set; }    
        public string direccion { get; set; }
        public string maps { get; set; }
        public string whatsapp { get; set; }
        public string descripcion { get; set; }
        public string images { get; set; }

        public Details()
        {
            cuit = string.Empty;
            titulo = string.Empty;
            direccion = string.Empty;
            maps = string.Empty;
            whatsapp = string.Empty;
            descripcion = string.Empty;
            images = string.Empty;  
        }

    }
}
