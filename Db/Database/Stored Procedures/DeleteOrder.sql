
CREATE PROCEDURE dbo.DeleteOrder
(
	@OrderID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int
	
	BEGIN TRANSACTION DeleteOrderInfo

	DELETE
	FROM [OrderPhoto]
	WHERE
		[OrderID] = @OrderID
		
	DELETE
	FROM [Order]
	WHERE
		[OrderID] = @OrderID
		
	COMMIT TRANSACTION DeleteOrderInfo
	
	SET @Err = @@Error

	RETURN @Err
END