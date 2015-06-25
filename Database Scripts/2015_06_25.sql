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
CREATE TABLE dbo.Error
	(
	ErrorID int NOT NULL IDENTITY (1, 1),
	Date smalldatetime NOT NULL,
	StackTrace text NULL,
	Browser nvarchar(1024) NULL,
	Name nvarchar(4000) NULL,
	Description nvarchar(4000) NULL,
	Session text NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Error ADD CONSTRAINT
	PK_Error PRIMARY KEY CLUSTERED 
	(
	ErrorID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Error SET (LOCK_ESCALATION = TABLE)
GO
COMMIT




SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteError]
(
	@ErrorID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE
	FROM [Error]
	WHERE
		[ErrorID] = @ErrorID
	SET @Err = @@Error

	RETURN @Err
END
GO




SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertError]
(
	@ErrorID int = NULL output,
	@Date smalldatetime,
	@StackTrace text = NULL,
	@Browser nvarchar(1024) = NULL,
	@Name nvarchar(4000) = NULL,
	@Description nvarchar(4000) = NULL,
	@Session text = NULL
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
           ,[Session])
	VALUES
	(
		@Date,
		@StackTrace,
		@Browser,
		@Name,
		@Description,
		@Session
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
CREATE PROCEDURE [dbo].[LoadAllError]
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
	FROM [Error]

	SET @Err = @@Error

	RETURN @Err
END
GO




SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoadErrorByPrimaryKey]
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
	FROM [Error]
	WHERE
		([ErrorID] = @ErrorID)

	SET @Err = @@Error

	RETURN @Err
END
GO






SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateError]
(
	@ErrorID int,
	@Date smalldatetime,
	@StackTrace text = NULL,
	@Browser nvarchar(1024) = NULL,
	@Name nvarchar(4000) = NULL,
	@Description nvarchar(4000) = NULL,
	@Session text = NULL
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
		Session = @Session
	WHERE
		[ErrorID] = @ErrorID


	SET @Err = @@Error


	RETURN @Err
END
GO



