
CREATE PROCEDURE [dbo].[DeletePhotoSalon]
(
	@PhotoSalonID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE 
		[Appointment]
	WHERE
		PhotoSalonID = @PhotoSalonID
		
	DELETE
	FROM [PhotoSalon]
	WHERE
		[PhotoSalonID] = @PhotoSalonID
	SET @Err = @@Error

	RETURN @Err
END