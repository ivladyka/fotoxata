
CREATE PROCEDURE dbo.InsertAdvice
(
	@AdviceID int = NULL output,
	@Question varchar(250),
	@Answer varchar(MAX),
	@Question_ru varchar(250) = NULL,
	@Question_en varchar(250) = NULL,
	@Answer_ru varchar(MAX) = NULL,
	@Answer_en varchar(MAX) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	INSERT
	INTO [Advice]
	(
		[Question],
		[Answer],
		[Question_ru],
		[Question_en],
		[Answer_ru],
		[Answer_en]
	)
	VALUES
	(
		@Question,
		@Answer,
		@Question_ru,
		@Question_en,
		@Answer_ru,
		@Answer_en
	)

	SET @Err = @@Error

	SELECT @AdviceID = SCOPE_IDENTITY()

	RETURN @Err
END