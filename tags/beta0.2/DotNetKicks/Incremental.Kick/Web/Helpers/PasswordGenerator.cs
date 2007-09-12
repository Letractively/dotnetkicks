using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Web.Helpers {
    public class PasswordGenerator {
       public static string Generate(int passwordLength) {
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
            char[] consonants = new char[] { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'r', 's', 't', 'v' };
            char[] doubleConsonants = new char[] { 'c', 'd', 'f', 'g', 'l', 'm', 'n', 'p', 'r', 's', 't' };

            bool haveWrittenConsonant = false;

            StringBuilder password = new StringBuilder();

            for (int i = 0; i < passwordLength; i++) {
                if ((password.Length > 0) && (!haveWrittenConsonant) && (ThreadSafeRandom.Next(100) < 10)) {
                    password.Append(doubleConsonants[ThreadSafeRandom.Next(doubleConsonants.Length)], 2);

                    haveWrittenConsonant = true;
                } else {
                    if ((!haveWrittenConsonant) && (ThreadSafeRandom.Next(100) < 90)) {
                        password.Append(consonants[ThreadSafeRandom.Next(consonants.Length)]);
                        haveWrittenConsonant = true;
                    } else {
                        password.Append(vowels[ThreadSafeRandom.Next(vowels.Length)]);
                        haveWrittenConsonant = false;
                    }
                }
            }

            if (password.Length > passwordLength) {
                return password.ToString(0, passwordLength);
            } else {
                return password.ToString();
            }
        }
    }
}
