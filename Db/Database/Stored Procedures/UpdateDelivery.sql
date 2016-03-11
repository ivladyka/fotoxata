
CREATE PROCEDURE dbo.UpdateDelivery
(
	@DeliveryID int,
	@Name nvarchar(50),
	@Active bit,
	@Name1 nvarchar(50) = NULL,
	@Name_ru nvarchar(50) = NULL,
	@Name_en nvarchar(50) = NULL,
	@Name1_ru nvarchar(50) = NULL,
	@Name1_en nvarchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	UPDATE [Delivery]
	SET
		[Name] = @Name,
		[Active] = @Active,
		[Name1] = @Name1,
		[Name_ru] = @Name_ru,
		[Name_en] = @Name_en,
		[Name1_ru] = @Name1_ru,
		[Name1_en] = @Name1_en
	WHERE
		[DeliveryID] = @DeliveryID


	SET @Err = @@Error


	RETURN @Err
END