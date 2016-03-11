
CREATE PROCEDURE dbo.LoadOrderPhotoByPrimaryKey
(
	@OrderPhotoID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[OrderPhotoID],
		[ClientPhotoName],
		[Count],
		[Border],
		[PaperTypeID],
		[MerchandiseID],
		[OrderID],
		[PhotoName]
	FROM [OrderPhoto]
	WHERE
		([OrderPhotoID] = @OrderPhotoID)

	SET @Err = @@Error

	RETURN @Err
END