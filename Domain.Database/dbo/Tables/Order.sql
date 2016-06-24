CREATE TABLE [dbo].[Order] (
    [OrderId]     BIGINT             IDENTITY (300001, 1) NOT NULL,
    [OrderNumber] NVARCHAR (50)      NOT NULL,
    [OrderTotal]  DECIMAL (18, 2)    NOT NULL,
    [IsDeleted]   BIT                CONSTRAINT [DF_Order_IsDeleted] DEFAULT ((0)) NOT NULL,
    [IsArchived]  BIT                CONSTRAINT [DF_Order_IsArchived] DEFAULT ((0)) NOT NULL,
    [Created]     DATETIMEOFFSET (7) CONSTRAINT [DF_Order_Created] DEFAULT (sysdatetimeoffset()) NOT NULL,
    [LastUpdated] DATETIMEOFFSET (7) NULL,
    [RowId]       UNIQUEIDENTIFIER   CONSTRAINT [DF_Order_RowId] DEFAULT (newid()) NOT NULL,
    [Watermark]   ROWVERSION         NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([OrderId] ASC)
);

