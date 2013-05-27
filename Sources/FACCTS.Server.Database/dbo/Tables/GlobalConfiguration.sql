CREATE TABLE [dbo].[GlobalConfiguration] (
    [Id] [int] NOT NULL IDENTITY,
    [SiteName] [nvarchar](max) NOT NULL,
    [IssuerUri] [nvarchar](max) NOT NULL,
    [IssuerContactEmail] [nvarchar](max) NOT NULL,
    [DefaultWSTokenType] [nvarchar](max) NOT NULL,
    [DefaultHttpTokenType] [nvarchar](max) NOT NULL,
    [DefaultTokenLifetime] [int] NOT NULL,
    [MaximumTokenLifetime] [int] NOT NULL,
    [SsoCookieLifetime] [int] NOT NULL,
    [RequireEncryption] [bit] NOT NULL,
    [RequireRelyingPartyRegistration] [bit] NOT NULL,
    [EnableClientCertificateAuthentication] [bit] NOT NULL,
    [EnforceUsersGroupMembership] [bit] NOT NULL,
    [HttpPort] [int] NOT NULL,
    [HttpsPort] [int] NOT NULL,
    CONSTRAINT [PK_dbo.GlobalConfiguration] PRIMARY KEY ([Id])
)