CREATE PROCEDURE [dbo].[LoadErrorByPrimaryKey]
(
	@ErrorID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ErrorID]
      ,[Date]
      ,[StackTrace]
      ,[Browser]
      ,[Name]
      ,[Description]
      ,[Session]
	  ,[OrderID]
	FROM [Error]
	WHERE
		([ErrorID] = @ErrorID)

	SET @Err = @@Error

	RETURN @Err
END