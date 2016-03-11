
CREATE PROCEDURE dbo.DeleteUser
(
	@UserID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int
	
	BEGIN TRANSACTION DeleteUserFullInfo
	
	DELETE
	FROM
		UserUserType
	WHERE
		UserID = @UserID

	DELETE
	FROM [User]
	WHERE
		[UserID] = @UserID
	
	COMMIT TRANSACTION DeleteUserFullInfo
	
	SET @Err = @@Error

	RETURN @Err
END