CREATE TABLE [dbo].[Advice] (
    [AdviceID]    INT           IDENTITY (1, 1) NOT NULL,
    [Question]    VARCHAR (250) NOT NULL,
    [Answer]      VARCHAR (MAX) NOT NULL,
    [Question_ru] VARCHAR (250) NULL,
    [Question_en] VARCHAR (250) NULL,
    [Answer_ru]   VARCHAR (MAX) NULL,
    [Answer_en]   VARCHAR (MAX) NULL,
    CONSTRAINT [PK_Advice] PRIMARY KEY CLUSTERED ([AdviceID] ASC)
);

