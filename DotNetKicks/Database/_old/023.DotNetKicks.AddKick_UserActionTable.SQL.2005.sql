USE [DotNetKicks]
GO
/****** Object:  Table [dbo].[Kick_UserAction]    Script Date: 09/18/2007 00:32:45 ******/
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
ALTER TABLE [dbo].[Kick_UserAction]  WITH CHECK ADD  CONSTRAINT [FK_Kick_UserAction_Kick_Chat] FOREIGN KEY([ChatID])
REFERENCES [dbo].[Kick_Chat] ([ChatID])
GO
ALTER TABLE [dbo].[Kick_UserAction] CHECK CONSTRAINT [FK_Kick_UserAction_Kick_Chat]
GO
ALTER TABLE [dbo].[Kick_UserAction]  WITH CHECK ADD  CONSTRAINT [FK_Kick_UserAction_Kick_Story] FOREIGN KEY([StoryID])
REFERENCES [dbo].[Kick_Story] ([StoryID])
GO
ALTER TABLE [dbo].[Kick_UserAction] CHECK CONSTRAINT [FK_Kick_UserAction_Kick_Story]
GO
ALTER TABLE [dbo].[Kick_UserAction]  WITH CHECK ADD  CONSTRAINT [FK_Kick_UserAction_Kick_ToUser] FOREIGN KEY([ToUserID])
REFERENCES [dbo].[Kick_User] ([UserID])
GO
ALTER TABLE [dbo].[Kick_UserAction] CHECK CONSTRAINT [FK_Kick_UserAction_Kick_ToUser]
GO
ALTER TABLE [dbo].[Kick_UserAction]  WITH CHECK ADD  CONSTRAINT [FK_Kick_UserAction_Kick_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Kick_User] ([UserID])
GO
ALTER TABLE [dbo].[Kick_UserAction] CHECK CONSTRAINT [FK_Kick_UserAction_Kick_User]