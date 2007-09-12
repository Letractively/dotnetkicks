/****** Object:  Table [dbo].[Kick_User]    Script Date: 07/08/2007 18:00:42 ******/
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
 CONSTRAINT [PK_Kick_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kick_Host]    Script Date: 07/08/2007 18:00:26 ******/
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
	[SmtpHost] [nvarchar](255) NULL,
	[SmtpPort] [int] NULL,
	[SmtpUsername] [nvarchar](50) NULL,
	[SmtpPassword] [nvarchar](50) NULL,
	[SmtpEnableSsl] [bit] NULL,
	[FeedBurnerMainRssFeedUrl] [nvarchar](255) NULL,
	[FeedBurnerMainRssFeedCountHtml] [nvarchar](500) NULL,
 CONSTRAINT [PK_Kick_Host] PRIMARY KEY CLUSTERED 
(
	[HostID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kick_Tag]    Script Date: 07/08/2007 18:00:37 ******/
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
/****** Object:  Table [dbo].[Kick_Story]    Script Date: 07/08/2007 18:00:31 ******/
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
	[Username] [nvarchar](50) NOT NULL,
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
/****** Object:  Table [dbo].[Kick_Comment]    Script Date: 07/08/2007 18:00:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kick_Comment](
	[CommentID] [int] IDENTITY(1,1) NOT NULL,
	[StoryID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Comment] [nvarchar](4000) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kick_StoryUserHostTag]    Script Date: 07/08/2007 18:00:36 ******/
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
/****** Object:  Table [dbo].[Kick_StoryKick]    Script Date: 07/08/2007 18:00:33 ******/
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
/****** Object:  Table [dbo].[Kick_Category]    Script Date: 07/08/2007 18:00:13 ******/
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
 CONSTRAINT [PK_Kick_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Kick_Setting]    Script Date: 07/12/2007 11:49:16 ******/
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
/****** Object:  StoredProcedure [dbo].[Kick_GetTagsByUserIDAndHostID]    Script Date: 07/08/2007 18:00:11 ******/
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
/****** Object:  StoredProcedure [dbo].[Kick_GetTagsByHostIDAndCreatedOnRange]    Script Date: 07/08/2007 18:00:10 ******/
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
/****** Object:  StoredProcedure [dbo].[Kick_GetTagsByUserIDAndStoryID]    Script Date: 07/08/2007 18:00:11 ******/
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
/****** Object:  StoredProcedure [dbo].[Kick_GetTagsByUserID]    Script Date: 07/08/2007 18:00:11 ******/
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
/****** Object:  StoredProcedure [dbo].[Kick_GetTagsByStoryID]    Script Date: 07/08/2007 18:00:10 ******/
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
/****** Object:  StoredProcedure [dbo].[Kick_GetPagedStoriesByTagIDAndHostID]    Script Date: 07/08/2007 18:00:09 ******/
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
	WHERE dbo.Kick_StoryUserHostTag.TagID=@TagID AND dbo.Kick_StoryUserHostTag.HostID=@HostID)

SELECT * FROM TaggedStories
WHERE ROW between @StartRow AND @EndRow



END
GO
/****** Object:  StoredProcedure [dbo].[Kick_GetPagedStoriesByTagIDAndHostIDAndUserID]    Script Date: 07/08/2007 18:00:10 ******/
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
	WHERE dbo.Kick_StoryUserHostTag.TagID=@TagID AND dbo.Kick_StoryUserHostTag.HostID=@HostID AND dbo.Kick_StoryUserHostTag.UserID=@UserID)

SELECT * FROM TaggedStories
WHERE ROW between @StartRow AND @EndRow



END
GO
/****** Object:  StoredProcedure [dbo].[Kick_GetPagedKickedStoriesByUserIDAndHostID]    Script Date: 07/08/2007 18:00:09 ******/
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
	WHERE dbo.Kick_StoryKick.UserID=@UserID AND dbo.Kick_StoryKick.HostID=@HostID)

SELECT * FROM KickedStories
WHERE ROW between @StartRow AND @EndRow



END
GO

/****** Object:  StoredProcedure [dbo].[Kick_GetUsersWhoKicked]    Script Date: 08/30/2007 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.Kick_GetUsersWhoKicked 
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
	FROM Kick_User u (NOLOCK)
		INNER JOIN Kick_StoryKick sk (NOLOCK) ON u.userId = sk.userId
	WHERE sk.storyId = @storyId

END
GO

/****** Object:  ForeignKey [FK_Kick_Category_Kick_Host]    Script Date: 07/08/2007 18:00:13 ******/
ALTER TABLE [dbo].[Kick_Category]  WITH NOCHECK ADD  CONSTRAINT [FK_Kick_Category_Kick_Host] FOREIGN KEY([HostID])
REFERENCES [dbo].[Kick_Host] ([HostID])
GO
ALTER TABLE [dbo].[Kick_Category] CHECK CONSTRAINT [FK_Kick_Category_Kick_Host]
GO
/****** Object:  ForeignKey [FK_Kick_Comment_Kick_Story]    Script Date: 07/08/2007 18:00:15 ******/
ALTER TABLE [dbo].[Kick_Comment]  WITH NOCHECK ADD  CONSTRAINT [FK_Kick_Comment_Kick_Story] FOREIGN KEY([StoryID])
REFERENCES [dbo].[Kick_Story] ([StoryID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Kick_Comment] CHECK CONSTRAINT [FK_Kick_Comment_Kick_Story]
GO
/****** Object:  ForeignKey [FK_Kick_Comment_Kick_User]    Script Date: 07/08/2007 18:00:16 ******/
ALTER TABLE [dbo].[Kick_Comment]  WITH NOCHECK ADD  CONSTRAINT [FK_Kick_Comment_Kick_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Kick_User] ([UserID])
GO
ALTER TABLE [dbo].[Kick_Comment] CHECK CONSTRAINT [FK_Kick_Comment_Kick_User]
GO
/****** Object:  ForeignKey [FK_Kick_Story_Kick_Category]    Script Date: 07/08/2007 18:00:31 ******/
ALTER TABLE [dbo].[Kick_Story]  WITH NOCHECK ADD  CONSTRAINT [FK_Kick_Story_Kick_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Kick_Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Kick_Story] CHECK CONSTRAINT [FK_Kick_Story_Kick_Category]
GO
/****** Object:  ForeignKey [FK_Kick_Story_Kick_Host]    Script Date: 07/08/2007 18:00:31 ******/
ALTER TABLE [dbo].[Kick_Story]  WITH NOCHECK ADD  CONSTRAINT [FK_Kick_Story_Kick_Host] FOREIGN KEY([HostID])
REFERENCES [dbo].[Kick_Host] ([HostID])
GO
ALTER TABLE [dbo].[Kick_Story] CHECK CONSTRAINT [FK_Kick_Story_Kick_Host]
GO
/****** Object:  ForeignKey [FK_Kick_Story_Kick_User]    Script Date: 07/08/2007 18:00:32 ******/
ALTER TABLE [dbo].[Kick_Story]  WITH NOCHECK ADD  CONSTRAINT [FK_Kick_Story_Kick_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Kick_User] ([UserID])
GO
ALTER TABLE [dbo].[Kick_Story] CHECK CONSTRAINT [FK_Kick_Story_Kick_User]
GO
/****** Object:  ForeignKey [FK_Kick_StoryKick_Kick_Story]    Script Date: 07/08/2007 18:00:34 ******/
ALTER TABLE [dbo].[Kick_StoryKick]  WITH NOCHECK ADD  CONSTRAINT [FK_Kick_StoryKick_Kick_Story] FOREIGN KEY([StoryID])
REFERENCES [dbo].[Kick_Story] ([StoryID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Kick_StoryKick] CHECK CONSTRAINT [FK_Kick_StoryKick_Kick_Story]
GO
/****** Object:  ForeignKey [FK_Kick_StoryKick_Kick_User]    Script Date: 07/08/2007 18:00:34 ******/
ALTER TABLE [dbo].[Kick_StoryKick]  WITH NOCHECK ADD  CONSTRAINT [FK_Kick_StoryKick_Kick_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Kick_User] ([UserID])
GO
ALTER TABLE [dbo].[Kick_StoryKick] CHECK CONSTRAINT [FK_Kick_StoryKick_Kick_User]
GO
/****** Object:  ForeignKey [FK_Kick_StoryUserHostTag_Kick_Host]    Script Date: 07/08/2007 18:00:36 ******/
ALTER TABLE [dbo].[Kick_StoryUserHostTag]  WITH CHECK ADD  CONSTRAINT [FK_Kick_StoryUserHostTag_Kick_Host] FOREIGN KEY([HostID])
REFERENCES [dbo].[Kick_Host] ([HostID])
GO
ALTER TABLE [dbo].[Kick_StoryUserHostTag] CHECK CONSTRAINT [FK_Kick_StoryUserHostTag_Kick_Host]
GO
/****** Object:  ForeignKey [FK_Kick_StoryUserHostTag_Kick_Story]    Script Date: 07/08/2007 18:00:36 ******/
ALTER TABLE [dbo].[Kick_StoryUserHostTag]  WITH CHECK ADD  CONSTRAINT [FK_Kick_StoryUserHostTag_Kick_Story] FOREIGN KEY([StoryID])
REFERENCES [dbo].[Kick_Story] ([StoryID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Kick_StoryUserHostTag] CHECK CONSTRAINT [FK_Kick_StoryUserHostTag_Kick_Story]
GO
/****** Object:  ForeignKey [FK_Kick_StoryUserHostTag_Kick_Tag]    Script Date: 07/08/2007 18:00:36 ******/
ALTER TABLE [dbo].[Kick_StoryUserHostTag]  WITH CHECK ADD  CONSTRAINT [FK_Kick_StoryUserHostTag_Kick_Tag] FOREIGN KEY([TagID])
REFERENCES [dbo].[Kick_Tag] ([TagID])
GO
ALTER TABLE [dbo].[Kick_StoryUserHostTag] CHECK CONSTRAINT [FK_Kick_StoryUserHostTag_Kick_Tag]
GO
/****** Object:  ForeignKey [FK_Kick_StoryUserHostTag_Kick_User]    Script Date: 07/08/2007 18:00:36 ******/
ALTER TABLE [dbo].[Kick_StoryUserHostTag]  WITH CHECK ADD  CONSTRAINT [FK_Kick_StoryUserHostTag_Kick_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Kick_User] ([UserID])
GO
ALTER TABLE [dbo].[Kick_StoryUserHostTag] CHECK CONSTRAINT [FK_Kick_StoryUserHostTag_Kick_User]
GO
