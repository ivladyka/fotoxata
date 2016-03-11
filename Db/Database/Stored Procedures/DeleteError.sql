CREATE PROCEDURE [dbo].[DeleteError]
(
	@ErrorID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE
	FROM [Error]
	WHERE
		[ErrorID] = @ErrorID
	SET @Err = @@Error

	RETURN @Err
END