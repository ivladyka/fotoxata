
CREATE PROCEDURE dbo.UpdateUserType
(
	@UserTypeID int,
	@Name varchar(50)
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	UPDATE [UserType]
	SET
		[Name] = @Name
	WHERE
		[UserTypeID] = @UserTypeID


	SET @Err = @@Error


	RETURN @Err
END