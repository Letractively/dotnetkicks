using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Incremental.Kick.Helpers {
    public class TextHelper {
        public static string Urlify(string input) {
            Regex urlMatchRegex = new Regex(@"((ht|f)tp(s?))\://([0-9a-zA-Z\-]+\.)+[a-zA-Z]{2,6}(\:[0-9]+)?(/\S*)?", RegexOptions.IgnoreCase);
            MatchCollection urlMatches = urlMatchRegex.Matches(input);

            foreach (Match match in urlMatches) {
                input = Regex.Replace(input, match.Value, String.Format(@"<a href=""{0}"" target=""_new"">{0}</a>", match.Value));
            }

            return input;
        }
    }
}