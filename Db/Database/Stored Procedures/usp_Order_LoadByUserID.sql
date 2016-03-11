
CREATE PROCEDURE dbo.usp_Order_LoadByUserID(
	@UserID int
) 
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT     
		[Order].OrderID, 
		[OrderStatus].Name AS OrderStatus,
		[OrderStatus].Name_ru AS OrderStatus_ru,
		[OrderStatus].Name_en AS OrderStatus_en,
		[Order].ClientNote, 
		[Order].OfficeNote, 
		[Order].PhotoCount, 
		[Order].Amount, 
		[Order].DateCreated
	FROM         
		[Order] 
		LEFT OUTER JOIN
        [User] ON [Order].UserID = [User].UserID
        LEFT OUTER JOIN
		OrderStatus ON [Order].OrderStatusID = [OrderStatus].OrderStatusID
	 WHERE     
		[Order].UserID = @UserID 
       

	SET @Err = @@Error

	RETURN @Err
END