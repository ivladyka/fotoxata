
CREATE PROCEDURE dbo.usp_Category_TitleLoad
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[CategoryID],
		ISNULL([Title],[Name]) AS Title,
		ISNULL([Title_ru],[Name_ru]) AS Title_ru,
		ISNULL([Title_en],[Name_en]) AS Title_en
	FROM [Category]
	

	SET @Err = @@Error

	RETURN @Err
END