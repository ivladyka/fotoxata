CREATE TABLE [dbo].[News] (
    [NewsID]         INT           IDENTITY (1, 1) NOT NULL,
    [Title]          VARCHAR (50)  NULL,
    [NewsContent]    VARCHAR (MAX) NOT NULL,
    [DateNews]       DATETIME      NOT NULL,
    [DateExpired]    DATETIME      NULL,
    [Title_ru]       VARCHAR (50)  NULL,
    [Title_en]       VARCHAR (50)  NULL,
    [NewsContent_ru] VARCHAR (MAX) NULL,
    [NewsContent_en] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED ([NewsID] ASC)
);

