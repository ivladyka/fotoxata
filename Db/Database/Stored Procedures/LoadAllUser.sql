
CREATE PROCEDURE dbo.LoadAllUser
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[UserID],
		[CellPhone],
		[FirstName],
		[LastName],
		[Password],
		[EMailAddress],
		[PhotoSalonID],
		[Active]
	FROM [User]

	SET @Err = @@Error

	RETURN @Err
END