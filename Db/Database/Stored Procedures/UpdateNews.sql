
CREATE PROCEDURE dbo.UpdateNews
(
	@NewsID int,
	@Title varchar(50) = NULL,
	@NewsContent varchar(MAX),
	@DateNews datetime,
	@DateExpired datetime = NULL,
	@Title_ru varchar(50) = NULL,
	@Title_en varchar(50) = NULL,
	@NewsContent_ru varchar(MAX) = NULL,
	@NewsContent_en varchar(MAX) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	UPDATE [News]
	SET
		[Title] = @Title,
		[NewsContent] = @NewsContent,
		[DateNews] = @DateNews,
		[DateExpired] = @DateExpired,
		[Title_ru] = @Title_ru,
		[Title_en] = @Title_en,
		[NewsContent_ru] = @NewsContent_ru,
		[NewsContent_en] = @NewsContent_en
	WHERE
		[NewsID] = @NewsID


	SET @Err = @@Error


	RETURN @Err
END