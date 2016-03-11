CREATE TABLE [dbo].[Merchandise] (
    [MerchandiseID]  INT            IDENTITY (1, 1) NOT NULL,
    [Name]           VARCHAR (50)   NOT NULL,
    [PhotoName]      VARCHAR (50)   NULL,
    [CategoryID]     INT            NOT NULL,
    [PriceFrom]      MONEY          NULL,
    [PriceTo]        MONEY          NULL,
    [DisplayOnPrice] BIT            CONSTRAINT [DF_Merchandise_DisplayOnPrice] DEFAULT ((0)) NOT NULL,
    [Description]    VARCHAR (4000) NULL,
    [Name_ru]        VARCHAR (50)   NULL,
    [Name_en]        VARCHAR (50)   NULL,
    [Description_ru] VARCHAR (4000) NULL,
    [Description_en] VARCHAR (4000) NULL,
    CONSTRAINT [PK_Merchandise] PRIMARY KEY CLUSTERED ([MerchandiseID] ASC)
);

