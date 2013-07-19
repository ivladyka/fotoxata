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
ALTER TABLE dbo.Category ADD
	Name_ru varchar(255) NULL,
	Title_ru varchar(255) NULL,
	CategoryContent_ru varchar(MAX) NULL,
	Name_en varchar(255) NULL,
	Title_en varchar(255) NULL,
	CategoryContent_en varchar(MAX) NULL
GO
ALTER TABLE dbo.Category SET (LOCK_ESCALATION = TABLE)
GO
COMMIT




IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('LoadCategoryByPrimaryKey') AND sysstat & 0xf = 4)
    DROP PROCEDURE [LoadCategoryByPrimaryKey];
GO

CREATE PROCEDURE [LoadCategoryByPrimaryKey]
(
	@CategoryID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[CategoryID],
		[Name],
		[IsGallery],
		[PriceFrom],
		[PriceTo],
		[DisplayOnPrice],
		[Title],
		[CategoryContent],
		[Name_ru],
		[Title_ru],
		[CategoryContent_ru],
		[Name_en],
		[Title_en],
		[CategoryContent_en]
	FROM [Category]
	WHERE
		([CategoryID] = @CategoryID)

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: LoadCategoryByPrimaryKey Succeeded'
ELSE PRINT 'Procedure Creation: LoadCategoryByPrimaryKey Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('LoadAllCategory') AND sysstat & 0xf = 4)
    DROP PROCEDURE [LoadAllCategory];
GO

CREATE PROCEDURE [LoadAllCategory]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[CategoryID],
		[Name],
		[IsGallery],
		[PriceFrom],
		[PriceTo],
		[DisplayOnPrice],
		[Title],
		[CategoryContent],
		[Name_ru],
		[Title_ru],
		[CategoryContent_ru],
		[Name_en],
		[Title_en],
		[CategoryContent_en]
	FROM [Category]

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: LoadAllCategory Succeeded'
ELSE PRINT 'Procedure Creation: LoadAllCategory Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('UpdateCategory') AND sysstat & 0xf = 4)
    DROP PROCEDURE [UpdateCategory];
GO

CREATE PROCEDURE [UpdateCategory]
(
	@CategoryID int,
	@Name varchar(255),
	@IsGallery bit,
	@PriceFrom money = NULL,
	@PriceTo money = NULL,
	@DisplayOnPrice bit,
	@Title varchar(255) = NULL,
	@CategoryContent varchar(MAX) = NULL,
	@Name_ru varchar(255) = NULL,
	@Title_ru varchar(255) = NULL,
	@CategoryContent_ru varchar(MAX) = NULL,
	@Name_en varchar(255) = NULL,
	@Title_en varchar(255) = NULL,
	@CategoryContent_en varchar(MAX) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	UPDATE [Category]
	SET
		[Name] = @Name,
		[IsGallery] = @IsGallery,
		[PriceFrom] = @PriceFrom,
		[PriceTo] = @PriceTo,
		[DisplayOnPrice] = @DisplayOnPrice,
		[Title] = @Title,
		[CategoryContent] = @CategoryContent,
		[Name_ru] = @Name_ru,
		[Title_ru] = @Title_ru,
		[CategoryContent_ru] = @CategoryContent_ru,
		[Name_en] = @Name_en,
		[Title_en] = @Title_en,
		[CategoryContent_en] = @CategoryContent_en
	WHERE
		[CategoryID] = @CategoryID


	SET @Err = @@Error


	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: UpdateCategory Succeeded'
ELSE PRINT 'Procedure Creation: UpdateCategory Error on Creation'
GO




IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('InsertCategory') AND sysstat & 0xf = 4)
    DROP PROCEDURE [InsertCategory];
GO

CREATE PROCEDURE [InsertCategory]
(
	@CategoryID int = NULL output,
	@Name varchar(255),
	@IsGallery bit,
	@PriceFrom money = NULL,
	@PriceTo money = NULL,
	@DisplayOnPrice bit,
	@Title varchar(255) = NULL,
	@CategoryContent varchar(MAX) = NULL,
	@Name_ru varchar(255) = NULL,
	@Title_ru varchar(255) = NULL,
	@CategoryContent_ru varchar(MAX) = NULL,
	@Name_en varchar(255) = NULL,
	@Title_en varchar(255) = NULL,
	@CategoryContent_en varchar(MAX) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	INSERT
	INTO [Category]
	(
		[Name],
		[IsGallery],
		[PriceFrom],
		[PriceTo],
		[DisplayOnPrice],
		[Title],
		[CategoryContent],
		[Name_ru],
		[Title_ru],
		[CategoryContent_ru],
		[Name_en],
		[Title_en],
		[CategoryContent_en]
	)
	VALUES
	(
		@Name,
		@IsGallery,
		@PriceFrom,
		@PriceTo,
		@DisplayOnPrice,
		@Title,
		@CategoryContent,
		@Name_ru,
		@Title_ru,
		@CategoryContent_ru,
		@Name_en,
		@Title_en,
		@CategoryContent_en
	)

	SET @Err = @@Error

	SELECT @CategoryID = SCOPE_IDENTITY()

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: InsertCategory Succeeded'
ELSE PRINT 'Procedure Creation: InsertCategory Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('DeleteCategory') AND sysstat & 0xf = 4)
    DROP PROCEDURE [DeleteCategory];
GO

CREATE PROCEDURE [DeleteCategory]
(
	@CategoryID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE
	FROM [Category]
	WHERE
		[CategoryID] = @CategoryID
	SET @Err = @@Error

	RETURN @Err
END






UPDATE [dbo].[Category]
   SET [Name_ru] = [Name],
		[Name_en] = [Name],
		[Title_ru] = [Title],
		[Title_en] = [Title],
		[CategoryContent_ru] = [CategoryContent],
		[CategoryContent_en] = [CategoryContent]
GO






IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('usp_Category_TitleLoad') AND sysstat & 0xf = 4)
    DROP PROCEDURE [usp_Category_TitleLoad];
GO

CREATE PROCEDURE [usp_Category_TitleLoad]
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[CategoryID],
		ISNULL([Title],[Name]) AS Title,
		ISNULL([Title_ru],[Name_ru]) AS Title_ru,
		ISNULL([Title_en],[Name_en]) AS Title_en
	FROM [Category]
	

	SET @Err = @@Error

	RETURN @Err
END
GO


