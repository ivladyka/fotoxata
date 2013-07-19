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
CREATE TABLE dbo.Advice
	(
	AdviceID int NOT NULL IDENTITY (1, 1),
	Question varchar(250) NOT NULL,
	Answer varchar(MAX) NOT NULL,
	ButtonImage varchar(50) NULL,
	ButtonImageHover varchar(50) NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Advice ADD CONSTRAINT
	PK_Advice PRIMARY KEY CLUSTERED 
	(
	AdviceID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Advice SET (LOCK_ESCALATION = TABLE)
GO
COMMIT



SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[LoadAdviceByPrimaryKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[LoadAdviceByPrimaryKey]
GO

CREATE PROCEDURE [dbo].[LoadAdviceByPrimaryKey]
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
		[ButtonImage],
		[ButtonImageHover]
	FROM [Advice]
	WHERE
		([AdviceID] = @AdviceID)

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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[LoadAllAdvice]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[LoadAllAdvice]
GO

CREATE PROCEDURE [dbo].[LoadAllAdvice]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[AdviceID],
		[Question],
		[Answer],
		[ButtonImage],
		[ButtonImageHover]
	FROM [Advice]

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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateAdvice]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateAdvice]
GO

CREATE PROCEDURE [dbo].[UpdateAdvice]
(
	@AdviceID int,
	@Question varchar(250),
	@Answer text,
	@ButtonImage varchar(50) = NULL,
	@ButtonImageHover varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	UPDATE [Advice]
	SET
		[Question] = @Question,
		[Answer] = @Answer,
		[ButtonImage] = @ButtonImage,
		[ButtonImageHover] = @ButtonImageHover
	WHERE
		[AdviceID] = @AdviceID


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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertAdvice]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertAdvice]
GO

CREATE PROCEDURE [dbo].[InsertAdvice]
(
	@AdviceID int = NULL output,
	@Question varchar(250),
	@Answer text,
	@ButtonImage varchar(50) = NULL,
	@ButtonImageHover varchar(50) = NULL
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
		[ButtonImage],
		[ButtonImageHover]
	)
	VALUES
	(
		@Question,
		@Answer,
		@ButtonImage,
		@ButtonImageHover
	)

	SET @Err = @@Error

	SELECT @AdviceID = SCOPE_IDENTITY()

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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteAdvice]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteAdvice]
GO

CREATE PROCEDURE [dbo].[DeleteAdvice]
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
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




