
CREATE PROCEDURE dbo.usp_Gallery_Move
(
	@CategoryID int,
	@SourceGalleryID int,
	@DestGalleryID int = NULL
)
AS
BEGIN

	IF @DestGalleryID IS NOT NULL
	 BEGIN
		DECLARE @DestOrder tinyint
		SELECT
			@DestOrder = OrderIndex
		FROM
			Gallery
		WHERE
			CategoryID = @CategoryID
			AND
			GalleryID = @DestGalleryID
			
		UPDATE
			Gallery
		SET 
			OrderIndex = OrderIndex + 1
		WHERE
			CategoryID = @CategoryID
			AND
			OrderIndex > @DestOrder
		
		UPDATE
			Gallery
		SET 
			OrderIndex = @DestOrder + 1
		WHERE
			CategoryID = @CategoryID
			AND
			GalleryID = @SourceGalleryID
	 END
	ELSE
	 BEGIN
		UPDATE
			Gallery
		SET 
			OrderIndex = 1
		WHERE
			CategoryID = @CategoryID
			AND
			GalleryID = @SourceGalleryID
	 END
	
	UPDATE 
		tdit
	SET tdit.OrderIndex = tdit.rNum
	FROM
	(SELECT row_number() over (order by [OrderIndex]) AS rNum,*
	FROM
		Gallery 
	WHERE
		CategoryID = @CategoryID
	) tdit
	
END