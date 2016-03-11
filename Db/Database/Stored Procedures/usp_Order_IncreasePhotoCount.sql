CREATE PROCEDURE [dbo].[usp_Order_IncreasePhotoCount]
(
	@OrderID int
)
AS
BEGIN
	
	UPDATE
		[Order]
	SET
		PhotoCount = ISNULL(PhotoCount, 0) + 1
	WHERE
		OrderID = @OrderID

END