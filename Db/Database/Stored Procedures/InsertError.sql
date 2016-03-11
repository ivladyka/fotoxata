CREATE PROCEDURE [dbo].[InsertError]
(
	@ErrorID int = NULL output,
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

	INSERT INTO [dbo].[Error]
           ([Date]
           ,[StackTrace]
           ,[Browser]
           ,[Name]
           ,[Description]
           ,[Session]
		   ,[OrderID])
	VALUES
	(
		@Date,
		@StackTrace,
		@Browser,
		@Name,
		@Description,
		@Session,
		@OrderID
	)

	SET @Err = @@Error

	SELECT @ErrorID = SCOPE_IDENTITY()

	RETURN @Err
END