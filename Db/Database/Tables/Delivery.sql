CREATE TABLE [dbo].[Delivery] (
    [DeliveryID] INT           IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50) NOT NULL,
    [Active]     BIT           CONSTRAINT [DF_Delivery_Active] DEFAULT ((1)) NOT NULL,
    [Name1]      NVARCHAR (50) NULL,
    [Name_ru]    NVARCHAR (50) NULL,
    [Name_en]    NVARCHAR (50) NULL,
    [Name1_ru]   NVARCHAR (50) NULL,
    [Name1_en]   NVARCHAR (50) NULL,
    CONSTRAINT [PK_Delivery] PRIMARY KEY CLUSTERED ([DeliveryID] ASC)
);

