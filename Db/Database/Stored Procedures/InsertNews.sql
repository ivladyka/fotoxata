
CREATE PROCEDURE dbo.InsertNews
(
	@NewsID int = NULL output,
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

	INSERT
	INTO [News]
	(
		[Title],
		[NewsContent],
		[DateNews],
		[DateExpired],
		[Title_ru],
		[Title_en],
		[NewsContent_ru],
		[NewsContent_en]
	)
	VALUES
	(
		@Title,
		@NewsContent,
		@DateNews,
		@DateExpired,
		@Title_ru,
		@Title_en,
		@NewsContent_ru,
		@NewsContent_en
	)

	SET @Err = @@Error

	SELECT @NewsID = SCOPE_IDENTITY()

	RETURN @Err
END