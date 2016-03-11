
CREATE PROCEDURE dbo.LoadMerchandiseByPrimaryKey
(
	@MerchandiseID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[MerchandiseID],
		[Name],
		[PhotoName],
		[CategoryID],
		[PriceFrom],
		[PriceTo],
		[DisplayOnPrice],
		[Description],
		[Name_ru],
		[Name_en],
		[Description_ru],
		[Description_en]
	FROM [Merchandise]
	WHERE
		([MerchandiseID] = @MerchandiseID)

	SET @Err = @@Error

	RETURN @Err
END