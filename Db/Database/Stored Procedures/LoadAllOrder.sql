
CREATE PROCEDURE [dbo].[LoadAllOrder]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

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

	SET @Err = @@Error

	RETURN @Err
END