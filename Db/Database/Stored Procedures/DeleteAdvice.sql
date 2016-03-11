
CREATE PROCEDURE dbo.DeleteAdvice
(
	@AdviceID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE
	FROM [Advice]
	WHERE
		[AdviceID] = @AdviceID
	SET @Err = @@Error

	RETURN @Err
END