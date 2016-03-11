
CREATE PROCEDURE dbo.LoadUserByPrimaryKey
(
	@UserID int
)
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
	WHERE
		([UserID] = @UserID)

	SET @Err = @@Error

	RETURN @Err
END