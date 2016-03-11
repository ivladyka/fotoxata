CREATE TABLE [dbo].[Category] (
    [CategoryID]         INT           IDENTITY (1, 1) NOT NULL,
    [Name]               VARCHAR (255) NOT NULL,
    [IsGallery]          BIT           CONSTRAINT [DF_Category_IsGallery] DEFAULT ((0)) NOT NULL,
    [PriceFrom]          MONEY         NULL,
    [PriceTo]            MONEY         NULL,
    [DisplayOnPrice]     BIT           CONSTRAINT [DF_Category_DisplayOnPrice] DEFAULT ((0)) NOT NULL,
    [Title]              VARCHAR (255) NULL,
    [CategoryContent]    VARCHAR (MAX) NULL,
    [Name_ru]            VARCHAR (255) NULL,
    [Title_ru]           VARCHAR (255) NULL,
    [CategoryContent_ru] VARCHAR (MAX) NULL,
    [Name_en]            VARCHAR (255) NULL,
    [Title_en]           VARCHAR (255) NULL,
    [CategoryContent_en] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([CategoryID] ASC)
);

