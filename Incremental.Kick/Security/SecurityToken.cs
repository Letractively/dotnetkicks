using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Security {
    public class SecurityToken {
        private int _salt;
        private int _userID;
        private const char seperator = '|';

        public SecurityToken(int userID) {
            _userID = userID;
            _salt = new Random().Next();
        }

        private SecurityToken(int userID, int salt) {
            _userID = userID;
            _salt = salt;
        }

        public int UserID {
            get { return _userID; }
            set { _userID = value; }
        }

        public override string ToString() {
            string plainSecurityToken = _userID.ToString() + seperator + _salt.ToString();
            return Cipher.EncryptToBase64(plainSecurityToken);
        }

        public static SecurityToken FromString(string ciphertext) {
            try {
                string plainSecurityToken = Cipher.DecryptFromBase64(ciphertext);
                string[] securityTokenParts = plainSecurityToken.Split(new char[] { seperator });

                int userID = int.Parse(securityTokenParts[0]);
                int salt = int.Parse(securityTokenParts[1]);

                return new SecurityToken(userID, salt);
            } catch {
                throw new Exception("Invalid SecurityToken");
            }
        }
    }
}
