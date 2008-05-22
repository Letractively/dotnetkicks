using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Web;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Web.UI.Services.Images
{
    /// <summary>
    /// Genreates the Kick It images
    /// </summary>
    public class KickItImageGenerator : IHttpHandler
    {
        #region Fields

        private Color _borderColor = Color.Black;
        private int _borderWidth = 1;
        private Color _countBackgroundColor = Color.FromArgb(212, 225, 237);
        private Font _countFont = new Font("Verdana", 10, FontStyle.Regular);
        private Color _countForegroundColor = Color.Black;
        private int _height = 18;
        private string _text = "kick it";
        private Color _textBackgroundColor = Color.FromArgb(163, 201, 82);
        private Font _textFont = new Font("Verdana", 10, FontStyle.Bold);
        private Color _textForegroundColor = Color.White;
        private int _width = 82;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        internal Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; }
        }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        public int BorderWidth
        {
            get { return _borderWidth; }
            set { _borderWidth = value; }
        }

        /// <summary>
        /// Gets or sets the color of the count background.
        /// </summary>
        /// <value>The color of the count background.</value>
        public Color CountBackgroundColor
        {
            get { return _countBackgroundColor; }
            set { _countBackgroundColor = value; }
        }

        /// <summary>
        /// Gets or sets the count font.
        /// </summary>
        /// <value>The count font.</value>
        public Font CountFont
        {
            get { return _countFont; }
            set { _countFont = value; }
        }

        /// <summary>
        /// Gets or sets the color of the count foreground.
        /// </summary>
        /// <value>The color of the count foreground.</value>
        public Color CountForegroundColor
        {
            get { return _countForegroundColor; }
            set { _countForegroundColor = value; }
        }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        internal int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        /// <summary>
        /// Gets a value indicating whether another request can use the <see cref="T:System.Web.IHttpHandler"></see> instance.
        /// </summary>
        /// <value></value>
        /// <returns>true if the <see cref="T:System.Web.IHttpHandler"></see> instance is reusable; otherwise, false.</returns>
        public bool IsReusable
        {
            get { return false; }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        /// <summary>
        /// Gets or sets the color of the text background.
        /// </summary>
        /// <value>The color of the background.</value>
        public Color TextBackgroundColor
        {
            get { return _textBackgroundColor; }
            set { _textBackgroundColor = value; }
        }

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>The font.</value>
        internal Font TextFont
        {
            get { return _textFont; }
            set { _textFont = value; }
        }

        /// <summary>
        /// Gets or sets the color of the text foreground.
        /// </summary>
        /// <value>The color of the text foreground.</value>
        public Color TextForegroundColor
        {
            get { return _textForegroundColor; }
            set { _textForegroundColor = value; }
        }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        internal int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        #endregion

        #region Methods

        // Public Methods 

        /// <summary>
        /// Enables processing of HTTP Web requests by a custom HttpHandler that implements 
        /// the <see cref="T:System.Web.IHttpHandler"></see> interface.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpContext"></see> object 
        /// that provides references to the intrinsic server objects (for example, Request, 
        /// Response, Session, and Server) used to service HTTP requests.</param>
        public void ProcessRequest(HttpContext context)
        {
            string url = context.Request["url"].Trim();

            ////TODO: GJ: check cache for image

            //can't use # in url, so need to check if its hex and prepend it
            if (context.Request["border"] != null)
                _borderColor = ConvertHexToColor(context.Request["border"], BorderColor);

            if (context.Request["bgcolor"] != null)
                _textBackgroundColor = ConvertHexToColor(context.Request["bgcolor"], TextBackgroundColor);

            if (context.Request["fgcolor"] != null)
                _textForegroundColor = ConvertHexToColor(context.Request["fgcolor"], TextForegroundColor);

            if (context.Request["cbgcolor"] != null)
                _countBackgroundColor = ConvertHexToColor(context.Request["cbgcolor"], CountBackgroundColor);

            if (context.Request["cfgcolor"] != null)
                _countForegroundColor = ConvertHexToColor(context.Request["cfgcolor"], CountForegroundColor);

            //TODO: GJ: turn off remote caching, turn on local caching (reluctant cache)
            using (Image img = new Bitmap(_width, _height, 1, PixelFormat.Format32bppArgb, new IntPtr()))
            {
                using (Graphics g = Graphics.FromImage(img))
                {
                    g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                    //draw border
                    g.FillRectangle(new SolidBrush(_borderColor), 0, 0, img.Width, img.Height);

                    //draw inner color
                    g.FillRectangle(new SolidBrush(_textBackgroundColor),
                        _borderWidth, _borderWidth, img.Width - (_borderWidth * 2), img.Height - (_borderWidth * 2));

                    //draw text for label ("kick it")
                    g.DrawString(_text, TextFont, new SolidBrush(_textForegroundColor), 1, 1);

                    //draw number of kicks
                    Story story = Story.FetchStoryByUrl(url);

                    //get counts
                    string count = GetKickCountDisplayCharacters(story);
                    float countWidth = g.MeasureString(count, _countFont).Width;

                    //draw background behind count
                    g.FillRectangle(new SolidBrush(_countBackgroundColor),
                        img.Width - countWidth - _borderWidth, _borderWidth, countWidth, img.Height - (_borderWidth * 2));

                    //make sure story != null before calling IsPublishedToHomepage 
                    //if published, make bold
                    if (story != null && story.IsPublishedToHomepage)
                        _countFont = new Font(_countFont.FontFamily, _countFont.Size, FontStyle.Bold);

                    //draw count
                    g.DrawString(count, _countFont, new SolidBrush(_countForegroundColor), img.Width - countWidth, _borderWidth);

                    using (MemoryStream s = new MemoryStream())
                    {
                        img.Save(s, ImageFormat.Png);
                        context.Response.ContentType = "image/PNG";
                        context.Response.BinaryWrite(s.GetBuffer());
                    }
                }
            }
        }

        // Private Methods 

        /// <summary>
        /// Converts the color of the hex to.
        /// </summary>
        /// <param name="urlValue">The URL value.</param>
        /// <param name="defaultColor">Color of the default.</param>
        /// <returns></returns>
        private static Color ConvertHexToColor(string urlValue, Color defaultColor)
        {
            Color myColor;

            try
            {
                if (!urlValue.StartsWith("#"))
                    urlValue = string.Concat("#", urlValue);

                myColor = ColorTranslator.FromHtml(urlValue);
            }
            catch
            {
                myColor = defaultColor;
            }

            return myColor;
        }

        /// <summary>
        /// Gets the kick count display characters.
        /// </summary>
        /// <param name="story">The story.</param>
        /// <returns></returns>
        private static string GetKickCountDisplayCharacters(Story story)
        {
            return story == null ? "0" : story.KickCount.ToString();
        }

        #endregion
    }
}
