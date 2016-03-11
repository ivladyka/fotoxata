
CREATE PROCEDURE dbo.LoadAdviceByPrimaryKey
(
	@AdviceID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[AdviceID],
		[Question],
		[Answer],
		[Question_ru],
		[Question_en],
		[Answer_ru],
		[Answer_en]
	FROM [Advice]
	WHERE
		([AdviceID] = @AdviceID)

	SET @Err = @@Error

	RETURN @Err
END