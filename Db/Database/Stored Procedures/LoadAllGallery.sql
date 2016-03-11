
CREATE PROCEDURE dbo.LoadAllGallery
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[GalleryID],
		[CategoryID],
		[PhotoName],
		[OrderIndex]
	FROM [Gallery]

	SET @Err = @@Error

	RETURN @Err
END