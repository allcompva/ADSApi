
namespace ADSWebApi.Models
{
    public class Formulario
    {
        public string days { get; set; }
        public string people { get; set; }
        public string purpose { get; set; }
        public string TravelMethod { get; set; }
        public string IsFirstVisit { get; set; }
        public string mail_turista { get; set; }

        public Formulario()
        {
            days= string.Empty;
            people= string.Empty;
            purpose= string.Empty;
            TravelMethod= string.Empty;
            IsFirstVisit= string.Empty;
            mail_turista= string.Empty;
        }
    }
}
