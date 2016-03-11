
CREATE PROCEDURE dbo.DeleteUserUserType
(
	@UserID int,
	@UserTypeID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE
	FROM [UserUserType]
	WHERE
		[UserID] = @UserID AND
		[UserTypeID] = @UserTypeID
	SET @Err = @@Error

	RETURN @Err
END