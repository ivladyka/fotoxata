
CREATE PROCEDURE dbo.InsertUserType
(
	@UserTypeID int,
	@Name varchar(50)
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	INSERT
	INTO [UserType]
	(
		[UserTypeID],
		[Name]
	)
	VALUES
	(
		@UserTypeID,
		@Name
	)

	SET @Err = @@Error


	RETURN @Err
END