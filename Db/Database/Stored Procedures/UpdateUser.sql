
CREATE PROCEDURE dbo.UpdateUser
(
	@UserID int,
	@CellPhone varchar(50),
	@FirstName varchar(50) = NULL,
	@LastName varchar(50) = NULL,
	@Password varchar(50),
	@EMailAddress varchar(50) = NULL,
	@PhotoSalonID int = NULL,
	@Active bit = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	UPDATE [User]
	SET
		[CellPhone] = @CellPhone,
		[FirstName] = @FirstName,
		[LastName] = @LastName,
		[Password] = @Password,
		[EMailAddress] = @EMailAddress,
		[PhotoSalonID] = @PhotoSalonID,
		[Active] = @Active
	WHERE
		[UserID] = @UserID


	SET @Err = @@Error


	RETURN @Err
END