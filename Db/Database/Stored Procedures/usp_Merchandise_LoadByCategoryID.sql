
CREATE PROCEDURE dbo.usp_Merchandise_LoadByCategoryID
(
	@CategoryID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT [MerchandiseID]
      ,[Name]
      ,[Name_ru]
      ,[Name_en]
      ,[PhotoName]
      ,[CategoryID]
      ,[PriceFrom]
      ,[PriceTo]
      ,[DisplayOnPrice]
      ,[Description]
      ,[Description_ru]
      ,[Description_en]
	FROM 
		[Merchandise]
	WHERE
		[CategoryID] = @CategoryID

	SET @Err = @@Error

	RETURN @Err
END