
CREATE PROCEDURE dbo.LoadAllNews
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[NewsID],
		[Title],
		[NewsContent],
		[DateNews],
		[DateExpired],
		[Title_ru],
		[Title_en],
		[NewsContent_ru],
		[NewsContent_en]
	FROM [News]

	SET @Err = @@Error

	RETURN @Err
END