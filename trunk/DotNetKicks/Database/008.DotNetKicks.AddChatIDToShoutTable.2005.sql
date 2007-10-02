USE [DotNetKicks]
GO

ALTER TABLE Kick_Shout ADD ChatID int NULL

GO

GO
ALTER TABLE [dbo].[Kick_Shout]  WITH CHECK ADD  CONSTRAINT [FK_Kick_Shout_Kick_Chat] FOREIGN KEY([ChatID])
REFERENCES [dbo].[Kick_Chat] ([ChatID])
GO