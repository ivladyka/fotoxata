SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_Appointment_LoadByUserID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_Appointment_LoadByUserID]
GO

CREATE PROCEDURE [dbo].[usp_Appointment_LoadByUserID]
(
	@UserID int,
	@DateStart datetime,
	@DateEnd datetime
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT 
		[Appointment].[AppointmentID]
		,[Appointment].[UserID]
		,[Appointment].[StartTime]
		,[Appointment].[EndTime]
		,[Appointment].[Subject]
		,[Appointment].[AssignedBy]
		,[Appointment].[AssignedDate]
		,[Appointment].[PhotoSalonID]
		,[Appointment].[MoneyAdvance]
		,[Appointment].[PhoneNumber]
		,PhotoSalon.Address AS PhotoSalonAddress
		,CASE 
		   WHEN
			[User].FirstName IS NULL AND [User].LastName IS NULL THEN [User].CellPhone
		   ELSE
			LTRIM(RTRIM(ISNULL([User].FirstName, '') + ' ' + ISNULL([User].LastName, ''))) END + ' ' 
		+ CONVERT(varchar(30), AssignedDate, 104) + ' ' + CONVERT(varchar(30), AssignedDate, 114) AS AssignedUserName
	FROM 
		[Appointment]
	INNER JOIN
        PhotoSalon ON Appointment.PhotoSalonID = PhotoSalon.PhotoSalonID
    INNER JOIN
        [User] ON AssignedBy = [User].UserID
	WHERE
		[Appointment].[UserID] = @UserID
		AND
		[Appointment].[StartTime] Between @DateStart AND @DateEnd

	SET @Err = @@Error

	RETURN @Err
END
GO
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



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
CREATE TABLE dbo.Category
	(
	CategoryID int NOT NULL IDENTITY (1, 1),
	Name varchar(255) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Category ADD CONSTRAINT
	PK_Category PRIMARY KEY CLUSTERED 
	(
	CategoryID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Category SET (LOCK_ESCALATION = TABLE)
GO
COMMIT




