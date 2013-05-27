CREATE TABLE [dbo].[Client] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](max) NOT NULL,
    [Description] [nvarchar](max) NOT NULL,
    [ClientId] [nvarchar](max) NOT NULL,
    [ClientSecret] [nvarchar](max) NOT NULL,
    [RedirectUri] [nvarchar](max),
    [NativeClient] [bit] NOT NULL,
    [AllowImplicitFlow] [bit] NOT NULL,
    [AllowResourceOwnerFlow] [bit] NOT NULL,
    [AllowCodeFlow] [bit] NOT NULL,
    CONSTRAINT [PK_dbo.Client] PRIMARY KEY ([Id])
)