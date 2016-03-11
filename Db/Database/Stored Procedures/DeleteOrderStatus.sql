
CREATE PROCEDURE dbo.DeleteOrderStatus
(
	@OrderStatusID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE
	FROM [OrderStatus]
	WHERE
		[OrderStatusID] = @OrderStatusID
	SET @Err = @@Error

	RETURN @Err
END