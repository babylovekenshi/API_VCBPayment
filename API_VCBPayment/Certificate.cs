using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;

namespace API_VCBPayment
{
    public class Certificate
    {
        public static bool Verify(string plainText, string signatureBase64, string cerFilePath)
        {

            string p12Password = "";
            bool isValid = false;

            try
            {
                X509Certificate2 certificate = new X509Certificate2(cerFilePath, p12Password, X509KeyStorageFlags.Exportable);
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                RSA publicKey = certificate.GetRSAPublicKey();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                byte[] signature = Convert.FromBase64String(signatureBase64);


                byte[] data = Encoding.UTF8.GetBytes(plainText);
                byte[] hash;
                using (SHA256 sha256 = SHA256.Create())
                {
                    hash = sha256.ComputeHash(data);
                }

                // Verify the signature
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                isValid = publicKey.VerifyHash(hash, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

                Console.WriteLine("Signature verification status: " + isValid);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return isValid;
        }
        public static string EncryptSHA256(string messageToSign, string certificateFilePath)
        {
            string base64Encrypted = string.Empty;
            try
            {

                //string certificateFilePath = "/usr/sap/Simon_NotifyTrans/SimonERP_Hana.p12"; // Replace with your .cer file path


                string dataToEncrypt = messageToSign;

                // Load the certificate from the file
                X509Certificate2 cer = new X509Certificate2(certificateFilePath);
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                RSA rsaTest2 = cer.GetRSAPublicKey();
                using (RSA rsaTest1 = cer.GetRSAPrivateKey())
                {
                    if (rsaTest1 == null)
                    {
                        throw new Exception("Certificate does not contain an RSA public key.");
                    }

                    // Compute the SHA-256 hash of the data
                    byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(dataToEncrypt);
                    using (SHA256 sha256 = SHA256.Create())
                    {
                        byte[] hashBytes = sha256.ComputeHash(dataBytes);

                        // Encrypt the hash using the RSA public key
                        byte[] encryptedHash = rsaTest1.SignHash(hashBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                        // Print the encrypted hash as a base64 string
                        base64Encrypted = Convert.ToBase64String(encryptedHash);
                    }
                }
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            }
            catch (Exception)
            {

            }
            return base64Encrypted;

        }
    }
}
