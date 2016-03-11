
CREATE PROCEDURE dbo.LoadAllPaperType
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[PaperTypeID],
		[Name],
		[Name_ru],
		[Name_en]
	FROM [PaperType]

	SET @Err = @@Error

	RETURN @Err
END