USE [DotNetKicks]
GO

ALTER TABLE dbo.Kick_Host ADD [AutoVetUsers] [bit] NOT NULL DEFAULT (0)
GO

ALTER TABLE dbo.Kick_User ADD [IsVetted] [bit] NOT NULL DEFAULT (1)
GO

