DECLARE @ClientID uniqueidentifier = CONVERT(uniqueidentifier, N'b8e55a36-04ff-4eee-8e77-fa792e8fa2aa')

if not exists (select 1 from [dbo].[OAuth_Client] where ClientId = @ClientID)
	insert into [dbo].[OAuth_Client] (ClientId, ClientIdentifier, ClientSecret, ClientType, Name)
		values (@ClientID, N'239E8EFF-5426-4C90-B856-1B969C6981B8', N'4067B0C1-401F-4D46-B56B-6B39C971B222', 1, N'Sample client')