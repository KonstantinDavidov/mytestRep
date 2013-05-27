CREATE TABLE [dbo].[AdfsIntegrationConfiguration] (
    [Id] [int] NOT NULL IDENTITY,
    [Enabled] [bit] NOT NULL,
    [UsernameAuthenticationEnabled] [bit] NOT NULL,
    [SamlAuthenticationEnabled] [bit] NOT NULL,
    [JwtAuthenticationEnabled] [bit] NOT NULL,
    [PassThruAuthenticationToken] [bit] NOT NULL,
    [AuthenticationTokenLifetime] [int] NOT NULL,
    [UserNameAuthenticationEndpoint] [nvarchar](max),
    [FederationEndpoint] [nvarchar](max),
    [IssuerUri] [nvarchar](max),
    [IssuerThumbprint] [nvarchar](max),
    [EncryptionCertificate] [nvarchar](max),
    CONSTRAINT [PK_dbo.AdfsIntegrationConfiguration] PRIMARY KEY ([Id])
)