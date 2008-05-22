/****** Object:  Table [dbo].[Kick_BannedUrlPattern]    Script Date: 12/16/2007 02:38:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kick_BannedUrlPattern](
	[PatternId] [int] IDENTITY(1,1) NOT NULL,
	[HostId] [int] NULL,
	[Description] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_Kick_BannedUrlPattern_Description]  DEFAULT (N'(No description given)'),
	[BannedUrlRegex] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_Kick_BannedUrlPattern] PRIMARY KEY CLUSTERED 
(
	[PatternId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The primary key for this table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Kick_BannedUrlPattern', @level2type=N'COLUMN',@level2name=N'PatternId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A short description of the URL this pattern should match against' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Kick_BannedUrlPattern', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A regular expression that matches a banned url' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Kick_BannedUrlPattern', @level2type=N'COLUMN',@level2name=N'BannedUrlRegex'
GO
ALTER TABLE [dbo].[Kick_BannedUrlPattern]  WITH CHECK ADD  CONSTRAINT [FK_Kick_BannedUrlPattern_Kick_Host] FOREIGN KEY([HostId])
REFERENCES [dbo].[Kick_Host] ([HostID])
GO
ALTER TABLE [dbo].[Kick_BannedUrlPattern] CHECK CONSTRAINT [FK_Kick_BannedUrlPattern_Kick_Host]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The host this URL applies to' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Kick_BannedUrlPattern', @level2type=N'CONSTRAINT',@level2name=N'FK_Kick_BannedUrlPattern_Kick_Host'