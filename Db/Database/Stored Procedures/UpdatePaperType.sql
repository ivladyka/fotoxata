
CREATE PROCEDURE dbo.UpdatePaperType
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