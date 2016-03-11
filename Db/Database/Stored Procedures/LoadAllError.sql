CREATE PROCEDURE [dbo].[LoadAllError]
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

	SET @Err = @@Error

	RETURN @Err
END