CREATE TABLE [dbo].[WSTrustConfiguration] (
    [Id] [int] NOT NULL IDENTITY,
    [Enabled] [bit] NOT NULL,
    [EnableMessageSecurity] [bit] NOT NULL,
    [EnableMixedModeSecurity] [bit] NOT NULL,
    [EnableClientCertificateAuthentication] [bit] NOT NULL,
    [EnableFederatedAuthentication] [bit] NOT NULL,
    [EnableDelegation] [bit] NOT NULL,
    CONSTRAINT [PK_dbo.WSTrustConfiguration] PRIMARY KEY ([Id])
)