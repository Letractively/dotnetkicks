using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using Incremental.Kick.Dal;
using Incremental.Kick.Caching;

namespace Incremental.Kick.Helpers {
    public class EmailHelper {

        public static void SendNewUserEmail(string toEmail, string username, string password, Host host) {
            Send(host.Email, toEmail, "Welcome to " + host.SiteTitle + " " + username, 
                String.Format(@"
                Welcome to {3}.
                
                Your account information is as follows:

                ---------------
                Username: {0}
                Password: {1}
                ---------------

                You can log in to kick at the following location : {2}

                Thanks for joining our site,
                {3}", username, password, host.RootUrl + "/login", host.SiteTitle), host);
        }

        public static void SendChangedPasswordEmail(string toEmail, string username, string password, Host host) {
            Send(host.Email, toEmail, "Your " + host.SiteTitle + " password has been changed",
                String.Format(@"
                As requested, you password has been changed.                
                
                Please keep this email for your records. Your new account information is as follows:

                ---------------
                Username: {0}
                Password: {1}
                ---------------

                You can log in to kick at the following location : {2}

                Thanks,
                {3}", username, password, host.RootUrl + "/login", host.SiteTitle), host);
        }

        public static void SendStoryDeletedEmail(Story story, Host host) {
            Send_Begin(host.Email, story.User.Email, "[" + host.SiteTitle + "]",
                String.Format(@"
                Your post 

                '{0}'
                '{1}'

                was deleted by a moderator.

                Please let us know if you think this was in error.", story.Title, story.Description), host);
        }

        public static void Send(MailMessage message, Host host) {
            SmtpClient smtpClient = new SmtpClient(host.SmtpHost, host.SmtpPort);
            smtpClient.Credentials = new NetworkCredential(host.SmtpUsername, host.SmtpPassword);
            smtpClient.EnableSsl = host.SmtpEnableSsl;
            smtpClient.Send(message);
        }

        public static void Send(string from, string to, string subject, string body, Host host) {
            Send(new MailMessage(from, to, subject, body), host);
        }

        public static void Send_Begin(string from, string to, string subject, string body, Host host) {
            AsyncHelper.FireAndForget(delegate { Send(from, to, subject, body, host); });
        }

        internal static void SendPasswordResetEmail(string toEmail, string username, DateTime createdDateTime, Host host) {
            Send(host.Email, toEmail, "Reset you " + host.SiteTitle + " password",
                String.Format(@"
                Please follow the link below to reset your password:

                {0}               

                Thanks,
                {1}", host.RootUrl + "/resetpassword/" + username + "/" + createdDateTime.Ticks.GetHashCode().ToString(), host.SiteTitle), host);
        }

        public static void SendPasswordEmail(string toEmail, string username, string password, Host host) {
            Send(host.Email, toEmail, "Your new " + host.SiteTitle + " password",
                String.Format(@"
                
                Please keep this email for your records. Your account information is as follows:

                ---------------
                Username: {0}
                Password: {1}
                ---------------

                You can log in to kick at the following location : {2}

                {3}", username, password, host.RootUrl + "/login", host.SiteTitle), host);
        }

        public static void SendUserBanEmail(User user, Host host) {
            Send_Begin(host.Email, user.Email, "[" + host.SiteTitle + "]",
                String.Format(@"
                A moderator has banned you from {0}.

                Please let us know if you think this was in error.", host.SiteTitle), host);
        }

        public static void SendUserUnBanEmail(User user, Host host) {
            Send_Begin(host.Email, user.Email, "[" + host.SiteTitle + "]",
                String.Format(@"
                A moderator has un-banned you from {0}. Welcome back!!", host.SiteTitle), host);
        }

        public static void SendChangedEmailEmail(string toEmail, string username, string currentEmail, Host host)
        {
            // Send a verify email address.  Add a 64bit encryption "hash" to verify when they click it.
            Send(host.Email, toEmail, host.SiteTitle + " has requested you to verify your email",
                String.Format(@"
                This is to verify that the email address you have selected is valid.                
                
                Please click on the link below to verify this email address:

                {0}

                If you did not request to change your email address, pleas disreguard this message.

                Thanks,
                {1}", host.RootUrl + "/verifyemail/" + Security.Cipher.EncryptToBase64(username + "#" + currentEmail + "#" + toEmail), host.SiteTitle), host);
        }
    }
}
