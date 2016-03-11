
CREATE PROCEDURE dbo.LoadUserUserTypeByPrimaryKey
(
	@UserID int,
	@UserTypeID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[UserID],
		[UserTypeID]
	FROM [UserUserType]
	WHERE
		([UserID] = @UserID) AND
		([UserTypeID] = @UserTypeID)

	SET @Err = @@Error

	RETURN @Err
END