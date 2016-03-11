
CREATE PROCEDURE dbo.LoadCategoryByPrimaryKey
(
	@CategoryID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[CategoryID],
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
	FROM [Category]
	WHERE
		([CategoryID] = @CategoryID)

	SET @Err = @@Error

	RETURN @Err
END