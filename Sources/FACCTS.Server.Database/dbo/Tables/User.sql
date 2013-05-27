CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [aspnetUserID] UNIQUEIDENTIFIER NOT NULL,
    [firstName] NVARCHAR(50) NULL, 
    [middleName] NVARCHAR(50) NULL, 
    [lastName] NVARCHAR(50) NULL, 
    [phone] NVARCHAR(50) NULL, 
	[isCertified] BIT NOT NULL DEFAULT 0, 
    [image] VARBINARY(MAX) NULL, 
    FOREIGN KEY ([aspnetUserID]) REFERENCES [dbo].[aspnet_Users] ([UserId])
)