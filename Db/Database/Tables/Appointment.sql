CREATE TABLE [dbo].[Appointment] (
    [AppointmentID] INT           IDENTITY (1, 1) NOT NULL,
    [UserID]        INT           NOT NULL,
    [StartTime]     DATETIME      NOT NULL,
    [EndTime]       DATETIME      NOT NULL,
    [Subject]       VARCHAR (255) NOT NULL,
    [AssignedBy]    INT           NOT NULL,
    [AssignedDate]  DATETIME      NOT NULL,
    [PhotoSalonID]  INT           NOT NULL,
    [MoneyAdvance]  MONEY         NULL,
    [PhoneNumber]   VARCHAR (20)  NULL,
    CONSTRAINT [PK_Appointment] PRIMARY KEY CLUSTERED ([AppointmentID] ASC),
    CONSTRAINT [FK_Appointment_PhotoSalon] FOREIGN KEY ([PhotoSalonID]) REFERENCES [dbo].[PhotoSalon] ([PhotoSalonID]),
    CONSTRAINT [FK_Appointment_User] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([UserID]),
    CONSTRAINT [FK_Appointment_User1] FOREIGN KEY ([AssignedBy]) REFERENCES [dbo].[User] ([UserID])
);

