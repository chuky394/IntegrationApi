namespace Integration.API.Responses
{
    public class TokenResponse
    {
        public string Token_Type { get; set; }
        public string Scope { get; set; }
        public int Expires_In { get; set; }
        public int Ext_Expires_In { get; set; }
        public string Access_Token { get; set; }
        public string Refresh_Token { get; set; }
    }
}