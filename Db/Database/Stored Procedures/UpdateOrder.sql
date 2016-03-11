
CREATE PROCEDURE [dbo].[UpdateOrder]
(
	@OrderID int,
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

	UPDATE [Order]
	SET
		[OrderStatusID] = @OrderStatusID,
		[DeliveryID] = @DeliveryID,
		[ClientNote] = @ClientNote,
		[OfficeNote] = @OfficeNote,
		[Amount] = @Amount,
		[CellPhone] = @CellPhone,
		[UserID] = @UserID,
		[DateCreated] = @DateCreated,
		[PhotoCount] = @PhotoCount,
		[OrderGuid] = @OrderGuid
	WHERE
		[OrderID] = @OrderID


	SET @Err = @@Error


	RETURN @Err
END