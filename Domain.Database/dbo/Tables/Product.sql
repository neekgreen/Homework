CREATE TABLE [dbo].[Product] (
    [ProductId]   BIGINT             IDENTITY (500001, 1) NOT NULL,
    [CommonName]  NVARCHAR (50)      NOT NULL,
    [UnitPrice]   DECIMAL (18, 2)    NOT NULL,
    [IsDeleted]   BIT                CONSTRAINT [DF_Product_IsDeleted] DEFAULT ((0)) NOT NULL,
    [IsArchived]  BIT                CONSTRAINT [DF_Product_IsArchived] DEFAULT ((0)) NOT NULL,
    [Created]     DATETIMEOFFSET (7) CONSTRAINT [DF_Product_Created] DEFAULT (sysdatetimeoffset()) NOT NULL,
    [LastUpdated] DATETIMEOFFSET (7) NULL,
    [RowId]       UNIQUEIDENTIFIER   CONSTRAINT [DF_Product_RowId] DEFAULT (newid()) NOT NULL,
    [Watermark]   ROWVERSION         NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([ProductId] ASC)
);

