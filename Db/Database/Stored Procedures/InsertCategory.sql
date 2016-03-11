
CREATE PROCEDURE dbo.InsertCategory
(
	@CategoryID int = NULL output,
	@Name varchar(255),
	@IsGallery bit,
	@PriceFrom money = NULL,
	@PriceTo money = NULL,
	@DisplayOnPrice bit,
	@Title varchar(255) = NULL,
	@CategoryContent varchar(MAX) = NULL,
	@Name_ru varchar(255) = NULL,
	@Title_ru varchar(255) = NULL,
	@CategoryContent_ru varchar(MAX) = NULL,
	@Name_en varchar(255) = NULL,
	@Title_en varchar(255) = NULL,
	@CategoryContent_en varchar(MAX) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	INSERT
	INTO [Category]
	(
		[Name],
		[IsGallery],
		[PriceFrom],
		[PriceTo],
		[DisplayOnPrice],
		[Title],
		[CategoryContent],
		[Name_ru],
		[Title_ru],
		[CategoryContent_ru],
		[Name_en],
		[Title_en],
		[CategoryContent_en]
	)
	VALUES
	(
		@Name,
		@IsGallery,
		@PriceFrom,
		@PriceTo,
		@DisplayOnPrice,
		@Title,
		@CategoryContent,
		@Name_ru,
		@Title_ru,
		@CategoryContent_ru,
		@Name_en,
		@Title_en,
		@CategoryContent_en
	)

	SET @Err = @@Error

	SELECT @CategoryID = SCOPE_IDENTITY()

	RETURN @Err
END