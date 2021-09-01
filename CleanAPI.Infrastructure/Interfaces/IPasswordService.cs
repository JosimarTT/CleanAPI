namespace CleanAPI.Infrastructure.Interfaces
{
    public interface IPasswordService
    {
        string Generate(string password);
        bool Validate(string hash, string password);
    }
}
