
CREATE PROCEDURE dbo.UpdatePhotoSalon
(
	@PhotoSalonID int,
	@Address varchar(50),
	@Active bit,
	@Phone1 varchar(20) = NULL,
	@Phone2 varchar(20) = NULL,
	@Phone3 varchar(20) = NULL,
	@Description varchar(MAX) = NULL,
	@ButtonImage varchar(50) = NULL,
	@ButtonImageHover varchar(50) = NULL,
	@Address_ru varchar(50) = NULL,
	@Address_en varchar(50) = NULL,
	@Description_ru varchar(MAX) = NULL,
	@Description_en varchar(MAX) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	UPDATE [PhotoSalon]
	SET
		[Address] = @Address,
		[Active] = @Active,
		[Phone1] = @Phone1,
		[Phone2] = @Phone2,
		[Phone3] = @Phone3,
		[Description] = @Description,
		[ButtonImage] = @ButtonImage,
		[ButtonImageHover] = @ButtonImageHover,
		[Address_ru] = @Address_ru,
		[Address_en] = @Address_en,
		[Description_ru] = @Description_ru,
		[Description_en] = @Description_en
	WHERE
		[PhotoSalonID] = @PhotoSalonID


	SET @Err = @@Error


	RETURN @Err
END