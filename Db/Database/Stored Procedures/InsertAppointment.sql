
CREATE PROCEDURE dbo.InsertAppointment
(
	@AppointmentID int = NULL output,
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

	INSERT
	INTO [Appointment]
	(
		[UserID],
		[StartTime],
		[EndTime],
		[Subject],
		[AssignedBy],
		[AssignedDate],
		[PhotoSalonID],
		[MoneyAdvance],
		[PhoneNumber]
	)
	VALUES
	(
		@UserID,
		@StartTime,
		@EndTime,
		@Subject,
		@AssignedBy,
		@AssignedDate,
		@PhotoSalonID,
		@MoneyAdvance,
		@PhoneNumber
	)

	SET @Err = @@Error

	SELECT @AppointmentID = SCOPE_IDENTITY()

	RETURN @Err
END