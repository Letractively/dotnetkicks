using System;
using System.Web;
using System.Web.UI;

namespace Incremental.Kick.Web.Controls {
    public abstract class KickAsyncPage : KickPage {
        protected virtual void Page_Load(object sender, EventArgs e) {
            if (!this.IsPostBack)
                this.RegisterAsyncTask();
        }

        protected void RegisterAsyncTask() {
            this.AsyncTimeout = new TimeSpan(0, 0, 30); //TODO: config

            PageAsyncTask task = new PageAsyncTask(
                    new BeginEventHandler(BeginAsyncRequest),
                    new EndEventHandler(EndAsyncRequest),
                    new EndEventHandler(TimeoutAsyncRequest),
                    null
                );

            this.RegisterAsyncTask(task);
        }

        protected abstract IAsyncResult BeginAsyncRequest(object sender, EventArgs e, AsyncCallback callback, object asyncState);
        protected abstract void EndAsyncRequest(IAsyncResult asyncResult);

        public void TimeoutAsyncRequest(IAsyncResult asyncResult) {
            throw new Exception("KickAsyncPage Timeout");
        }
    }
}
