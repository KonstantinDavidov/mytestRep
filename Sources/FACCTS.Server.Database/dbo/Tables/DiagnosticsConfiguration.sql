CREATE TABLE [dbo].[DiagnosticsConfiguration] (
    [Id] [int] NOT NULL IDENTITY,
    [EnableFederationMessageTracing] [bit] NOT NULL,
    CONSTRAINT [PK_dbo.DiagnosticsConfiguration] PRIMARY KEY ([Id])
)