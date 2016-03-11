
CREATE PROCEDURE dbo.LoadAllAppointment
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[AppointmentID],
		[UserID],
		[StartTime],
		[EndTime],
		[Subject],
		[AssignedBy],
		[AssignedDate],
		[PhotoSalonID],
		[MoneyAdvance],
		[PhoneNumber]
	FROM [Appointment]

	SET @Err = @@Error

	RETURN @Err
END