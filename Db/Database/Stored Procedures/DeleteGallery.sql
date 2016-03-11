
CREATE PROCEDURE dbo.DeleteGallery
(
	@GalleryID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE
	FROM [Gallery]
	WHERE
		[GalleryID] = @GalleryID
	SET @Err = @@Error

	RETURN @Err
END