namespace GDNET.Domain.Services.Security
{
    public interface IEncryptionService : IBusinessService
    {
        string Encrypt(string plainData);
        string Decrypt(string encryptedData);
    }
}
