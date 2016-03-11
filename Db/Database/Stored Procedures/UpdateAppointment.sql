
CREATE PROCEDURE dbo.UpdateAppointment
(
	@AppointmentID int,
	@UserID int,
	@StartTime datetime,
	@EndTime datetime,
	@Subject varchar(255),
	@AssignedBy int,
	@AssignedDate datetime,
	@PhotoSalonID int,
	@MoneyAdvance money = NULL,
	@PhoneNumber varchar(20) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	UPDATE [Appointment]
	SET
		[UserID] = @UserID,
		[StartTime] = @StartTime,
		[EndTime] = @EndTime,
		[Subject] = @Subject,
		[AssignedBy] = @AssignedBy,
		[AssignedDate] = @AssignedDate,
		[PhotoSalonID] = @PhotoSalonID,
		[MoneyAdvance] = @MoneyAdvance,
		[PhoneNumber] = @PhoneNumber
	WHERE
		[AppointmentID] = @AppointmentID


	SET @Err = @@Error


	RETURN @Err
END