CREATE TABLE [dbo].[Delegation] (
    [Id] [int] NOT NULL IDENTITY,
    [UserName] [nvarchar](max) NOT NULL,
    [Realm] [nvarchar](max) NOT NULL,
    [Description] [nvarchar](max),
    CONSTRAINT [PK_dbo.Delegation] PRIMARY KEY ([Id])
)