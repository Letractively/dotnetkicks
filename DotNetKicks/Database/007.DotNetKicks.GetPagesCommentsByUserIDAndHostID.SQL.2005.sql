USE [DotNetKicks]
GO
/****** Object:  StoredProcedure [dbo].[Kick_GetPagedCommentsByUserIDAndHostID]    Script Date: 09/08/2007 15:35:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Kick_GetPagedCommentsByUserIDAndHostID]
	@UserID int,
	@HostID int,
	@PageNumber int,
	@PageSize int
AS
BEGIN

DECLARE @StartRow int, @EndRow int
SET @StartRow = (((@PageNumber - 1) * @PageSize) + 1);
SET @EndRow = (@StartRow + @PageSize - 1);


WITH UserComments 
	AS (SELECT ROW_NUMBER() OVER (ORDER BY Kick_Comment.CreatedOn DESC) AS 
		Row, dbo.Kick_Comment.*
	FROM         
		dbo.Kick_Comment 
	WHERE dbo.Kick_Comment.UserID=@UserID AND dbo.Kick_Comment.HostID=@HostID)

SELECT * FROM UserComments
WHERE ROW between @StartRow AND @EndRow



END
