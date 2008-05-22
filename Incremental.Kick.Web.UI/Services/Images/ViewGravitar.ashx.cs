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

        private const int GRAVATAR_CACHE_DURATION_IN_MINUTES = 60;

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
            string gravatarCopyPath = cachedGravatarFilePath.Replace(".jpg", ".copy.jpg");

            string gravatarToReturnPath = cachedGravatarFilePath;
            if (File.Exists(gravatarToReturnPath) && (File.GetLastWriteTime(gravatarToReturnPath).AddMinutes(GRAVATAR_CACHE_DURATION_IN_MINUTES) < DateTime.Now)) {

                if(!File.Exists(gravatarCopyPath) && new FileInfo(cachedGravatarFilePath).Length > 0)
                    File.Copy(cachedGravatarFilePath, gravatarCopyPath, true); //create a copy for tempory serving

                try {
                    File.Delete(cachedGravatarFilePath);
                } catch (System.IO.IOException) { }

                gravatarToReturnPath = gravatarCopyPath;
            }

            if (File.Exists(gravatarToReturnPath)) {
                context.Response.Cache.SetExpires(DateTime.Now.AddHours(24));
                context.Response.Cache.SetValidUntilExpires(true);
                context.Response.Cache.SetCacheability(HttpCacheability.Public);
            } else {                
                if (File.Exists(gravatarCopyPath))
                    gravatarToReturnPath = gravatarCopyPath;
                else
                    gravatarToReturnPath = Path.Combine(defaultGravatarFolderPath, String.Format("gravatar_{0}.jpg", size));

                //Asynchronously download the gravatars to the cache
                GravatarHelper.DownloadGravatar_Begin(gravatarID, size, cachedGravatarFilePath);
            }

            try {
                context.Response.WriteFile(gravatarToReturnPath);
            } catch(System.IO.IOException) { //The file may be locked
                try {
                    context.Response.WriteFile(gravatarCopyPath);
                } catch (System.IO.IOException) {
                    context.Response.WriteFile(Path.Combine(defaultGravatarFolderPath, String.Format("gravatar_{0}.jpg", size)));
                }
            }
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}
