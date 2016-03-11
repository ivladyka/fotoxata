
CREATE PROCEDURE dbo.UpdateOrderStatus
(
	@OrderStatusID int,
	@Name varchar(50),
	@Active bit,
	@Name_ru varchar(50) = NULL,
	@Name_en varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	UPDATE [OrderStatus]
	SET
		[Name] = @Name,
		[Active] = @Active,
		[Name_ru] = @Name_ru,
		[Name_en] = @Name_en
	WHERE
		[OrderStatusID] = @OrderStatusID


	SET @Err = @@Error


	RETURN @Err
END