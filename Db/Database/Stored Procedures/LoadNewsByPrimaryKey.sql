
CREATE PROCEDURE dbo.LoadNewsByPrimaryKey
(
	@NewsID int
)
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
	WHERE
		([NewsID] = @NewsID)

	SET @Err = @@Error

	RETURN @Err
END