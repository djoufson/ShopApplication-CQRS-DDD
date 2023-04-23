namespace Shop.UserService.Infrastructure.Authentication;

public class JwtSettings
{
    public static string SectionName => nameof(JwtSettings);
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public string Secret { get; set; } = null!;
    public int Expires { get; set; }
}
