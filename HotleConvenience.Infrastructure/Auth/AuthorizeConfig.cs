namespace HotleConvenience.Infrastructure.Auth
{
    public class AuthorizeConfig
    {
        public string Audience { get; set; }

        public string Secret { get; set; }

        public string Issuer { get; set; }
    }
}
