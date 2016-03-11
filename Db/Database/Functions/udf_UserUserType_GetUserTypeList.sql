

CREATE function dbo.udf_UserUserType_GetUserTypeList(
	@UserID int
) 
RETURNS 
	varchar(200)
begin
	DECLARE @SummaryList varchar(200),
			@UserTypeName varchar(50)

	SET @SummaryList = ''

	DECLARE UserUserType_crsr CURSOR
   	FOR
   	SELECT     
   		UserType.Name
	FROM         
		UserUserType 
	INNER JOIN
        UserType ON UserUserType.UserTypeID = UserType.UserTypeID
	WHERE     
		UserUserType.UserID = @UserID 

	OPEN UserUserType_crsr

	FETCH NEXT FROM UserUserType_crsr INTO @UserTypeName
	   WHILE @@Fetch_Status = 0
	     BEGIN

		SET @SummaryList = @SummaryList + @UserTypeName + ', '

		FETCH NEXT FROM UserUserType_crsr INTO @UserTypeName
	     END

	CLOSE UserUserType_crsr
	DEALLOCATE UserUserType_crsr

	IF LEN(@SummaryList) > 0
	 BEGIN
		SET @SummaryList = SUBSTRING(@SummaryList,0,LEN(@SummaryList))
	 END

	RETURN @SummaryList
end