
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
	
	EXEC dbo.usp_Order_CalculateAmount @OrderID

	SET @Err = @@Error

	RETURN @Err

END
GO





SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_OrderPhoto_LoadByClientPhotoName]
(
	@ClientPhotoName varchar(50),
	@OrderID int
)
AS
BEGIN
	
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[OrderPhotoID],
		[ClientPhotoName],
		[Count],
		[Border],
		[PaperTypeID],
		[MerchandiseID],
		[OrderID],
		[PhotoName]
	FROM [OrderPhoto]
	WHERE
		OrderID = @OrderID
		AND
		([ClientPhotoName] = @ClientPhotoName)
		AND
		[Count] = 0

	SET @Err = @@Error

	RETURN @Err

END
GO



