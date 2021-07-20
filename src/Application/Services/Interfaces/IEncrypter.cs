namespace Application.Services.Interfaces
{
    public interface IEncrypter : IService
    {
        string CreateSalt();
        string GetHash(string value, string salt);
    }
}