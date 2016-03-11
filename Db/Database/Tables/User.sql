CREATE TABLE [dbo].[User] (
    [UserID]       INT          IDENTITY (1, 1) NOT NULL,
    [CellPhone]    VARCHAR (50) NOT NULL,
    [FirstName]    VARCHAR (50) NULL,
    [LastName]     VARCHAR (50) NULL,
    [Password]     VARCHAR (50) NOT NULL,
    [EMailAddress] VARCHAR (50) NULL,
    [PhotoSalonID] INT          NULL,
    [Active]       BIT          CONSTRAINT [DF_User_Active] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [FK_User_PhotoSalon] FOREIGN KEY ([PhotoSalonID]) REFERENCES [dbo].[PhotoSalon] ([PhotoSalonID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserCellPhone]
    ON [dbo].[User]([CellPhone] ASC);

