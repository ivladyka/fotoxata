
CREATE PROCEDURE [dbo].[InsertOrderPhoto]
(
	@OrderPhotoID int = NULL output,
	@ClientPhotoName varchar(50),
	@Count int,
	@Border bit,
	@PaperTypeID int,
	@MerchandiseID int,
	@OrderID int,
	@PhotoName varchar(50)
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	INSERT
	INTO [OrderPhoto]
	(
		[ClientPhotoName],
		[Count],
		[Border],
		[PaperTypeID],
		[MerchandiseID],
		[OrderID],
		[PhotoName]
	)
	VALUES
	(
		@ClientPhotoName,
		@Count,
		@Border,
		@PaperTypeID,
		@MerchandiseID,
		@OrderID,
		@PhotoName
	)

	SET @Err = @@Error

	SELECT @OrderPhotoID = SCOPE_IDENTITY()

	RETURN @Err
END