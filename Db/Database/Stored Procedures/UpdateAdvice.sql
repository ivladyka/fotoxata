
CREATE PROCEDURE dbo.UpdateAdvice
(
	@AdviceID int,
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

	UPDATE [Advice]
	SET
		[Question] = @Question,
		[Answer] = @Answer,
		[Question_ru] = @Question_ru,
		[Question_en] = @Question_en,
		[Answer_ru] = @Answer_ru,
		[Answer_en] = @Answer_en
	WHERE
		[AdviceID] = @AdviceID


	SET @Err = @@Error


	RETURN @Err
END