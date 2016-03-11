
CREATE PROCEDURE dbo.InsertDelivery
(
	@DeliveryID int = NULL output,
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

	INSERT
	INTO [Delivery]
	(
		[Name],
		[Active],
		[Name1],
		[Name_ru],
		[Name_en],
		[Name1_ru],
		[Name1_en]
	)
	VALUES
	(
		@Name,
		@Active,
		@Name1,
		@Name_ru,
		@Name_en,
		@Name1_ru,
		@Name1_en
	)

	SET @Err = @@Error

	SELECT @DeliveryID = SCOPE_IDENTITY()

	RETURN @Err
END