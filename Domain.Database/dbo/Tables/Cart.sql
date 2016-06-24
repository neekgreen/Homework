CREATE TABLE [dbo].[Cart] (
    [CartId]      BIGINT             IDENTITY (600000, 1) NOT NULL,
    [CartTotal]   DECIMAL (18, 2)    NOT NULL,
    [Created]     DATETIMEOFFSET (7) CONSTRAINT [DF_Cart_Created] DEFAULT (sysdatetimeoffset()) NOT NULL,
    [LastUpdated] DATETIMEOFFSET (7) NULL,
    [RowId]       UNIQUEIDENTIFIER   CONSTRAINT [DF_Cart_RowId] DEFAULT (newid()) NOT NULL,
    [Watermark]   ROWVERSION         NOT NULL,
    CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED ([CartId] ASC)
);

