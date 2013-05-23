DECLARE @AppIdStr nvarchar(max) = N'655509CC-8A9A-454A-A706-97F9FFC46474'
DECLARE @AppId uniqueidentifier = CONVERT(uniqueidentifier, @AppIdStr)
DECLARE @RoleAdmin nvarchar(256) = N'Administrator'
DECLARE @LoweredRoleAdmin nvarchar(256) = N'administrator'
DECLARE @AdminRoleId uniqueidentifier = Convert(uniqueidentifier, N'1F895650-4D00-4445-AFB8-E21A532821BB')

DECLARE @CourtClerkRoleID uniqueidentifier = CONVERT(uniqueidentifier, N'5167D76E-B22F-485E-B3F9-DAFB97B90830')
DECLARE @RoleCourtClerk nvarchar(256) = N'Court Clerk'
DECLARE @RoleCourtClerkLowered nvarchar(256) = N'court clerk'

DECLARE @JudicialOfficerID uniqueidentifier = CONVERT(uniqueidentifier, N'328DAD44-A87C-4253-B18C-0D557F7B9412')
DECLARE @RoleJudicialOfficer nvarchar(256) = N'Judicial Officer'
DECLARE @RoleJudicialOfficerLowered nvarchar(256) = N'judicial officer'

DECLARE @DefaultUserId uniqueidentifier = CONVERT(uniqueidentifier, N'5518737B-67C1-496D-A6BC-7203837EBF27')

if not exists(Select * from [dbo].[aspnet_SchemaVersions])
begin
	insert into dbo.aspnet_SchemaVersions (Feature, CompatibleSchemaVersion, IsCurrentVersion)
		values('common', 1, 1)
	insert into dbo.aspnet_SchemaVersions (Feature, CompatibleSchemaVersion, IsCurrentVersion)
		values('membership', 1, 1)
	insert into dbo.aspnet_SchemaVersions (Feature, CompatibleSchemaVersion, IsCurrentVersion)
		values('role manager', 1, 1)
end

if not exists (Select * from [dbo].[aspnet_Applications] where LoweredApplicationName = 'faccts')
	insert into [dbo].[aspnet_Applications] (ApplicationName, LoweredApplicationName, Description, ApplicationId)
		values ('FACCTS', 'faccts', 'Family Court Case Tracking System', @AppId)
if not exists (Select * from [dbo].[aspnet_Roles] where RoleId = @AdminRoleId)
	insert into [dbo].[aspnet_Roles] (ApplicationId, RoleName, LoweredRoleName, RoleId)
		values (@AppId, @RoleAdmin, @LoweredRoleAdmin, @AdminRoleId)
if not exists(Select * from [dbo].[aspnet_Roles] where RoleId = @CourtClerkRoleID)	
	insert into [dbo].[aspnet_Roles] (ApplicationId, RoleName, LoweredRoleName, RoleId)
		values (@AppId, @RoleCourtClerk, @RoleCourtClerkLowered, @CourtClerkRoleID)
if not exists (Select * from [dbo].[aspnet_Roles] where RoleId = @JudicialOfficerID)
	insert into [dbo].[aspnet_Roles] (ApplicationId, RoleName, LoweredRoleName, RoleId)
		values (@AppId, @RoleJudicialOfficer, @RoleJudicialOfficerLowered, @JudicialOfficerID)

if not exists (Select * from [dbo].[aspnet_Users] where UserId = @DefaultUserId)
	insert into [dbo].[aspnet_Users] (ApplicationId, UserId, UserName, LoweredUserName, IsAnonymous, LastActivityDate)
		values (@AppId, @DefaultUserId, N'UncleSam', N'unclesam', 0, GETDATE())
if not exists (Select * from [dbo].[aspnet_UsersInRoles] where UserId = @DefaultUserId)
	insert into [dbo].[aspnet_UsersInRoles] (UserId, RoleId)
		values (@DefaultUserId, @AdminRoleId)