
CREATE PROCEDURE dbo.LoadUserTypeByPrimaryKey
(
	@UserTypeID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[UserTypeID],
		[Name]
	FROM [UserType]
	WHERE
		([UserTypeID] = @UserTypeID)

	SET @Err = @@Error

	RETURN @Err
END