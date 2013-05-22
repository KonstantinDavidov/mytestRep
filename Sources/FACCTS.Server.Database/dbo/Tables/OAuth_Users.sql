CREATE TABLE [dbo].[OAuth_Users]
(
	[UserId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [OpenIDClaimedIdentifier] NVARCHAR(150) NOT NULL, 
    [OpenIDFriendlyIdentifier] NVARCHAR(150) NULL, 
    CONSTRAINT [FK_OAuth_Users_ToAspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [aspnet_Users]([UserId]) 
)
