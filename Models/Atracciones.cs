namespace ADSWebApi.Models
{
    public class Atracciones
    {
        public int atraccionId { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string ubicacion { get; set; }
        public string googleMaps { get; set; }
        public string fotos { get; set; }
        public bool publicada { get; set; }
    }
}
