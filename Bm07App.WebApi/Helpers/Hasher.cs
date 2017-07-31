using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace Bm07App.WebApi.Helpers
{
    /// <summary>
    /// A class to help hasing strings with a correct algorithm.
    /// </summary>
    public class Hasher
    {
        /// <summary>
        /// Creates a hashed version of a string and returns a byte array (to store into the database).
        /// Uses an empty string for salt.
        /// <para>
        /// Throws <see cref="ArgumentNullException"/>.
        /// </para>
        /// </summary>
        /// <param name="unhashedString">The string to hash</param>
        /// <returns></returns>
        public static byte[] HashString(string unhashedString)
        {
            return Hasher.HashStringAndSalt(unhashedString, string.Empty);
        }

        /// <summary>
        /// Creates a hashed version of a string and includes a salt at the end before hashing. unhashedString and salt can not be null.
        /// <para>
        /// Throws <see cref="ArgumentNullException"/>.
        /// </para>
        /// </summary>
        /// <param name="unhashedString">The string to hash</param>
        /// <param name="salt">The salt (extra string) to include at the end of the string</param>
        /// <returns></returns>
        public static byte[] HashStringAndSalt(string unhashedString, string salt)
        {
            if (unhashedString == null)
            {
                throw new ArgumentNullException("unhashedString");
            }

            if (salt == null)
            {
                throw new ArgumentNullException("salt");
            }

            HashAlgorithm hasher = Hasher.GetAlgorithm();
            byte[] stringBytes = Encoding.Unicode.GetBytes(unhashedString + salt);
            return hasher.ComputeHash(stringBytes);
        }

        /// <summary>
        /// This method should be used by methods of this class to ensure that each method is using the same has algorithm.
        /// </summary>
        /// <returns></returns>
        private static HashAlgorithm GetAlgorithm()
        {
            return SHA512.Create();
        }
    }
}