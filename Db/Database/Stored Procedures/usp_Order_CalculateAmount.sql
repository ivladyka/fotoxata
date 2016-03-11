
CREATE PROCEDURE dbo.usp_Order_CalculateAmount
(
	@OrderID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	DECLARE @Amount money,
		@PhotoCount int
	SET @Amount = 0
	SET @PhotoCount = 0
	
	SELECT
		@Amount = SUM(OrderPhoto.Count * ISNULL(Merchandise.PriceFrom, 0)),
		@PhotoCount = SUM(OrderPhoto.Count)
	FROM
		OrderPhoto
	INNER JOIN
		Merchandise ON OrderPhoto.MerchandiseID = Merchandise.MerchandiseID
	WHERE
		OrderID = @OrderID
	
	UPDATE
		[Order]
	SET
		Amount = @Amount,
		PhotoCount = @PhotoCount
	WHERE
		OrderID = @OrderID

	SET @Err = @@Error

	RETURN @Err
END