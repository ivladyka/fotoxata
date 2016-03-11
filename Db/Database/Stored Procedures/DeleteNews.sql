
CREATE PROCEDURE dbo.DeleteNews
(
	@NewsID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE
	FROM [News]
	WHERE
		[NewsID] = @NewsID
	SET @Err = @@Error

	RETURN @Err
END