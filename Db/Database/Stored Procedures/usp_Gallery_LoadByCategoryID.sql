
CREATE PROCEDURE dbo.usp_Gallery_LoadByCategoryID
(
	@CategoryID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT [GalleryID]
      ,[CategoryID]
      ,[PhotoName]
	FROM 
		[Gallery]
	WHERE
		[CategoryID] = @CategoryID
	ORDER BY
		OrderIndex

	SET @Err = @@Error

	RETURN @Err
END