using System.Diagnostics;
using System.Security.Cryptography;

namespace SecretBase.Utilities
{
    // 暗号化・復号化機能を提供するクラス
    internal static class FileCryption
    {
        // 暗号化
        public static void EncryptFile(string inputFile, string password)
        {
            byte[] salt = new byte[Constants.Constants.saltLength];
            new RNGCryptoServiceProvider().GetBytes(salt); // 鍵作成に使用する乱数のソルトを生成

            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt, 10000); // 任意のパスワード・作成したソルトからPBKDF2による鍵の作成
            using (Aes aes = Aes.Create())
            {
                aes.Key = key.GetBytes(aes.KeySize / 8);
                aes.IV = key.GetBytes(aes.BlockSize / 8);

                string fileName = Path.GetFileNameWithoutExtension(inputFile) + "_encrypted" + Path.GetExtension(inputFile);
                string outputFile = Path.Combine(Path.GetDirectoryName(inputFile), fileName);
                try
                {
                    using (FileStream fsCrypt = new FileStream(outputFile, FileMode.Create))
                    {
                        fsCrypt.Write(salt, 0, salt.Length);  // ソルトを出力ファイルの先頭に書き込む

                        using (CryptoStream cryptoStream = new CryptoStream(fsCrypt, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        using (FileStream fsIn = new FileStream(inputFile, FileMode.Open))
                        {
                            int read;
                            byte[] buffer = new byte[1048576];  // 1MBのバッファ

                            while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                cryptoStream.Write(buffer, 0, read);
                            }
                        }
                    }
                }
                catch
                {
                    // 暗号化に失敗した場合、出力ファイル削除
                    if (File.Exists(outputFile))
                    {
                        File.Delete(outputFile);
                    }
                    throw;
                }
            }
        }

        // 復号化
        public static void DecryptFile(string inputFile, string password)
        {
            byte[] salt = new byte[Constants.Constants.saltLength];
            using (FileStream fsCrypt = new FileStream(inputFile, FileMode.Open))
            {
                fsCrypt.Read(salt, 0, salt.Length);  // 入力ファイルの先頭からソルトを読み取る

                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt, 10000); // 任意のパスワード・保存されていたソルトからPBKDF2による鍵の作成

                using (Aes aes = Aes.Create())
                {
                    aes.Key = key.GetBytes(aes.KeySize / 8);
                    aes.IV = key.GetBytes(aes.BlockSize / 8);

                    string fileName = Path.GetFileNameWithoutExtension(inputFile) + "_decrypted" + Path.GetExtension(inputFile);
                    string outputFile = Path.Combine(Path.GetDirectoryName(inputFile), fileName);
                    try
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(fsCrypt, aes.CreateDecryptor(), CryptoStreamMode.Read))
                        using (FileStream fsOut = new FileStream(outputFile, FileMode.Create))
                        {
                            int read;
                            byte[] buffer = new byte[1048576];  // 1MBのバッファ

                            while ((read = cryptoStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                fsOut.Write(buffer, 0, read);
                            }
                        }
                    }
                    catch
                    {
                        // 復号化に失敗した場合、出力ファイル削除
                        if (File.Exists(outputFile))
                        {
                            File.Delete(outputFile);
                        }
                        throw;
                    }
                    
                }
            }
        }
    }
}
