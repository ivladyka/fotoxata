
CREATE PROCEDURE dbo.usp_User_LoadWithPhotoSalonAddress
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT     
		[User].UserID, 
		[User].CellPhone, 
		[User].FirstName, 
		[User].LastName, 
		[User].EMailAddress, 
		dbo.[udf_UserUserType_GetUserTypeList]([User].UserID) AS UserTypeList,
		PhotoSalon.Address AS PhotoSalonAddress,
		[User].Active  
	FROM         
		[User] 
	LEFT OUTER JOIN
        PhotoSalon ON [User].PhotoSalonID = PhotoSalon.PhotoSalonID
    ORDER BY
		[User].Active DESC,
		[User].LastName,
		[User].FirstName,
		[User].CellPhone

	SET @Err = @@Error

	RETURN @Err
END