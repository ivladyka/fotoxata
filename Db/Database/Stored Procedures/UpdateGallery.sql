
CREATE PROCEDURE dbo.UpdateGallery
(
	@GalleryID int,
	@CategoryID int,
	@PhotoName varchar(50),
	@OrderIndex int = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	UPDATE [Gallery]
	SET
		[CategoryID] = @CategoryID,
		[PhotoName] = @PhotoName,
		[OrderIndex] = @OrderIndex
	WHERE
		[GalleryID] = @GalleryID


	SET @Err = @@Error


	RETURN @Err
END