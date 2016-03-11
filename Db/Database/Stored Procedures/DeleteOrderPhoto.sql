
CREATE PROCEDURE [dbo].[DeleteOrderPhoto]
(
	@OrderPhotoID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int,
		@OrderID int
		
	SELECT
		@OrderID = OrderID
	FROM
		[OrderPhoto]
	WHERE
		[OrderPhotoID] = @OrderPhotoID

	DELETE
	FROM [OrderPhoto]
	WHERE
		[OrderPhotoID] = @OrderPhotoID

	SET @Err = @@Error

	RETURN @Err
END