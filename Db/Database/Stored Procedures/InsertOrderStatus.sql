
CREATE PROCEDURE dbo.InsertOrderStatus
(
	@OrderStatusID int = NULL output,
	@Name varchar(50),
	@Active bit,
	@Name_ru varchar(50) = NULL,
	@Name_en varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	INSERT
	INTO [OrderStatus]
	(
		[Name],
		[Active],
		[Name_ru],
		[Name_en]
	)
	VALUES
	(
		@Name,
		@Active,
		@Name_ru,
		@Name_en
	)

	SET @Err = @@Error

	SELECT @OrderStatusID = SCOPE_IDENTITY()

	RETURN @Err
END