CREATE PROCEDURE [dbo].[UpdateError]
(
	@ErrorID int,
	@Date smalldatetime,
	@StackTrace text = NULL,
	@Browser nvarchar(1024) = NULL,
	@Name nvarchar(4000) = NULL,
	@Description nvarchar(4000) = NULL,
	@Session text = NULL,
	@OrderID int = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	UPDATE [Error]
	SET
		Date = @Date,
		StackTrace = @StackTrace,
		Browser = @Browser,
		Name = @Name,
		Description = @Description,
		Session = @Session,
		OrderID = @OrderID
	WHERE
		[ErrorID] = @ErrorID


	SET @Err = @@Error


	RETURN @Err
END