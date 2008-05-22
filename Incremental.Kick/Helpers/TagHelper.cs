using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Incremental.Kick.Dal;
using Incremental.Kick.Common;
using Incremental.Common.Web.Helpers;


namespace Incremental.Kick.Helpers {
    public class TagHelper {

        public static List<string> DistillTagInput(string rawTagInput, bool isAdministrator) {
            rawTagInput = rawTagInput.Replace(",", " ");

            //handle any quoted text
            bool hasDoubleQuotes = true;
            while(hasDoubleQuotes) {
                Regex doubleQuotesMatch = new Regex(RegExHelper.MATCH_DOUBLE_QUOTES_REGEX);
                if (doubleQuotesMatch.IsMatch(rawTagInput)) {
                    string match = doubleQuotesMatch.Match(rawTagInput).Value;
                    string replacement = match.Replace("\"", "").Trim(); //remove double quotes
                    replacement = replacement.Replace(" ", "");

                    rawTagInput = rawTagInput.Replace(match, replacement);
                } else {
                    hasDoubleQuotes = false;
                }
            }

            //now remove unwanted characters
            string adminAllowedCharacters = "";
            if (isAdministrator) 
                adminAllowedCharacters += Constants.NAMESPACE_SEPERATOR; //allow the use of namespaces
            rawTagInput = new Regex(@"[^A-Za-z0-9#_()+. /-" + adminAllowedCharacters + "]").Replace(rawTagInput, "");

            string[] tagArray = rawTagInput.Split(" ".ToCharArray());
            List<string> tags = new List<string>();
            foreach (string tag in tagArray) {
                //TODO: GJ: cut of any characters over 40 

                if(tag.Trim().Length > 1)  //NOTE: GJ: should we allow single characters??
                    if(!tags.Contains(tag))
                        tags.Add(tag);
            }

            return tags;
        }
    }
}
