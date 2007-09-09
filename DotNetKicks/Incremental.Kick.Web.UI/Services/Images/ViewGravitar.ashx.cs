using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.UI.Services.Images {
    public class ViewGravitar : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "image/JPEG";

            int size = int.Parse(context.Request["size"]);
            string gravatarID = context.Request["gravatar_id"];

            if (size != 16 && size != 50 && size != 80)
                throw new ArgumentException("The size must be either 16, 50 or 80");

            string gravatarFileName = String.Format("{0}_{1}.jpg", gravatarID, size);
            string cachedGravatarFolderPath = Path.Combine(context.Request.PhysicalApplicationPath, @"Static\Images\Cache\Gravatars\");
            string defaultGravatarFolderPath = Path.Combine(context.Request.PhysicalApplicationPath, @"Static\Images\Cache\DefaultGravatars\");
            string cachedGravatarFilePath = Path.Combine(cachedGravatarFolderPath, gravatarFileName);

            string gravatarToReturnPath = cachedGravatarFilePath;
            if (File.Exists(cachedGravatarFilePath)) {
                //TODO: GJ: set some response caching attributes
                //TODO: GJ: replace the cached gravatar if more than x hours old
            } else {
                gravatarToReturnPath = Path.Combine(defaultGravatarFolderPath, String.Format("gravatar_{0}.jpg", size));
                if (!File.Exists(cachedGravatarFilePath))
                    gravatarToReturnPath = Path.Combine(defaultGravatarFolderPath, "gravatar_80.jpg");

                //Asynchronously download the gravatars to the cache
                GravatarHelper.DownloadGravatar_Begin(gravatarID, size, cachedGravatarFilePath);
            }

            try {
                context.Response.WriteFile(gravatarToReturnPath);
            } catch(System.IO.IOException) { //The file may be locked
                context.Response.WriteFile(Path.Combine(defaultGravatarFolderPath, "gravatar_80.jpg"));
            }
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}
