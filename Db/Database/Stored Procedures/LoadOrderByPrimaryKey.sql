
CREATE PROCEDURE [dbo].[LoadOrderByPrimaryKey]
(
	@OrderID int
)
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
	WHERE
		([OrderID] = @OrderID)

	SET @Err = @@Error

	RETURN @Err
END