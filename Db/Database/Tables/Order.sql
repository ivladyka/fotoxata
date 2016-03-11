CREATE TABLE [dbo].[Order] (
    [OrderID]       INT              IDENTITY (1, 1) NOT NULL,
    [OrderStatusID] INT              NULL,
    [DeliveryID]    INT              NOT NULL,
    [ClientNote]    VARCHAR (2000)   NULL,
    [OfficeNote]    VARCHAR (2000)   NULL,
    [Amount]        MONEY            NULL,
    [CellPhone]     VARCHAR (50)     NULL,
    [UserID]        INT              NULL,
    [DateCreated]   DATETIME         NULL,
    [PhotoCount]    INT              NULL,
    [OrderGuid]     UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Order_1] PRIMARY KEY CLUSTERED ([OrderID] ASC),
    CONSTRAINT [FK_Order_Delivery] FOREIGN KEY ([DeliveryID]) REFERENCES [dbo].[Delivery] ([DeliveryID]),
    CONSTRAINT [FK_Order_OrderStatus] FOREIGN KEY ([OrderStatusID]) REFERENCES [dbo].[OrderStatus] ([OrderStatusID]),
    CONSTRAINT [FK_Order_User] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([UserID])
);



