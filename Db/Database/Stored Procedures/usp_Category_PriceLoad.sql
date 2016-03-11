
CREATE PROCEDURE [dbo].[usp_Category_PriceLoad]
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	DECLARE @Price TABLE (
	Name varchar(255),
	Name_ru varchar(255),
	Name_en varchar(255),
	PriceFrom money,
	PriceTo money,
	MerchandiseID int,
	CategoryID int)
	
	INSERT INTO @Price
	(
		Name,
		Name_ru,
		Name_en,
		PriceFrom,
		PriceTo,
		MerchandiseID,
		CategoryID
	)
	SELECT CASE WHEN [Title] IS NULL THEN [Name] ELSE [Title] END
      , CASE WHEN [Title_ru] IS NULL THEN [Name_ru] ELSE [Title_ru] END
      , CASE WHEN [Title_en] IS NULL THEN [Name_en] ELSE [Title_en] END
      ,[PriceFrom]
      ,[PriceTo]
      ,0
      ,[CategoryID]
	FROM 
		[Category]
	WHERE
		DisplayOnPrice = 1
		
	INSERT INTO @Price
	(
		Name,
		Name_ru,
		Name_en,
		PriceFrom,
		PriceTo,
		MerchandiseID,
		CategoryID
	)
	SELECT 
       m.[Name]
      ,m.Name_ru
	  ,m.Name_en
      ,m.[PriceFrom]
      ,m.[PriceTo]
      ,m.[MerchandiseID]
      ,m.[CategoryID]
	FROM 
		[Merchandise] m
	INNER JOIN
		Category c ON m.CategoryID = c.CategoryID 
	WHERE
		m.DisplayOnPrice = 1
		
	SELECT * FROM @Price ORDER BY CategoryID, MerchandiseID

	SET @Err = @@Error

	RETURN @Err
END