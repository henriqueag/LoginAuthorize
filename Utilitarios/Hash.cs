using System.Security.Cryptography;
using System.Text;

namespace LoginAuthorize.Utilitarios
{
    public class Hash
    {
        public static string GerarHash (string text)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            byte[] hash = sha256.ComputeHash(bytes);
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X"));
            }
            return result.ToString();
        }
    }
}