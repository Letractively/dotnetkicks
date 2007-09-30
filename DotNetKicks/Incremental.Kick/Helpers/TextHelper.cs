using System;
using System.Text.RegularExpressions;
using System.Web;

namespace Incremental.Kick.Helpers {
    public class TextHelper {
        public static string Urlify(string input) {
            //NOTE: GJ: this regex fails 'period at the end of a link' unit test
            //return RegExReplace(input, @"((ht|f)tp(s?))\://([0-9a-zA-Z\-]+\.)+[a-zA-Z]{2,6}(\:[0-9]+)?(/\S*)?", @"<a href=""{0}"" target=""_new"">{0}</a>");

            return RegExReplace(input, @"(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?", @"<a href=""{0}"" target=""_new"">{0}</a>");
        }

        public static string RegExReplace(string input, string regExPattern, string outputPattern) {
            return RegExReplace(input, regExPattern, outputPattern, 0);
        }

        public static string RegExReplace(string input, string regExPattern, string outputPattern, int matchGroup) {
            return  new Regex(regExPattern, RegexOptions.IgnoreCase).Replace(input, delegate(Match match) { return string.Format(outputPattern, match.Value); });
        }

        public static string EncodeAndReplaceComment(string message) {
            message = HttpUtility.HtmlEncode(message);
            message = Urlify(message);
            message = message.Replace("\n", "<br />");
            //TODO: GJ: add reg ex replacements here
            return message;
        }
    }
}