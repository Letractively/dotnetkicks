USE [DotNetKicks]
GO
/****** Object:  Table [dbo].[Kick_Chat]    Script Date: 09/18/2007 00:31:46 ******/
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
ALTER TABLE [dbo].[Kick_Chat]  WITH CHECK ADD  CONSTRAINT [FK_Kick_Chat_Kick_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Kick_User] ([UserID])
GO
ALTER TABLE [dbo].[Kick_Chat] CHECK CONSTRAINT [FK_Kick_Chat_Kick_User]