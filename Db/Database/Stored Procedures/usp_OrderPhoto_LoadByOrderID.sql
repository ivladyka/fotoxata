
CREATE PROCEDURE [dbo].[usp_OrderPhoto_LoadByOrderID]
(
	@OrderID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT     
		OrderPhoto.OrderPhotoID, 
		OrderPhoto.ClientPhotoName, 
		OrderPhoto.Count AS PhotoCount, 
		OrderPhoto.Border, 
		OrderPhoto.PaperTypeID, 
		OrderPhoto.MerchandiseID, 
        OrderPhoto.PhotoName, 
        PaperType.Name AS PaperTypeName, 
        Merchandise.Name AS MerchandiseName,
		(OrderPhoto.Count * ISNULL(Merchandise.PriceFrom, 0)) AS PhotoAmount
	FROM         
		OrderPhoto 
	INNER JOIN
        PaperType ON OrderPhoto.PaperTypeID = PaperType.PaperTypeID 
	INNER JOIN
        Merchandise ON OrderPhoto.MerchandiseID = Merchandise.MerchandiseID
	WHERE     
		OrderPhoto.OrderID = @OrderID

	SET @Err = @@Error


	RETURN @Err
END