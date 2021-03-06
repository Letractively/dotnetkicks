USE [DotNetKicks]
GO
/****** Object:  Table [dbo].[Kick_Host]    Script Date: 09/26/2007 11:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kick_Host](
	[HostID] [int] IDENTITY(1,1) NOT NULL,
	[HostName] [nvarchar](255) NOT NULL,
	[RootUrl] [nvarchar](50) NOT NULL,
	[SiteTitle] [nvarchar](255) NOT NULL,
	[SiteDescription] [nvarchar](2000) NOT NULL,
	[TagLine] [nvarchar](255) NOT NULL,
	[LogoPath] [nvarchar](255) NOT NULL CONSTRAINT [DF_Kick_Host_LogoPath]  DEFAULT (''),
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_Kick_Host_CreatedDateTime]  DEFAULT (getdate()),
	[BlogUrl] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Template] [nvarchar](50) NOT NULL,
	[ShowAds] [bit] NOT NULL,
	[Culture] [nvarchar](50) NOT NULL,
	[UICulture] [nvarchar](50) NOT NULL,
	[Publish_MinimumStoryAgeInHours] [smallint] NOT NULL CONSTRAINT [DF_Kick_Host_MinimumStoryAgeInHours]  DEFAULT ((0)),
	[Publish_MaximumStoryAgeInHours] [smallint] NOT NULL CONSTRAINT [DF_Kick_Host_Publish_MaximumStoryAgeInHours]  DEFAULT ((48)),
	[Publish_MaximumSimultaneousStoryPublishCount] [smallint] NOT NULL CONSTRAINT [DF_Kick_Host_Publish_MaximumSimiltanousStoryPublishCount]  DEFAULT ((1)),
	[Publish_MinimumStoryScore] [smallint] NOT NULL CONSTRAINT [DF_Kick_Host_Publish_MinimumStoryScore]  DEFAULT ((50)),
	[Publish_MinimumStoryKickCount] [smallint] NOT NULL CONSTRAINT [DF_Kick_Host_Publish_MinimumStoryKickCount]  DEFAULT ((5)),
	[Publish_MinimumStoryCommentCount] [smallint] NOT NULL CONSTRAINT [DF_Kick_Host_Publish_MinimumStoryCommentCount]  DEFAULT ((0)),
	[Publish_MinimumAverageStoryKicksPerHour] [smallint] NOT NULL CONSTRAINT [DF_Kick_Host_Publish_MinimumAverageStoryKicksPerHour]  DEFAULT ((0)),
	[Publish_MinimunAverageCommentsPerHour] [smallint] NOT NULL CONSTRAINT [DF_Kick_Host_Publish_MinimunAverageCommentsPerHour]  DEFAULT ((0)),
	[Publish_MinimumViewCount] [smallint] NOT NULL CONSTRAINT [DF_Kick_Host_Publish_MinimumViewCount]  DEFAULT ((0)),
	[Publish_KickScore] [smallint] NOT NULL CONSTRAINT [DF_Kick_Host_Publish_KickScore]  DEFAULT ((5)),
	[Publish_CommentScore] [smallint] NOT NULL CONSTRAINT [DF_Kick_Host_Publish_CommentScore]  DEFAULT ((2)),
	[AdsenseID] [nvarchar](30) NOT NULL CONSTRAINT [DF_Kick_Host_AdsenseID]  DEFAULT (''),
	[TrackingHtml] [text] NOT NULL CONSTRAINT [DF_Kick_Host_TrackingHtml]  DEFAULT (''),
	[AnnouncementHtml] [text] NULL,
	[FeedBurnerMainRssFeedUrl] [nvarchar](255) NULL,
	[FeedBurnerMainRssFeedCountHtml] [nvarchar](500) NULL,
	[UseStaticRoot] [bit] NOT NULL DEFAULT ((0)),
	[SmtpHost] [nvarchar](255) NOT NULL DEFAULT (''),
	[SmtpPort] [int] NOT NULL DEFAULT ((25)),
	[SmtpUsername] [nvarchar](50) NOT NULL DEFAULT (''),
	[SmtpPassword] [nvarchar](50) NOT NULL DEFAULT (''),
	[SmtpEnableSsl] [bit] NOT NULL DEFAULT ((1)),
 CONSTRAINT [PK_Kick_Host] PRIMARY KEY CLUSTERED 
(
	[HostID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kick_Tag]    Script Date: 09/26/2007 11:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kick_Tag](
	[TagID] [int] IDENTITY(1,1) NOT NULL,
	[TagIdentifier] [nvarchar](60) NOT NULL,
 CONSTRAINT [PK_Kick_Tag] PRIMARY KEY CLUSTERED 
(
	[TagID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kick_Setting]    Script Date: 09/26/2007 11:17:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kick_Setting](
	[SettingID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Value] [text] NOT NULL,
 CONSTRAINT [PK_Kick_Setting] PRIMARY KEY CLUSTERED 
(
	[SettingID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ELMAH_Error]    Script Date: 09/26/2007 11:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ELMAH_Error](
	[ErrorId] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ELMAH_Error_ErrorId]  DEFAULT (newid()),
	[Application] [nvarchar](60) NOT NULL,
	[Host] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](100) NOT NULL,
	[Source] [nvarchar](60) NOT NULL,
	[Message] [nvarchar](500) NOT NULL,
	[User] [nvarchar](50) NOT NULL,
	[StatusCode] [int] NOT NULL,
	[TimeUtc] [datetime] NOT NULL,
	[Sequence] [int] IDENTITY(1,1) NOT NULL,
	[AllXml] [ntext] NOT NULL,
 CONSTRAINT [PK_ELMAH_Error] PRIMARY KEY CLUSTERED 
(
	[ErrorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kick_User]    Script Date: 09/26/2007 11:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kick_User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[PasswordSalt] [nvarchar](50) NOT NULL,
	[IsGeneratedPassword] [bit] NOT NULL CONSTRAINT [DF_Kick_User_IsGeneratedPassword]  DEFAULT ((1)),
	[IsValidated] [bit] NOT NULL,
	[IsBanned] [bit] NOT NULL,
	[AdsenseID] [nvarchar](30) NOT NULL CONSTRAINT [DF_Kick_User_AdsenseID]  DEFAULT (''),
	[ReceiveEmailNewsletter] [bit] NOT NULL CONSTRAINT [DF_Kick_User_ReceiveEmailNewsletter]  DEFAULT ((1)),
	[Roles] [nvarchar](100) NOT NULL,
	[HostID] [int] NOT NULL,
	[LastActiveOn] [datetime] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	[Location] [nvarchar](255) NULL,
	[UseGravatar] [bit] NOT NULL DEFAULT ((0)),
	[GravatarCustomEmail] [nvarchar](255) NULL,
	[WebsiteURL] [nvarchar](1000) NULL,
	[BlogURL] [nvarchar](1000) NULL,
	[BlogFeedURL] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Kick_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kick_Category]    Script Date: 09/26/2007 11:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kick_Category](
	[CategoryID] [smallint] IDENTITY(1,1) NOT NULL,
	[HostID] [int] NOT NULL,
	[CategoryIdentifier] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](4000) NOT NULL,
	[IconName] [nvarchar](50) NULL,
	[OrderPriority] [smallint] NOT NULL CONSTRAINT [DF_Kick_Category_OrderPriority]  DEFAULT ((100)),
	[TagIdentifier] [nvarchar](50) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Kick_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kick_Shout]    Script Date: 09/26/2007 11:17:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kick_Shout](
	[ShoutID] [int] IDENTITY(1,1) NOT NULL,
	[FromUserID] [int] NOT NULL,
	[ToUserID] [int] NULL,
	[HostID] [int] NOT NULL,
	[Message] [nvarchar](4000) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[IsSpam] [bit] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_Kick_Shout] PRIMARY KEY CLUSTERED 
(
	[ShoutID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kick_Story]    Script Date: 09/26/2007 11:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kick_Story](
	[StoryID] [int] IDENTITY(1,1) NOT NULL,
	[HostID] [int] NOT NULL,
	[StoryIdentifier] [nvarchar](255) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](4000) NOT NULL,
	[Url] [nvarchar](1000) NOT NULL,
	[CategoryID] [smallint] NOT NULL,
	[UserID] [int] NOT NULL CONSTRAINT [DF_Kick_Story_UserID]  DEFAULT ((1)),
	[KickCount] [int] NOT NULL,
	[SpamCount] [int] NOT NULL,
	[ViewCount] [int] NOT NULL,
	[CommentCount] [int] NOT NULL,
	[IsPublishedToHomepage] [bit] NOT NULL,
	[IsSpam] [bit] NOT NULL,
	[AdsenseID] [nvarchar](30) NOT NULL CONSTRAINT [DF_Kick_Story_AdsenseID]  DEFAULT (''),
	[CreatedOn] [datetime] NOT NULL,
	[PublishedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Kick_Story] PRIMARY KEY CLUSTERED 
(
	[StoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kick_StoryUserHostTag]    Script Date: 09/26/2007 11:18:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kick_StoryUserHostTag](
	[StoryUserHostTagID] [int] IDENTITY(1,1) NOT NULL,
	[StoryID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[HostID] [int] NOT NULL,
	[TagID] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Kick_StoryUserHostTag_1] PRIMARY KEY CLUSTERED 
(
	[StoryUserHostTagID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kick_Comment]    Script Date: 09/26/2007 11:17:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kick_Comment](
	[CommentID] [int] IDENTITY(1,1) NOT NULL,
	[StoryID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[Comment] [nvarchar](4000) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[HostID] [int] NOT NULL DEFAULT ((1)),
	[IsSpam] [bit] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kick_StoryKick]    Script Date: 09/26/2007 11:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kick_StoryKick](
	[StoryKickID] [int] IDENTITY(1,1) NOT NULL,
	[StoryID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[HostID] [int] NOT NULL CONSTRAINT [DF_Kick_StoryKick_HostID]  DEFAULT ((2)),
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_Kick_StoryKick_CreatedDateTime]  DEFAULT (((1)/(1))/(2000)),
 CONSTRAINT [PK_Kick_StoryKick_1] PRIMARY KEY CLUSTERED 
(
	[StoryKickID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kick_UserAction]    Script Date: 09/26/2007 11:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kick_UserAction](
	[UserActionID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[HostID] [int] NOT NULL,
	[UserActionTypeID] [int] NOT NULL,
	[Message] [nvarchar](1000) NOT NULL,
	[ToUserID] [int] NULL,
	[StoryID] [int] NULL,
	[ChatID] [int] NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Kick_UserAction] PRIMARY KEY CLUSTERED 
(
	[UserActionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kick_UserFriend]    Script Date: 09/26/2007 11:18:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kick_UserFriend](
	[UserFriendID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[FriendID] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Kick_UserFriend] PRIMARY KEY CLUSTERED 
(
	[UserFriendID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_Kick_UserFriend] UNIQUE NONCLUSTERED 
(
	[UserID] ASC,
	[FriendID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kick_Chat]    Script Date: 09/26/2007 11:17:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kick_Chat](
	[ChatID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[HostID] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](2000) NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[IsPrivate] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Kick_Chat] PRIMARY KEY CLUSTERED 
(
	[ChatID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Kick_GetTagsByUserIDAndHostID]    Script Date: 09/26/2007 11:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Kick_GetTagsByUserIDAndHostID] 
	@UserID int,
	@HostID int
AS
BEGIN
	SET NOCOUNT ON;
	
SELECT     dbo.Kick_Tag.TagID, dbo.Kick_Tag.TagIdentifier
FROM         dbo.Kick_StoryUserHostTag INNER JOIN
                      dbo.Kick_Tag ON dbo.Kick_StoryUserHostTag.TagID = dbo.Kick_Tag.TagID

WHERE     
	(dbo.Kick_StoryUserHostTag.UserID = @UserID)
AND
	(dbo.Kick_StoryUserHostTag.HostID = @HostID)
END
GO
/****** Object:  StoredProcedure [dbo].[Kick_GetTagsByHostIDAndCreatedOnRange]    Script Date: 09/26/2007 11:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Kick_GetTagsByHostIDAndCreatedOnRange]
	@HostID int,
	@CreatedOn_Lower datetime,
	@CreatedOn_Upper datetime
AS
BEGIN
	SET NOCOUNT ON;
	
SELECT     dbo.Kick_Tag.TagID, dbo.Kick_Tag.TagIdentifier
FROM         dbo.Kick_StoryUserHostTag INNER JOIN
                      dbo.Kick_Tag ON dbo.Kick_StoryUserHostTag.TagID = dbo.Kick_Tag.TagID

WHERE     
	(dbo.Kick_StoryUserHostTag.HostID = @HostID)
AND
	(dbo.Kick_StoryUserHostTag.CreatedOn BETWEEN @CreatedOn_Lower AND @CreatedOn_Upper)
END
GO
/****** Object:  StoredProcedure [dbo].[Kick_GetTagsByUserIDAndStoryID]    Script Date: 09/26/2007 11:17:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Kick_GetTagsByUserIDAndStoryID] 
	@UserID int,
	@StoryID int
AS
BEGIN
	SET NOCOUNT ON;
	
SELECT     dbo.Kick_Tag.TagID, dbo.Kick_Tag.TagIdentifier
FROM         dbo.Kick_StoryUserHostTag INNER JOIN
                      dbo.Kick_Tag ON dbo.Kick_StoryUserHostTag.TagID = dbo.Kick_Tag.TagID

WHERE     
	(dbo.Kick_StoryUserHostTag.UserID = @UserID)
AND
	(dbo.Kick_StoryUserHostTag.StoryID = @StoryID)
END
GO
/****** Object:  StoredProcedure [dbo].[Kick_GetTagsByUserID]    Script Date: 09/26/2007 11:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Kick_GetTagsByUserID] 
	@UserID int
AS
BEGIN
	SET NOCOUNT ON;
	
SELECT     dbo.Kick_Tag.TagID, dbo.Kick_Tag.TagIdentifier
FROM         dbo.Kick_StoryUserHostTag INNER JOIN
                      dbo.Kick_Tag ON dbo.Kick_StoryUserHostTag.TagID = dbo.Kick_Tag.TagID

WHERE     
	(dbo.Kick_StoryUserHostTag.UserID = @UserID)
END
GO
/****** Object:  StoredProcedure [dbo].[Kick_GetTagsByStoryID]    Script Date: 09/26/2007 11:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Kick_GetTagsByStoryID] 
	@StoryID int
AS
BEGIN
	SET NOCOUNT ON;
	
SELECT     dbo.Kick_Tag.TagID, dbo.Kick_Tag.TagIdentifier
FROM         dbo.Kick_StoryUserHostTag INNER JOIN
                      dbo.Kick_Tag ON dbo.Kick_StoryUserHostTag.TagID = dbo.Kick_Tag.TagID

WHERE     
	(dbo.Kick_StoryUserHostTag.StoryID = @StoryID)
END
GO
/****** Object:  StoredProcedure [dbo].[Kick_GetPagedStoriesByTagIDAndHostID]    Script Date: 09/26/2007 11:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Kick_GetPagedStoriesByTagIDAndHostID]
	@TagID int,
	@HostID int,
	@PageNumber int,
	@PageSize int
AS
BEGIN

DECLARE @StartRow int, @EndRow int
SET @StartRow = (((@PageNumber - 1) * @PageSize) + 1);
SET @EndRow = (@StartRow + @PageSize - 1);

WITH TaggedStories 
	AS (SELECT ROW_NUMBER() OVER (ORDER BY Kick_Story.CreatedOn DESC) AS 
		Row, dbo.Kick_Story.*
	FROM         
		dbo.Kick_Story INNER JOIN
			dbo.Kick_StoryUserHostTag ON dbo.Kick_Story.StoryID = dbo.Kick_StoryUserHostTag.StoryID
	WHERE dbo.Kick_StoryUserHostTag.TagID=@TagID AND dbo.Kick_StoryUserHostTag.HostID=@HostID AND dbo.Kick_Story.IsSpam=0)

SELECT * FROM TaggedStories
WHERE ROW between @StartRow AND @EndRow



END
GO
/****** Object:  StoredProcedure [dbo].[Kick_GetPagedKickedStoriesByUserIDAndHostID]    Script Date: 09/26/2007 11:17:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Kick_GetPagedKickedStoriesByUserIDAndHostID]
	@UserID int,
	@HostID int,
	@PageNumber int,
	@PageSize int
AS
BEGIN

DECLARE @StartRow int, @EndRow int
SET @StartRow = (((@PageNumber - 1) * @PageSize) + 1);
SET @EndRow = (@StartRow + @PageSize - 1);





WITH KickedStories 
	AS (SELECT ROW_NUMBER() OVER (ORDER BY Kick_Story.CreatedOn DESC) AS 
		Row, dbo.Kick_Story.*
	FROM         
		dbo.Kick_Story INNER JOIN
			dbo.Kick_StoryKick ON dbo.Kick_Story.StoryID = dbo.Kick_StoryKick.StoryID
	WHERE dbo.Kick_StoryKick.UserID=@UserID AND dbo.Kick_StoryKick.HostID=@HostID AND dbo.Kick_Story.IsSpam=0)

SELECT * FROM KickedStories
WHERE ROW between @StartRow AND @EndRow



END
GO
/****** Object:  StoredProcedure [dbo].[Kick_GetPagedFriendsKickedStoriesByUserIDAndHostIDCount]    Script Date: 09/26/2007 11:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	returns count of a user's friends kicked stories
-- =============================================
CREATE PROCEDURE [dbo].[Kick_GetPagedFriendsKickedStoriesByUserIDAndHostIDCount] 
	-- Add the parameters for the stored procedure here
	@UserID int,
	@HostID int,
    @RecordCount int out
AS
BEGIN

SET NOCOUNT ON;

SET @RecordCount = (Select count(0) from (select distinct Kick_Story.StoryId
	FROM  dbo.Kick_Story INNER JOIN
			dbo.Kick_StoryKick ON dbo.Kick_Story.StoryID = dbo.Kick_StoryKick.StoryID
		INNER JOIN dbo.Kick_UserFriend ON dbo.Kick_UserFriend.FriendID = dbo.Kick_StoryKick.UserID
	WHERE dbo.Kick_UserFriend.UserID=@UserID AND dbo.Kick_StoryKick.HostID=@HostID AND dbo.Kick_Story.IsSpam=0) a
)

return @RecordCount

END
GO
/****** Object:  StoredProcedure [dbo].[Kick_GetPagedFriendsSubmittedStoriesByUserIDAndHostIDCount]    Script Date: 09/26/2007 11:17:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Description:	returns count of a user's friends submitted stories
-- =============================================
CREATE PROCEDURE [dbo].[Kick_GetPagedFriendsSubmittedStoriesByUserIDAndHostIDCount] 
	-- Add the parameters for the stored procedure here
	@UserID int,
	@HostID int,
	@RecordCount int out
AS
BEGIN

SET NOCOUNT ON;
DECLARE @TotalRows int

SET @RecordCount = (select count(0) from 
	(Select distinct dbo.Kick_Story.StoryId
		FROM         
			dbo.Kick_Story INNER JOIN dbo.Kick_UserFriend ON 
			dbo.Kick_UserFriend.FriendID = dbo.Kick_Story.UserID
		WHERE dbo.Kick_UserFriend.UserID=@UserID AND dbo.Kick_Story.HostID=@HostID AND dbo.Kick_Story.IsSpam=0) a
	)

RETURN @RecordCount

END
GO
/****** Object:  StoredProcedure [dbo].[Kick_GetPagedFriendsSubmittedStoriesByUserIDAndHostID]    Script Date: 09/26/2007 11:17:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Kick_GetPagedFriendsSubmittedStoriesByUserIDAndHostID]
	@UserID int,
	@HostID int,
	@PageNumber int,
	@PageSize int
AS
BEGIN

DECLARE @StartRow int, @EndRow int
SET @StartRow = (((@PageNumber - 1) * @PageSize) + 1);
SET @EndRow = (@StartRow + @PageSize - 1);


WITH SubmittedStories 
	AS (SELECT ROW_NUMBER() OVER (ORDER BY Kick_Story.CreatedOn DESC) AS 
		Row, dbo.Kick_Story.*
	FROM         
		dbo.Kick_Story INNER JOIN dbo.Kick_UserFriend ON 
			dbo.Kick_UserFriend.FriendID = dbo.Kick_Story.UserID
	WHERE dbo.Kick_UserFriend.UserID=@UserID AND dbo.Kick_Story.HostID=@HostID AND dbo.Kick_Story.IsSpam=0)

SELECT * FROM SubmittedStories
WHERE ROW between @StartRow AND @EndRow


END
GO
/****** Object:  StoredProcedure [dbo].[Kick_GetTopKickedStoriesByYearMonth]    Script Date: 09/26/2007 11:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jim Welch
-- Create date: 
-- Description:	returns the top 10 stories by year
-- =============================================
CREATE PROCEDURE [dbo].[Kick_GetTopKickedStoriesByYearMonth] 
	-- Add the parameters for the stored procedure here
	@HostId int,
	@Year int,
	@Month int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select top 10 count(0) as ItemCount,
		Kick_Story.StoryID, Kick_Story.HostID ,
		Kick_Story.StoryIdentifier, Kick_Story.Title,
		Kick_Story.CategoryID, Kick_Story.UserID,
		Kick_Story.PublishedOn, Kick_Story.ViewCount,
		Kick_Story.CommentCount, Kick_Category.CategoryIdentifier				
	from
		Kick_Story inner join Kick_StoryKick on 
		Kick_Story.StoryId=Kick_StoryKick.StoryId inner join
		Kick_Category on Kick_Story.CategoryId=Kick_Category.CategoryId
	where 
		Kick_Story.HostId=@HostId AND
		Kick_Story.IsSpam=0 AND
		datepart(year,Kick_StoryKick.CreatedOn) = @Year	 AND 	
		datepart(month,Kick_StoryKick.CreatedOn) = @Month
	group by Kick_Story.StoryID, Kick_Story.HostID ,
		Kick_Story.StoryIdentifier, Kick_Story.Title,
		Kick_Story.CategoryID, Kick_Story.UserID,
		Kick_Story.PublishedOn, 
		Kick_Story.ViewCount, Kick_Story.CommentCount,
		Kick_Category.CategoryIdentifier
	having count(0) > 0
	order by count(0) desc, Kick_Story.ViewCount desc, Kick_Story.CommentCount desc 

	--- order by view count & comment count in hopes to break tie-breakers
END
GO
/****** Object:  StoredProcedure [dbo].[Kick_GetTopCommentedOnStoriesByYear]    Script Date: 09/26/2007 11:17:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jim Welch
-- Create date: 
-- Description:	returns the top 10 stories by year
-- =============================================
CREATE PROCEDURE [dbo].[Kick_GetTopCommentedOnStoriesByYear] 
	-- Add the parameters for the stored procedure here
	@HostId int,
	@Year int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select top 10 Kick_Story.StoryID, Kick_Story.HostID ,
		Kick_Story.StoryIdentifier, Kick_Story.Title,
		Kick_Story.CategoryID, Kick_Story.UserID,
		Kick_Story.PublishedOn, Kick_Story.ViewCount,
		Kick_Story.KickCount, Kick_Category.CategoryIdentifier,
		count(0) as ItemCount
	from
		Kick_Story inner join Kick_Comment on 
		Kick_Story.StoryId=Kick_Comment.StoryId inner join
		Kick_Category on Kick_Story.CategoryId=Kick_Category.CategoryId
	where 
		Kick_Story.HostId=@HostId AND
		Kick_Story.IsSpam=0 AND
		datepart(year,Kick_Comment.CreatedOn) = @Year		
	group by Kick_Story.StoryID, Kick_Story.HostID ,
		Kick_Story.StoryIdentifier, Kick_Story.Title,
		Kick_Story.CategoryID, Kick_Story.UserID,
		Kick_Story.PublishedOn, 
		Kick_Story.ViewCount, Kick_Story.KickCount,
		Kick_Category.CategoryIdentifier
	order by count(0) desc, Kick_Story.KickCount desc, Kick_Story.ViewCount desc

	--- order by view count & comment count in hopes to break tie-breakers
END
GO
/****** Object:  StoredProcedure [dbo].[Kick_GetTopCommentedOnStoriesByYearMonth]    Script Date: 09/26/2007 11:17:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jim Welch
-- Create date: 
-- Description:	returns the top 10 stories by year
-- =============================================
CREATE PROCEDURE [dbo].[Kick_GetTopCommentedOnStoriesByYearMonth] 
	-- Add the parameters for the stored procedure here
	@HostId int,
	@Year int = 0,
	@Month int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select top 10 Kick_Story.StoryID, Kick_Story.HostID ,
		Kick_Story.StoryIdentifier, Kick_Story.Title,
		Kick_Story.CategoryID, Kick_Story.UserID,
		Kick_Story.PublishedOn, Kick_Story.ViewCount,
		Kick_Story.KickCount, Kick_Category.CategoryIdentifier,
		count(0) as ItemCount		
	from
		Kick_Story inner join Kick_Comment on 
		Kick_Story.StoryId=Kick_Comment.StoryId inner join
		Kick_Category on Kick_Story.CategoryId=Kick_Category.CategoryId
	where 
		Kick_Story.HostId=@HostId AND
		Kick_Story.IsSpam=0 AND
		datepart(year, Kick_Comment.CreatedOn) = @Year AND		
		datepart(month, Kick_Comment.CreatedOn) = @Month 
	group by Kick_Story.StoryID, Kick_Story.HostID ,
		Kick_Story.StoryIdentifier, Kick_Story.Title,
		Kick_Story.CategoryID, Kick_Story.UserID,
		Kick_Story.PublishedOn, 
		Kick_Story.ViewCount, Kick_Story.KickCount,
		Kick_Category.CategoryIdentifier
	order by count(0) desc, Kick_Story.KickCount desc, Kick_Story.ViewCount desc

	--- order by view count & comment count in hopes to break tie-breakers
END
GO
/****** Object:  StoredProcedure [dbo].[Kick_GetPagedFriendsKickedStoriesByUserIDAndHostID]    Script Date: 09/26/2007 11:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Kick_GetPagedFriendsKickedStoriesByUserIDAndHostID]
	@UserID int,
	@HostID int,
	@PageNumber int,
	@PageSize int
AS
BEGIN

DECLARE @StartRow int, @EndRow int
SET @StartRow = (((@PageNumber - 1) * @PageSize) + 1);
SET @EndRow = (@StartRow + @PageSize - 1);

WITH KickedStories 
	AS (SELECT ROW_NUMBER() OVER (ORDER BY Kick_Story.CreatedOn DESC) AS 
		Row, dbo.Kick_Story.*
	FROM         
		dbo.Kick_Story INNER JOIN
			dbo.Kick_StoryKick ON dbo.Kick_Story.StoryID = dbo.Kick_StoryKick.StoryID
		INNER JOIN dbo.Kick_UserFriend ON dbo.Kick_UserFriend.FriendID = dbo.Kick_StoryKick.UserID
	WHERE dbo.Kick_UserFriend.UserID=@UserID AND dbo.Kick_StoryKick.HostID=@HostID AND dbo.Kick_Story.IsSpam=0)

SELECT * FROM KickedStories
WHERE ROW between @StartRow AND @EndRow

END
GO
/****** Object:  StoredProcedure [dbo].[Kick_GetTopKickedStoriesByYear]    Script Date: 09/26/2007 11:17:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jim Welch
-- Create date: 
-- Description:	returns the top 10 stories by year
-- =============================================
CREATE PROCEDURE [dbo].[Kick_GetTopKickedStoriesByYear] 
	-- Add the parameters for the stored procedure here
	@HostId int,
	@Year int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select top 10 Kick_Story.StoryID, Kick_Story.HostID ,
		Kick_Story.StoryIdentifier, Kick_Story.Title,
		Kick_Story.CategoryID, Kick_Story.UserID,
		Kick_Story.PublishedOn, Kick_Story.ViewCount,
		Kick_Story.CommentCount, Kick_Category.CategoryIdentifier,
		count(0) as ItemCount		
	from
		Kick_Story inner join Kick_StoryKick on 
		Kick_Story.StoryId=Kick_StoryKick.StoryId inner join
		Kick_Category on Kick_Story.CategoryId=Kick_Category.CategoryId
	where 
		Kick_Story.HostId=@HostId AND
		Kick_Story.IsSpam=0 AND
		datepart(year,Kick_StoryKick.CreatedOn) = @Year		
	group by Kick_Story.StoryID, Kick_Story.HostID ,
		Kick_Story.StoryIdentifier, Kick_Story.Title,
		Kick_Story.CategoryID, Kick_Story.UserID,
		Kick_Story.PublishedOn, 
		Kick_Story.ViewCount, Kick_Story.CommentCount,
		Kick_Category.CategoryIdentifier
	order by count(0) desc, Kick_Story.ViewCount desc, Kick_Story.CommentCount desc

	--- order by view count & comment count in hopes to break tie-breakers
END
GO
/****** Object:  StoredProcedure [dbo].[Kick_GetPagedStoriesByTagIDAndHostIDAndUserID]    Script Date: 09/26/2007 11:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Kick_GetPagedStoriesByTagIDAndHostIDAndUserID]
	@TagID int,
	@HostID int,
	@UserID int,
	@PageNumber int,
	@PageSize int
AS
BEGIN

DECLARE @StartRow int, @EndRow int
SET @StartRow = (((@PageNumber - 1) * @PageSize) + 1);
SET @EndRow = (@StartRow + @PageSize - 1);

WITH TaggedStories 
	AS (SELECT ROW_NUMBER() OVER (ORDER BY Kick_Story.CreatedOn DESC) AS 
		Row, dbo.Kick_Story.*
	FROM         
		dbo.Kick_Story INNER JOIN
			dbo.Kick_StoryUserHostTag ON dbo.Kick_Story.StoryID = dbo.Kick_StoryUserHostTag.StoryID
	WHERE dbo.Kick_StoryUserHostTag.TagID=@TagID AND dbo.Kick_StoryUserHostTag.HostID=@HostID AND dbo.Kick_StoryUserHostTag.UserID=@UserID AND dbo.Kick_Story.IsSpam=0)

SELECT * FROM TaggedStories
WHERE ROW between @StartRow AND @EndRow



END
GO
/****** Object:  StoredProcedure [dbo].[Kick_GetPagedSubmittedStoriesByUserIDAndHostID]    Script Date: 09/26/2007 11:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Kick_GetPagedSubmittedStoriesByUserIDAndHostID]
	@UserID int,
	@HostID int,
	@PageNumber int,
	@PageSize int
AS
BEGIN

DECLARE @StartRow int, @EndRow int
SET @StartRow = (((@PageNumber - 1) * @PageSize) + 1);
SET @EndRow = (@StartRow + @PageSize - 1);





WITH SubmittedStories 
	AS (SELECT ROW_NUMBER() OVER (ORDER BY Kick_Story.CreatedOn DESC) AS 
		Row, dbo.Kick_Story.*
	FROM         
		dbo.Kick_Story 
	WHERE dbo.Kick_Story.UserID=@UserID AND dbo.Kick_Story.HostID=@HostID AND dbo.Kick_Story.IsSpam=0)

SELECT * FROM SubmittedStories
WHERE ROW between @StartRow AND @EndRow



END
GO
/****** Object:  StoredProcedure [dbo].[Kick_GetPagedCommentsByUserIDAndHostID]    Script Date: 09/26/2007 11:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Kick_GetPagedCommentsByUserIDAndHostID]
	@UserID int,
	@HostID int,
	@PageNumber int,
	@PageSize int
AS
BEGIN

DECLARE @StartRow int, @EndRow int
SET @StartRow = (((@PageNumber - 1) * @PageSize) + 1);
SET @EndRow = (@StartRow + @PageSize - 1);


WITH UserComments 
	AS (SELECT ROW_NUMBER() OVER (ORDER BY Kick_Comment.CreatedOn DESC) AS 
		Row, dbo.Kick_Comment.*
	FROM         
		dbo.Kick_Comment 
	WHERE dbo.Kick_Comment.UserID=@UserID AND dbo.Kick_Comment.HostID=@HostID)

SELECT * FROM UserComments
WHERE ROW between @StartRow AND @EndRow



END
GO
/****** Object:  StoredProcedure [dbo].[Kick_GetUsersWhoKicked]    Script Date: 09/26/2007 11:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Kick_GetUsersWhoKicked] 
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

	FROM Kick_User u (NOLOCK)
		INNER JOIN Kick_StoryKick sk (NOLOCK) ON u.userId = sk.userId
	WHERE sk.storyId = @storyId

END
GO
/****** Object:  StoredProcedure [dbo].[ELMAH_GetErrorXml]    Script Date: 09/26/2007 11:17:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ELMAH_GetErrorXml]
(
    @Application NVARCHAR(60),
    @ErrorId UNIQUEIDENTIFIER
)
AS

SET NOCOUNT ON

SELECT 
    AllXml
FROM 
    ELMAH_Error
WHERE
    ErrorId = @ErrorId
AND
    Application = @Application
GO
/****** Object:  StoredProcedure [dbo].[ELMAH_GetErrorsXml]    Script Date: 09/26/2007 11:17:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ELMAH_GetErrorsXml]
(
    @Application NVARCHAR(60),
    @PageIndex INT = 0,
    @PageSize INT = 15,
    @TotalCount INT OUTPUT
)
AS 

SET NOCOUNT ON

DECLARE @Page TABLE
(
    Position INT IDENTITY(1, 1) NOT NULL,
    ErrorId UNIQUEIDENTIFIER NOT NULL,
    Application NVARCHAR(60) NOT NULL,
    Host NVARCHAR(30) NOT NULL,
    Type NVARCHAR(100) NOT NULL,
    Source NVARCHAR(60) NOT NULL,
    Message NVARCHAR(500) NOT NULL,
    [User] NVARCHAR(50) NOT NULL,
    StatusCode INT NOT NULL,
    TimeUtc DATETIME NOT NULL
)

INSERT
INTO
    @Page
    (
        ErrorId,
        Application,
        Host,
        Type,
        Source,
        Message,
        [User],
        StatusCode,
        TimeUtc
    )
SELECT
    ErrorId,
    Application,
    Host,
    Type,
    Source,
    Message,
    [User],
    StatusCode,
    TimeUtc
FROM
    ELMAH_Error
WHERE
    Application = @Application    
ORDER BY
    TimeUtc DESC,
    Sequence DESC

SELECT 
    @TotalCount = COUNT(*) 
FROM 
    @Page

DECLARE @FirstPosition INT
SET @FirstPosition = @PageIndex * @PageSize + 1

DECLARE @LastPosition INT
SET @LastPosition  = @FirstPosition + @PageSize - 1

SELECT 
    errorId, 
    application,
    host, 
    type,
    source,
    message,
    [user],
    statusCode, 
    CONVERT(VARCHAR(50), TimeUtc, 126) + 'Z' time
FROM 
    @Page error
WHERE
    Position >= @FirstPosition
AND
    Position <= @LastPosition
ORDER BY
    Position
FOR
    XML AUTO
GO
/****** Object:  StoredProcedure [dbo].[ELMAH_LogError]    Script Date: 09/26/2007 11:17:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ELMAH_LogError]
(
    @ErrorId UNIQUEIDENTIFIER,
    @Application NVARCHAR(60),
    @Host NVARCHAR(30),
    @Type NVARCHAR(100),
    @Source NVARCHAR(60),
    @Message NVARCHAR(500),
    @User NVARCHAR(50),
    @AllXml NTEXT,
    @StatusCode INT,
    @TimeUtc DATETIME
)
AS

SET NOCOUNT ON

INSERT
INTO
    ELMAH_Error
    (
        ErrorId,
        Application,
        Host,
        Type,
        Source,
        Message,
        [User],
        AllXml,
        StatusCode,
        TimeUtc
    )
VALUES
    (
        @ErrorId,
        @Application,
        @Host,
        @Type,
        @Source,
        @Message,
        @User,
        @AllXml,
        @StatusCode,
        @TimeUtc
    )
GO
/****** Object:  ForeignKey [FK_Kick_Category_Kick_Host]    Script Date: 09/26/2007 11:17:35 ******/
ALTER TABLE [dbo].[Kick_Category]  WITH NOCHECK ADD  CONSTRAINT [FK_Kick_Category_Kick_Host] FOREIGN KEY([HostID])
REFERENCES [dbo].[Kick_Host] ([HostID])
GO
ALTER TABLE [dbo].[Kick_Category] CHECK CONSTRAINT [FK_Kick_Category_Kick_Host]
GO
/****** Object:  ForeignKey [FK_Kick_Chat_Kick_User]    Script Date: 09/26/2007 11:17:38 ******/
ALTER TABLE [dbo].[Kick_Chat]  WITH CHECK ADD  CONSTRAINT [FK_Kick_Chat_Kick_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Kick_User] ([UserID])
GO
ALTER TABLE [dbo].[Kick_Chat] CHECK CONSTRAINT [FK_Kick_Chat_Kick_User]
GO
/****** Object:  ForeignKey [FK_Kick_Comment_Kick_Story]    Script Date: 09/26/2007 11:17:40 ******/
ALTER TABLE [dbo].[Kick_Comment]  WITH NOCHECK ADD  CONSTRAINT [FK_Kick_Comment_Kick_Story] FOREIGN KEY([StoryID])
REFERENCES [dbo].[Kick_Story] ([StoryID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Kick_Comment] CHECK CONSTRAINT [FK_Kick_Comment_Kick_Story]
GO
/****** Object:  ForeignKey [FK_Kick_Comment_Kick_User]    Script Date: 09/26/2007 11:17:41 ******/
ALTER TABLE [dbo].[Kick_Comment]  WITH NOCHECK ADD  CONSTRAINT [FK_Kick_Comment_Kick_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Kick_User] ([UserID])
GO
ALTER TABLE [dbo].[Kick_Comment] CHECK CONSTRAINT [FK_Kick_Comment_Kick_User]
GO
/****** Object:  ForeignKey [FK_Kick_Shout_Kick_Host]    Script Date: 09/26/2007 11:17:56 ******/
ALTER TABLE [dbo].[Kick_Shout]  WITH NOCHECK ADD  CONSTRAINT [FK_Kick_Shout_Kick_Host] FOREIGN KEY([HostID])
REFERENCES [dbo].[Kick_Host] ([HostID])
GO
ALTER TABLE [dbo].[Kick_Shout] CHECK CONSTRAINT [FK_Kick_Shout_Kick_Host]
GO
/****** Object:  ForeignKey [FK_Kick_Shout_Kick_User]    Script Date: 09/26/2007 11:17:56 ******/
ALTER TABLE [dbo].[Kick_Shout]  WITH NOCHECK ADD  CONSTRAINT [FK_Kick_Shout_Kick_User] FOREIGN KEY([FromUserID])
REFERENCES [dbo].[Kick_User] ([UserID])
GO
ALTER TABLE [dbo].[Kick_Shout] CHECK CONSTRAINT [FK_Kick_Shout_Kick_User]
GO
/****** Object:  ForeignKey [FK_Kick_Shout_Kick_User1]    Script Date: 09/26/2007 11:17:56 ******/
ALTER TABLE [dbo].[Kick_Shout]  WITH NOCHECK ADD  CONSTRAINT [FK_Kick_Shout_Kick_User1] FOREIGN KEY([ToUserID])
REFERENCES [dbo].[Kick_User] ([UserID])
GO
ALTER TABLE [dbo].[Kick_Shout] CHECK CONSTRAINT [FK_Kick_Shout_Kick_User1]
GO
/****** Object:  ForeignKey [FK_Kick_Story_Kick_Category]    Script Date: 09/26/2007 11:18:01 ******/
ALTER TABLE [dbo].[Kick_Story]  WITH NOCHECK ADD  CONSTRAINT [FK_Kick_Story_Kick_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Kick_Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Kick_Story] CHECK CONSTRAINT [FK_Kick_Story_Kick_Category]
GO
/****** Object:  ForeignKey [FK_Kick_Story_Kick_Host]    Script Date: 09/26/2007 11:18:01 ******/
ALTER TABLE [dbo].[Kick_Story]  WITH NOCHECK ADD  CONSTRAINT [FK_Kick_Story_Kick_Host] FOREIGN KEY([HostID])
REFERENCES [dbo].[Kick_Host] ([HostID])
GO
ALTER TABLE [dbo].[Kick_Story] CHECK CONSTRAINT [FK_Kick_Story_Kick_Host]
GO
/****** Object:  ForeignKey [FK_Kick_Story_Kick_User]    Script Date: 09/26/2007 11:18:01 ******/
ALTER TABLE [dbo].[Kick_Story]  WITH NOCHECK ADD  CONSTRAINT [FK_Kick_Story_Kick_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Kick_User] ([UserID])
GO
ALTER TABLE [dbo].[Kick_Story] CHECK CONSTRAINT [FK_Kick_Story_Kick_User]
GO
/****** Object:  ForeignKey [FK_Kick_StoryKick_Kick_Story]    Script Date: 09/26/2007 11:18:03 ******/
ALTER TABLE [dbo].[Kick_StoryKick]  WITH NOCHECK ADD  CONSTRAINT [FK_Kick_StoryKick_Kick_Story] FOREIGN KEY([StoryID])
REFERENCES [dbo].[Kick_Story] ([StoryID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Kick_StoryKick] CHECK CONSTRAINT [FK_Kick_StoryKick_Kick_Story]
GO
/****** Object:  ForeignKey [FK_Kick_StoryKick_Kick_User]    Script Date: 09/26/2007 11:18:03 ******/
ALTER TABLE [dbo].[Kick_StoryKick]  WITH NOCHECK ADD  CONSTRAINT [FK_Kick_StoryKick_Kick_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Kick_User] ([UserID])
GO
ALTER TABLE [dbo].[Kick_StoryKick] CHECK CONSTRAINT [FK_Kick_StoryKick_Kick_User]
GO
/****** Object:  ForeignKey [FK_Kick_StoryUserHostTag_Kick_Host]    Script Date: 09/26/2007 11:18:05 ******/
ALTER TABLE [dbo].[Kick_StoryUserHostTag]  WITH NOCHECK ADD  CONSTRAINT [FK_Kick_StoryUserHostTag_Kick_Host] FOREIGN KEY([HostID])
REFERENCES [dbo].[Kick_Host] ([HostID])
GO
ALTER TABLE [dbo].[Kick_StoryUserHostTag] CHECK CONSTRAINT [FK_Kick_StoryUserHostTag_Kick_Host]
GO
/****** Object:  ForeignKey [FK_Kick_StoryUserHostTag_Kick_Story]    Script Date: 09/26/2007 11:18:05 ******/
ALTER TABLE [dbo].[Kick_StoryUserHostTag]  WITH NOCHECK ADD  CONSTRAINT [FK_Kick_StoryUserHostTag_Kick_Story] FOREIGN KEY([StoryID])
REFERENCES [dbo].[Kick_Story] ([StoryID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Kick_StoryUserHostTag] CHECK CONSTRAINT [FK_Kick_StoryUserHostTag_Kick_Story]
GO
/****** Object:  ForeignKey [FK_Kick_StoryUserHostTag_Kick_Tag]    Script Date: 09/26/2007 11:18:06 ******/
ALTER TABLE [dbo].[Kick_StoryUserHostTag]  WITH NOCHECK ADD  CONSTRAINT [FK_Kick_StoryUserHostTag_Kick_Tag] FOREIGN KEY([TagID])
REFERENCES [dbo].[Kick_Tag] ([TagID])
GO
ALTER TABLE [dbo].[Kick_StoryUserHostTag] CHECK CONSTRAINT [FK_Kick_StoryUserHostTag_Kick_Tag]
GO
/****** Object:  ForeignKey [FK_Kick_StoryUserHostTag_Kick_User]    Script Date: 09/26/2007 11:18:06 ******/
ALTER TABLE [dbo].[Kick_StoryUserHostTag]  WITH NOCHECK ADD  CONSTRAINT [FK_Kick_StoryUserHostTag_Kick_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Kick_User] ([UserID])
GO
ALTER TABLE [dbo].[Kick_StoryUserHostTag] CHECK CONSTRAINT [FK_Kick_StoryUserHostTag_Kick_User]
GO
/****** Object:  ForeignKey [FK_Kick_UserAction_Kick_Chat]    Script Date: 09/26/2007 11:18:16 ******/
ALTER TABLE [dbo].[Kick_UserAction]  WITH CHECK ADD  CONSTRAINT [FK_Kick_UserAction_Kick_Chat] FOREIGN KEY([ChatID])
REFERENCES [dbo].[Kick_Chat] ([ChatID])
GO
ALTER TABLE [dbo].[Kick_UserAction] CHECK CONSTRAINT [FK_Kick_UserAction_Kick_Chat]
GO
/****** Object:  ForeignKey [FK_Kick_UserAction_Kick_Story]    Script Date: 09/26/2007 11:18:16 ******/
ALTER TABLE [dbo].[Kick_UserAction]  WITH CHECK ADD  CONSTRAINT [FK_Kick_UserAction_Kick_Story] FOREIGN KEY([StoryID])
REFERENCES [dbo].[Kick_Story] ([StoryID])
GO
ALTER TABLE [dbo].[Kick_UserAction] CHECK CONSTRAINT [FK_Kick_UserAction_Kick_Story]
GO
/****** Object:  ForeignKey [FK_Kick_UserAction_Kick_ToUser]    Script Date: 09/26/2007 11:18:16 ******/
ALTER TABLE [dbo].[Kick_UserAction]  WITH CHECK ADD  CONSTRAINT [FK_Kick_UserAction_Kick_ToUser] FOREIGN KEY([ToUserID])
REFERENCES [dbo].[Kick_User] ([UserID])
GO
ALTER TABLE [dbo].[Kick_UserAction] CHECK CONSTRAINT [FK_Kick_UserAction_Kick_ToUser]
GO
/****** Object:  ForeignKey [FK_Kick_UserAction_Kick_User]    Script Date: 09/26/2007 11:18:16 ******/
ALTER TABLE [dbo].[Kick_UserAction]  WITH CHECK ADD  CONSTRAINT [FK_Kick_UserAction_Kick_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Kick_User] ([UserID])
GO
ALTER TABLE [dbo].[Kick_UserAction] CHECK CONSTRAINT [FK_Kick_UserAction_Kick_User]
GO
/****** Object:  ForeignKey [FK_Kick_UserFriend_Kick_Friend]    Script Date: 09/26/2007 11:18:18 ******/
ALTER TABLE [dbo].[Kick_UserFriend]  WITH NOCHECK ADD  CONSTRAINT [FK_Kick_UserFriend_Kick_Friend] FOREIGN KEY([FriendID])
REFERENCES [dbo].[Kick_User] ([UserID])
GO
ALTER TABLE [dbo].[Kick_UserFriend] CHECK CONSTRAINT [FK_Kick_UserFriend_Kick_Friend]
GO
/****** Object:  ForeignKey [FK_Kick_UserFriend_Kick_User]    Script Date: 09/26/2007 11:18:18 ******/
ALTER TABLE [dbo].[Kick_UserFriend]  WITH NOCHECK ADD  CONSTRAINT [FK_Kick_UserFriend_Kick_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Kick_User] ([UserID])
GO
ALTER TABLE [dbo].[Kick_UserFriend] CHECK CONSTRAINT [FK_Kick_UserFriend_Kick_User]
GO
