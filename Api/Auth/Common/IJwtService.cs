namespace Api.Auth.Common
{
    public interface IJwtService
    {
        string GetToken(string username, string password);
    }
}