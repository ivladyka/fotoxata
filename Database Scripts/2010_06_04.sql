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
	FROM 
		[Appointment]
	INNER JOIN
        PhotoSalon ON Appointment.PhotoSalonID = PhotoSalon.PhotoSalonID
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





INSERT INTO [Fotoxata].[dbo].[PhotoSalon]
           ([Address])
     VALUES
           ('вул. Сихівська, 11')
GO

INSERT INTO [Fotoxata].[dbo].[PhotoSalon]
           ([Address])
     VALUES
           ('вул. Петлюри, 2')
GO

INSERT INTO [Fotoxata].[dbo].[PhotoSalon]
           ([Address])
     VALUES
           ('вул. Городоцька, 12')
GO

INSERT INTO [Fotoxata].[dbo].[PhotoSalon]
           ([Address])
     VALUES
           ('вул. Франка, 71')
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
ALTER TABLE dbo.Appointment
	DROP COLUMN Description
GO
ALTER TABLE dbo.Appointment SET (LOCK_ESCALATION = TABLE)
GO
COMMIT



SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[LoadAppointmentByPrimaryKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[LoadAppointmentByPrimaryKey]
GO

CREATE PROCEDURE [dbo].[LoadAppointmentByPrimaryKey]
(
	@AppointmentID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[AppointmentID],
		[UserID],
		[StartTime],
		[EndTime],
		[Subject],
		[AssignedBy],
		[AssignedDate],
		[PhotoSalonID],
		[MoneyAdvance],
		[PhoneNumber]
	FROM [Appointment]
	WHERE
		([AppointmentID] = @AppointmentID)

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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[LoadAllAppointment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[LoadAllAppointment]
GO

CREATE PROCEDURE [dbo].[LoadAllAppointment]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[AppointmentID],
		[UserID],
		[StartTime],
		[EndTime],
		[Subject],
		[AssignedBy],
		[AssignedDate],
		[PhotoSalonID],
		[MoneyAdvance],
		[PhoneNumber]
	FROM [Appointment]

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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateAppointment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateAppointment]
GO

CREATE PROCEDURE [dbo].[UpdateAppointment]
(
	@AppointmentID int,
	@UserID int,
	@StartTime datetime,
	@EndTime datetime,
	@Subject varchar(255),
	@AssignedBy int,
	@AssignedDate datetime,
	@PhotoSalonID int,
	@MoneyAdvance money = NULL,
	@PhoneNumber varchar(20) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	UPDATE [Appointment]
	SET
		[UserID] = @UserID,
		[StartTime] = @StartTime,
		[EndTime] = @EndTime,
		[Subject] = @Subject,
		[AssignedBy] = @AssignedBy,
		[AssignedDate] = @AssignedDate,
		[PhotoSalonID] = @PhotoSalonID,
		[MoneyAdvance] = @MoneyAdvance,
		[PhoneNumber] = @PhoneNumber
	WHERE
		[AppointmentID] = @AppointmentID


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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertAppointment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertAppointment]
GO

CREATE PROCEDURE [dbo].[InsertAppointment]
(
	@AppointmentID int = NULL output,
	@UserID int,
	@StartTime datetime,
	@EndTime datetime,
	@Subject varchar(255),
	@AssignedBy int,
	@AssignedDate datetime,
	@PhotoSalonID int,
	@MoneyAdvance money = NULL,
	@PhoneNumber varchar(20) = NULL
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	INSERT
	INTO [Appointment]
	(
		[UserID],
		[StartTime],
		[EndTime],
		[Subject],
		[AssignedBy],
		[AssignedDate],
		[PhotoSalonID],
		[MoneyAdvance],
		[PhoneNumber]
	)
	VALUES
	(
		@UserID,
		@StartTime,
		@EndTime,
		@Subject,
		@AssignedBy,
		@AssignedDate,
		@PhotoSalonID,
		@MoneyAdvance,
		@PhoneNumber
	)

	SET @Err = @@Error

	SELECT @AppointmentID = SCOPE_IDENTITY()

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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteAppointment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteAppointment]
GO

CREATE PROCEDURE [dbo].[DeleteAppointment]
(
	@AppointmentID int
)
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	DELETE
	FROM [Appointment]
	WHERE
		[AppointmentID] = @AppointmentID
	SET @Err = @@Error

	RETURN @Err
END
GO
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




