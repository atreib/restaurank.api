namespace restaurank.api.Data.Protocols
{
    public interface IJwtGenerator
    {
        string GenerateJwt (string jsonData);
    }
}