CREATE TABLE [dbo].[OrderItem] (
    [OrderItemId] BIGINT             IDENTITY (100001, 1) NOT NULL,
    [OrderId]     BIGINT             NOT NULL,
    [ProductId]   BIGINT             NOT NULL,
    [Quantity]    INT                NOT NULL,
    [UnitPrice]   DECIMAL (18, 2)    NOT NULL,
    [TotalPrice]  DECIMAL (18, 2)    NOT NULL,
    [IsArchived]  BIT                CONSTRAINT [DF_OrderProduct_IsArchived] DEFAULT ((0)) NOT NULL,
    [Created]     DATETIMEOFFSET (7) CONSTRAINT [DF_OrderProduct_Created] DEFAULT (sysdatetimeoffset()) NOT NULL,
    [LastUpdated] DATETIMEOFFSET (7) NULL,
    [RowId]       UNIQUEIDENTIFIER   CONSTRAINT [DF_OrderProduct_RowId] DEFAULT (newid()) NOT NULL,
    [Watermark]   ROWVERSION         NOT NULL,
    CONSTRAINT [PK_OrderProduct] PRIMARY KEY CLUSTERED ([OrderItemId] ASC),
    CONSTRAINT [FK_OrderProduct_Order] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([OrderId]),
    CONSTRAINT [FK_OrderProduct_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId])
);

