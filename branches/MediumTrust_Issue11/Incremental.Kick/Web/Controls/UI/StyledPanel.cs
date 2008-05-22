using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace Incremental.Kick.Web.Controls {

    public enum StyledPanelStyle {
        GreenPanel,
        GreenPanelPlain,
        BluePanel,
        GreyPanel,
        PinkPanel,
        BlackPanel
    }

    public class StyledPanel : KickHtmlControl {
        private string _caption;
        private StyledPanelStyle _panelStyle = StyledPanelStyle.GreenPanel;

        public string Caption {
            get { return this._caption; }
            set { this._caption = value; }
        }

        public StyledPanelStyle StyledPanelStyle {
            get { return this._panelStyle; }
            set { this._panelStyle = value; }
        }

        public void RenderTop(HtmlTextWriter writer) {

            writer.WriteLine(@"
                <div class=""{0}"">
                    <span class=""{0}Caption"">{1}</span>
                ", this.StyledPanelStyle, this.Caption);
        }

        public void RenderBottom(HtmlTextWriter writer) {
            writer.WriteLine(@"</div>");
        }
    }
}
