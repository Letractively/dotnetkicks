using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;

namespace Incremental.Kick.Security.Principal {

    public class ApiIdentity : IIdentity {
        public ApiIdentity() { }
        public ApiIdentity(string name) {
            this._name = name;
        }

        private string _name;
        public string Name { get { return this._name; } }
        public string AuthenticationType { get { return "Custom"; } }
        public bool IsAuthenticated { get { return true; } }
    }
}
