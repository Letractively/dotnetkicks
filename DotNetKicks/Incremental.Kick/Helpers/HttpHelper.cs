using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Incremental.Kick.Helpers {
    public class HttpHelper {

        public static string MakeHttpGetRequest(string url) {
            WebRequest request = WebRequest.Create(url);
            string html;
            using (StreamReader streamReader = new StreamReader(request.GetResponse().GetResponseStream())) {
                html = streamReader.ReadToEnd();
            }

            return html;
        }
    }
}
