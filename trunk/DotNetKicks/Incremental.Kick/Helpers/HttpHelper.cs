using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Incremental.Kick.Helpers {
    public class HttpHelper {
        public static string MakeHttpGetRequest(string uri) {
            WebRequest request = WebRequest.Create(uri);
            string html;
            using (StreamReader streamReader = new StreamReader(request.GetResponse().GetResponseStream()))
                html = streamReader.ReadToEnd();

            return html;
        }

        public static void DownloadFile(string uri, string targetPath) {
            using(WebClient client = new WebClient()) {
                client.DownloadFile(uri, targetPath);
            }           
        }
    }
}
