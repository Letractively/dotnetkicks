USE [DotNetKicks]
GO
/****** Object:  Table [dbo].[Kick_Shout]    Script Date: 09/14/2007 21:54:45 ******/
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
 CONSTRAINT [PK_Kick_Shout] PRIMARY KEY CLUSTERED 
(
	[ShoutID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Kick_Shout_Kick_Host]    Script Date: 09/14/2007 21:54:45 ******/
ALTER TABLE [dbo].[Kick_Shout]  WITH CHECK ADD  CONSTRAINT [FK_Kick_Shout_Kick_Host] FOREIGN KEY([HostID])
REFERENCES [dbo].[Kick_Host] ([HostID])
GO
ALTER TABLE [dbo].[Kick_Shout] CHECK CONSTRAINT [FK_Kick_Shout_Kick_Host]
GO
/****** Object:  ForeignKey [FK_Kick_Shout_Kick_User]    Script Date: 09/14/2007 21:54:45 ******/
ALTER TABLE [dbo].[Kick_Shout]  WITH CHECK ADD  CONSTRAINT [FK_Kick_Shout_Kick_User] FOREIGN KEY([FromUserID])
REFERENCES [dbo].[Kick_User] ([UserID])
GO
ALTER TABLE [dbo].[Kick_Shout] CHECK CONSTRAINT [FK_Kick_Shout_Kick_User]
GO
/****** Object:  ForeignKey [FK_Kick_Shout_Kick_User1]    Script Date: 09/14/2007 21:54:46 ******/
ALTER TABLE [dbo].[Kick_Shout]  WITH CHECK ADD  CONSTRAINT [FK_Kick_Shout_Kick_User1] FOREIGN KEY([ToUserID])
REFERENCES [dbo].[Kick_User] ([UserID])
GO
ALTER TABLE [dbo].[Kick_Shout] CHECK CONSTRAINT [FK_Kick_Shout_Kick_User1]
GO
