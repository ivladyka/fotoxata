
CREATE PROCEDURE dbo.LoadAppointmentByPrimaryKey
(
	@AppointmentID int
)
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
	WHERE
		([AppointmentID] = @AppointmentID)

	SET @Err = @@Error

	RETURN @Err
END