USE [DotNetKicks]
GO

ALTER TABLE [dbo].[Kick_Comment] ADD [IsSpam] [bit] NOT NULL DEFAULT 0
ALTER TABLE [dbo].[Kick_Shout] ADD [IsSpam] [bit] NOT NULL DEFAULT 0

GO