CREATE TABLE [dbo].[PaperType] (
    [PaperTypeID] INT          NOT NULL,
    [Name]        VARCHAR (50) NOT NULL,
    [Name_ru]     VARCHAR (50) NULL,
    [Name_en]     VARCHAR (50) NULL,
    CONSTRAINT [PK_PaperType] PRIMARY KEY CLUSTERED ([PaperTypeID] ASC)
);

