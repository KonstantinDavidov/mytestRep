CREATE TABLE [dbo].[OAuth_ClientAuthorization]
(
	[AuthorizationId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT (newid()), 
    [CreatedOnUtc] DATETIME NOT NULL, 
    [ClientId] UNIQUEIDENTIFIER NOT NULL, 
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    [Scope] NVARCHAR(MAX) NOT NULL, 
    [ExpirationDateUtc] DATETIME NULL, 
    CONSTRAINT [FK_OAuth_ClientAuthorization_ToOAuthClient] FOREIGN KEY ([ClientId]) REFERENCES [OAuth_Client]([ClientId]), 
    CONSTRAINT [FK_OAuth_ClientAuthorization_ToOAuthUsers] FOREIGN KEY ([UserId]) REFERENCES [OAuth_Users]([UserId])
)
