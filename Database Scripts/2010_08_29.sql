/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.OrderPhoto ADD
	PhotoName varchar(50) NOT NULL CONSTRAINT DF_OrderPhoto_PhotoName DEFAULT 'a'
GO
ALTER TABLE dbo.OrderPhoto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[LoadOrderPhotoByPrimaryKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[LoadOrderPhotoByPrimaryKey]
GO

CREATE PROCEDURE [dbo].[LoadOrderPhotoByPrimaryKey]
(
	@OrderPhotoID int
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
		([OrderPhotoID] = @OrderPhotoID)

	SET @Err = @@Error

	RETURN @Err
END
GO
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[LoadAllOrderPhoto]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[LoadAllOrderPhoto]
GO

CREATE PROCEDURE [dbo].[LoadAllOrderPhoto]
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

	SET @Err = @@Error

	RETURN @Err
END
GO
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateOrderPhoto]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateOrderPhoto]
GO

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
GO
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertOrderPhoto]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertOrderPhoto]
GO

CREATE PROCEDURE [dbo].[InsertOrderPhoto]
(
	@OrderPhotoID int = NULL output,
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

	INSERT
	INTO [OrderPhoto]
	(
		[ClientPhotoName],
		[Count],
		[Border],
		[PaperTypeID],
		[MerchandiseID],
		[OrderID],
		[PhotoName]
	)
	VALUES
	(
		@ClientPhotoName,
		@Count,
		@Border,
		@PaperTypeID,
		@MerchandiseID,
		@OrderID,
		@PhotoName
	)

	SET @Err = @@Error

	SELECT @OrderPhotoID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteOrderPhoto]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteOrderPhoto]
GO

CREATE PROCEDURE [dbo].[DeleteOrderPhoto]
(
	@OrderPhotoID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE
	FROM [OrderPhoto]
	WHERE
		[OrderPhotoID] = @OrderPhotoID
	SET @Err = @@Error

	RETURN @Err
END
GO
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO








