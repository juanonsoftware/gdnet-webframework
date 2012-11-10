namespace GDNET.Domain.Services.Security
{
    public interface IEncryptionService
    {
        string Encrypt(string plainData);
        string Decrypt(string encryptedData);
    }
}
