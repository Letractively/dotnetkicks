using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SubSonic;
using Incremental.Kick.Caching;
using Incremental.Kick.Helpers;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Web.Controls;
using Incremental.Kick.Dal.Entities.Api;
using System.Collections.Specialized;
using System.Web.Mvc;

namespace Incremental.Kick.Dal {
    public partial class Host {

        public bool HasRecaptcha {
            get { return !String.IsNullOrEmpty(this.ReCaptchaPublicKey); }
        }

    }
}
