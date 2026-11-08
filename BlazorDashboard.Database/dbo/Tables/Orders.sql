CREATE TABLE [dbo].[Orders]
(
    [Id] nvarchar(128) NOT NULL CONSTRAINT [PK_Orders] PRIMARY KEY,
    [Customer] nvarchar(256) NOT NULL,
    [Status] nvarchar(32) NOT NULL,
    [Total] decimal(18, 2) NOT NULL
);
