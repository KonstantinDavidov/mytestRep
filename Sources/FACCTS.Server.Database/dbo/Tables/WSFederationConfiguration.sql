CREATE TABLE [dbo].[WSFederationConfiguration] (
    [Id] [int] NOT NULL IDENTITY,
    [Enabled] [bit] NOT NULL,
    [EnableAuthentication] [bit] NOT NULL,
    [EnableFederation] [bit] NOT NULL,
    [EnableHrd] [bit] NOT NULL,
    [AllowReplyTo] [bit] NOT NULL,
    [RequireReplyToWithinRealm] [bit] NOT NULL,
    [RequireSslForReplyTo] [bit] NOT NULL,
    CONSTRAINT [PK_dbo.WSFederationConfiguration] PRIMARY KEY ([Id])
)