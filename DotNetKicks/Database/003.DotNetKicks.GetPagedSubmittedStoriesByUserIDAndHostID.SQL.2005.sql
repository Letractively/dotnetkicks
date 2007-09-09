USE [DotNetKicks]
GO
/****** Object:  StoredProcedure [dbo].[Kick_GetPagedSubmittedStoriesByUserIDAndHostID]    Script Date: 09/07/2007 17:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Kick_GetPagedSubmittedStoriesByUserIDAndHostID]
	@UserID int,
	@HostID int,
	@PageNumber int,
	@PageSize int
AS
BEGIN

DECLARE @StartRow int, @EndRow int
SET @StartRow = (((@PageNumber - 1) * @PageSize) + 1);
SET @EndRow = (@StartRow + @PageSize - 1);





WITH SubmittedStories 
	AS (SELECT ROW_NUMBER() OVER (ORDER BY Kick_Story.CreatedOn DESC) AS 
		Row, dbo.Kick_Story.*
	FROM         
		dbo.Kick_Story 
	WHERE dbo.Kick_Story.UserID=@UserID AND dbo.Kick_Story.HostID=@HostID)

SELECT * FROM SubmittedStories
WHERE ROW between @StartRow AND @EndRow



END
