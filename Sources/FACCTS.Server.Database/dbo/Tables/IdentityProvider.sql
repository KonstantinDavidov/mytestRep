CREATE TABLE [dbo].[IdentityProvider] (
    [ID] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](max) NOT NULL,
    [DisplayName] [nvarchar](max) NOT NULL,
    [Type] [int] NOT NULL,
    [ShowInHrdSelection] [bit] NOT NULL,
    [WSFederationEndpoint] [nvarchar](max),
    [IssuerThumbprint] [nvarchar](max),
    [ClientID] [nvarchar](max),
    [ClientSecret] [nvarchar](max),
    [OAuth2ProviderType] [int],
    [Enabled] [bit] NOT NULL,
    CONSTRAINT [PK_dbo.IdentityProvider] PRIMARY KEY ([ID])
)