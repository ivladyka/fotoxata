
CREATE PROCEDURE [dbo].[DeleteOrderPhotoByPhotoName]
(
	@PhotoName varchar(50),
	@OrderID int
)
AS
BEGIN
	
	SET NOCOUNT ON
	DECLARE @Err int
		
	DELETE
	FROM [OrderPhoto]
	WHERE
		OrderID = @OrderID
		AND
		PhotoName = @PhotoName

	SET @Err = @@Error

	RETURN @Err

END