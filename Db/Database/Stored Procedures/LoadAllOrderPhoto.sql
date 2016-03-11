
CREATE PROCEDURE dbo.LoadAllOrderPhoto
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

	SET @Err = @@Error

	RETURN @Err
END