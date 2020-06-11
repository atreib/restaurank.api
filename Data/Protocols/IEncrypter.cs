namespace restaurank.api.Data.Protocols
{
    public interface IEncrypter
    {
        string hash (string value);
        bool compare (string hashedPassword, string providedPassword);
    }
}