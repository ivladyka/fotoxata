
CREATE PROCEDURE dbo.InsertPaperType
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