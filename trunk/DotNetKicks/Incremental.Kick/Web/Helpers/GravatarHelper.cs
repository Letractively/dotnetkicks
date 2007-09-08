using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Helpers;

namespace Incremental.Kick.Web.Helpers {
    public class GravatarHelper {
        delegate void DownloadGravatarDelegate(string gravatarID, int size, string targetFolderPath);
        public static void DownloadGravatar_Begin(string gravatarID, int size, string targetFolderPath) {
            AsyncHelper.FireAndForget(new DownloadGravatarDelegate(DownloadGravatar), gravatarID, size, targetFolderPath);
        }

        public static void DownloadGravatar(string gravatarID, int size, string targetFilePath) {
            string gravatarPath = String.Format("http://www.gravatar.com/avatar.php?gravatar_id={0}&size={1}", gravatarID, size);
            HttpHelper.DownloadFile(gravatarPath, targetFilePath);
        }
    }
}
