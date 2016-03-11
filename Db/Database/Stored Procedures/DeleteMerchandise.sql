
CREATE PROCEDURE dbo.DeleteMerchandise
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