CREATE TABLE [dbo].[OrderStatus] (
    [OrderStatusID] INT          IDENTITY (1, 1) NOT NULL,
    [Name]          VARCHAR (50) NOT NULL,
    [Active]        BIT          CONSTRAINT [DF_OrderStatus_Active_1] DEFAULT ((1)) NOT NULL,
    [Name_ru]       VARCHAR (50) NULL,
    [Name_en]       VARCHAR (50) NULL,
    CONSTRAINT [PK_OrderStatus_1] PRIMARY KEY CLUSTERED ([OrderStatusID] ASC)
);

