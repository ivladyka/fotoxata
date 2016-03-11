
CREATE PROCEDURE dbo.DeleteDelivery
(
	@DeliveryID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE
	FROM [Delivery]
	WHERE
		[DeliveryID] = @DeliveryID
	SET @Err = @@Error

	RETURN @Err
END