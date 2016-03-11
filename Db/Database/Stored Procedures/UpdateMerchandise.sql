
CREATE PROCEDURE dbo.UpdateMerchandise
(
	@MerchandiseID int,
	@Name varchar(50),
	@PhotoName varchar(50) = NULL,
	@CategoryID int,
	@PriceFrom money = NULL,
	@PriceTo money = NULL,
	@DisplayOnPrice bit,
	@Description varchar(4000) = NULL,
	@Name_ru varchar(50) = NULL,
	@Name_en varchar(50) = NULL,
	@Description_ru varchar(4000) = NULL,
	@Description_en varchar(4000) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	UPDATE [Merchandise]
	SET
		[Name] = @Name,
		[PhotoName] = @PhotoName,
		[CategoryID] = @CategoryID,
		[PriceFrom] = @PriceFrom,
		[PriceTo] = @PriceTo,
		[DisplayOnPrice] = @DisplayOnPrice,
		[Description] = @Description,
		[Name_ru] = @Name_ru,
		[Name_en] = @Name_en,
		[Description_ru] = @Description_ru,
		[Description_en] = @Description_en
	WHERE
		[MerchandiseID] = @MerchandiseID


	SET @Err = @@Error


	RETURN @Err
END