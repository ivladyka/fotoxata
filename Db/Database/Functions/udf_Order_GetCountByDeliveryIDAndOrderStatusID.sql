

CREATE function dbo.udf_Order_GetCountByDeliveryIDAndOrderStatusID(
	@DeliveryID int,
	@OrderStatusID int
) 
RETURNS 
	int
begin
	DECLARE @CountOrder INT
	SET @CountOrder = 0

	SELECT     
		@CountOrder = COUNT([OrderID])   
	FROM 
		[Order]
	WHERE
		[DeliveryID] = @DeliveryID
		AND
		[OrderStatusID] = @OrderStatusID

	RETURN @CountOrder
end