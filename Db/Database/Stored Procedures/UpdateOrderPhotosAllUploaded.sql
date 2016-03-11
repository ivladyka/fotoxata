CREATE PROCEDURE [dbo].[UpdateOrderPhotosAllUploaded]
(
	@OrderID int,
	@Count int,
	@Border bit,
	@PaperTypeID int,
	@MerchandiseID int
)
AS
BEGIN
	
	SET NOCOUNT ON
	DECLARE @Err int

	UPDATE [OrderPhoto]
	SET
		[Count] = @Count,
		[Border] = @Border,
		[PaperTypeID] = @PaperTypeID,
		[MerchandiseID] = @MerchandiseID
	WHERE
		[OrderID] = @OrderID
		AND
		[Count] = 0

	SET @Err = @@Error

	RETURN @Err
		
END