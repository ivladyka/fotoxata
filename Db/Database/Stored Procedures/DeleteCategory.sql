
CREATE PROCEDURE dbo.DeleteCategory
(
	@CategoryID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE
	FROM [Category]
	WHERE
		[CategoryID] = @CategoryID
	SET @Err = @@Error

	RETURN @Err
END













IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('usp_Category_TitleLoad') AND sysstat & 0xf = 4)
    DROP PROCEDURE [usp_Category_TitleLoad];