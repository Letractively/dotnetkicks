using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Security.Principal;
using Incremental.Kick.Security.Principal;
using Incremental.Kick.BusinessLogic;
using Incremental.Kick.Config;
using Incremental.Kick.Caching;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Dal.Entities;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Web.Security {
    public class SecurityManager {
        
        public static void Logout() {
            UserCache.RemoveUser(SecurityToken);
            FormsAuthentication.SignOut();
        }

        public static string SecurityToken {
            get { return ((FormsIdentity)HttpContext.Current.User.Identity).Ticket.UserData; }
        }

        public static bool Login(string username, string password) {
            return Login(username, password, false);
        }

        public static bool Login(string username, string password, bool isPersistant) {
            try {
                string securityToken = UserBR.AuthenticateUser(username, password);

                DateTime expiryDate = DateTime.Now;
                if (isPersistant)
                    expiryDate = expiryDate.AddYears(1);
                else
                    expiryDate = expiryDate.AddDays(1);

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                     1, username, DateTime.Now, expiryDate, isPersistant,
                     securityToken, FormsAuthentication.FormsCookiePath);

                string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                if (isPersistant)
                    cookie.Expires = expiryDate;
                
                HttpContext.Current.Response.Cookies.Add(cookie);

                return true;
            } catch {
                return false;
            }
        }

        public static void SetPrincipal() {
            IKickPrincipal principal = null;
            FormsIdentity identity;
            UrlParameters urlParameters = UrlParametersHelper.GetUrlParameters(HttpContext.Current.Request);

            if (HttpContext.Current.Request.IsAuthenticated) {
                identity = (FormsIdentity)HttpContext.Current.User.Identity;

                User userProfile;
                urlParameters.SecurityToken = (((FormsIdentity)identity).Ticket).UserData;
                try {
                    userProfile = UserCache.GetUser(urlParameters.SecurityToken);
                    userProfile.UpdateLastActiveOn();                    
                    principal = new AuthenticatedKickPrincipal(identity, userProfile);
                } catch {
                    //TODO: Log an exception
                    FormsAuthentication.SignOut();
                    principal = new AnonymousKickPrincipal(new GuestIdentity(), UserCache.GetUser(null));
                }

            } else {
                principal = new AnonymousKickPrincipal(new GuestIdentity(), UserCache.GetUser(null));
            }

            HttpContext.Current.User = principal;
        }

        public static IKickPrincipal GetPrincipal(string username, string password) {
            System.Diagnostics.Trace.WriteLine("GetPrincipal " + username + " : " + password);
            string securityToken = UserBR.AuthenticateUser(username, password);
            IIdentity identity = new ApiIdentity(username);
            return new AuthenticatedKickPrincipal(identity, UserCache.GetUser(securityToken));
        }

        public static void SetAnonymousPrincipal() {
            HttpContext.Current.User = new GenericPrincipal(new GuestIdentity(), new string[0]); ;
        }
    }
}