
CREATE PROCEDURE dbo.LoadPaperTypeByPrimaryKey
(
	@PaperTypeID int
)
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
	WHERE
		([PaperTypeID] = @PaperTypeID)

	SET @Err = @@Error

	RETURN @Err
END