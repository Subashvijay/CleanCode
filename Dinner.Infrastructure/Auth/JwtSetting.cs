namespace Dinner.Infrastructure.Auth
{
    public class JwtSetting
    {
        public string Secret { get; init; } = null!;

        public string Issuer { get; init; } = null!;

        public int ExpireIn { get; init; }

        public string Audience { get; init; } = null!;

    }
}