using System.Security.Cryptography;
using System.Text;

namespace STMApi.Security
{
    internal static class SecurityUtils
    {
        internal static string ComputeHash(string input, HashAlgorithm algorithm)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] outputBytes = algorithm.ComputeHash(inputBytes);

            var builder = new StringBuilder();

            foreach (byte b in outputBytes)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }

    }
}
