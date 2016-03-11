CREATE TABLE [dbo].[OrderPhoto] (
    [OrderPhotoID]    INT          IDENTITY (1, 1) NOT NULL,
    [ClientPhotoName] VARCHAR (50) NOT NULL,
    [Count]           INT          NOT NULL,
    [Border]          BIT          CONSTRAINT [DF_OrderPhoto_Border] DEFAULT ((0)) NOT NULL,
    [PaperTypeID]     INT          NOT NULL,
    [MerchandiseID]   INT          NOT NULL,
    [OrderID]         INT          NOT NULL,
    [PhotoName]       VARCHAR (50) CONSTRAINT [DF_OrderPhoto_PhotoName] DEFAULT ('a') NOT NULL,
    CONSTRAINT [PK_OrderPhoto] PRIMARY KEY CLUSTERED ([OrderPhotoID] ASC),
    CONSTRAINT [FK_OrderPhoto_Merchandise] FOREIGN KEY ([MerchandiseID]) REFERENCES [dbo].[Merchandise] ([MerchandiseID]),
    CONSTRAINT [FK_OrderPhoto_Order] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Order] ([OrderID]),
    CONSTRAINT [FK_OrderPhoto_PaperType] FOREIGN KEY ([PaperTypeID]) REFERENCES [dbo].[PaperType] ([PaperTypeID])
);

