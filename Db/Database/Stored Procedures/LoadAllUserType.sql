
CREATE PROCEDURE dbo.LoadAllUserType
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[UserTypeID],
		[Name]
	FROM [UserType]

	SET @Err = @@Error

	RETURN @Err
END