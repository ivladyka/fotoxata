SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_Order_CalculateAmount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_Order_CalculateAmount]
GO

CREATE PROCEDURE [dbo].[usp_Order_CalculateAmount]
(
	@OrderID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	DECLARE @Amount money
	SET @Amount = 0
	
	SELECT
		@Amount = SUM(OrderPhoto.Count * ISNULL(Merchandise.PriceFrom, 0))
	FROM
		OrderPhoto
	INNER JOIN
		Merchandise ON OrderPhoto.MerchandiseID = Merchandise.MerchandiseID
		
	WHERE
		OrderID = @OrderID
	
	UPDATE
		[Order]
	SET
		Amount = @Amount
	WHERE
		OrderID = @OrderID

	SET @Err = @@Error

	RETURN @Err
END
GO
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



USE [Fotoxata]
GO
/****** Object:  StoredProcedure [dbo].[InsertOrderPhoto]    Script Date: 08/25/2010 20:10:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[InsertOrderPhoto]
(
	@OrderPhotoID int = NULL output,
	@ClientPhotoName varchar(50),
	@Count int,
	@Border bit,
	@PaperTypeID int,
	@MerchandiseID int,
	@OrderID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	INSERT
	INTO [OrderPhoto]
	(
		[ClientPhotoName],
		[Count],
		[Border],
		[PaperTypeID],
		[MerchandiseID],
		[OrderID]
	)
	VALUES
	(
		@ClientPhotoName,
		@Count,
		@Border,
		@PaperTypeID,
		@MerchandiseID,
		@OrderID
	)

	EXEC dbo.usp_Order_CalculateAmount @OrderID
	
	SET @Err = @@Error

	SELECT @OrderPhotoID = SCOPE_IDENTITY()

	RETURN @Err
END




USE [Fotoxata]
GO
/****** Object:  StoredProcedure [dbo].[UpdateOrderPhoto]    Script Date: 08/25/2010 20:12:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[UpdateOrderPhoto]
(
	@OrderPhotoID int,
	@ClientPhotoName varchar(50),
	@Count int,
	@Border bit,
	@PaperTypeID int,
	@MerchandiseID int,
	@OrderID int
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
		[OrderID] = @OrderID
	WHERE
		[OrderPhotoID] = @OrderPhotoID

	EXEC dbo.usp_Order_CalculateAmount @OrderID

	SET @Err = @@Error


	RETURN @Err
END





USE [Fotoxata]
GO
/****** Object:  StoredProcedure [dbo].[DeleteOrderPhoto]    Script Date: 08/25/2010 20:13:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[DeleteOrderPhoto]
(
	@OrderPhotoID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int
	
	DECLARE @OrderID int
	
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
		
	EXEC dbo.usp_Order_CalculateAmount @OrderID
	
	SET @Err = @@Error

	RETURN @Err
END


