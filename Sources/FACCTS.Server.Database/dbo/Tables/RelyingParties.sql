CREATE TABLE [dbo].[RelyingParties] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](max) NOT NULL,
    [Enabled] [bit] NOT NULL,
    [Realm] [nvarchar](max) NOT NULL,
    [TokenLifeTime] [int] NOT NULL,
    [ReplyTo] [nvarchar](max),
    [EncryptingCertificate] [nvarchar](max),
    [SymmetricSigningKey] [nvarchar](max),
    [ExtraData1] [nvarchar](max),
    [ExtraData2] [nvarchar](max),
    [ExtraData3] [nvarchar](max),
    CONSTRAINT [PK_dbo.RelyingParties] PRIMARY KEY ([Id])
)