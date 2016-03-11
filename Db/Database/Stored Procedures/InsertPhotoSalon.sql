
CREATE PROCEDURE dbo.InsertPhotoSalon
(
	@PhotoSalonID int = NULL output,
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

	INSERT
	INTO [PhotoSalon]
	(
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
	)
	VALUES
	(
		@Address,
		@Active,
		@Phone1,
		@Phone2,
		@Phone3,
		@Description,
		@ButtonImage,
		@ButtonImageHover,
		@Address_ru,
		@Address_en,
		@Description_ru,
		@Description_en
	)

	SET @Err = @@Error

	SELECT @PhotoSalonID = SCOPE_IDENTITY()

	RETURN @Err
END