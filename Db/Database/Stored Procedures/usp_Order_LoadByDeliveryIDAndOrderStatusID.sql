
CREATE PROCEDURE dbo.usp_Order_LoadByDeliveryIDAndOrderStatusID(
	@DeliveryID int,
	@OrderStatusID int
) 
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT     
		[Order].OrderID, 
		CASE WHEN [Order].UserID IS NULL THEN [Order].CellPhone
			ELSE [User].CellPhone END AS CellPhone,
		ISNULL([User].FirstName, '') + ' ' + ISNULL([User].LastName, '') AS UserName,
		[Order].ClientNote, 
		[Order].OfficeNote, 
		[Order].PhotoCount, 
		[Order].Amount, 
		[Order].DateCreated,
		'' AS FTP
	FROM         
		[Order] 
	LEFT OUTER JOIN
        [User] ON [Order].UserID = [User].UserID
	WHERE     
		[Order].OrderStatusID = @OrderStatusID 
		AND 
		[Order].DeliveryID = @DeliveryID


	SET @Err = @@Error

	RETURN @Err
END