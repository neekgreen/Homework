CREATE TABLE [dbo].[CartItem] (
    [CartItemId]  BIGINT             IDENTITY (1, 1) NOT NULL,
    [CartId]      BIGINT             NULL,
    [ProductId]   BIGINT             NULL,
    [Quantity]    INT                NOT NULL,
    [UnitPrice]   DECIMAL (18, 2)    NOT NULL,
    [TotalPrice]  DECIMAL (18, 2)    NOT NULL,
    [IsDeleted]   BIT                CONSTRAINT [DF_CartItem_IsDeleted] DEFAULT ((0)) NOT NULL,
    [Created]     DATETIMEOFFSET (7) CONSTRAINT [DF_CartItem_Created] DEFAULT (sysdatetimeoffset()) NOT NULL,
    [LastUpdated] DATETIMEOFFSET (7) NULL,
    [RowId]       UNIQUEIDENTIFIER   CONSTRAINT [DF_CartItem_RowId] DEFAULT (newid()) NOT NULL,
    [Watermark]   ROWVERSION         NOT NULL,
    CONSTRAINT [PK_CartItem] PRIMARY KEY CLUSTERED ([CartItemId] ASC),
    CONSTRAINT [FK_CartItem_Cart] FOREIGN KEY ([CartId]) REFERENCES [dbo].[Cart] ([CartId]),
    CONSTRAINT [FK_CartItem_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId])
);

