
CREATE PROCEDURE dbo.InsertUserUserType
(
	@UserID int,
	@UserTypeID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	INSERT
	INTO [UserUserType]
	(
		[UserID],
		[UserTypeID]
	)
	VALUES
	(
		@UserID,
		@UserTypeID
	)

	SET @Err = @@Error


	RETURN @Err
END