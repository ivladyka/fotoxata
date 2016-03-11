CREATE PROCEDURE [dbo].[usp_Order_LoadByOrderGuid]
(
	@OrderGuid uniqueidentifier
) 
AS
BEGIN
	
	SELECT
		[OrderID],
		[OrderStatusID],
		[DeliveryID],
		[ClientNote],
		[OfficeNote],
		[Amount],
		[CellPhone],
		[UserID],
		[DateCreated],
		[PhotoCount],
		[OrderGuid]
	FROM [Order]
	WHERE
		[OrderGuid] = @OrderGuid

END