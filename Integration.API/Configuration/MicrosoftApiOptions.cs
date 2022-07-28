namespace Integration.API.Configuration
{
    public class MicrosoftApiOptions
    {
        public static string Section = "Application:MicrosoftApi";
        public string BaseUrl { get; set; }
        public string TokenUrl { get; set; }
        public string RedirectUrl { get; set; }
       
    }
}