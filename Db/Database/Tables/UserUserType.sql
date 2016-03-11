CREATE TABLE [dbo].[UserUserType] (
    [UserID]     INT NOT NULL,
    [UserTypeID] INT NOT NULL,
    CONSTRAINT [PK_UserUserType] PRIMARY KEY CLUSTERED ([UserID] ASC, [UserTypeID] ASC),
    CONSTRAINT [FK_UserUserType_User] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([UserID]),
    CONSTRAINT [FK_UserUserType_UserType] FOREIGN KEY ([UserTypeID]) REFERENCES [dbo].[UserType] ([UserTypeID])
);

