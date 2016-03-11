
CREATE PROCEDURE dbo.LoadOrderStatusByPrimaryKey
(
	@OrderStatusID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[OrderStatusID],
		[Name],
		[Active],
		[Name_ru],
		[Name_en]
	FROM [OrderStatus]
	WHERE
		([OrderStatusID] = @OrderStatusID)

	SET @Err = @@Error

	RETURN @Err
END