
CREATE PROCEDURE dbo.usp_User_LoadPhotographer
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT     
		[User].UserID,
		[User].CellPhone,
		[User].FirstName,
		[User].LastName
	FROM     
		[User]    
	INNER JOIN
        UserUserType ON [User].UserID = UserUserType.UserID 
	WHERE     
		[User].Active = 1
		AND 
		UserUserType.UserTypeID = 2

	SET @Err = @@Error

	RETURN @Err
END