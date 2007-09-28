using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;

namespace Incremental.Kick.Dal
{
    /// <summary>
    /// Controller class for Kick_User
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class UserController
    {
        // Preload our schema..
        User thisSchemaLoad = new User();
        private string userName = string.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}

					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}

				}

				return userName;
            }

        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public UserCollection FetchAll()
        {
            UserCollection coll = new UserCollection();
            Query qry = new Query(User.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public UserCollection FetchByID(object UserID)
        {
            UserCollection coll = new UserCollection().Where("UserID", UserID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public UserCollection FetchByQuery(Query qry)
        {
            UserCollection coll = new UserCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object UserID)
        {
            return (User.Delete(UserID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object UserID)
        {
            return (User.Destroy(UserID) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Username,string Email,string Password,string PasswordSalt,bool IsGeneratedPassword,bool IsValidated,bool IsBanned,string AdsenseID,bool ReceiveEmailNewsletter,string Roles,int HostID,DateTime LastActiveOn,DateTime CreatedOn,DateTime ModifiedOn,string Location,bool UseGravatar,string GravatarCustomEmail,string WebsiteURL,string BlogURL,string BlogFeedURL)
	    {
		    User item = new User();
		    
            item.Username = Username;
            
            item.Email = Email;
            
            item.Password = Password;
            
            item.PasswordSalt = PasswordSalt;
            
            item.IsGeneratedPassword = IsGeneratedPassword;
            
            item.IsValidated = IsValidated;
            
            item.IsBanned = IsBanned;
            
            item.AdsenseID = AdsenseID;
            
            item.ReceiveEmailNewsletter = ReceiveEmailNewsletter;
            
            item.Roles = Roles;
            
            item.HostID = HostID;
            
            item.LastActiveOn = LastActiveOn;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedOn = ModifiedOn;
            
            item.Location = Location;
            
            item.UseGravatar = UseGravatar;
            
            item.GravatarCustomEmail = GravatarCustomEmail;
            
            item.WebsiteURL = WebsiteURL;
            
            item.BlogURL = BlogURL;
            
            item.BlogFeedURL = BlogFeedURL;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int UserID,string Username,string Email,string Password,string PasswordSalt,bool IsGeneratedPassword,bool IsValidated,bool IsBanned,string AdsenseID,bool ReceiveEmailNewsletter,string Roles,int HostID,DateTime LastActiveOn,DateTime CreatedOn,DateTime ModifiedOn,string Location,bool UseGravatar,string GravatarCustomEmail,string WebsiteURL,string BlogURL,string BlogFeedURL)
	    {
		    User item = new User();
		    
				item.UserID = UserID;
				
				item.Username = Username;
				
				item.Email = Email;
				
				item.Password = Password;
				
				item.PasswordSalt = PasswordSalt;
				
				item.IsGeneratedPassword = IsGeneratedPassword;
				
				item.IsValidated = IsValidated;
				
				item.IsBanned = IsBanned;
				
				item.AdsenseID = AdsenseID;
				
				item.ReceiveEmailNewsletter = ReceiveEmailNewsletter;
				
				item.Roles = Roles;
				
				item.HostID = HostID;
				
				item.LastActiveOn = LastActiveOn;
				
				item.CreatedOn = CreatedOn;
				
				item.ModifiedOn = ModifiedOn;
				
				item.Location = Location;
				
				item.UseGravatar = UseGravatar;
				
				item.GravatarCustomEmail = GravatarCustomEmail;
				
				item.WebsiteURL = WebsiteURL;
				
				item.BlogURL = BlogURL;
				
				item.BlogFeedURL = BlogFeedURL;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

