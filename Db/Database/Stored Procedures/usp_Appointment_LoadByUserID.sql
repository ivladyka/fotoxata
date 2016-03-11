
CREATE PROCEDURE dbo.usp_Appointment_LoadByUserID
(
	@UserID int,
	@DateStart datetime,
	@DateEnd datetime
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT 
		[Appointment].[AppointmentID]
		,[Appointment].[UserID]
		,[Appointment].[StartTime]
		,[Appointment].[EndTime]
		,[Appointment].[Subject]
		,[Appointment].[AssignedBy]
		,[Appointment].[AssignedDate]
		,[Appointment].[PhotoSalonID]
		,[Appointment].[MoneyAdvance]
		,[Appointment].[PhoneNumber]
		,PhotoSalon.Address AS PhotoSalonAddress
		,CASE 
		   WHEN
			[User].FirstName IS NULL AND [User].LastName IS NULL THEN [User].CellPhone
		   ELSE
			LTRIM(RTRIM(ISNULL([User].FirstName, '') + ' ' + ISNULL([User].LastName, ''))) END + ' ' 
		+ CONVERT(varchar(30), AssignedDate, 104) + ' ' + CONVERT(varchar(30), AssignedDate, 114) AS AssignedUserName
	FROM 
		[Appointment]
	INNER JOIN
        PhotoSalon ON Appointment.PhotoSalonID = PhotoSalon.PhotoSalonID
    INNER JOIN
        [User] ON AssignedBy = [User].UserID
	WHERE
		[Appointment].[UserID] = @UserID
		AND
		[Appointment].[StartTime] Between @DateStart AND @DateEnd

	SET @Err = @@Error

	RETURN @Err
END