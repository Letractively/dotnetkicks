using System;
using System.Web;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Web.Helpers {
    public class UrlFactory {

        public enum PageName {
            Home,
            HomeRss,

            Login,
            LoginSwitch,
            Logout,
            ForgotPassword,
            ChangePassword,
            Register,
            About,
            EarnMoney,
            Contribute,
            JavaScriptFeeds,
            Tools,
            Search,

            WhoIsOnline,
            KickSpy,

            UserHome,
            UserProfile,
            UserFriends,
            UserKickedStories,
            UserKickedStoriesRss,
            UserSubmittedStories,
            UserSubmittedStoriesRss,
            UserComments,
            UserCommentsRss,
            UserTag,
            UserTags,
            Users,
            UserTest,

            FriendsKickedStories,
            FriendsKickedStoriesRss,
            FriendsSubmittedStories,
            FriendsSubmittedStoriesRss,

            ViewCategory,
            ViewCategoryRss,
            ViewCategoryNewStories,
            ViewCategoryNewStoriesRss,
            ViewTag,
            ViewTags,
            
            ViewStory,
            SubmitStory,

            NewStories,
            NewStoriesRss,
            UpcomingWeek,
            UpcomingToday,

            PopularToday,
            PopularWeek,
            PopularTenDays,
            PopularMonth,
            PopularYear,

            VerifyEmail,
			ChangeEmail,

            Zeitgeist,

            ViewTagRss,
            NotAuthorised,
            Admin,

            ApiOverview,
            ApiGenerateKey,
            
            JsonServices,
            LiveKicks
        }

        public static string CreateUrl(PageName pageName) {
            switch (pageName) {
                case PageName.Home:
                    return MapPath("/");
                case PageName.HomeRss:
                    return MapPath("/feeds/rss");
                case PageName.Login:
                    return MapPath("/login");
                case PageName.LoginSwitch:
                    return MapPath("/loginswitch");
                case PageName.Logout:
                    return MapPath("/logout");
                case PageName.Register:
                    return MapPath("/register");
                case PageName.About:
                    return MapPath("/docs/about");
                case PageName.EarnMoney:
                    return MapPath("/docs/earnmoney");
                case PageName.Contribute:
                    return MapPath("/docs/contribute");
                case PageName.JavaScriptFeeds:
                    return MapPath("/docs/webfeeds");
                case PageName.Tools:
                    return MapPath("/docs/tools");
                case PageName.Search:
                    return MapPath("/search");
                case PageName.Users:
                    return MapPath("/users");
                case PageName.SubmitStory:
                    return MapPath("/submit");
                case PageName.NewStories:
                    return MapPath("/upcoming");
                case PageName.NewStoriesRss:
                    return MapPath("/upcoming/rss");
                case PageName.ChangePassword:
                    return MapPath("/changepassword");
                case PageName.ViewTags:
                    return MapPath("/tags");
                case PageName.NotAuthorised:
                    return MapPath("/notauthorised");
                case PageName.Admin:
                    return MapPath("/admin");  
                case PageName.Zeitgeist:
                    return MapPath("/zeitgeist"); 
                case PageName.WhoIsOnline:
                case PageName.KickSpy:
                    return MapPath("/spy");

				case PageName.ChangeEmail:
					return MapPath("/changeemail");
                
                case PageName.ApiOverview:
                    return MapPath("/api");
                case PageName.ApiGenerateKey:
                    return MapPath("/api/key");
                
                case PageName.JsonServices:
                    return MapPath("/services/json/jsonservices.ashx");
                case PageName.LiveKicks:
                    return "http://widgets.dotnetkicks.com/";

                default:
                    throw new Exception("not enough params to create url");
            }
        }

        public static string CreateUrl(PageName pageName, string value) {
            switch (pageName) {
                case PageName.UserHome:
                    return MapPath(String.Format("/users/{0}", value));
                case PageName.UserProfile:
                    return MapPath(String.Format("/users/{0}/profile", value));
                case PageName.UserFriends:
                    return MapPath(String.Format("/users/{0}/friends", value));
                case PageName.UserKickedStories:
                    return MapPath(String.Format("/users/{0}/kicked", value));
                case PageName.UserKickedStoriesRss:
                    return MapPath(String.Format("/users/{0}/kicked/rss", value));
                case PageName.UserSubmittedStories:
                    return MapPath(String.Format("/users/{0}/submitted", value));
                case PageName.UserSubmittedStoriesRss:
                    return MapPath(String.Format("/users/{0}/submitted/rss", value));
                case PageName.UserComments:
                    return MapPath(String.Format("/users/{0}/comments", value));
                case PageName.UserCommentsRss:
                    return MapPath(String.Format("/users/{0}/comments/rss", value));
                case PageName.UserTags:
                    return MapPath(String.Format("/users/{0}/tags", value));
                case PageName.UserTest:
                    return MapPath(String.Format("/users/{0}/test", value));
                case PageName.FriendsKickedStories:
                    return MapPath(String.Format("/users/{0}/friends/kicked", value));
                case PageName.FriendsSubmittedStories:
                    return MapPath(String.Format("/users/{0}/friends/submitted", value));
                case PageName.ViewCategory:
                    return MapPath(String.Format("/{0}", value));
                case PageName.ViewCategoryRss:
                    return MapPath(String.Format("/{0}/feeds/rss", value));
                case PageName.ViewCategoryNewStories:
                    return MapPath(String.Format("/{0}/upcoming", value));
                case PageName.ViewCategoryNewStoriesRss:
                    if (String.IsNullOrEmpty(value))
                        return MapPath(String.Format("/upcoming/rss", value));
                    else
                        return MapPath(String.Format("/{0}/upcoming/rss", value));
                case PageName.LoginSwitch:
                    return MapPath(String.Format("/loginswitch/?url={0}", HttpUtility.UrlEncode(value)));
                case PageName.ViewTag:
                    return MapPath(String.Format("/tags/{0}", value));
                case PageName.ViewTagRss:
                    return MapPath(String.Format("/tags/{0}/feeds/rss", value));
                case PageName.Login:
                    return MapPath(String.Format("/login?ReturnUrl={0}", HttpUtility.UrlEncode(value)));
                
                case PageName.Zeitgeist:
                    return MapPath(String.Format("/zeitgeist/{0}", value));
                case PageName.Search:
                    return MapPath(String.Format("/search?q={0}", value));
                default:
                    throw new Exception("not enough params to create url");
            }
        }

        public static string CreateUrl(PageName pageName, string identifier1, string identifier2) {
            switch (pageName) {
                case PageName.ViewStory:
                    return MapPath(String.Format("/{1}/{0}", identifier1, identifier2));
                case PageName.UserTag:
                    return MapPath(String.Format("/users/{0}/tags/{1}", identifier1, identifier2));
                case PageName.Zeitgeist:
                    return MapPath(String.Format("/zeitgeist/{0}/{1}", identifier1, identifier2));
                case PageName.UserProfile:
                    return MapPath(String.Format("/users/{0}/profile?EmailSent={1}", identifier1, identifier2));
                default:
                    throw new Exception("not enough params to create url");
            }
        }
        public static string CreateUrl(PageName pageName, string identifier1, string identifier2, string identifier3)
        {
            switch (pageName)
            {
                case PageName.Zeitgeist:
                    return MapPath(String.Format("/zeitgeist/{0}/{1}/{2}", identifier1, identifier2, identifier3 ));
                default:
                    throw new Exception("not enough params to create url");
            }
        }
        public static string CreateUrl(PageName pageName, string storyIdentifier, string categoryIdentifier, int commentID) {
            switch (pageName) {
                case PageName.ViewStory:
                    return MapPath(String.Format("/{0}/{1}#Comment_{2}", categoryIdentifier, storyIdentifier, commentID));
                default:
                    throw new Exception("not enough params to create url");
            }
        }

        public static string CreateUrl(PageName pageName, string storyIdentifier, string categoryIdentifier, Host hostProfile) {
            switch (pageName) {
                case PageName.ViewStory:
                    return hostProfile.RootUrl + String.Format("/{0}/{1}", categoryIdentifier, storyIdentifier);
                default:
                    throw new Exception("not enough params to create url");
            }
        }

        private static string MapPath(string relativeUrl) {
            string mappedPath;
            if (HttpContext.Current.Request.ApplicationPath.Length > 1) {
                mappedPath = HttpContext.Current.Request.ApplicationPath + relativeUrl;
            } else {
                mappedPath = relativeUrl;
            }

            mappedPath = mappedPath.TrimEnd('/');

            if (mappedPath.Length == 0)
                mappedPath = "/";

            //System.Diagnostics.Trace.WriteLine("MapPath Url:  " + mappedPath);

            return mappedPath;
        }
    }
}
