namespace Integration.API.Configuration
{
    public class ApplicationOptions
    {
        public static string Section = "Application";
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}