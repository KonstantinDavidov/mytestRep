CREATE TABLE [dbo].[OAuth_Users]
(
	[UserId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT (newid()), 
    [OpenIDClaimedIdentifier] NVARCHAR(150) NOT NULL, 
    [OpenIDFriendlyIdentifier] NVARCHAR(150) NULL 
)
