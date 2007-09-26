USE [DotNetKicks]
GO

ALTER TABLE [dbo].[Kick_Host] DROP COLUMN [UseStaticRoot]
ALTER TABLE [dbo].[Kick_Host] ADD [UseStaticRoot] [bit] NOT NULL DEFAULT 0

GO