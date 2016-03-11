
CREATE PROCEDURE dbo.InsertGallery
(
	@GalleryID int = NULL output,
	@CategoryID int,
	@PhotoName varchar(50),
	@OrderIndex int = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	INSERT
	INTO [Gallery]
	(
		[CategoryID],
		[PhotoName],
		[OrderIndex]
	)
	VALUES
	(
		@CategoryID,
		@PhotoName,
		@OrderIndex
	)

	SET @Err = @@Error

	SELECT @GalleryID = SCOPE_IDENTITY()

	RETURN @Err
END