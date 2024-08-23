namespace WebAPI_JWT.Settings;

public static class Settings
{
    public static string SecretKeyJwt = WebApplication.CreateBuilder().Configuration.GetSection("Jwt:SecretKey").Value.EncryptString();
}