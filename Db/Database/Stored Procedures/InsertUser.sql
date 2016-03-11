
CREATE PROCEDURE dbo.InsertUser
(
	@UserID int = NULL output,
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

	INSERT
	INTO [User]
	(
		[CellPhone],
		[FirstName],
		[LastName],
		[Password],
		[EMailAddress],
		[PhotoSalonID],
		[Active]
	)
	VALUES
	(
		@CellPhone,
		@FirstName,
		@LastName,
		@Password,
		@EMailAddress,
		@PhotoSalonID,
		@Active
	)

	SET @Err = @@Error

	SELECT @UserID = SCOPE_IDENTITY()

	RETURN @Err
END