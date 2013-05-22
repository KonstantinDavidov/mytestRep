CREATE TABLE [dbo].[OAuth_SymmetricCryptoKey]
(
	[Bucket] NVARCHAR(50) NOT NULL , 
    [Handle] NVARCHAR(50) NOT NULL, 
    [ExpiresUtc] DATETIME NOT NULL, 
    [Secret] VARBINARY(50) NOT NULL, 
    PRIMARY KEY ([Bucket], [Handle])
)
