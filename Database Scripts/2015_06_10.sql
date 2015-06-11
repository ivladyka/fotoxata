
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	
	EXEC dbo.usp_Order_CalculateAmount @OrderID

	SET @Err = @@Error

	RETURN @Err
		
END
GO


