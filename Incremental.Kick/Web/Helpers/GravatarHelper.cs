using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Helpers;
using System.IO;

namespace Incremental.Kick.Web.Helpers {
    public class GravatarHelper {
        public static void DownloadGravatar_Begin(string gravatarID, int size, string targetFolderPath) {
            AsyncHelper.FireAndForget(delegate {
                DownloadGravatar(gravatarID, size, targetFolderPath);
            });
        }

        private static object _downloadLock = new object();

        public static void DownloadGravatar(string gravatarID, int size, string targetFilePath) {
            string gravatarPath = String.Format("http://www.gravatar.com/avatar.php?gravatar_id={0}&size={1}", gravatarID, size);

            if (!File.Exists(targetFilePath)) //TODO: GJ: there is a possible race condition here
                HttpHelper.DownloadFile(gravatarPath, targetFilePath);

            try { //Delete copy as we now have a fresh copy
                File.Delete(targetFilePath.Replace(".jpg", ".copy.jpg"));
            } catch (System.IO.IOException) { }
            
        }
    }
}
