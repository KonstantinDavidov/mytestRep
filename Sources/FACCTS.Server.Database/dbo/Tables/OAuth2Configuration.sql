CREATE TABLE [dbo].[OAuth2Configuration] (
    [Id] [int] NOT NULL IDENTITY,
    [Enabled] [bit] NOT NULL,
    [EnableConsent] [bit] NOT NULL,
    [EnableResourceOwnerFlow] [bit] NOT NULL,
    [EnableImplicitFlow] [bit] NOT NULL,
    CONSTRAINT [PK_dbo.OAuth2Configuration] PRIMARY KEY ([Id])
)