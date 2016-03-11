﻿
CREATE PROCEDURE dbo.LoadPhotoSalonByPrimaryKey
(
	@PhotoSalonID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[PhotoSalonID],
		[Address],
		[Active],
		[Phone1],
		[Phone2],
		[Phone3],
		[Description],
		[ButtonImage],
		[ButtonImageHover],
		[Address_ru],
		[Address_en],
		[Description_ru],
		[Description_en]
	FROM [PhotoSalon]
	WHERE
		([PhotoSalonID] = @PhotoSalonID)

	SET @Err = @@Error

	RETURN @Err
END