
CREATE PROCEDURE dbo.usp_UserUserType_IsUserType
(
	@UserID int,
	@UserTypeID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT     
		UserUserType.UserTypeID
	FROM         
		UserUserType 
	WHERE     
		UserUserType.UserID = @UserID 
		AND 
		UserUserType.UserTypeID = @UserTypeID

	SET @Err = @@Error

	RETURN @Err
END