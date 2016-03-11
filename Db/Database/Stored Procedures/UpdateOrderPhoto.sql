
CREATE PROCEDURE [dbo].[UpdateOrderPhoto]
(
	@OrderPhotoID int,
	@ClientPhotoName varchar(50),
	@Count int,
	@Border bit,
	@PaperTypeID int,
	@MerchandiseID int,
	@OrderID int,
	@PhotoName varchar(50)
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	UPDATE [OrderPhoto]
	SET
		[ClientPhotoName] = @ClientPhotoName,
		[Count] = @Count,
		[Border] = @Border,
		[PaperTypeID] = @PaperTypeID,
		[MerchandiseID] = @MerchandiseID,
		[OrderID] = @OrderID,
		[PhotoName] = @PhotoName
	WHERE
		[OrderPhotoID] = @OrderPhotoID

	SET @Err = @@Error

	RETURN @Err
END