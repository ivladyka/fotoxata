
CREATE PROCEDURE dbo.LoadGalleryByPrimaryKey
(
	@GalleryID int
)
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
	WHERE
		([GalleryID] = @GalleryID)

	SET @Err = @@Error

	RETURN @Err
END