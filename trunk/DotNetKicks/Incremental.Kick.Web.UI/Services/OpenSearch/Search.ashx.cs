using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;

using Incremental.Kick.Caching;
using Incremental.Kick.Dal;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.UI.Services.OpenSearch
{
    /// <summary>
    /// Generates the OpenSearch 1.1 xml required by modern browsers
    /// so that the search for site can be added to the browser and or
    /// other aggregation serarch
    /// 
    /// details of the spec can be found here http://www.opensearch.org/Specifications/OpenSearch/1.1
    /// </summary>
    /// <remarks>Data used in the xml below is taken from the host table in the database</remarks>
    public class Search : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/opensearchdescription+xml";

            using (XmlTextWriter writer = new XmlTextWriter(context.Response.OutputStream, System.Text.Encoding.UTF8))
            {
                //get the details from host object
                Host host = HostCache.GetHost(HostHelper.GetHostAndPort(context.Request.Url));

                writer.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"UTF-8\"");

                writer.WriteStartElement("OpenSearchDescription", "http://a9.com/-/spec/opensearch/1.1/");
                writer.WriteElementString("ShortName", host.SiteTitle);
                writer.WriteElementString("Description", host.SiteDescription);
                writer.WriteElementString("Contact", host.Email);
                
                writer.WriteStartElement("Image");
                writer.WriteAttributeString("height", "16");
                writer.WriteAttributeString("weight", "16");
                writer.WriteAttributeString("type", "image/x-icon");
                writer.WriteString(string.Format("{0}/favicon.ico", host.RootUrl));
                writer.WriteEndElement();

                writer.WriteStartElement("Url");
                writer.WriteAttributeString("type", "text/html");
                writer.WriteAttributeString("method", "GET");
                writer.WriteAttributeString("template", string.Format("{0}/search?q={{searchTerms}}&user=False&page={{startPage?}}", host.RootUrl));
                writer.WriteEndElement();
                
                writer.Flush();
            }


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
