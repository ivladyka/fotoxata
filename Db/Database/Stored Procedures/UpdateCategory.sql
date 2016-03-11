
CREATE PROCEDURE dbo.UpdateCategory
(
	@CategoryID int,
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

	UPDATE [Category]
	SET
		[Name] = @Name,
		[IsGallery] = @IsGallery,
		[PriceFrom] = @PriceFrom,
		[PriceTo] = @PriceTo,
		[DisplayOnPrice] = @DisplayOnPrice,
		[Title] = @Title,
		[CategoryContent] = @CategoryContent,
		[Name_ru] = @Name_ru,
		[Title_ru] = @Title_ru,
		[CategoryContent_ru] = @CategoryContent_ru,
		[Name_en] = @Name_en,
		[Title_en] = @Title_en,
		[CategoryContent_en] = @CategoryContent_en
	WHERE
		[CategoryID] = @CategoryID


	SET @Err = @@Error


	RETURN @Err
END