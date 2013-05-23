CREATE TABLE [dbo].[OAuth_Client]
(
	[ClientId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT (newid()), 
    [ClientIdentifier] NVARCHAR(50) NOT NULL, 
    [ClientSecret] NVARCHAR(50) NULL, 
    [Callback] NVARCHAR(150) NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [ClientType] INT NOT NULL DEFAULT 0
)
