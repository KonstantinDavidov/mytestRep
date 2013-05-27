CREATE TABLE [dbo].[FederationMetadataConfiguration] (
    [Id] [int] NOT NULL IDENTITY,
    [Enabled] [bit] NOT NULL,
    CONSTRAINT [PK_dbo.FederationMetadataConfiguration] PRIMARY KEY ([Id])
)