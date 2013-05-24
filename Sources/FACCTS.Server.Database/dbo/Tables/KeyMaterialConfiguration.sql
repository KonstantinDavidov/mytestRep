CREATE TABLE [dbo].[KeyMaterialConfiguration] (
    [Id] [int] NOT NULL IDENTITY,
    [SigningCertificateName] [nvarchar](max),
    [DecryptionCertificateName] [nvarchar](max),
    [RSASigningKey] [nvarchar](max),
    [SymmetricSigningKey] [nvarchar](max),
    CONSTRAINT [PK_dbo.KeyMaterialConfiguration] PRIMARY KEY ([Id])
)