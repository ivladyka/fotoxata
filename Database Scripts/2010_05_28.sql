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
ALTER TABLE dbo.News ADD
	Title_ru varchar(50) NULL,
	Title_en varchar(50) NULL,
	NewsContent_ru varchar(MAX) NULL,
	NewsContent_en varchar(MAX) NULL
GO
ALTER TABLE dbo.News SET (LOCK_ESCALATION = TABLE)
GO
COMMIT




USE [Fotoxata]
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('LoadNewsByPrimaryKey') AND sysstat & 0xf = 4)
    DROP PROCEDURE [LoadNewsByPrimaryKey];
GO

CREATE PROCEDURE [LoadNewsByPrimaryKey]
(
	@NewsID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[NewsID],
		[Title],
		[NewsContent],
		[DateNews],
		[DateExpired],
		[Title_ru],
		[Title_en],
		[NewsContent_ru],
		[NewsContent_en]
	FROM [News]
	WHERE
		([NewsID] = @NewsID)

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: LoadNewsByPrimaryKey Succeeded'
ELSE PRINT 'Procedure Creation: LoadNewsByPrimaryKey Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('LoadAllNews') AND sysstat & 0xf = 4)
    DROP PROCEDURE [LoadAllNews];
GO

CREATE PROCEDURE [LoadAllNews]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[NewsID],
		[Title],
		[NewsContent],
		[DateNews],
		[DateExpired],
		[Title_ru],
		[Title_en],
		[NewsContent_ru],
		[NewsContent_en]
	FROM [News]

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: LoadAllNews Succeeded'
ELSE PRINT 'Procedure Creation: LoadAllNews Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('UpdateNews') AND sysstat & 0xf = 4)
    DROP PROCEDURE [UpdateNews];
GO

CREATE PROCEDURE [UpdateNews]
(
	@NewsID int,
	@Title varchar(50) = NULL,
	@NewsContent varchar(MAX),
	@DateNews datetime,
	@DateExpired datetime = NULL,
	@Title_ru varchar(50) = NULL,
	@Title_en varchar(50) = NULL,
	@NewsContent_ru varchar(MAX) = NULL,
	@NewsContent_en varchar(MAX) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	UPDATE [News]
	SET
		[Title] = @Title,
		[NewsContent] = @NewsContent,
		[DateNews] = @DateNews,
		[DateExpired] = @DateExpired,
		[Title_ru] = @Title_ru,
		[Title_en] = @Title_en,
		[NewsContent_ru] = @NewsContent_ru,
		[NewsContent_en] = @NewsContent_en
	WHERE
		[NewsID] = @NewsID


	SET @Err = @@Error


	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: UpdateNews Succeeded'
ELSE PRINT 'Procedure Creation: UpdateNews Error on Creation'
GO




IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('InsertNews') AND sysstat & 0xf = 4)
    DROP PROCEDURE [InsertNews];
GO

CREATE PROCEDURE [InsertNews]
(
	@NewsID int = NULL output,
	@Title varchar(50) = NULL,
	@NewsContent varchar(MAX),
	@DateNews datetime,
	@DateExpired datetime = NULL,
	@Title_ru varchar(50) = NULL,
	@Title_en varchar(50) = NULL,
	@NewsContent_ru varchar(MAX) = NULL,
	@NewsContent_en varchar(MAX) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	INSERT
	INTO [News]
	(
		[Title],
		[NewsContent],
		[DateNews],
		[DateExpired],
		[Title_ru],
		[Title_en],
		[NewsContent_ru],
		[NewsContent_en]
	)
	VALUES
	(
		@Title,
		@NewsContent,
		@DateNews,
		@DateExpired,
		@Title_ru,
		@Title_en,
		@NewsContent_ru,
		@NewsContent_en
	)

	SET @Err = @@Error

	SELECT @NewsID = SCOPE_IDENTITY()

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: InsertNews Succeeded'
ELSE PRINT 'Procedure Creation: InsertNews Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('DeleteNews') AND sysstat & 0xf = 4)
    DROP PROCEDURE [DeleteNews];
GO

CREATE PROCEDURE [DeleteNews]
(
	@NewsID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE
	FROM [News]
	WHERE
		[NewsID] = @NewsID
	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: DeleteNews Succeeded'
ELSE PRINT 'Procedure Creation: DeleteNews Error on Creation'
GO


UPDATE [dbo].[News]
   SET 
      [Title_ru] = [Title]
      ,[Title_en] = [Title]
      ,[NewsContent_ru] = [NewsContent]
      ,[NewsContent_en] = [NewsContent]
GO



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
ALTER TABLE dbo.Advice ADD
	Question_ru varchar(250) NULL,
	Question_en varchar(250) NULL,
	Answer_ru varchar(MAX) NULL,
	Answer_en varchar(MAX) NULL
GO
ALTER TABLE dbo.Advice SET (LOCK_ESCALATION = TABLE)
GO
COMMIT






USE [Fotoxata]
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('LoadAdviceByPrimaryKey') AND sysstat & 0xf = 4)
    DROP PROCEDURE [LoadAdviceByPrimaryKey];
GO

CREATE PROCEDURE [LoadAdviceByPrimaryKey]
(
	@AdviceID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[AdviceID],
		[Question],
		[Answer],
		[Question_ru],
		[Question_en],
		[Answer_ru],
		[Answer_en]
	FROM [Advice]
	WHERE
		([AdviceID] = @AdviceID)

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: LoadAdviceByPrimaryKey Succeeded'
ELSE PRINT 'Procedure Creation: LoadAdviceByPrimaryKey Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('LoadAllAdvice') AND sysstat & 0xf = 4)
    DROP PROCEDURE [LoadAllAdvice];
GO

CREATE PROCEDURE [LoadAllAdvice]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[AdviceID],
		[Question],
		[Answer],
		[Question_ru],
		[Question_en],
		[Answer_ru],
		[Answer_en]
	FROM [Advice]

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: LoadAllAdvice Succeeded'
ELSE PRINT 'Procedure Creation: LoadAllAdvice Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('UpdateAdvice') AND sysstat & 0xf = 4)
    DROP PROCEDURE [UpdateAdvice];
GO

CREATE PROCEDURE [UpdateAdvice]
(
	@AdviceID int,
	@Question varchar(250),
	@Answer varchar(MAX),
	@Question_ru varchar(250) = NULL,
	@Question_en varchar(250) = NULL,
	@Answer_ru varchar(MAX) = NULL,
	@Answer_en varchar(MAX) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	UPDATE [Advice]
	SET
		[Question] = @Question,
		[Answer] = @Answer,
		[Question_ru] = @Question_ru,
		[Question_en] = @Question_en,
		[Answer_ru] = @Answer_ru,
		[Answer_en] = @Answer_en
	WHERE
		[AdviceID] = @AdviceID


	SET @Err = @@Error


	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: UpdateAdvice Succeeded'
ELSE PRINT 'Procedure Creation: UpdateAdvice Error on Creation'
GO




IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('InsertAdvice') AND sysstat & 0xf = 4)
    DROP PROCEDURE [InsertAdvice];
GO

CREATE PROCEDURE [InsertAdvice]
(
	@AdviceID int = NULL output,
	@Question varchar(250),
	@Answer varchar(MAX),
	@Question_ru varchar(250) = NULL,
	@Question_en varchar(250) = NULL,
	@Answer_ru varchar(MAX) = NULL,
	@Answer_en varchar(MAX) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	INSERT
	INTO [Advice]
	(
		[Question],
		[Answer],
		[Question_ru],
		[Question_en],
		[Answer_ru],
		[Answer_en]
	)
	VALUES
	(
		@Question,
		@Answer,
		@Question_ru,
		@Question_en,
		@Answer_ru,
		@Answer_en
	)

	SET @Err = @@Error

	SELECT @AdviceID = SCOPE_IDENTITY()

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: InsertAdvice Succeeded'
ELSE PRINT 'Procedure Creation: InsertAdvice Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('DeleteAdvice') AND sysstat & 0xf = 4)
    DROP PROCEDURE [DeleteAdvice];
GO

CREATE PROCEDURE [DeleteAdvice]
(
	@AdviceID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE
	FROM [Advice]
	WHERE
		[AdviceID] = @AdviceID
	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: DeleteAdvice Succeeded'
ELSE PRINT 'Procedure Creation: DeleteAdvice Error on Creation'
GO



UPDATE [dbo].[Advice]
   SET [Question_ru] = [Question]
      ,[Question_en] = [Question]
      ,[Answer_ru] = [Answer]
      ,[Answer_en] = [Answer]

GO




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
ALTER TABLE dbo.OrderStatus ADD
	Name_ru varchar(50) NULL,
	Name_en varchar(50) NULL
GO
ALTER TABLE dbo.OrderStatus SET (LOCK_ESCALATION = TABLE)
GO
COMMIT





USE [Fotoxata]
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('LoadOrderStatusByPrimaryKey') AND sysstat & 0xf = 4)
    DROP PROCEDURE [LoadOrderStatusByPrimaryKey];
GO

CREATE PROCEDURE [LoadOrderStatusByPrimaryKey]
(
	@OrderStatusID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[OrderStatusID],
		[Name],
		[Active],
		[Name_ru],
		[Name_en]
	FROM [OrderStatus]
	WHERE
		([OrderStatusID] = @OrderStatusID)

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: LoadOrderStatusByPrimaryKey Succeeded'
ELSE PRINT 'Procedure Creation: LoadOrderStatusByPrimaryKey Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('LoadAllOrderStatus') AND sysstat & 0xf = 4)
    DROP PROCEDURE [LoadAllOrderStatus];
GO

CREATE PROCEDURE [LoadAllOrderStatus]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[OrderStatusID],
		[Name],
		[Active],
		[Name_ru],
		[Name_en]
	FROM [OrderStatus]

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: LoadAllOrderStatus Succeeded'
ELSE PRINT 'Procedure Creation: LoadAllOrderStatus Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('UpdateOrderStatus') AND sysstat & 0xf = 4)
    DROP PROCEDURE [UpdateOrderStatus];
GO

CREATE PROCEDURE [UpdateOrderStatus]
(
	@OrderStatusID int,
	@Name varchar(50),
	@Active bit,
	@Name_ru varchar(50) = NULL,
	@Name_en varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	UPDATE [OrderStatus]
	SET
		[Name] = @Name,
		[Active] = @Active,
		[Name_ru] = @Name_ru,
		[Name_en] = @Name_en
	WHERE
		[OrderStatusID] = @OrderStatusID


	SET @Err = @@Error


	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: UpdateOrderStatus Succeeded'
ELSE PRINT 'Procedure Creation: UpdateOrderStatus Error on Creation'
GO




IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('InsertOrderStatus') AND sysstat & 0xf = 4)
    DROP PROCEDURE [InsertOrderStatus];
GO

CREATE PROCEDURE [InsertOrderStatus]
(
	@OrderStatusID int = NULL output,
	@Name varchar(50),
	@Active bit,
	@Name_ru varchar(50) = NULL,
	@Name_en varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	INSERT
	INTO [OrderStatus]
	(
		[Name],
		[Active],
		[Name_ru],
		[Name_en]
	)
	VALUES
	(
		@Name,
		@Active,
		@Name_ru,
		@Name_en
	)

	SET @Err = @@Error

	SELECT @OrderStatusID = SCOPE_IDENTITY()

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: InsertOrderStatus Succeeded'
ELSE PRINT 'Procedure Creation: InsertOrderStatus Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('DeleteOrderStatus') AND sysstat & 0xf = 4)
    DROP PROCEDURE [DeleteOrderStatus];
GO

CREATE PROCEDURE [DeleteOrderStatus]
(
	@OrderStatusID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE
	FROM [OrderStatus]
	WHERE
		[OrderStatusID] = @OrderStatusID
	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: DeleteOrderStatus Succeeded'
ELSE PRINT 'Procedure Creation: DeleteOrderStatus Error on Creation'
GO




UPDATE [dbo].[OrderStatus]
   SET [Name_ru] = [Name]
      ,[Name_en] = [Name]

GO





/****** Object:  StoredProcedure [dbo].[usp_Order_LoadByUserID]    Script Date: 09/29/2012 07:33:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[usp_Order_LoadByUserID](
	@UserID int
) 
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT     
		[Order].OrderID, 
		[OrderStatus].Name AS OrderStatus,
		[OrderStatus].Name_ru AS OrderStatus_ru,
		[OrderStatus].Name_en AS OrderStatus_en,
		[Order].ClientNote, 
		[Order].OfficeNote, 
		[Order].PhotoCount, 
		[Order].Amount, 
		[Order].DateCreated
	FROM         
		[Order] 
		LEFT OUTER JOIN
        [User] ON [Order].UserID = [User].UserID
        LEFT OUTER JOIN
		OrderStatus ON [Order].OrderStatusID = [OrderStatus].OrderStatusID
	 WHERE     
		[Order].UserID = @UserID 
       

	SET @Err = @@Error

	RETURN @Err
END



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
ALTER TABLE dbo.Delivery ADD
	Name_ru nvarchar(50) NULL,
	Name_en nvarchar(50) NULL,
	Name1_ru nvarchar(50) NULL,
	Name1_en nvarchar(50) NULL
GO
ALTER TABLE dbo.Delivery SET (LOCK_ESCALATION = TABLE)
GO
COMMIT





USE [Fotoxata]
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('LoadDeliveryByPrimaryKey') AND sysstat & 0xf = 4)
    DROP PROCEDURE [LoadDeliveryByPrimaryKey];
GO

CREATE PROCEDURE [LoadDeliveryByPrimaryKey]
(
	@DeliveryID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[DeliveryID],
		[Name],
		[Active],
		[Name1],
		[Name_ru],
		[Name_en],
		[Name1_ru],
		[Name1_en]
	FROM [Delivery]
	WHERE
		([DeliveryID] = @DeliveryID)

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: LoadDeliveryByPrimaryKey Succeeded'
ELSE PRINT 'Procedure Creation: LoadDeliveryByPrimaryKey Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('LoadAllDelivery') AND sysstat & 0xf = 4)
    DROP PROCEDURE [LoadAllDelivery];
GO

CREATE PROCEDURE [LoadAllDelivery]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[DeliveryID],
		[Name],
		[Active],
		[Name1],
		[Name_ru],
		[Name_en],
		[Name1_ru],
		[Name1_en]
	FROM [Delivery]

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: LoadAllDelivery Succeeded'
ELSE PRINT 'Procedure Creation: LoadAllDelivery Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('UpdateDelivery') AND sysstat & 0xf = 4)
    DROP PROCEDURE [UpdateDelivery];
GO

CREATE PROCEDURE [UpdateDelivery]
(
	@DeliveryID int,
	@Name nvarchar(50),
	@Active bit,
	@Name1 nvarchar(50) = NULL,
	@Name_ru nvarchar(50) = NULL,
	@Name_en nvarchar(50) = NULL,
	@Name1_ru nvarchar(50) = NULL,
	@Name1_en nvarchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	UPDATE [Delivery]
	SET
		[Name] = @Name,
		[Active] = @Active,
		[Name1] = @Name1,
		[Name_ru] = @Name_ru,
		[Name_en] = @Name_en,
		[Name1_ru] = @Name1_ru,
		[Name1_en] = @Name1_en
	WHERE
		[DeliveryID] = @DeliveryID


	SET @Err = @@Error


	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: UpdateDelivery Succeeded'
ELSE PRINT 'Procedure Creation: UpdateDelivery Error on Creation'
GO




IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('InsertDelivery') AND sysstat & 0xf = 4)
    DROP PROCEDURE [InsertDelivery];
GO

CREATE PROCEDURE [InsertDelivery]
(
	@DeliveryID int = NULL output,
	@Name nvarchar(50),
	@Active bit,
	@Name1 nvarchar(50) = NULL,
	@Name_ru nvarchar(50) = NULL,
	@Name_en nvarchar(50) = NULL,
	@Name1_ru nvarchar(50) = NULL,
	@Name1_en nvarchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	INSERT
	INTO [Delivery]
	(
		[Name],
		[Active],
		[Name1],
		[Name_ru],
		[Name_en],
		[Name1_ru],
		[Name1_en]
	)
	VALUES
	(
		@Name,
		@Active,
		@Name1,
		@Name_ru,
		@Name_en,
		@Name1_ru,
		@Name1_en
	)

	SET @Err = @@Error

	SELECT @DeliveryID = SCOPE_IDENTITY()

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: InsertDelivery Succeeded'
ELSE PRINT 'Procedure Creation: InsertDelivery Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('DeleteDelivery') AND sysstat & 0xf = 4)
    DROP PROCEDURE [DeleteDelivery];
GO

CREATE PROCEDURE [DeleteDelivery]
(
	@DeliveryID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE
	FROM [Delivery]
	WHERE
		[DeliveryID] = @DeliveryID
	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: DeleteDelivery Succeeded'
ELSE PRINT 'Procedure Creation: DeleteDelivery Error on Creation'
GO



UPDATE [dbo].[Delivery]
   SET [Name_ru] = [Name]
      ,[Name_en] = [Name]
      ,[Name1_ru] = [Name1]
      ,[Name1_en] = [Name1]
 
GO



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
ALTER TABLE dbo.Merchandise ADD
	Name_ru varchar(50) NULL,
	Name_en varchar(50) NULL,
	Description_ru varchar(4000) NULL,
	Description_en varchar(4000) NULL
GO
ALTER TABLE dbo.Merchandise SET (LOCK_ESCALATION = TABLE)
GO
COMMIT




USE [Fotoxata]
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('LoadMerchandiseByPrimaryKey') AND sysstat & 0xf = 4)
    DROP PROCEDURE [LoadMerchandiseByPrimaryKey];
GO

CREATE PROCEDURE [LoadMerchandiseByPrimaryKey]
(
	@MerchandiseID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[MerchandiseID],
		[Name],
		[PhotoName],
		[CategoryID],
		[PriceFrom],
		[PriceTo],
		[DisplayOnPrice],
		[Description],
		[Name_ru],
		[Name_en],
		[Description_ru],
		[Description_en]
	FROM [Merchandise]
	WHERE
		([MerchandiseID] = @MerchandiseID)

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: LoadMerchandiseByPrimaryKey Succeeded'
ELSE PRINT 'Procedure Creation: LoadMerchandiseByPrimaryKey Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('LoadAllMerchandise') AND sysstat & 0xf = 4)
    DROP PROCEDURE [LoadAllMerchandise];
GO

CREATE PROCEDURE [LoadAllMerchandise]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[MerchandiseID],
		[Name],
		[PhotoName],
		[CategoryID],
		[PriceFrom],
		[PriceTo],
		[DisplayOnPrice],
		[Description],
		[Name_ru],
		[Name_en],
		[Description_ru],
		[Description_en]
	FROM [Merchandise]

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: LoadAllMerchandise Succeeded'
ELSE PRINT 'Procedure Creation: LoadAllMerchandise Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('UpdateMerchandise') AND sysstat & 0xf = 4)
    DROP PROCEDURE [UpdateMerchandise];
GO

CREATE PROCEDURE [UpdateMerchandise]
(
	@MerchandiseID int,
	@Name varchar(50),
	@PhotoName varchar(50) = NULL,
	@CategoryID int,
	@PriceFrom money = NULL,
	@PriceTo money = NULL,
	@DisplayOnPrice bit,
	@Description varchar(4000) = NULL,
	@Name_ru varchar(50) = NULL,
	@Name_en varchar(50) = NULL,
	@Description_ru varchar(4000) = NULL,
	@Description_en varchar(4000) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	UPDATE [Merchandise]
	SET
		[Name] = @Name,
		[PhotoName] = @PhotoName,
		[CategoryID] = @CategoryID,
		[PriceFrom] = @PriceFrom,
		[PriceTo] = @PriceTo,
		[DisplayOnPrice] = @DisplayOnPrice,
		[Description] = @Description,
		[Name_ru] = @Name_ru,
		[Name_en] = @Name_en,
		[Description_ru] = @Description_ru,
		[Description_en] = @Description_en
	WHERE
		[MerchandiseID] = @MerchandiseID


	SET @Err = @@Error


	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: UpdateMerchandise Succeeded'
ELSE PRINT 'Procedure Creation: UpdateMerchandise Error on Creation'
GO




IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('InsertMerchandise') AND sysstat & 0xf = 4)
    DROP PROCEDURE [InsertMerchandise];
GO

CREATE PROCEDURE [InsertMerchandise]
(
	@MerchandiseID int = NULL output,
	@Name varchar(50),
	@PhotoName varchar(50) = NULL,
	@CategoryID int,
	@PriceFrom money = NULL,
	@PriceTo money = NULL,
	@DisplayOnPrice bit,
	@Description varchar(4000) = NULL,
	@Name_ru varchar(50) = NULL,
	@Name_en varchar(50) = NULL,
	@Description_ru varchar(4000) = NULL,
	@Description_en varchar(4000) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	INSERT
	INTO [Merchandise]
	(
		[Name],
		[PhotoName],
		[CategoryID],
		[PriceFrom],
		[PriceTo],
		[DisplayOnPrice],
		[Description],
		[Name_ru],
		[Name_en],
		[Description_ru],
		[Description_en]
	)
	VALUES
	(
		@Name,
		@PhotoName,
		@CategoryID,
		@PriceFrom,
		@PriceTo,
		@DisplayOnPrice,
		@Description,
		@Name_ru,
		@Name_en,
		@Description_ru,
		@Description_en
	)

	SET @Err = @@Error

	SELECT @MerchandiseID = SCOPE_IDENTITY()

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: InsertMerchandise Succeeded'
ELSE PRINT 'Procedure Creation: InsertMerchandise Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('DeleteMerchandise') AND sysstat & 0xf = 4)
    DROP PROCEDURE [DeleteMerchandise];
GO

CREATE PROCEDURE [DeleteMerchandise]
(
	@MerchandiseID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE
	FROM [Merchandise]
	WHERE
		[MerchandiseID] = @MerchandiseID
	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: DeleteMerchandise Succeeded'
ELSE PRINT 'Procedure Creation: DeleteMerchandise Error on Creation'
GO




UPDATE [dbo].[Merchandise]
   SET [Name_ru] = [Name]
      ,[Name_en] = [Name]
      ,[Description_ru] = [Description]
      ,[Description_en] = [Description]
GO




/****** Object:  StoredProcedure [dbo].[usp_Merchandise_LoadByCategoryID]    Script Date: 09/29/2012 11:44:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[usp_Merchandise_LoadByCategoryID]
(
	@CategoryID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT [MerchandiseID]
      ,[Name]
      ,[Name_ru]
      ,[Name_en]
      ,[PhotoName]
      ,[CategoryID]
      ,[PriceFrom]
      ,[PriceTo]
      ,[DisplayOnPrice]
      ,[Description]
      ,[Description_ru]
      ,[Description_en]
	FROM 
		[Merchandise]
	WHERE
		[CategoryID] = @CategoryID

	SET @Err = @@Error

	RETURN @Err
END




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
ALTER TABLE dbo.PaperType ADD
	Name_ru varchar(50) NULL,
	Name_en varchar(50) NULL
GO
ALTER TABLE dbo.PaperType SET (LOCK_ESCALATION = TABLE)
GO
COMMIT






IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('LoadPaperTypeByPrimaryKey') AND sysstat & 0xf = 4)
    DROP PROCEDURE [LoadPaperTypeByPrimaryKey];
GO

CREATE PROCEDURE [LoadPaperTypeByPrimaryKey]
(
	@PaperTypeID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[PaperTypeID],
		[Name],
		[Name_ru],
		[Name_en]
	FROM [PaperType]
	WHERE
		([PaperTypeID] = @PaperTypeID)

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: LoadPaperTypeByPrimaryKey Succeeded'
ELSE PRINT 'Procedure Creation: LoadPaperTypeByPrimaryKey Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('LoadAllPaperType') AND sysstat & 0xf = 4)
    DROP PROCEDURE [LoadAllPaperType];
GO

CREATE PROCEDURE [LoadAllPaperType]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[PaperTypeID],
		[Name],
		[Name_ru],
		[Name_en]
	FROM [PaperType]

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: LoadAllPaperType Succeeded'
ELSE PRINT 'Procedure Creation: LoadAllPaperType Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('UpdatePaperType') AND sysstat & 0xf = 4)
    DROP PROCEDURE [UpdatePaperType];
GO

CREATE PROCEDURE [UpdatePaperType]
(
	@PaperTypeID int,
	@Name varchar(50),
	@Name_ru varchar(50) = NULL,
	@Name_en varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	UPDATE [PaperType]
	SET
		[Name] = @Name,
		[Name_ru] = @Name_ru,
		[Name_en] = @Name_en
	WHERE
		[PaperTypeID] = @PaperTypeID


	SET @Err = @@Error


	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: UpdatePaperType Succeeded'
ELSE PRINT 'Procedure Creation: UpdatePaperType Error on Creation'
GO




IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('InsertPaperType') AND sysstat & 0xf = 4)
    DROP PROCEDURE [InsertPaperType];
GO

CREATE PROCEDURE [InsertPaperType]
(
	@PaperTypeID int,
	@Name varchar(50),
	@Name_ru varchar(50) = NULL,
	@Name_en varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	INSERT
	INTO [PaperType]
	(
		[PaperTypeID],
		[Name],
		[Name_ru],
		[Name_en]
	)
	VALUES
	(
		@PaperTypeID,
		@Name,
		@Name_ru,
		@Name_en
	)

	SET @Err = @@Error


	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: InsertPaperType Succeeded'
ELSE PRINT 'Procedure Creation: InsertPaperType Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('DeletePaperType') AND sysstat & 0xf = 4)
    DROP PROCEDURE [DeletePaperType];
GO

CREATE PROCEDURE [DeletePaperType]
(
	@PaperTypeID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE
	FROM [PaperType]
	WHERE
		[PaperTypeID] = @PaperTypeID
	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: DeletePaperType Succeeded'
ELSE PRINT 'Procedure Creation: DeletePaperType Error on Creation'
GO



UPDATE [dbo].[PaperType]
   SET [Name_ru] = 'Матовый'
      ,[Name_en] = 'Mat'
 WHERE [PaperTypeID] = 1
GO

UPDATE [dbo].[PaperType]
   SET [Name_ru] = 'Глянцевый'
      ,[Name_en] = 'Glossy'
 WHERE [PaperTypeID] = 2
GO





/****** Object:  StoredProcedure [dbo].[usp_Category_PriceLoad]    Script Date: 09/30/2012 08:00:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[usp_Category_PriceLoad]
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	DECLARE @Price TABLE (
	Name varchar(255),
	Name_ru varchar(255),
	Name_en varchar(255),
	PriceFrom money,
	PriceTo money,
	MerchandiseID int,
	CategoryID int)
	
	INSERT INTO @Price
	(
		Name,
		Name_ru,
		Name_en,
		PriceFrom,
		PriceTo,
		MerchandiseID,
		CategoryID
	)
	SELECT CASE WHEN [Title] IS NULL THEN [Name] ELSE [Title] END
      , CASE WHEN [Title_ru] IS NULL THEN [Name_ru] ELSE [Title_ru] END
      , CASE WHEN [Title_en] IS NULL THEN [Name_en] ELSE [Title_en] END
      ,[PriceFrom]
      ,[PriceTo]
      ,0
      ,[CategoryID]
	FROM 
		[Category]
	WHERE
		DisplayOnPrice = 1
		
	INSERT INTO @Price
	(
		Name,
		Name_ru,
		Name_en,
		PriceFrom,
		PriceTo,
		MerchandiseID,
		CategoryID
	)
	SELECT 
       [Name]
      ,Name_ru
	  ,Name_en
      ,[PriceFrom]
      ,[PriceTo]
      ,[MerchandiseID]
      ,[CategoryID]
	FROM 
		[Merchandise]
	WHERE
		DisplayOnPrice = 1
		
	SELECT * FROM @Price ORDER BY CategoryID, MerchandiseID

	SET @Err = @@Error

	RETURN @Err
END





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
ALTER TABLE dbo.PhotoSalon ADD
	Address_ru varchar(50) NULL,
	Address_en varchar(50) NULL,
	Description_ru varchar(MAX) NULL,
	Description_en varchar(MAX) NULL
GO
ALTER TABLE dbo.PhotoSalon SET (LOCK_ESCALATION = TABLE)
GO
COMMIT






USE [Fotoxata]
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('LoadPhotoSalonByPrimaryKey') AND sysstat & 0xf = 4)
    DROP PROCEDURE [LoadPhotoSalonByPrimaryKey];
GO

CREATE PROCEDURE [LoadPhotoSalonByPrimaryKey]
(
	@PhotoSalonID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[PhotoSalonID],
		[Address],
		[Active],
		[Phone1],
		[Phone2],
		[Phone3],
		[Description],
		[ButtonImage],
		[ButtonImageHover],
		[Address_ru],
		[Address_en],
		[Description_ru],
		[Description_en]
	FROM [PhotoSalon]
	WHERE
		([PhotoSalonID] = @PhotoSalonID)

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: LoadPhotoSalonByPrimaryKey Succeeded'
ELSE PRINT 'Procedure Creation: LoadPhotoSalonByPrimaryKey Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('LoadAllPhotoSalon') AND sysstat & 0xf = 4)
    DROP PROCEDURE [LoadAllPhotoSalon];
GO

CREATE PROCEDURE [LoadAllPhotoSalon]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[PhotoSalonID],
		[Address],
		[Active],
		[Phone1],
		[Phone2],
		[Phone3],
		[Description],
		[ButtonImage],
		[ButtonImageHover],
		[Address_ru],
		[Address_en],
		[Description_ru],
		[Description_en]
	FROM [PhotoSalon]

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: LoadAllPhotoSalon Succeeded'
ELSE PRINT 'Procedure Creation: LoadAllPhotoSalon Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('UpdatePhotoSalon') AND sysstat & 0xf = 4)
    DROP PROCEDURE [UpdatePhotoSalon];
GO

CREATE PROCEDURE [UpdatePhotoSalon]
(
	@PhotoSalonID int,
	@Address varchar(50),
	@Active bit,
	@Phone1 varchar(20) = NULL,
	@Phone2 varchar(20) = NULL,
	@Phone3 varchar(20) = NULL,
	@Description varchar(MAX) = NULL,
	@ButtonImage varchar(50) = NULL,
	@ButtonImageHover varchar(50) = NULL,
	@Address_ru varchar(50) = NULL,
	@Address_en varchar(50) = NULL,
	@Description_ru varchar(MAX) = NULL,
	@Description_en varchar(MAX) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	UPDATE [PhotoSalon]
	SET
		[Address] = @Address,
		[Active] = @Active,
		[Phone1] = @Phone1,
		[Phone2] = @Phone2,
		[Phone3] = @Phone3,
		[Description] = @Description,
		[ButtonImage] = @ButtonImage,
		[ButtonImageHover] = @ButtonImageHover,
		[Address_ru] = @Address_ru,
		[Address_en] = @Address_en,
		[Description_ru] = @Description_ru,
		[Description_en] = @Description_en
	WHERE
		[PhotoSalonID] = @PhotoSalonID


	SET @Err = @@Error


	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: UpdatePhotoSalon Succeeded'
ELSE PRINT 'Procedure Creation: UpdatePhotoSalon Error on Creation'
GO




IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('InsertPhotoSalon') AND sysstat & 0xf = 4)
    DROP PROCEDURE [InsertPhotoSalon];
GO

CREATE PROCEDURE [InsertPhotoSalon]
(
	@PhotoSalonID int = NULL output,
	@Address varchar(50),
	@Active bit,
	@Phone1 varchar(20) = NULL,
	@Phone2 varchar(20) = NULL,
	@Phone3 varchar(20) = NULL,
	@Description varchar(MAX) = NULL,
	@ButtonImage varchar(50) = NULL,
	@ButtonImageHover varchar(50) = NULL,
	@Address_ru varchar(50) = NULL,
	@Address_en varchar(50) = NULL,
	@Description_ru varchar(MAX) = NULL,
	@Description_en varchar(MAX) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	INSERT
	INTO [PhotoSalon]
	(
		[Address],
		[Active],
		[Phone1],
		[Phone2],
		[Phone3],
		[Description],
		[ButtonImage],
		[ButtonImageHover],
		[Address_ru],
		[Address_en],
		[Description_ru],
		[Description_en]
	)
	VALUES
	(
		@Address,
		@Active,
		@Phone1,
		@Phone2,
		@Phone3,
		@Description,
		@ButtonImage,
		@ButtonImageHover,
		@Address_ru,
		@Address_en,
		@Description_ru,
		@Description_en
	)

	SET @Err = @@Error

	SELECT @PhotoSalonID = SCOPE_IDENTITY()

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: InsertPhotoSalon Succeeded'
ELSE PRINT 'Procedure Creation: InsertPhotoSalon Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('DeletePhotoSalon') AND sysstat & 0xf = 4)
    DROP PROCEDURE [DeletePhotoSalon];
GO

CREATE PROCEDURE [DeletePhotoSalon]
(
	@PhotoSalonID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE
	FROM [PhotoSalon]
	WHERE
		[PhotoSalonID] = @PhotoSalonID
	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: DeletePhotoSalon Succeeded'
ELSE PRINT 'Procedure Creation: DeletePhotoSalon Error on Creation'
GO



UPDATE [dbo].[PhotoSalon]
   SET [Address_ru] = [Address]
      ,[Address_en] = [Address]
      ,[Description_ru] = [Description]
      ,[Description_en] = [Description]

GO


