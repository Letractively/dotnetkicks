use [DotNetKicks]
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kick_AlertMessage](
	[alertID] [int] IDENTITY(1,1) NOT NULL,
	[alertTypeId] [int] not null,
	[singleAlertText] [nvarchar](512) not null,
	[multipleAlertText] [nvarchar](512) not null,
	[alertOrder] [int] not null
 CONSTRAINT [PK_Kick_AlertMessage] PRIMARY KEY CLUSTERED 
(
	[alertId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
go


insert into Kick_AlertMessage
	(alertTypeId, singleAlertText, multipleAlertText, alertOrder)
	values (1, 
			'You have a new friend request', 
			'You have [count] new friend requests', 
			200)
go

insert into Kick_AlertMessage
	(alertTypeId, singleAlertText, multipleAlertText, alertOrder)
	values (2, 
			'You have a new shout on your profile', 
			'You have [count] new shouts on your profile', 
			300)
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kick_UserAlertMessage](
	[userAlertID] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] not null,
	[alertId] [int] not null,
	[alertCount] [int] not null
 CONSTRAINT [PK_Kick_UserAlertMessage] PRIMARY KEY CLUSTERED 
(
	[userAlertID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
go

ALTER TABLE [dbo].[Kick_UserAlertMessage]  WITH NOCHECK ADD  CONSTRAINT [FK_Kick_UserAlertMessage_Kick_User] FOREIGN KEY([userID])
REFERENCES [dbo].[Kick_User] ([UserID])
GO
ALTER TABLE [dbo].[Kick_UserAlertMessage] CHECK CONSTRAINT [FK_Kick_UserAlertMessage_Kick_User]
GO

ALTER TABLE [dbo].[Kick_UserAlertMessage]  WITH NOCHECK ADD  CONSTRAINT [FK_Kick_UserAlertMessage_Kick_AlertMessage] FOREIGN KEY([alertID])
REFERENCES [dbo].[Kick_AlertMessage] ([alertID])
GO
ALTER TABLE [dbo].[Kick_UserAlertMessage] CHECK CONSTRAINT [FK_Kick_UserAlertMessage_Kick_AlertMessage]
GO

create view [dbo].[Kick_UserAlertMessageView] as
select userAlertId, userId, a.alertId, alertCount, alertTypeId,
		singleAlertText, multipleAlertText, alertOrder from Kick_AlertMessage a
		inner join Kick_UserAlertMessage um on a.alertId=um.alertId

go

create procedure [dbo].[Kick_AddAlertMessageForUser]
(
@userId int,
@alertMessageId int
)
as

set nocount on

declare @alertId int

select @alertId=alertId from Kick_AlertMessage
	where alertTypeId=@alertMessageId

if exists(select null from Kick_UserAlertMessage where userId=@userId and alertId=@alertId)
  begin
	update Kick_UserAlertMessage set alertCount = alertCount + 1
		where userId=@userId and alertId=@alertId
  end
else
  begin
	insert into Kick_UserAlertMessage (userId, alertId, alertCount)
		values(@userId, @alertId, 1)
  end


return
go

