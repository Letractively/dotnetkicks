/*
** DotNetKicks Database Reset
** Running this script will return the database to a clean state
*/

SET NOCOUNT ON
SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ARITHABORT ON
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
SET NUMERIC_ROUNDABORT OFF
GO

-- [*Begin transaction]
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
BEGIN TRANSACTION
GO

-- Nuke all current data and reset
DELETE FROM [dbo].[ELMAH_Error]
DELETE FROM [dbo].[Kick_BlockedReferral]
DELETE FROM [dbo].[Kick_Category]
DELETE FROM [dbo].[Kick_Chat]
DELETE FROM [dbo].[Kick_Comment]
DELETE FROM [dbo].[Kick_Host]
DELETE FROM [dbo].[Kick_ReservedUsername]
DELETE FROM [dbo].[Kick_Setting]
DELETE FROM [dbo].[Kick_Shout]
DELETE FROM [dbo].[Kick_Story]
DELETE FROM [dbo].[Kick_StoryKick]
DELETE FROM [dbo].[Kick_StoryUserHostTag]
DELETE FROM [dbo].[Kick_Tag]
DELETE FROM [dbo].[Kick_User]
DELETE FROM [dbo].[Kick_UserAction]
DELETE FROM [dbo].[Kick_UserFriend]
GO

-- Resetting idents
DBCC CHECKIDENT ( '[dbo].[Kick_Category]', RESEED, 0)
DBCC CHECKIDENT ( '[dbo].[Kick_Comment]', RESEED, 0)
DBCC CHECKIDENT ( '[dbo].[Kick_Host]', RESEED, 0)
DBCC CHECKIDENT ( '[dbo].[Kick_Setting]', RESEED, 0)
DBCC CHECKIDENT ( '[dbo].[Kick_Shout]', RESEED, 0)
DBCC CHECKIDENT ( '[dbo].[Kick_Story]', RESEED, 0)
DBCC CHECKIDENT ( '[dbo].[Kick_StoryKick]', RESEED, 0)
DBCC CHECKIDENT ( '[dbo].[Kick_StoryUserHostTag]', RESEED, 0)
DBCC CHECKIDENT ( '[dbo].[Kick_Tag]', RESEED, 0)
DBCC CHECKIDENT ( '[dbo].[Kick_User]', RESEED, 0)
DBCC CHECKIDENT ( '[dbo].[Kick_UserFriend]', RESEED, 0)
GO

-- Inserting default settings
INSERT INTO [dbo].[Kick_Setting] ([Name], [Value]) VALUES (N'Security.Cipher.PassPhrase', N'Lol Im the default passphrase')
INSERT INTO [dbo].[Kick_Setting] ([Name], [Value]) VALUES (N'Security.Cipher.Salt', N'Arr matey salt I be, yarrr')
INSERT INTO [dbo].[Kick_Setting] ([Name], [Value]) VALUES (N'Security.Cipher.InitVector', N'This is 16 chars') -- MUST be 16 chars 
INSERT INTO [dbo].[Kick_Setting] ([Name], [Value]) VALUES (N'Search.Lucene.LastCrawl', N'633312012776190000')
INSERT INTO [dbo].[Kick_Setting] ([Name], [Value]) VALUES (N'Search.Lucene.StoriesPageSize', N'100')
INSERT INTO [dbo].[Kick_Setting] ([Name], [Value]) VALUES (N'Search.Lucene.BaseDirectory', N'~/App_Data/StoryIndex')
INSERT INTO [dbo].[Kick_Setting] ([Name], [Value]) VALUES (N'Search.Lucene.ReindexInterval', N'10')	
GO

-- Inserting default users
INSERT INTO [dbo].[Kick_User] ([Username], [Email], [Password], [PasswordSalt], [IsGeneratedPassword], [IsValidated], [IsBanned], [AdsenseID], [ReceiveEmailNewsletter], [Roles], [HostID], [LastActiveOn], [CreatedOn], [ModifiedOn], [Location], [UseGravatar], [GravatarCustomEmail], [WebsiteURL], [BlogURL], [BlogFeedURL]) VALUES (N'admin', N'admin@domain.com', N'aSIT7is4z4XpZGjGyXJlisxCY0s=', N'6sPIz+jZmyR0UTNVjaYNow==', 0, 1, 0, N'', 1, N'administrator|debugger|moderator', 1, '2007-09-16T15:58:02', '2007-09-12T17:07:15', '2007-09-16T15:58:02', NULL, 0, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[Kick_User] ([Username], [Email], [Password], [PasswordSalt], [IsGeneratedPassword], [IsValidated], [IsBanned], [AdsenseID], [ReceiveEmailNewsletter], [Roles], [HostID], [LastActiveOn], [CreatedOn], [ModifiedOn], [Location], [UseGravatar], [GravatarCustomEmail], [WebsiteURL], [BlogURL], [BlogFeedURL]) VALUES (N'moderator', N'moderator@domain.com', N'z6m9Bi2C6eorO+qrPQgEOav6mog=', N'1WRd65K1dNGAGmPPMwP1zA==', 0, 1, 0, N'', 1, N'moderator', 1, '2007-09-12T17:33:47', '2007-09-12T17:10:00', '2007-09-12T17:33:50', NULL, 0, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[Kick_User] ([Username], [Email], [Password], [PasswordSalt], [IsGeneratedPassword], [IsValidated], [IsBanned], [AdsenseID], [ReceiveEmailNewsletter], [Roles], [HostID], [LastActiveOn], [CreatedOn], [ModifiedOn], [Location], [UseGravatar], [GravatarCustomEmail], [WebsiteURL], [BlogURL], [BlogFeedURL]) VALUES (N'user1', N'user1@domain.com', N'QIN7nbb9kSXr7YJWiY47ggSOKCQ=', N'j4/+4Gp1cq4iLCp8qhhuCg==', 0, 1, 0, N'', 1, N'', 1, '2007-09-16T15:59:02', '2007-09-12T17:11:17', '2007-09-16T15:59:02', NULL, 1, N'user01.test@gavinjoyce.com', NULL, NULL, NULL)

IF @@TRANCOUNT>0 COMMIT TRANSACTION
