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
ALTER TABLE dbo.Error ADD
	OrderID int NULL
GO
ALTER TABLE dbo.Error SET (LOCK_ESCALATION = TABLE)
GO
COMMIT





SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[InsertError]
(
	@ErrorID int = NULL output,
	@Date smalldatetime,
	@StackTrace text = NULL,
	@Browser nvarchar(1024) = NULL,
	@Name nvarchar(4000) = NULL,
	@Description nvarchar(4000) = NULL,
	@Session text = NULL,
	@OrderID int = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	INSERT INTO [dbo].[Error]
           ([Date]
           ,[StackTrace]
           ,[Browser]
           ,[Name]
           ,[Description]
           ,[Session]
		   ,[OrderID])
	VALUES
	(
		@Date,
		@StackTrace,
		@Browser,
		@Name,
		@Description,
		@Session,
		@OrderID
	)

	SET @Err = @@Error

	SELECT @ErrorID = SCOPE_IDENTITY()

	RETURN @Err
END
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[LoadAllError]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ErrorID]
      ,[Date]
      ,[StackTrace]
      ,[Browser]
      ,[Name]
      ,[Description]
      ,[Session]
	  ,[OrderID]
	FROM [Error]

	SET @Err = @@Error

	RETURN @Err
END
GO



/****** Object:  StoredProcedure [dbo].[LoadErrorByPrimaryKey]    Script Date: 7/18/2015 10:02:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[LoadErrorByPrimaryKey]
(
	@ErrorID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ErrorID]
      ,[Date]
      ,[StackTrace]
      ,[Browser]
      ,[Name]
      ,[Description]
      ,[Session]
	  ,[OrderID]
	FROM [Error]
	WHERE
		([ErrorID] = @ErrorID)

	SET @Err = @@Error

	RETURN @Err
END
GO



/****** Object:  StoredProcedure [dbo].[UpdateError]    Script Date: 7/18/2015 10:03:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[UpdateError]
(
	@ErrorID int,
	@Date smalldatetime,
	@StackTrace text = NULL,
	@Browser nvarchar(1024) = NULL,
	@Name nvarchar(4000) = NULL,
	@Description nvarchar(4000) = NULL,
	@Session text = NULL,
	@OrderID int = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	UPDATE [Error]
	SET
		Date = @Date,
		StackTrace = @StackTrace,
		Browser = @Browser,
		Name = @Name,
		Description = @Description,
		Session = @Session,
		OrderID = @OrderID
	WHERE
		[ErrorID] = @ErrorID


	SET @Err = @@Error


	RETURN @Err
END
GO


