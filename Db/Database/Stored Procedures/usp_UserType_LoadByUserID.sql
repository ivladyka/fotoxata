
CREATE PROCEDURE dbo.usp_UserType_LoadByUserID
(
	@UserID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT     
		UserType.UserTypeID, 
		UserType.Name, 
		CASE 
		   WHEN
			UserUserType.UserTypeID IS NULL THEN 0
		   ELSE
			1 END AS IsChecked
	FROM         
		UserType 
	LEFT OUTER JOIN
        UserUserType ON UserType.UserTypeID = UserUserType.UserTypeID AND UserUserType.UserID = @UserID

	SET @Err = @@Error

	RETURN @Err
END