USE [DotNetKicks]
GO

ALTER TABLE [dbo].[Kick_Host] DROP COLUMN [SmtpHost]
ALTER TABLE [dbo].[Kick_Host] ADD [SmtpHost] nvarchar(255) NOT NULL DEFAULT ''


ALTER TABLE [dbo].[Kick_Host] DROP COLUMN [SmtpPort]
ALTER TABLE [dbo].[Kick_Host] ADD [SmtpPort] [int] NOT NULL DEFAULT 25


ALTER TABLE [dbo].[Kick_Host] DROP COLUMN [SmtpUsername]
ALTER TABLE [dbo].[Kick_Host] ADD [SmtpUsername] nvarchar(50) NOT NULL DEFAULT ''


ALTER TABLE [dbo].[Kick_Host] DROP COLUMN [SmtpPassword]
ALTER TABLE [dbo].[Kick_Host] ADD [SmtpPassword] nvarchar(50) NOT NULL DEFAULT ''


ALTER TABLE [dbo].[Kick_Host] DROP COLUMN [SmtpEnableSsl]
ALTER TABLE [dbo].[Kick_Host] ADD [SmtpEnableSsl] [bit] NOT NULL DEFAULT 1

GO