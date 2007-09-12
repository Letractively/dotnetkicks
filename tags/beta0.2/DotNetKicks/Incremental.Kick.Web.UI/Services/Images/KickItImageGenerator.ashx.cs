using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Text;
using Incremental.Kick.BusinessLogic;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Web.UI.Services.Images {


    public class KickItImageGenerator : IHttpHandler {

        internal Color BorderColor {
            get { return Color.Black; }
        }


        public void ProcessRequest(HttpContext context) {
            string url = context.Request["url"].Trim();

            ////TODO: GJ: check cache for image




            //TODO: GJ: turn off remote caching, turn on local caching (reluctant cache)
            Image img = new Bitmap(82, 18, 1, PixelFormat.Format32bppArgb, new IntPtr());
            Graphics g = Graphics.FromImage(img);
            Font f = new Font("Verdana", 10, FontStyle.Bold);

            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            g.FillRectangle(new SolidBrush(this.BorderColor), 0, 0, img.Width, img.Height); //Color.FromArgb(133, 255, 124)
            g.FillRectangle(new SolidBrush(Color.FromArgb(163, 201, 82)), 1, 1, img.Width - 2, img.Height - 2);
            g.DrawString("kick it", f, new SolidBrush(Color.White), 1, 1);


            Story story = Story.FetchStoryByUrl(url);
            if ((story == null) || (!story.IsPublishedToHomepage)) 
                f = new Font("Verdana", 10, FontStyle.Regular);
             string count = this.GetKickCountDisplayCharacters(story);
            float countWidth = g.MeasureString(count, f).Width;

            g.FillRectangle(new SolidBrush(Color.FromArgb(212, 225, 237)), img.Width - countWidth - 1, 1, countWidth, img.Height - 2);
            g.DrawString(count, f, new SolidBrush(Color.Black), img.Width - countWidth, 1);

            MemoryStream s = new MemoryStream();
            img.Save(s, ImageFormat.Png);

            context.Response.ContentType = "image/PNG";
            context.Response.BinaryWrite(s.GetBuffer());
        }

        private string GetKickCountDisplayCharacters(Story story) {
            if (story == null) {
                return "0";
            } else {
                return story.KickCount.ToString();
            }
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}
