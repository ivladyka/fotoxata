
CREATE PROCEDURE dbo.DeletePaperType
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