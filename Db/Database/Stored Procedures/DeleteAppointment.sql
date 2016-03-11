
CREATE PROCEDURE dbo.DeleteAppointment
(
	@AppointmentID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE
	FROM [Appointment]
	WHERE
		[AppointmentID] = @AppointmentID
	SET @Err = @@Error

	RETURN @Err
END