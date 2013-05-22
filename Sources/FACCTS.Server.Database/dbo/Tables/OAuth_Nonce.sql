CREATE TABLE [dbo].[OAuth_Nonce]
(
	[Context] NVARCHAR(50) NOT NULL , 
    [Code] VARCHAR(50) NOT NULL, 
    [Timestamp] TIMESTAMP NOT NULL, 
    PRIMARY KEY ([Context], [Code], [Timestamp])
)
