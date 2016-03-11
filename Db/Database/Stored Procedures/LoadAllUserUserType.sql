
CREATE PROCEDURE dbo.LoadAllUserUserType
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[UserID],
		[UserTypeID]
	FROM [UserUserType]

	SET @Err = @@Error

	RETURN @Err
END