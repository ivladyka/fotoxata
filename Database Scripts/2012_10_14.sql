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
ALTER TABLE dbo.Gallery ADD
	OrderIndex int NULL
GO
ALTER TABLE dbo.Gallery SET (LOCK_ESCALATION = TABLE)
GO
COMMIT





IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('LoadGalleryByPrimaryKey') AND sysstat & 0xf = 4)
    DROP PROCEDURE [LoadGalleryByPrimaryKey];
GO

CREATE PROCEDURE [LoadGalleryByPrimaryKey]
(
	@GalleryID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[GalleryID],
		[CategoryID],
		[PhotoName],
		[OrderIndex]
	FROM [Gallery]
	WHERE
		([GalleryID] = @GalleryID)

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: LoadGalleryByPrimaryKey Succeeded'
ELSE PRINT 'Procedure Creation: LoadGalleryByPrimaryKey Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('LoadAllGallery') AND sysstat & 0xf = 4)
    DROP PROCEDURE [LoadAllGallery];
GO

CREATE PROCEDURE [LoadAllGallery]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[GalleryID],
		[CategoryID],
		[PhotoName],
		[OrderIndex]
	FROM [Gallery]

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: LoadAllGallery Succeeded'
ELSE PRINT 'Procedure Creation: LoadAllGallery Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('UpdateGallery') AND sysstat & 0xf = 4)
    DROP PROCEDURE [UpdateGallery];
GO

CREATE PROCEDURE [UpdateGallery]
(
	@GalleryID int,
	@CategoryID int,
	@PhotoName varchar(50),
	@OrderIndex int = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	UPDATE [Gallery]
	SET
		[CategoryID] = @CategoryID,
		[PhotoName] = @PhotoName,
		[OrderIndex] = @OrderIndex
	WHERE
		[GalleryID] = @GalleryID


	SET @Err = @@Error


	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: UpdateGallery Succeeded'
ELSE PRINT 'Procedure Creation: UpdateGallery Error on Creation'
GO




IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('InsertGallery') AND sysstat & 0xf = 4)
    DROP PROCEDURE [InsertGallery];
GO

CREATE PROCEDURE [InsertGallery]
(
	@GalleryID int = NULL output,
	@CategoryID int,
	@PhotoName varchar(50),
	@OrderIndex int = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	INSERT
	INTO [Gallery]
	(
		[CategoryID],
		[PhotoName],
		[OrderIndex]
	)
	VALUES
	(
		@CategoryID,
		@PhotoName,
		@OrderIndex
	)

	SET @Err = @@Error

	SELECT @GalleryID = SCOPE_IDENTITY()

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: InsertGallery Succeeded'
ELSE PRINT 'Procedure Creation: InsertGallery Error on Creation'
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('DeleteGallery') AND sysstat & 0xf = 4)
    DROP PROCEDURE [DeleteGallery];
GO

CREATE PROCEDURE [DeleteGallery]
(
	@GalleryID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE
	FROM [Gallery]
	WHERE
		[GalleryID] = @GalleryID
	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: DeleteGallery Succeeded'
ELSE PRINT 'Procedure Creation: DeleteGallery Error on Creation'
GO



/****** Object:  StoredProcedure [dbo].[usp_Gallery_LoadByCategoryID]    Script Date: 10/14/2012 08:47:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[usp_Gallery_LoadByCategoryID]
(
	@CategoryID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT [GalleryID]
      ,[CategoryID]
      ,[PhotoName]
	FROM 
		[Gallery]
	WHERE
		[CategoryID] = @CategoryID
	ORDER BY
		OrderIndex

	SET @Err = @@Error

	RETURN @Err
END





--SET Gallery OrderIndex Script START
DECLARE @CategoryID int
DECLARE @GalleryID int
DECLARE @Index int
	
DECLARE Category_crsr CURSOR
   	FOR
   	SELECT     
		CategoryID
	FROM         
		Category 

	OPEN Category_crsr

	FETCH NEXT FROM Category_crsr INTO @CategoryID
	   WHILE @@Fetch_Status = 0
	     BEGIN
		SET @Index = 1
		DECLARE Gallery_crsr CURSOR
   	FOR
   	SELECT 
   		[GalleryID]
	FROM 
		[Gallery]
	WHERE
		[CategoryID] = @CategoryID 

	OPEN Gallery_crsr

	FETCH NEXT FROM Gallery_crsr INTO @GalleryID
	   WHILE @@Fetch_Status = 0
	     BEGIN
	
		UPDATE    [Gallery]
		SET
			OrderIndex = @Index
		WHERE
			 [GalleryID] =  @GalleryID
	     
	     SET @Index = @Index + 1
	     
	     FETCH NEXT FROM Gallery_crsr INTO @GalleryID
	     END

	CLOSE Gallery_crsr
	DEALLOCATE Gallery_crsr
	

		FETCH NEXT FROM Category_crsr INTO @CategoryID
	     END

	CLOSE Category_crsr
	DEALLOCATE Category_crsr


--SET Gallery OrderIndex Script END



IF EXISTS (SELECT * FROM SYSOBJECTS WHERE ID = OBJECT_ID('usp_Gallery_Move') AND sysstat & 0xf = 4)
    DROP PROCEDURE [usp_Gallery_Move];
GO

CREATE PROCEDURE [usp_Gallery_Move]
(
	@CategoryID int,
	@SourceGalleryID int,
	@DestGalleryID int = NULL
)
AS
BEGIN

	IF @DestGalleryID IS NOT NULL
	 BEGIN
		DECLARE @DestOrder tinyint
		SELECT
			@DestOrder = OrderIndex
		FROM
			Gallery
		WHERE
			CategoryID = @CategoryID
			AND
			GalleryID = @DestGalleryID
			
		UPDATE
			Gallery
		SET 
			OrderIndex = OrderIndex + 1
		WHERE
			CategoryID = @CategoryID
			AND
			OrderIndex > @DestOrder
		
		UPDATE
			Gallery
		SET 
			OrderIndex = @DestOrder + 1
		WHERE
			CategoryID = @CategoryID
			AND
			GalleryID = @SourceGalleryID
	 END
	ELSE
	 BEGIN
		UPDATE
			Gallery
		SET 
			OrderIndex = 1
		WHERE
			CategoryID = @CategoryID
			AND
			GalleryID = @SourceGalleryID
	 END
	
	UPDATE 
		tdit
	SET tdit.OrderIndex = tdit.rNum
	FROM
	(SELECT row_number() over (order by [OrderIndex]) AS rNum,*
	FROM
		Gallery 
	WHERE
		CategoryID = @CategoryID
	) tdit
	
END
GO


