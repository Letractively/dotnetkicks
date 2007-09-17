using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Incremental.Kick.Helpers {
    public class TextHelper {
        public static string Urlify(string input) {
            return RegExReplace(input, @"((ht|f)tp(s?))\://([0-9a-zA-Z\-]+\.)+[a-zA-Z]{2,6}(\:[0-9]+)?(/\S*)?", @"<a href=""{0}"" target=""_new"">{0}</a>");
        }

        public static string RegExReplace(string input, string regExPattern, string outputPattern) {
            return RegExReplace(input, regExPattern, outputPattern, 0);
        }
        public static string RegExReplace(string input, string regExPattern, string outputPattern, int matchGroup) {
            Regex urlMatchRegex = new Regex(regExPattern, RegexOptions.IgnoreCase);
            MatchCollection urlMatches = urlMatchRegex.Matches(input);

            foreach (Match match in urlMatches) {
                input = input.Replace(match.Value, String.Format(outputPattern, match.Groups[matchGroup].Value));
            }

            return input;
        }
    }
}