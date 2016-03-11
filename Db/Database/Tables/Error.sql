CREATE TABLE [dbo].[Error] (
    [ErrorID]     INT             IDENTITY (1, 1) NOT NULL,
    [Date]        SMALLDATETIME   NOT NULL,
    [StackTrace]  TEXT            NULL,
    [Browser]     NVARCHAR (1024) NULL,
    [Name]        NVARCHAR (4000) NULL,
    [Description] NVARCHAR (4000) NULL,
    [Session]     TEXT            NULL,
    [OrderID]     INT             NULL,
    CONSTRAINT [PK_Error] PRIMARY KEY CLUSTERED ([ErrorID] ASC)
);

