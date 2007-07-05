using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using Incremental.Kick.Common.Entities;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Helpers {
    public class EmailHelper {

        public static void SendNewUserEmail(string toEmail, string username, string password, Host hostProfile) {
            Send(hostProfile.Email, toEmail, "Welcome to " + hostProfile.SiteTitle + " " + username, 
                String.Format(@"
                Welcome to {3}.
                
                Your account information is as follows:

                ---------------
                Username: {0}
                Password: {1}
                ---------------

                You can log in to kick at the following location : {2}

                Thanks for joining our site,
                {3}", username, password, hostProfile.RootUrl + "/login", hostProfile.SiteTitle));
        }

        public static void SendChangedPasswordEmail(string toEmail, string username, string password, Host hostProfile) {
            Send(hostProfile.Email, toEmail, "Your " + hostProfile.SiteTitle + " password has been changed",
                String.Format(@"
                As requested, you password has been changed.                
                
                Please keep this email for your records. Your new account information is as follows:

                ---------------
                Username: {0}
                Password: {1}
                ---------------

                You can log in to kick at the following location : {2}

                Thanks,
                {3}", username, password, hostProfile.RootUrl + "/login", hostProfile.SiteTitle));
        }


        public static void Send(MailMessage message) {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential("auto@dotnetkicks.com", "11Q864");
            smtpClient.EnableSsl = true;
            smtpClient.Send(message);
        }

        public static void Send(string from, string to, string subject, string body) {
            Send(new MailMessage(from, to, subject, body));
        }

        internal static void SendPasswordResetEmail(string toEmail, string username, DateTime createdDateTime, Host hostProfile) {
            Send(hostProfile.Email, toEmail, "Reset you " + hostProfile.SiteTitle + " password",
                String.Format(@"
                Please follow the link below to reset your password:

                {0}               

                Thanks,
                {1}", hostProfile.RootUrl + "/resetpassword/" + username + "/" + createdDateTime.Ticks.GetHashCode().ToString(), hostProfile.SiteTitle));
        }

        public static void SendPasswordEmail(string toEmail, string username, string password, Host hostProfile) {
            Send(hostProfile.Email, toEmail, "Your new " + hostProfile.SiteTitle + " password",
                String.Format(@"
                
                Please keep this email for your records. Your account information is as follows:

                ---------------
                Username: {0}
                Password: {1}
                ---------------

                You can log in to kick at the following location : {2}

                {3}", username, password, hostProfile.RootUrl + "/login", hostProfile.SiteTitle));
        }
    }
}
