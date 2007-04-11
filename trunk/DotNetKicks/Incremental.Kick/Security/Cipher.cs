using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Helpers;
using System.Security.Cryptography;

//NOTE: GJ: COPYRIGHT: this can not be published.
//see : http://www.obviex.com/samples/Code.aspx?Source=EncryptionCS&Title=Symmetric%20Key%20Encryption&Lang=C%23
//TODO: GJ: find alternative for this class

namespace Incremental.Kick.Security
{
    public class Cipher {
        internal static string EncryptToBase64(string plainSecurityToken)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        internal static string DecryptFromBase64(string ciphertext)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        internal static string GenerateSalt()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        internal static string Hash(string password, string passwordSalt)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
