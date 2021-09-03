namespace CleanAPI.Infrastructure.Interfaces
{
    public interface IPasswordService
    {
        string Hash(string password);
        bool Validate(string hash, string password);
    }
}
