CREATE TABLE [dbo].[ClientCertificates] (
    [Id] [int] NOT NULL IDENTITY,
    [UserName] [nvarchar](max) NOT NULL,
    [Thumbprint] [nvarchar](max) NOT NULL,
    [Description] [nvarchar](max) NOT NULL,
    CONSTRAINT [PK_dbo.ClientCertificates] PRIMARY KEY ([Id])
)