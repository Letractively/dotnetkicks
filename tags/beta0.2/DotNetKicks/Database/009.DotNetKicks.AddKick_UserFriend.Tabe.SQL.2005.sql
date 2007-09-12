USE [DotNetKicks]
GO
/****** Object:  Table [dbo].[Kick_UserFriend]    Script Date: 09/10/2007 21:39:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kick_UserFriend](
	[UserFriendID] [int] IDENTITY(1,1) NOT NULL,
	[HostID] [int] NOT NULL,
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
ALTER TABLE [dbo].[Kick_UserFriend]  WITH CHECK ADD  CONSTRAINT [FK_Kick_UserFriend_Kick_Friend] FOREIGN KEY([FriendID])
REFERENCES [dbo].[Kick_User] ([UserID])
GO
ALTER TABLE [dbo].[Kick_UserFriend] CHECK CONSTRAINT [FK_Kick_UserFriend_Kick_Friend]
GO
ALTER TABLE [dbo].[Kick_UserFriend]  WITH CHECK ADD  CONSTRAINT [FK_Kick_UserFriend_Kick_Host] FOREIGN KEY([HostID])
REFERENCES [dbo].[Kick_Host] ([HostID])
GO
ALTER TABLE [dbo].[Kick_UserFriend] CHECK CONSTRAINT [FK_Kick_UserFriend_Kick_Host]
GO
ALTER TABLE [dbo].[Kick_UserFriend]  WITH CHECK ADD  CONSTRAINT [FK_Kick_UserFriend_Kick_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Kick_User] ([UserID])
GO
ALTER TABLE [dbo].[Kick_UserFriend] CHECK CONSTRAINT [FK_Kick_UserFriend_Kick_User]