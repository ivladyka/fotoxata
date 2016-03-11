
CREATE PROCEDURE [dbo].[InsertOrder]
(
	@OrderID int = NULL output,
	@OrderStatusID int = NULL,
	@DeliveryID int,
	@ClientNote varchar(2000) = NULL,
	@OfficeNote varchar(2000) = NULL,
	@Amount money = NULL,
	@CellPhone varchar(50) = NULL,
	@UserID int = NULL,
	@DateCreated datetime = NULL,
	@PhotoCount int = NULL,
	@OrderGuid uniqueidentifier
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	INSERT
	INTO [Order]
	(
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
	)
	VALUES
	(
		@OrderStatusID,
		@DeliveryID,
		@ClientNote,
		@OfficeNote,
		@Amount,
		@CellPhone,
		@UserID,
		@DateCreated,
		@PhotoCount,
		@OrderGuid
	)

	SET @Err = @@Error

	SELECT @OrderID = SCOPE_IDENTITY()

	RETURN @Err
END