using System;
using Elixis;
using Elixis.EncryptionOptions;
using GDNET.Domain.Base.Exceptions;
using GDNET.Domain.Services.Security;
using GDNET.Utils;

namespace GDNET.Business.Services.Impl.Security
{
    public class EncryptionService : IEncryptionService
    {
        private static readonly string _defaultPassword = "@A1B2C3D4$";
        private readonly AESEncryptor elixisAESEncryptor = null;
        private readonly EncryptionOption encryptionOption = EncryptionOption.None;

        #region Ctors

        public EncryptionService(EncryptionOption encryptionOption)
            : this(_defaultPassword)
        {
            this.encryptionOption = encryptionOption;
        }

        public EncryptionService(string password)
        {
            ExceptionsManager.BusinessException.ThrowIfIsNullOrWhiteSpace(password);
            this.elixisAESEncryptor = new AESEncryptor(password, AESBits.BITS128);
        }

        #endregion

        /// <summary>
        /// Encrypts a string
        /// </summary>
        public string Encrypt(string plainData)
        {
            switch (encryptionOption)
            {
                case EncryptionOption.Base64:
                    return Base64Assistant.Encrypt(plainData);

                case EncryptionOption.AES:
                    return this.elixisAESEncryptor.Encrypt(plainData);

                case EncryptionOption.None:
                    return plainData;

                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Descripts a encripted string
        /// </summary>
        public string Decrypt(string encryptedData)
        {
            switch (encryptionOption)
            {
                case EncryptionOption.Base64:
                    return Base64Assistant.Decrypt(encryptedData);

                case EncryptionOption.AES:
                    return this.elixisAESEncryptor.Decrypt(encryptedData);

                case EncryptionOption.None:
                    return encryptedData;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
