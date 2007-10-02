using System.Collections;
using System.Text.RegularExpressions;
using System.Web;

namespace Incremental.Kick.Helpers
{
    public class TextHelper
    {
        public static readonly Hashtable Emoticons = new Hashtable();

        static TextHelper()
        {
            Emoticons[@":,("] = "cry.gif";
            Emoticons[":)"] = "glad.gif";
            Emoticons[":D"] = "happy.gif";
            Emoticons[";("] = "nervous.gif";
            Emoticons[";)"] = "ok.gif";
            Emoticons[":("] = "sad.gif";
            Emoticons["=)"] = "satisfied.gif";
        }

        public static string Urlify(string input)
        {
            return
                RegExReplace(input,
                             @"(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#\(\)]*[\w\-\@?^=%&amp;/~\+#])?",
                             @"<a href=""{0}"" target=""_new"">{0}</a>");
        }

        public static string ReplaceEmoticons(string input, string emoticonsRoot)
        {
            Regex emoticonRegex = new Regex(@":,\(|:\)|:D|;\(|;\)|:\(|=\)");

            return
                emoticonRegex.Replace(input,
                                      delegate(Match match)
                                          {
                                              return
                                                  string.Format("<img src=\"{0}/{1}\" border=\"0\" style=\"vertical-align:sub;\" />", emoticonsRoot,
                                                                Emoticons[match.Value]);
                                          });
        }

        public static string RegExReplace(string input, string regExPattern, string outputPattern)
        {
            return RegExReplace(input, regExPattern, outputPattern, 0);
        }

        public static string RegExReplace(string input, string regExPattern, string outputPattern, int matchGroup)
        {
            return Regex.Replace(input, regExPattern, delegate(Match match) { return string.Format(outputPattern, match.Value); });
        }

        public static string EncodeAndReplaceComment(string message)
        {
            message = HttpUtility.HtmlEncode(message);
            message = Urlify(message);
            message = message.Replace("\n", "<br />");
            //TODO: GJ: add reg ex replacements here
            return message;
        }
    }
}