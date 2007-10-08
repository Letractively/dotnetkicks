using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;


namespace Incremental.Kick.Helpers {
    public class TrackbackHelper {

        public static void SendTrackbackPing_Begin(string resourceUrl, string storyTitle, string storyUrl, string storyExcerpt, string siteName) {
            AsyncHelper.FireAndForget(delegate {
                SendTrackbackPing(resourceUrl, storyTitle, storyUrl, storyExcerpt, siteName);
            });
        }

        private static void SendTrackbackPing(string resourceUrl, string storyTitle, string storyUrl, string storyExcerpt, string siteName) {

            string trackbackUrl = GetTrackbackUrl(resourceUrl);

            string parameters = "title=" + HttpUtility.HtmlEncode(storyTitle) + "&url=" + HttpUtility.HtmlEncode(storyUrl) +
                "&excerpt=" + HttpUtility.HtmlEncode(storyExcerpt) + "&blog_name=" + HttpUtility.HtmlEncode(siteName);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(trackbackUrl);
            request.Method = "POST";
            request.ContentLength = parameters.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            request.KeepAlive = false;

            StreamWriter streamWriter = null;

            try {
                streamWriter = new StreamWriter(request.GetRequestStream());
                streamWriter.AutoFlush = true;
                streamWriter.Write(parameters);
            } catch (Exception ex) {
                System.Diagnostics.Trace.WriteLine("An exception occured posting a trackback:" + ex.ToString());
            } finally {
                if (streamWriter != null) streamWriter.Close();
            }
        }

        public static string GetTrackbackUrl(string resourceUrl) {
            string html = HttpHelper.MakeHttpGetRequest(resourceUrl);

            Regex rdfRegex = new Regex(@"<rdf:\w+\s[^>]*?>(</rdf:rdf>)?", RegexOptions.IgnoreCase);
            MatchCollection rdfMatches = rdfRegex.Matches(html);

            foreach (Match rdfMatch in rdfMatches) {
                if (rdfMatch.Groups.Count > 0) {
                    string rdfData = rdfMatch.Groups[0].ToString();
                    if (rdfData.IndexOf(resourceUrl) > 0) {
                        Regex trackbackRegex = new Regex("trackback:ping=\"([^\"]+)\"", RegexOptions.IgnoreCase);
                        Match trackbackMatch = trackbackRegex.Match(rdfData);
                        if (trackbackMatch.Success) {
                            return trackbackMatch.Result("$1");
                        }
                    }
                }
            }

            throw new Exception("Trackback URL was not found for [" + resourceUrl + "]");
        }
    }
}
