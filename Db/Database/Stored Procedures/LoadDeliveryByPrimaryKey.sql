
CREATE PROCEDURE dbo.LoadDeliveryByPrimaryKey
(
	@DeliveryID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[DeliveryID],
		[Name],
		[Active],
		[Name1],
		[Name_ru],
		[Name_en],
		[Name1_ru],
		[Name1_en]
	FROM [Delivery]
	WHERE
		([DeliveryID] = @DeliveryID)

	SET @Err = @@Error

	RETURN @Err
END