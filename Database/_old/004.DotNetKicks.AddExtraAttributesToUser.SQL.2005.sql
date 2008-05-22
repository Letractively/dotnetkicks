USE [DotNetKicks]
GO

ALTER TABLE Kick_User ADD Location nvarchar(255)
ALTER TABLE Kick_User ADD UseGravatar bit NOT NULL DEFAULT 0
ALTER TABLE Kick_User ADD GravatarCustomEmail nvarchar(255) 
ALTER TABLE Kick_User ADD WebsiteURL nvarchar(1000)
ALTER TABLE Kick_User ADD BlogURL nvarchar(1000)
ALTER TABLE Kick_User ADD BlogFeedURL nvarchar(1000)

GO