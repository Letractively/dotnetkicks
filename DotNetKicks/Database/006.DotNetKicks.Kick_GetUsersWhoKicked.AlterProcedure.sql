USE [DotNetKicks]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Kick_GetUsersWhoKicked] 
@storyId int

AS
BEGIN

SET NOCOUNT ON;

SELECT	
	u.[UserID]
   ,u.[Username]
   ,u.[Email]
   ,u.[Password]
   ,u.[PasswordSalt]
   ,u.[IsGeneratedPassword]
   ,u.[IsValidated]
   ,u.[IsBanned]
   ,u.[AdsenseID]
   ,u.[ReceiveEmailNewsletter]
   ,u.[Roles]
   ,u.[HostID]
   ,u.[LastActiveOn]
   ,u.[CreatedOn]
   ,u.[ModifiedOn]
   ,u.[Location]
   ,u.[UseGravatar]
   ,u.[GravatarCustomEmail]
   ,u.[WebsiteURL]
   ,u.[BlogURL]
   ,u.[BlogFeedURL]
   ,u.[AppearOnline]
   ,u.[ShowStoryThumbnail]

	FROM Kick_User u (NOLOCK)
		INNER JOIN Kick_StoryKick sk (NOLOCK) ON u.userId = sk.userId
	WHERE sk.storyId = @storyId

END
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

