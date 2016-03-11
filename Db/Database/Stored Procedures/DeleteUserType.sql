
CREATE PROCEDURE dbo.DeleteUserType
(
	@UserTypeID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE
	FROM [UserType]
	WHERE
		[UserTypeID] = @UserTypeID
	SET @Err = @@Error

	RETURN @Err
END