
CREATE PROCEDURE dbo.LoadAllOrderStatus
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

	SET @Err = @@Error

	RETURN @Err
END