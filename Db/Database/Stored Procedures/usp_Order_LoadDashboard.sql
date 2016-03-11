
CREATE PROCEDURE dbo.usp_Order_LoadDashboard
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT 
		[DeliveryID]
		,[Name1],
		dbo.udf_Order_GetCountByDeliveryIDAndOrderStatusID(DeliveryID, 1) AS NewOrder,
		dbo.udf_Order_GetCountByDeliveryIDAndOrderStatusID(DeliveryID, 3) AS CompletedWorkOrder
	FROM 
		[Delivery]
	WHERE
		[Active] = 1


	SET @Err = @@Error

	RETURN @Err
END