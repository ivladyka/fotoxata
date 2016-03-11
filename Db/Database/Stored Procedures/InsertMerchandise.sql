
CREATE PROCEDURE dbo.InsertMerchandise
(
	@MerchandiseID int = NULL output,
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

	INSERT
	INTO [Merchandise]
	(
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
	)
	VALUES
	(
		@Name,
		@PhotoName,
		@CategoryID,
		@PriceFrom,
		@PriceTo,
		@DisplayOnPrice,
		@Description,
		@Name_ru,
		@Name_en,
		@Description_ru,
		@Description_en
	)

	SET @Err = @@Error

	SELECT @MerchandiseID = SCOPE_IDENTITY()

	RETURN @Err
END