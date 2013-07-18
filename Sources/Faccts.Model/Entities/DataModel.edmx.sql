
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 07/17/2013 18:18:37
-- Generated from EDMX file: D:\FACCTS\FACCTSNEW\faccts.net\Sources\Faccts.Model\Entities\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FACCTS_DB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_CourtParty_dbo_Attorneys_Attorney_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtParty] DROP CONSTRAINT [FK_dbo_CourtParty_dbo_Attorneys_Attorney_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CaseHistory_dbo_CourtCaseOrders_CourtCaseOrderId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CaseHistory] DROP CONSTRAINT [FK_dbo_CaseHistory_dbo_CourtCaseOrders_CourtCaseOrderId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CourtCase_dbo_User_CourtClerk_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtCase] DROP CONSTRAINT [FK_dbo_CourtCase_dbo_User_CourtClerk_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CourtDepartmenets_dbo_CourtCounty_CourtCountyId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtDepartmenets] DROP CONSTRAINT [FK_dbo_CourtDepartmenets_dbo_CourtCounty_CourtCountyId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CourtLocations_dbo_CourtCounty_CourtCounty_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtLocations] DROP CONSTRAINT [FK_dbo_CourtLocations_dbo_CourtCounty_CourtCounty_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_FACCTSConfiguration_dbo_CourtCounty_CurrentCourtCountyId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FACCTSConfiguration] DROP CONSTRAINT [FK_dbo_FACCTSConfiguration_dbo_CourtCounty_CurrentCourtCountyId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Courtrooms_dbo_CourtLocations_CourtLocation_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Courtrooms] DROP CONSTRAINT [FK_dbo_Courtrooms_dbo_CourtLocations_CourtLocation_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CourtMember_dbo_CourtMember_SubstituteId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtMember] DROP CONSTRAINT [FK_dbo_CourtMember_dbo_CourtMember_SubstituteId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CourtMember_dbo_User_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtMember] DROP CONSTRAINT [FK_dbo_CourtMember_dbo_User_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CourtParty_dbo_Designation_Designation_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtParty] DROP CONSTRAINT [FK_dbo_CourtParty_dbo_Designation_Designation_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_ManualIntegrationTasks_dbo_User_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ManualIntegrationTasks] DROP CONSTRAINT [FK_dbo_ManualIntegrationTasks_dbo_User_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_ScheduledIntegrationTasks_dbo_User_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScheduledIntegrationTasks] DROP CONSTRAINT [FK_dbo_ScheduledIntegrationTasks_dbo_User_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CaseHistory_dbo_Hearings_Hearing_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CaseHistory] DROP CONSTRAINT [FK_dbo_CaseHistory_dbo_Hearings_Hearing_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Hearings_dbo_Courtrooms_Courtroom_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Hearings] DROP CONSTRAINT [FK_dbo_Hearings_dbo_Courtrooms_Courtroom_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CaseHistory_dbo_CourtCase_MergeCase_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CaseHistory] DROP CONSTRAINT [FK_dbo_CaseHistory_dbo_CourtCase_MergeCase_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Hearings_dbo_CourtDepartmenets_Department_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Hearings] DROP CONSTRAINT [FK_dbo_Hearings_dbo_CourtDepartmenets_Department_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CourtCase_dbo_CourtCase_ParentCase_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtCase] DROP CONSTRAINT [FK_dbo_CourtCase_dbo_CourtCase_ParentCase_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CaseHistory_dbo_CourtCaseOrders_CourtOrder_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CaseHistory] DROP CONSTRAINT [FK_dbo_CaseHistory_dbo_CourtCaseOrders_CourtOrder_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_CourtDocketRecordCourtCase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtDocketRecordSet] DROP CONSTRAINT [FK_CourtDocketRecordCourtCase];
GO
IF OBJECT_ID(N'[dbo].[FK_CourtDocketRecordHearings]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtDocketRecordSet] DROP CONSTRAINT [FK_CourtDocketRecordHearings];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_ThirdPartyData_dbo_Attorneys_Attorney_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ThirdPartyData] DROP CONSTRAINT [FK_dbo_ThirdPartyData_dbo_Attorneys_Attorney_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CaseHistory_dbo_User_CourtClerk_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CaseHistory] DROP CONSTRAINT [FK_dbo_CaseHistory_dbo_User_CourtClerk_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CaseNotes_dbo_User_Author_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CaseNotes] DROP CONSTRAINT [FK_dbo_CaseNotes_dbo_User_Author_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CourtCase_dbo_User_CourtClerk_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtCase] DROP CONSTRAINT [FK_dbo_CourtCase_dbo_User_CourtClerk_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleUser_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleUser] DROP CONSTRAINT [FK_RoleUser_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleUser_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleUser] DROP CONSTRAINT [FK_RoleUser_User];
GO
IF OBJECT_ID(N'[dbo].[FK_RolePermission2_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RolePermission2] DROP CONSTRAINT [FK_RolePermission2_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_RolePermission2_Permission]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RolePermission2] DROP CONSTRAINT [FK_RolePermission2_Permission];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CaseHistory_dbo_CourtCase_CourtCase_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CaseHistory] DROP CONSTRAINT [FK_dbo_CaseHistory_dbo_CourtCase_CourtCase_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CaseNotes_dbo_CourtCase_CourtCase_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CaseNotes] DROP CONSTRAINT [FK_dbo_CaseNotes_dbo_CourtCase_CourtCase_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CourtCase_dbo_CourtCounty_CourtCounty_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtCase] DROP CONSTRAINT [FK_dbo_CourtCase_dbo_CourtCounty_CourtCounty_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_HairColorCourtParty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtParty] DROP CONSTRAINT [FK_HairColorCourtParty];
GO
IF OBJECT_ID(N'[dbo].[FK_CourtPartyRace]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtParty] DROP CONSTRAINT [FK_CourtPartyRace];
GO
IF OBJECT_ID(N'[dbo].[FK_CourtPartyEyesColor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtParty] DROP CONSTRAINT [FK_CourtPartyEyesColor];
GO
IF OBJECT_ID(N'[dbo].[FK_CourtPartyCourtCase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtCase] DROP CONSTRAINT [FK_CourtPartyCourtCase];
GO
IF OBJECT_ID(N'[dbo].[FK_CourtPartyCourtCase1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtCase] DROP CONSTRAINT [FK_CourtPartyCourtCase1];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CaseHistory_dbo_Attorneys_AttorneyForChild_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CaseHistory] DROP CONSTRAINT [FK_dbo_CaseHistory_dbo_Attorneys_AttorneyForChild_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CourtPartyAttorneyData_dbo_Attorneys_Attorney_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtPartyAttorneyData] DROP CONSTRAINT [FK_dbo_CourtPartyAttorneyData_dbo_Attorneys_Attorney_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CaseHistory_dbo_CourtPartyAttorneyData_Party1Attorney_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CaseHistory] DROP CONSTRAINT [FK_dbo_CaseHistory_dbo_CourtPartyAttorneyData_Party1Attorney_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CaseHistory_dbo_CourtPartyAttorneyData_Party2Attorney_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CaseHistory] DROP CONSTRAINT [FK_dbo_CaseHistory_dbo_CourtPartyAttorneyData_Party2Attorney_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CaseHistory_dbo_ThirdPartyData_ThirdPartyData_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CaseHistory] DROP CONSTRAINT [FK_dbo_CaseHistory_dbo_ThirdPartyData_ThirdPartyData_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CourtCase_dbo_CourtParty_Party1_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtCase] DROP CONSTRAINT [FK_dbo_CourtCase_dbo_CourtParty_Party1_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CourtCase_dbo_CourtParty_Party2_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtCase] DROP CONSTRAINT [FK_dbo_CourtCase_dbo_CourtParty_Party2_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_CourtCaseAdditionalParty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdditionalPartySet] DROP CONSTRAINT [FK_CourtCaseAdditionalParty];
GO
IF OBJECT_ID(N'[dbo].[FK_Child_inherits_AdditionalParty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdditionalPartySet_Child] DROP CONSTRAINT [FK_Child_inherits_AdditionalParty];
GO
IF OBJECT_ID(N'[dbo].[FK_OtherProtected_inherits_AdditionalParty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdditionalPartySet_OtherProtected] DROP CONSTRAINT [FK_OtherProtected_inherits_AdditionalParty];
GO
IF OBJECT_ID(N'[dbo].[FK_Interpreter_inherits_AdditionalParty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdditionalPartySet_Interpreter] DROP CONSTRAINT [FK_Interpreter_inherits_AdditionalParty];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AdfsIntegrationConfiguration]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdfsIntegrationConfiguration];
GO
IF OBJECT_ID(N'[dbo].[Attorneys]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Attorneys];
GO
IF OBJECT_ID(N'[dbo].[CaseHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CaseHistory];
GO
IF OBJECT_ID(N'[dbo].[CaseNotes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CaseNotes];
GO
IF OBJECT_ID(N'[dbo].[Client]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Client];
GO
IF OBJECT_ID(N'[dbo].[ClientCertificates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClientCertificates];
GO
IF OBJECT_ID(N'[dbo].[CodeToken]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CodeToken];
GO
IF OBJECT_ID(N'[dbo].[CourtCase]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourtCase];
GO
IF OBJECT_ID(N'[dbo].[CourtCaseOrders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourtCaseOrders];
GO
IF OBJECT_ID(N'[dbo].[CourtCounty]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourtCounty];
GO
IF OBJECT_ID(N'[dbo].[CourtDepartmenets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourtDepartmenets];
GO
IF OBJECT_ID(N'[dbo].[CourtLocations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourtLocations];
GO
IF OBJECT_ID(N'[dbo].[CourtMember]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourtMember];
GO
IF OBJECT_ID(N'[dbo].[CourtParty]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourtParty];
GO
IF OBJECT_ID(N'[dbo].[Courtrooms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Courtrooms];
GO
IF OBJECT_ID(N'[dbo].[Delegation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Delegation];
GO
IF OBJECT_ID(N'[dbo].[Designation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Designation];
GO
IF OBJECT_ID(N'[dbo].[DiagnosticsConfiguration]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DiagnosticsConfiguration];
GO
IF OBJECT_ID(N'[dbo].[EyesColor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EyesColor];
GO
IF OBJECT_ID(N'[dbo].[FACCTSConfiguration]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FACCTSConfiguration];
GO
IF OBJECT_ID(N'[dbo].[FederationMetadataConfiguration]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FederationMetadataConfiguration];
GO
IF OBJECT_ID(N'[dbo].[FormField]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormField];
GO
IF OBJECT_ID(N'[dbo].[GlobalConfiguration]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GlobalConfiguration];
GO
IF OBJECT_ID(N'[dbo].[HairColor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HairColor];
GO
IF OBJECT_ID(N'[dbo].[IdentityProvider]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IdentityProvider];
GO
IF OBJECT_ID(N'[dbo].[KeyMaterialConfiguration]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KeyMaterialConfiguration];
GO
IF OBJECT_ID(N'[dbo].[ManualIntegrationTasks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ManualIntegrationTasks];
GO
IF OBJECT_ID(N'[dbo].[OAuth2Configuration]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OAuth2Configuration];
GO
IF OBJECT_ID(N'[dbo].[Permission]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Permission];
GO
IF OBJECT_ID(N'[dbo].[Race]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Race];
GO
IF OBJECT_ID(N'[dbo].[RelyingParties]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RelyingParties];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[ScheduledIntegrationTasks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScheduledIntegrationTasks];
GO
IF OBJECT_ID(N'[dbo].[SimpleHttpConfiguration]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SimpleHttpConfiguration];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[WSFederationConfiguration]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WSFederationConfiguration];
GO
IF OBJECT_ID(N'[dbo].[WSTrustConfiguration]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WSTrustConfiguration];
GO
IF OBJECT_ID(N'[dbo].[Hearings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Hearings];
GO
IF OBJECT_ID(N'[dbo].[CourtDocketRecordSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourtDocketRecordSet];
GO
IF OBJECT_ID(N'[dbo].[ThirdPartyData]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ThirdPartyData];
GO
IF OBJECT_ID(N'[dbo].[CourtPartyAttorneyData]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourtPartyAttorneyData];
GO
IF OBJECT_ID(N'[dbo].[AdditionalPartySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdditionalPartySet];
GO
IF OBJECT_ID(N'[dbo].[AdditionalPartySet_Child]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdditionalPartySet_Child];
GO
IF OBJECT_ID(N'[dbo].[AdditionalPartySet_OtherProtected]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdditionalPartySet_OtherProtected];
GO
IF OBJECT_ID(N'[dbo].[AdditionalPartySet_Interpreter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdditionalPartySet_Interpreter];
GO
IF OBJECT_ID(N'[dbo].[RoleUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleUser];
GO
IF OBJECT_ID(N'[dbo].[RolePermission2]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RolePermission2];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AdfsIntegrationConfiguration'
CREATE TABLE [dbo].[AdfsIntegrationConfiguration] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Enabled] bit  NOT NULL,
    [UsernameAuthenticationEnabled] bit  NOT NULL,
    [SamlAuthenticationEnabled] bit  NOT NULL,
    [JwtAuthenticationEnabled] bit  NOT NULL,
    [PassThruAuthenticationToken] bit  NOT NULL,
    [AuthenticationTokenLifetime] int  NOT NULL,
    [UserNameAuthenticationEndpoint] nvarchar(max)  NULL,
    [FederationEndpoint] nvarchar(max)  NULL,
    [IssuerUri] nvarchar(max)  NULL,
    [IssuerThumbprint] nvarchar(max)  NULL,
    [EncryptionCertificate] nvarchar(max)  NULL
);
GO

-- Creating table 'Attorneys'
CREATE TABLE [dbo].[Attorneys] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(150)  NULL,
    [LastName] nvarchar(150)  NULL,
    [FirmName] nvarchar(100)  NULL,
    [StreetAddress] nvarchar(200)  NULL,
    [City] nvarchar(100)  NULL,
    [ZipCode] nvarchar(20)  NULL,
    [Phone] nvarchar(20)  NULL,
    [Fax] nvarchar(20)  NULL,
    [Email] nvarchar(50)  NULL,
    [StateBarId] nvarchar(50)  NULL,
    [USAState] int  NOT NULL
);
GO

-- Creating table 'CaseHistory'
CREATE TABLE [dbo].[CaseHistory] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Date] datetime  NULL,
    [CaseHistoryEvent] int  NOT NULL,
    [CCPOR_ID] nvarchar(30)  NULL,
    [CourtCaseOrderId] bigint  NULL,
    [MergeCase_Id] bigint  NULL,
    [CourtOrder_Id] bigint  NULL,
    [CourtClerk_Id] bigint  NULL,
    [CourtCase_Id] bigint  NULL,
    [AttorneyForChild_Id] bigint  NULL,
    [Party1Attorney_Id] bigint  NULL,
    [Party2Attorney_Id] bigint  NULL,
    [ThirdPartyData_Id] bigint  NULL
);
GO

-- Creating table 'CaseNotes'
CREATE TABLE [dbo].[CaseNotes] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Status] int  NOT NULL,
    [Text] nvarchar(max)  NULL,
    [Author_Id] bigint  NULL,
    [CourtCase_Id] bigint  NULL,
    [CaseRecord_Id] bigint  NULL,
    [CourtCase_Id1] bigint  NULL
);
GO

-- Creating table 'Client'
CREATE TABLE [dbo].[Client] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL,
    [ClientId] nvarchar(max)  NULL,
    [ClientSecret] nvarchar(max)  NULL,
    [RedirectUri] nvarchar(max)  NULL,
    [AllowRefreshToken] bit  NOT NULL,
    [AllowImplicitFlow] bit  NOT NULL,
    [AllowResourceOwnerFlow] bit  NOT NULL,
    [AllowCodeFlow] bit  NOT NULL
);
GO

-- Creating table 'ClientCertificates'
CREATE TABLE [dbo].[ClientCertificates] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NULL,
    [Thumbprint] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'CodeToken'
CREATE TABLE [dbo].[CodeToken] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(max)  NULL,
    [ClientId] int  NOT NULL,
    [UserName] nvarchar(max)  NULL,
    [Scope] nvarchar(max)  NULL,
    [Type] int  NOT NULL,
    [TimeStamp] datetime  NOT NULL
);
GO

-- Creating table 'CourtCase'
CREATE TABLE [dbo].[CourtCase] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [CaseNumber] nvarchar(20)  NULL,
    [CCPORStatus] int  NULL,
    [CCPORId] nvarchar(20)  NULL,
    [ParentCase_Id] bigint  NULL,
    [CourtClerk_Id] bigint  NULL,
    [Party1_Id] bigint  NULL,
    [Party2_Id] bigint  NULL,
    [CourtCounty_Id] bigint  NULL,
    [RestrainingPartyIdentificationInformation_IDType] int  NOT NULL,
    [RestrainingPartyIdentificationInformation_IDNumber] nvarchar(max)  NOT NULL,
    [RestrainingPartyIdentificationInformation_IDIssuedDate] datetime  NOT NULL
);
GO

-- Creating table 'CourtCaseOrders'
CREATE TABLE [dbo].[CourtCaseOrders] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [AvailableCourtOrderId] int  NOT NULL,
    [XMLContent] nvarchar(max)  NULL,
    [IsSigned] bit  NOT NULL,
    [ServerFileName] nvarchar(255)  NULL,
    [OrderType] int  NOT NULL
);
GO

-- Creating table 'CourtCounty'
CREATE TABLE [dbo].[CourtCounty] (
    [Id] bigint  NOT NULL,
    [court_code] nvarchar(8)  NULL,
    [county] nvarchar(64)  NULL,
    [court_name] nvarchar(50)  NULL,
    [location] nvarchar(64)  NULL
);
GO

-- Creating table 'CourtDepartmenets'
CREATE TABLE [dbo].[CourtDepartmenets] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(150)  NULL,
    [Room] nvarchar(20)  NULL,
    [BranchOfficer] nvarchar(100)  NULL,
    [Reporter] nvarchar(100)  NULL,
    [CourtCountyId] bigint  NOT NULL
);
GO

-- Creating table 'CourtLocations'
CREATE TABLE [dbo].[CourtLocations] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(150)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [StreetAddress] nvarchar(200)  NULL,
    [PostalCode] nvarchar(20)  NULL,
    [City] nvarchar(100)  NULL,
    [CourtCounty_Id] bigint  NULL,
    [USAState] int  NOT NULL
);
GO

-- Creating table 'CourtMember'
CREATE TABLE [dbo].[CourtMember] (
    [Id] bigint  NOT NULL,
    [SubstituteId] bigint  NULL,
    [IsCertified] bit  NOT NULL,
    [IsAvilable] bit  NOT NULL,
    [Image] varbinary(max)  NULL,
    [Phone] nvarchar(max)  NULL
);
GO

-- Creating table 'CourtParty'
CREATE TABLE [dbo].[CourtParty] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(255)  NULL,
    [MiddleName] nvarchar(255)  NULL,
    [LastName] nvarchar(255)  NULL,
    [Description] nvarchar(max)  NULL,
    [Address] nvarchar(max)  NULL,
    [City] nvarchar(100)  NULL,
    [ZipCode] nvarchar(20)  NULL,
    [Phone] nvarchar(20)  NULL,
    [Fax] nvarchar(20)  NULL,
    [Weight] decimal(18,2)  NOT NULL,
    [HeightFt] decimal(18,2)  NOT NULL,
    [HeightIns] decimal(18,2)  NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [Age] int  NOT NULL,
    [HasAttorney] bit  NULL,
    [Designation_Id] bigint  NULL,
    [HairColor_Id] bigint  NULL,
    [EyesColor_Id] bigint  NULL,
    [Race_Id] bigint  NULL,
    [Attorney_Id] bigint  NULL,
    [ParticipantRole] int  NOT NULL,
    [Sex] int  NOT NULL,
    [ParentRole] nvarchar(50)  NULL,
    [EntityType] int  NOT NULL,
    [Email] nvarchar(max)  NULL,
    [RelationToOtherParty] nvarchar(max)  NULL,
    [USAState] int  NOT NULL
);
GO

-- Creating table 'Courtrooms'
CREATE TABLE [dbo].[Courtrooms] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [RoomName] nvarchar(100)  NULL,
    [CourtLocation_Id] bigint  NULL
);
GO

-- Creating table 'Delegation'
CREATE TABLE [dbo].[Delegation] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Realm] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'Designation'
CREATE TABLE [dbo].[Designation] (
    [Id] bigint  NOT NULL,
    [DesignationName] nvarchar(150)  NULL
);
GO

-- Creating table 'DiagnosticsConfiguration'
CREATE TABLE [dbo].[DiagnosticsConfiguration] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EnableFederationMessageTracing] bit  NOT NULL
);
GO

-- Creating table 'EyesColor'
CREATE TABLE [dbo].[EyesColor] (
    [Id] bigint  NOT NULL,
    [Color] nvarchar(150)  NULL
);
GO

-- Creating table 'FACCTSConfiguration'
CREATE TABLE [dbo].[FACCTSConfiguration] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [CaseNumberAutoGeneration] bit  NOT NULL,
    [CurrentCourtCountyId] bigint  NULL
);
GO

-- Creating table 'FederationMetadataConfiguration'
CREATE TABLE [dbo].[FederationMetadataConfiguration] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Enabled] bit  NOT NULL
);
GO

-- Creating table 'FormField'
CREATE TABLE [dbo].[FormField] (
    [Id] bigint  NOT NULL,
    [form_field_name] nvarchar(150)  NULL,
    [form_name] nvarchar(125)  NULL,
    [field_type] nvarchar(12)  NULL,
    [screen_name] nvarchar(60)  NULL,
    [form_field_id] int  NOT NULL,
    [dupe] nvarchar(5)  NULL,
    [dropdown_options] nvarchar(160)  NULL,
    [bool_options] nvarchar(64)  NULL,
    [screen_panel] nvarchar(32)  NULL,
    [panel_section] nvarchar(32)  NULL,
    [xml_export] nvarchar(200)  NULL
);
GO

-- Creating table 'GlobalConfiguration'
CREATE TABLE [dbo].[GlobalConfiguration] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SiteName] nvarchar(max)  NOT NULL,
    [IssuerUri] nvarchar(max)  NOT NULL,
    [IssuerContactEmail] nvarchar(max)  NOT NULL,
    [DefaultWSTokenType] nvarchar(max)  NOT NULL,
    [DefaultHttpTokenType] nvarchar(max)  NOT NULL,
    [DefaultTokenLifetime] int  NOT NULL,
    [MaximumTokenLifetime] int  NOT NULL,
    [SsoCookieLifetime] int  NOT NULL,
    [RequireEncryption] bit  NOT NULL,
    [RequireRelyingPartyRegistration] bit  NOT NULL,
    [EnableClientCertificateAuthentication] bit  NOT NULL,
    [EnforceUsersGroupMembership] bit  NOT NULL,
    [HttpPort] int  NOT NULL,
    [HttpsPort] int  NOT NULL
);
GO

-- Creating table 'HairColor'
CREATE TABLE [dbo].[HairColor] (
    [Id] bigint  NOT NULL,
    [Color] nvarchar(150)  NULL
);
GO

-- Creating table 'IdentityProvider'
CREATE TABLE [dbo].[IdentityProvider] (
    [Name] nvarchar(max)  NOT NULL,
    [DisplayName] nvarchar(max)  NOT NULL,
    [Type] int  NOT NULL,
    [ShowInHrdSelection] bit  NOT NULL,
    [WSFederationEndpoint] nvarchar(max)  NULL,
    [IssuerThumbprint] nvarchar(max)  NULL,
    [ClientID] nvarchar(max)  NULL,
    [ClientSecret] nvarchar(max)  NULL,
    [OAuth2ProviderType] int  NULL,
    [Enabled] bit  NOT NULL,
    [Id] bigint IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'KeyMaterialConfiguration'
CREATE TABLE [dbo].[KeyMaterialConfiguration] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SigningCertificateName] nvarchar(max)  NULL,
    [DecryptionCertificateName] nvarchar(max)  NULL,
    [RSASigningKey] nvarchar(max)  NULL,
    [SymmetricSigningKey] nvarchar(max)  NULL
);
GO

-- Creating table 'ManualIntegrationTasks'
CREATE TABLE [dbo].[ManualIntegrationTasks] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [ReceiveTime] datetime  NULL,
    [StartTime] datetime  NULL,
    [EndTime] datetime  NULL,
    [Info] nvarchar(max)  NULL,
    [UserId] bigint  NULL,
    [TaskState] tinyint  NOT NULL
);
GO

-- Creating table 'OAuth2Configuration'
CREATE TABLE [dbo].[OAuth2Configuration] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Enabled] bit  NOT NULL,
    [EnableConsent] bit  NOT NULL,
    [EnableResourceOwnerFlow] bit  NOT NULL,
    [EnableImplicitFlow] bit  NOT NULL,
    [EnableCodeFlow] bit  NOT NULL
);
GO

-- Creating table 'Permission'
CREATE TABLE [dbo].[Permission] (
    [Id] bigint  NOT NULL,
    [Name] nvarchar(max)  NULL
);
GO

-- Creating table 'Race'
CREATE TABLE [dbo].[Race] (
    [Id] bigint  NOT NULL,
    [RaceName] nvarchar(150)  NULL
);
GO

-- Creating table 'RelyingParties'
CREATE TABLE [dbo].[RelyingParties] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Enabled] bit  NOT NULL,
    [Realm] nvarchar(max)  NOT NULL,
    [TokenLifeTime] int  NOT NULL,
    [ReplyTo] nvarchar(max)  NULL,
    [EncryptingCertificate] nvarchar(max)  NULL,
    [SymmetricSigningKey] nvarchar(max)  NULL,
    [ExtraData1] nvarchar(max)  NULL,
    [ExtraData2] nvarchar(max)  NULL,
    [ExtraData3] nvarchar(max)  NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(50)  NULL,
    [Description] nvarchar(max)  NULL,
    [IsIdentityServerUser] bit  NOT NULL
);
GO

-- Creating table 'ScheduledIntegrationTasks'
CREATE TABLE [dbo].[ScheduledIntegrationTasks] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [StartTime] datetime  NOT NULL,
    [RepeatPeriod] tinyint  NOT NULL,
    [Info] nvarchar(max)  NULL,
    [UserId] bigint  NULL,
    [Enabled] bit  NOT NULL,
    [TaskState] tinyint  NOT NULL
);
GO

-- Creating table 'SimpleHttpConfiguration'
CREATE TABLE [dbo].[SimpleHttpConfiguration] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Enabled] bit  NOT NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NULL,
    [Password] nvarchar(max)  NULL,
    [FirstName] nvarchar(max)  NULL,
    [LastName] nvarchar(max)  NULL,
    [MiddleName] nvarchar(max)  NULL,
    [Comment] nvarchar(max)  NULL,
    [IsApproved] bit  NOT NULL,
    [PasswordFailuresSinceLastSuccess] int  NOT NULL,
    [LastPasswordFailureDate] datetime  NULL,
    [LastActivityDate] datetime  NULL,
    [LastLockoutDate] datetime  NULL,
    [LastLoginDate] datetime  NULL,
    [ConfirmationToken] nvarchar(max)  NULL,
    [CreateDate] datetime  NULL,
    [IsLockedOut] bit  NOT NULL,
    [LastPasswordChangedDate] datetime  NULL,
    [PasswordVerificationToken] nvarchar(max)  NULL,
    [PasswordVerificationTokenExpirationDate] datetime  NULL
);
GO

-- Creating table 'WSFederationConfiguration'
CREATE TABLE [dbo].[WSFederationConfiguration] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Enabled] bit  NOT NULL,
    [EnableAuthentication] bit  NOT NULL,
    [EnableFederation] bit  NOT NULL,
    [EnableHrd] bit  NOT NULL,
    [AllowReplyTo] bit  NOT NULL,
    [RequireReplyToWithinRealm] bit  NOT NULL,
    [RequireSslForReplyTo] bit  NOT NULL
);
GO

-- Creating table 'WSTrustConfiguration'
CREATE TABLE [dbo].[WSTrustConfiguration] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Enabled] bit  NOT NULL,
    [EnableMessageSecurity] bit  NOT NULL,
    [EnableMixedModeSecurity] bit  NOT NULL,
    [EnableClientCertificateAuthentication] bit  NOT NULL,
    [EnableFederatedAuthentication] bit  NOT NULL,
    [EnableDelegation] bit  NOT NULL
);
GO

-- Creating table 'Hearings'
CREATE TABLE [dbo].[Hearings] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [HearingDate] datetime  NOT NULL,
    [Judge] nvarchar(250)  NULL,
    [Courtroom_Id] bigint  NULL,
    [HearingIssue_PermanentRO] bit  NOT NULL,
    [HearingIssue_ChildCustodyOrChildVisitation] bit  NOT NULL,
    [HearingIssue_ChildSupport] bit  NOT NULL,
    [HearingIssue_SpousalSupport] bit  NOT NULL,
    [HearingIssue_IsOtherIssue] bit  NOT NULL,
    [HearingIssue_OtheIssueText] nvarchar(max)  NOT NULL,
    [Department_Id] bigint  NULL,
    [Session] int  NOT NULL,
    [Appearance_Party1Appear] bit  NULL,
    [Appearance_Party1Sworn] bit  NULL,
    [Appearance_Party1AttorneyPresent] bit  NULL,
    [Appearance_Party1Atty] bit  NULL,
    [Appearance_Party2Appear] bit  NULL,
    [Appearance_Party2AttorneyPresent] bit  NULL,
    [Appearance_Party2Atty] bit  NULL,
    [Appearance_Party2Sworn] bit  NULL
);
GO

-- Creating table 'CourtDocketRecordSet'
CREATE TABLE [dbo].[CourtDocketRecordSet] (
    [Id] bigint  NOT NULL,
    [CourtCaseId] bigint  NOT NULL,
    [HearingId] bigint  NOT NULL
);
GO

-- Creating table 'ThirdPartyData'
CREATE TABLE [dbo].[ThirdPartyData] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [IsThirdPartyProPer] bit  NOT NULL,
    [IsThirdPartyRequestorInEACase] bit  NOT NULL,
    [Attorney_Id] bigint  NULL
);
GO

-- Creating table 'CourtPartyAttorneyData'
CREATE TABLE [dbo].[CourtPartyAttorneyData] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [HasAttorney] bit  NULL,
    [Attorney_Id] bigint  NULL
);
GO

-- Creating table 'AdditionalPartySet'
CREATE TABLE [dbo].[AdditionalPartySet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [EntityType] int  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Designation] int  NOT NULL,
    [PartyFor] int  NOT NULL,
    [Contact] nvarchar(max)  NOT NULL,
    [CourtCaseId] bigint  NOT NULL
);
GO

-- Creating table 'AdditionalPartySet_Child'
CREATE TABLE [dbo].[AdditionalPartySet_Child] (
    [Sex] int  NOT NULL,
    [DateOfBirth] datetime  NULL,
    [RelationToProtected] int  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'AdditionalPartySet_OtherProtected'
CREATE TABLE [dbo].[AdditionalPartySet_OtherProtected] (
    [RelationToProtected] int  NOT NULL,
    [DateOfBirth] datetime  NULL,
    [Sex] int  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'AdditionalPartySet_Interpreter'
CREATE TABLE [dbo].[AdditionalPartySet_Interpreter] (
    [Language] nvarchar(max)  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'RoleUser'
CREATE TABLE [dbo].[RoleUser] (
    [Role_Id] bigint  NOT NULL,
    [User_Id] bigint  NOT NULL
);
GO

-- Creating table 'RolePermission2'
CREATE TABLE [dbo].[RolePermission2] (
    [Role_Id] bigint  NOT NULL,
    [Permissions_Id] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AdfsIntegrationConfiguration'
ALTER TABLE [dbo].[AdfsIntegrationConfiguration]
ADD CONSTRAINT [PK_AdfsIntegrationConfiguration]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Attorneys'
ALTER TABLE [dbo].[Attorneys]
ADD CONSTRAINT [PK_Attorneys]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CaseHistory'
ALTER TABLE [dbo].[CaseHistory]
ADD CONSTRAINT [PK_CaseHistory]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CaseNotes'
ALTER TABLE [dbo].[CaseNotes]
ADD CONSTRAINT [PK_CaseNotes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Client'
ALTER TABLE [dbo].[Client]
ADD CONSTRAINT [PK_Client]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClientCertificates'
ALTER TABLE [dbo].[ClientCertificates]
ADD CONSTRAINT [PK_ClientCertificates]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CodeToken'
ALTER TABLE [dbo].[CodeToken]
ADD CONSTRAINT [PK_CodeToken]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CourtCase'
ALTER TABLE [dbo].[CourtCase]
ADD CONSTRAINT [PK_CourtCase]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CourtCaseOrders'
ALTER TABLE [dbo].[CourtCaseOrders]
ADD CONSTRAINT [PK_CourtCaseOrders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CourtCounty'
ALTER TABLE [dbo].[CourtCounty]
ADD CONSTRAINT [PK_CourtCounty]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CourtDepartmenets'
ALTER TABLE [dbo].[CourtDepartmenets]
ADD CONSTRAINT [PK_CourtDepartmenets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CourtLocations'
ALTER TABLE [dbo].[CourtLocations]
ADD CONSTRAINT [PK_CourtLocations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CourtMember'
ALTER TABLE [dbo].[CourtMember]
ADD CONSTRAINT [PK_CourtMember]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CourtParty'
ALTER TABLE [dbo].[CourtParty]
ADD CONSTRAINT [PK_CourtParty]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Courtrooms'
ALTER TABLE [dbo].[Courtrooms]
ADD CONSTRAINT [PK_Courtrooms]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Delegation'
ALTER TABLE [dbo].[Delegation]
ADD CONSTRAINT [PK_Delegation]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Designation'
ALTER TABLE [dbo].[Designation]
ADD CONSTRAINT [PK_Designation]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DiagnosticsConfiguration'
ALTER TABLE [dbo].[DiagnosticsConfiguration]
ADD CONSTRAINT [PK_DiagnosticsConfiguration]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EyesColor'
ALTER TABLE [dbo].[EyesColor]
ADD CONSTRAINT [PK_EyesColor]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FACCTSConfiguration'
ALTER TABLE [dbo].[FACCTSConfiguration]
ADD CONSTRAINT [PK_FACCTSConfiguration]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FederationMetadataConfiguration'
ALTER TABLE [dbo].[FederationMetadataConfiguration]
ADD CONSTRAINT [PK_FederationMetadataConfiguration]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FormField'
ALTER TABLE [dbo].[FormField]
ADD CONSTRAINT [PK_FormField]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GlobalConfiguration'
ALTER TABLE [dbo].[GlobalConfiguration]
ADD CONSTRAINT [PK_GlobalConfiguration]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HairColor'
ALTER TABLE [dbo].[HairColor]
ADD CONSTRAINT [PK_HairColor]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'IdentityProvider'
ALTER TABLE [dbo].[IdentityProvider]
ADD CONSTRAINT [PK_IdentityProvider]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KeyMaterialConfiguration'
ALTER TABLE [dbo].[KeyMaterialConfiguration]
ADD CONSTRAINT [PK_KeyMaterialConfiguration]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ManualIntegrationTasks'
ALTER TABLE [dbo].[ManualIntegrationTasks]
ADD CONSTRAINT [PK_ManualIntegrationTasks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OAuth2Configuration'
ALTER TABLE [dbo].[OAuth2Configuration]
ADD CONSTRAINT [PK_OAuth2Configuration]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Permission'
ALTER TABLE [dbo].[Permission]
ADD CONSTRAINT [PK_Permission]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Race'
ALTER TABLE [dbo].[Race]
ADD CONSTRAINT [PK_Race]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RelyingParties'
ALTER TABLE [dbo].[RelyingParties]
ADD CONSTRAINT [PK_RelyingParties]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ScheduledIntegrationTasks'
ALTER TABLE [dbo].[ScheduledIntegrationTasks]
ADD CONSTRAINT [PK_ScheduledIntegrationTasks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SimpleHttpConfiguration'
ALTER TABLE [dbo].[SimpleHttpConfiguration]
ADD CONSTRAINT [PK_SimpleHttpConfiguration]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WSFederationConfiguration'
ALTER TABLE [dbo].[WSFederationConfiguration]
ADD CONSTRAINT [PK_WSFederationConfiguration]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WSTrustConfiguration'
ALTER TABLE [dbo].[WSTrustConfiguration]
ADD CONSTRAINT [PK_WSTrustConfiguration]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Hearings'
ALTER TABLE [dbo].[Hearings]
ADD CONSTRAINT [PK_Hearings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CourtDocketRecordSet'
ALTER TABLE [dbo].[CourtDocketRecordSet]
ADD CONSTRAINT [PK_CourtDocketRecordSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ThirdPartyData'
ALTER TABLE [dbo].[ThirdPartyData]
ADD CONSTRAINT [PK_ThirdPartyData]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CourtPartyAttorneyData'
ALTER TABLE [dbo].[CourtPartyAttorneyData]
ADD CONSTRAINT [PK_CourtPartyAttorneyData]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AdditionalPartySet'
ALTER TABLE [dbo].[AdditionalPartySet]
ADD CONSTRAINT [PK_AdditionalPartySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AdditionalPartySet_Child'
ALTER TABLE [dbo].[AdditionalPartySet_Child]
ADD CONSTRAINT [PK_AdditionalPartySet_Child]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AdditionalPartySet_OtherProtected'
ALTER TABLE [dbo].[AdditionalPartySet_OtherProtected]
ADD CONSTRAINT [PK_AdditionalPartySet_OtherProtected]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AdditionalPartySet_Interpreter'
ALTER TABLE [dbo].[AdditionalPartySet_Interpreter]
ADD CONSTRAINT [PK_AdditionalPartySet_Interpreter]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Role_Id], [User_Id] in table 'RoleUser'
ALTER TABLE [dbo].[RoleUser]
ADD CONSTRAINT [PK_RoleUser]
    PRIMARY KEY NONCLUSTERED ([Role_Id], [User_Id] ASC);
GO

-- Creating primary key on [Role_Id], [Permissions_Id] in table 'RolePermission2'
ALTER TABLE [dbo].[RolePermission2]
ADD CONSTRAINT [PK_RolePermission2]
    PRIMARY KEY NONCLUSTERED ([Role_Id], [Permissions_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Attorney_Id] in table 'CourtParty'
ALTER TABLE [dbo].[CourtParty]
ADD CONSTRAINT [FK_dbo_CourtParty_dbo_Attorneys_Attorney_Id]
    FOREIGN KEY ([Attorney_Id])
    REFERENCES [dbo].[Attorneys]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CourtParty_dbo_Attorneys_Attorney_Id'
CREATE INDEX [IX_FK_dbo_CourtParty_dbo_Attorneys_Attorney_Id]
ON [dbo].[CourtParty]
    ([Attorney_Id]);
GO

-- Creating foreign key on [CourtCaseOrderId] in table 'CaseHistory'
ALTER TABLE [dbo].[CaseHistory]
ADD CONSTRAINT [FK_dbo_CaseHistory_dbo_CourtCaseOrders_CourtCaseOrderId]
    FOREIGN KEY ([CourtCaseOrderId])
    REFERENCES [dbo].[CourtCaseOrders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CaseHistory_dbo_CourtCaseOrders_CourtCaseOrderId'
CREATE INDEX [IX_FK_dbo_CaseHistory_dbo_CourtCaseOrders_CourtCaseOrderId]
ON [dbo].[CaseHistory]
    ([CourtCaseOrderId]);
GO

-- Creating foreign key on [CourtClerk_Id] in table 'CourtCase'
ALTER TABLE [dbo].[CourtCase]
ADD CONSTRAINT [FK_dbo_CourtCase_dbo_User_CourtClerk_UserId]
    FOREIGN KEY ([CourtClerk_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CourtCase_dbo_User_CourtClerk_UserId'
CREATE INDEX [IX_FK_dbo_CourtCase_dbo_User_CourtClerk_UserId]
ON [dbo].[CourtCase]
    ([CourtClerk_Id]);
GO

-- Creating foreign key on [CourtCountyId] in table 'CourtDepartmenets'
ALTER TABLE [dbo].[CourtDepartmenets]
ADD CONSTRAINT [FK_dbo_CourtDepartmenets_dbo_CourtCounty_CourtCountyId]
    FOREIGN KEY ([CourtCountyId])
    REFERENCES [dbo].[CourtCounty]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CourtDepartmenets_dbo_CourtCounty_CourtCountyId'
CREATE INDEX [IX_FK_dbo_CourtDepartmenets_dbo_CourtCounty_CourtCountyId]
ON [dbo].[CourtDepartmenets]
    ([CourtCountyId]);
GO

-- Creating foreign key on [CourtCounty_Id] in table 'CourtLocations'
ALTER TABLE [dbo].[CourtLocations]
ADD CONSTRAINT [FK_dbo_CourtLocations_dbo_CourtCounty_CourtCounty_Id]
    FOREIGN KEY ([CourtCounty_Id])
    REFERENCES [dbo].[CourtCounty]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CourtLocations_dbo_CourtCounty_CourtCounty_Id'
CREATE INDEX [IX_FK_dbo_CourtLocations_dbo_CourtCounty_CourtCounty_Id]
ON [dbo].[CourtLocations]
    ([CourtCounty_Id]);
GO

-- Creating foreign key on [CurrentCourtCountyId] in table 'FACCTSConfiguration'
ALTER TABLE [dbo].[FACCTSConfiguration]
ADD CONSTRAINT [FK_dbo_FACCTSConfiguration_dbo_CourtCounty_CurrentCourtCountyId]
    FOREIGN KEY ([CurrentCourtCountyId])
    REFERENCES [dbo].[CourtCounty]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_FACCTSConfiguration_dbo_CourtCounty_CurrentCourtCountyId'
CREATE INDEX [IX_FK_dbo_FACCTSConfiguration_dbo_CourtCounty_CurrentCourtCountyId]
ON [dbo].[FACCTSConfiguration]
    ([CurrentCourtCountyId]);
GO

-- Creating foreign key on [CourtLocation_Id] in table 'Courtrooms'
ALTER TABLE [dbo].[Courtrooms]
ADD CONSTRAINT [FK_dbo_Courtrooms_dbo_CourtLocations_CourtLocation_Id]
    FOREIGN KEY ([CourtLocation_Id])
    REFERENCES [dbo].[CourtLocations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Courtrooms_dbo_CourtLocations_CourtLocation_Id'
CREATE INDEX [IX_FK_dbo_Courtrooms_dbo_CourtLocations_CourtLocation_Id]
ON [dbo].[Courtrooms]
    ([CourtLocation_Id]);
GO

-- Creating foreign key on [SubstituteId] in table 'CourtMember'
ALTER TABLE [dbo].[CourtMember]
ADD CONSTRAINT [FK_dbo_CourtMember_dbo_CourtMember_SubstituteId]
    FOREIGN KEY ([SubstituteId])
    REFERENCES [dbo].[CourtMember]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CourtMember_dbo_CourtMember_SubstituteId'
CREATE INDEX [IX_FK_dbo_CourtMember_dbo_CourtMember_SubstituteId]
ON [dbo].[CourtMember]
    ([SubstituteId]);
GO

-- Creating foreign key on [Id] in table 'CourtMember'
ALTER TABLE [dbo].[CourtMember]
ADD CONSTRAINT [FK_dbo_CourtMember_dbo_User_Id]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Designation_Id] in table 'CourtParty'
ALTER TABLE [dbo].[CourtParty]
ADD CONSTRAINT [FK_dbo_CourtParty_dbo_Designation_Designation_Id]
    FOREIGN KEY ([Designation_Id])
    REFERENCES [dbo].[Designation]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CourtParty_dbo_Designation_Designation_Id'
CREATE INDEX [IX_FK_dbo_CourtParty_dbo_Designation_Designation_Id]
ON [dbo].[CourtParty]
    ([Designation_Id]);
GO

-- Creating foreign key on [UserId] in table 'ManualIntegrationTasks'
ALTER TABLE [dbo].[ManualIntegrationTasks]
ADD CONSTRAINT [FK_dbo_ManualIntegrationTasks_dbo_User_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_ManualIntegrationTasks_dbo_User_UserId'
CREATE INDEX [IX_FK_dbo_ManualIntegrationTasks_dbo_User_UserId]
ON [dbo].[ManualIntegrationTasks]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'ScheduledIntegrationTasks'
ALTER TABLE [dbo].[ScheduledIntegrationTasks]
ADD CONSTRAINT [FK_dbo_ScheduledIntegrationTasks_dbo_User_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_ScheduledIntegrationTasks_dbo_User_UserId'
CREATE INDEX [IX_FK_dbo_ScheduledIntegrationTasks_dbo_User_UserId]
ON [dbo].[ScheduledIntegrationTasks]
    ([UserId]);
GO

-- Creating foreign key on [Id] in table 'CaseHistory'
ALTER TABLE [dbo].[CaseHistory]
ADD CONSTRAINT [FK_dbo_CaseHistory_dbo_Hearings_Hearing_Id]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Hearings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Courtroom_Id] in table 'Hearings'
ALTER TABLE [dbo].[Hearings]
ADD CONSTRAINT [FK_dbo_Hearings_dbo_Courtrooms_Courtroom_Id]
    FOREIGN KEY ([Courtroom_Id])
    REFERENCES [dbo].[Courtrooms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Hearings_dbo_Courtrooms_Courtroom_Id'
CREATE INDEX [IX_FK_dbo_Hearings_dbo_Courtrooms_Courtroom_Id]
ON [dbo].[Hearings]
    ([Courtroom_Id]);
GO

-- Creating foreign key on [MergeCase_Id] in table 'CaseHistory'
ALTER TABLE [dbo].[CaseHistory]
ADD CONSTRAINT [FK_dbo_CaseHistory_dbo_CourtCase_MergeCase_Id]
    FOREIGN KEY ([MergeCase_Id])
    REFERENCES [dbo].[CourtCase]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CaseHistory_dbo_CourtCase_MergeCase_Id'
CREATE INDEX [IX_FK_dbo_CaseHistory_dbo_CourtCase_MergeCase_Id]
ON [dbo].[CaseHistory]
    ([MergeCase_Id]);
GO

-- Creating foreign key on [Department_Id] in table 'Hearings'
ALTER TABLE [dbo].[Hearings]
ADD CONSTRAINT [FK_dbo_Hearings_dbo_CourtDepartmenets_Department_Id]
    FOREIGN KEY ([Department_Id])
    REFERENCES [dbo].[CourtDepartmenets]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Hearings_dbo_CourtDepartmenets_Department_Id'
CREATE INDEX [IX_FK_dbo_Hearings_dbo_CourtDepartmenets_Department_Id]
ON [dbo].[Hearings]
    ([Department_Id]);
GO

-- Creating foreign key on [ParentCase_Id] in table 'CourtCase'
ALTER TABLE [dbo].[CourtCase]
ADD CONSTRAINT [FK_dbo_CourtCase_dbo_CourtCase_ParentCase_Id]
    FOREIGN KEY ([ParentCase_Id])
    REFERENCES [dbo].[CourtCase]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CourtCase_dbo_CourtCase_ParentCase_Id'
CREATE INDEX [IX_FK_dbo_CourtCase_dbo_CourtCase_ParentCase_Id]
ON [dbo].[CourtCase]
    ([ParentCase_Id]);
GO

-- Creating foreign key on [CourtOrder_Id] in table 'CaseHistory'
ALTER TABLE [dbo].[CaseHistory]
ADD CONSTRAINT [FK_dbo_CaseHistory_dbo_CourtCaseOrders_CourtOrder_Id]
    FOREIGN KEY ([CourtOrder_Id])
    REFERENCES [dbo].[CourtCaseOrders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CaseHistory_dbo_CourtCaseOrders_CourtOrder_Id'
CREATE INDEX [IX_FK_dbo_CaseHistory_dbo_CourtCaseOrders_CourtOrder_Id]
ON [dbo].[CaseHistory]
    ([CourtOrder_Id]);
GO

-- Creating foreign key on [CourtCaseId] in table 'CourtDocketRecordSet'
ALTER TABLE [dbo].[CourtDocketRecordSet]
ADD CONSTRAINT [FK_CourtDocketRecordCourtCase]
    FOREIGN KEY ([CourtCaseId])
    REFERENCES [dbo].[CourtCase]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CourtDocketRecordCourtCase'
CREATE INDEX [IX_FK_CourtDocketRecordCourtCase]
ON [dbo].[CourtDocketRecordSet]
    ([CourtCaseId]);
GO

-- Creating foreign key on [HearingId] in table 'CourtDocketRecordSet'
ALTER TABLE [dbo].[CourtDocketRecordSet]
ADD CONSTRAINT [FK_CourtDocketRecordHearings]
    FOREIGN KEY ([HearingId])
    REFERENCES [dbo].[Hearings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CourtDocketRecordHearings'
CREATE INDEX [IX_FK_CourtDocketRecordHearings]
ON [dbo].[CourtDocketRecordSet]
    ([HearingId]);
GO

-- Creating foreign key on [Attorney_Id] in table 'ThirdPartyData'
ALTER TABLE [dbo].[ThirdPartyData]
ADD CONSTRAINT [FK_dbo_ThirdPartyData_dbo_Attorneys_Attorney_Id]
    FOREIGN KEY ([Attorney_Id])
    REFERENCES [dbo].[Attorneys]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_ThirdPartyData_dbo_Attorneys_Attorney_Id'
CREATE INDEX [IX_FK_dbo_ThirdPartyData_dbo_Attorneys_Attorney_Id]
ON [dbo].[ThirdPartyData]
    ([Attorney_Id]);
GO

-- Creating foreign key on [CourtClerk_Id] in table 'CaseHistory'
ALTER TABLE [dbo].[CaseHistory]
ADD CONSTRAINT [FK_dbo_CaseHistory_dbo_User_CourtClerk_Id]
    FOREIGN KEY ([CourtClerk_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CaseHistory_dbo_User_CourtClerk_Id'
CREATE INDEX [IX_FK_dbo_CaseHistory_dbo_User_CourtClerk_Id]
ON [dbo].[CaseHistory]
    ([CourtClerk_Id]);
GO

-- Creating foreign key on [Author_Id] in table 'CaseNotes'
ALTER TABLE [dbo].[CaseNotes]
ADD CONSTRAINT [FK_dbo_CaseNotes_dbo_User_Author_Id]
    FOREIGN KEY ([Author_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CaseNotes_dbo_User_Author_Id'
CREATE INDEX [IX_FK_dbo_CaseNotes_dbo_User_Author_Id]
ON [dbo].[CaseNotes]
    ([Author_Id]);
GO

-- Creating foreign key on [CourtClerk_Id] in table 'CourtCase'
ALTER TABLE [dbo].[CourtCase]
ADD CONSTRAINT [FK_dbo_CourtCase_dbo_User_CourtClerk_Id]
    FOREIGN KEY ([CourtClerk_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CourtCase_dbo_User_CourtClerk_Id'
CREATE INDEX [IX_FK_dbo_CourtCase_dbo_User_CourtClerk_Id]
ON [dbo].[CourtCase]
    ([CourtClerk_Id]);
GO

-- Creating foreign key on [Role_Id] in table 'RoleUser'
ALTER TABLE [dbo].[RoleUser]
ADD CONSTRAINT [FK_RoleUser_Role]
    FOREIGN KEY ([Role_Id])
    REFERENCES [dbo].[Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [User_Id] in table 'RoleUser'
ALTER TABLE [dbo].[RoleUser]
ADD CONSTRAINT [FK_RoleUser_User]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleUser_User'
CREATE INDEX [IX_FK_RoleUser_User]
ON [dbo].[RoleUser]
    ([User_Id]);
GO

-- Creating foreign key on [Role_Id] in table 'RolePermission2'
ALTER TABLE [dbo].[RolePermission2]
ADD CONSTRAINT [FK_RolePermission2_Role]
    FOREIGN KEY ([Role_Id])
    REFERENCES [dbo].[Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Permissions_Id] in table 'RolePermission2'
ALTER TABLE [dbo].[RolePermission2]
ADD CONSTRAINT [FK_RolePermission2_Permission]
    FOREIGN KEY ([Permissions_Id])
    REFERENCES [dbo].[Permission]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RolePermission2_Permission'
CREATE INDEX [IX_FK_RolePermission2_Permission]
ON [dbo].[RolePermission2]
    ([Permissions_Id]);
GO

-- Creating foreign key on [CourtCase_Id] in table 'CaseHistory'
ALTER TABLE [dbo].[CaseHistory]
ADD CONSTRAINT [FK_dbo_CaseHistory_dbo_CourtCase_CourtCase_Id]
    FOREIGN KEY ([CourtCase_Id])
    REFERENCES [dbo].[CourtCase]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CaseHistory_dbo_CourtCase_CourtCase_Id'
CREATE INDEX [IX_FK_dbo_CaseHistory_dbo_CourtCase_CourtCase_Id]
ON [dbo].[CaseHistory]
    ([CourtCase_Id]);
GO

-- Creating foreign key on [CourtCase_Id] in table 'CaseNotes'
ALTER TABLE [dbo].[CaseNotes]
ADD CONSTRAINT [FK_dbo_CaseNotes_dbo_CourtCase_CourtCase_Id]
    FOREIGN KEY ([CourtCase_Id])
    REFERENCES [dbo].[CourtCase]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CaseNotes_dbo_CourtCase_CourtCase_Id'
CREATE INDEX [IX_FK_dbo_CaseNotes_dbo_CourtCase_CourtCase_Id]
ON [dbo].[CaseNotes]
    ([CourtCase_Id]);
GO

-- Creating foreign key on [CourtCounty_Id] in table 'CourtCase'
ALTER TABLE [dbo].[CourtCase]
ADD CONSTRAINT [FK_dbo_CourtCase_dbo_CourtCounty_CourtCounty_Id]
    FOREIGN KEY ([CourtCounty_Id])
    REFERENCES [dbo].[CourtCounty]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CourtCase_dbo_CourtCounty_CourtCounty_Id'
CREATE INDEX [IX_FK_dbo_CourtCase_dbo_CourtCounty_CourtCounty_Id]
ON [dbo].[CourtCase]
    ([CourtCounty_Id]);
GO

-- Creating foreign key on [HairColor_Id] in table 'CourtParty'
ALTER TABLE [dbo].[CourtParty]
ADD CONSTRAINT [FK_HairColorCourtParty]
    FOREIGN KEY ([HairColor_Id])
    REFERENCES [dbo].[HairColor]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HairColorCourtParty'
CREATE INDEX [IX_FK_HairColorCourtParty]
ON [dbo].[CourtParty]
    ([HairColor_Id]);
GO

-- Creating foreign key on [Race_Id] in table 'CourtParty'
ALTER TABLE [dbo].[CourtParty]
ADD CONSTRAINT [FK_CourtPartyRace]
    FOREIGN KEY ([Race_Id])
    REFERENCES [dbo].[Race]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CourtPartyRace'
CREATE INDEX [IX_FK_CourtPartyRace]
ON [dbo].[CourtParty]
    ([Race_Id]);
GO

-- Creating foreign key on [EyesColor_Id] in table 'CourtParty'
ALTER TABLE [dbo].[CourtParty]
ADD CONSTRAINT [FK_CourtPartyEyesColor]
    FOREIGN KEY ([EyesColor_Id])
    REFERENCES [dbo].[EyesColor]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CourtPartyEyesColor'
CREATE INDEX [IX_FK_CourtPartyEyesColor]
ON [dbo].[CourtParty]
    ([EyesColor_Id]);
GO

-- Creating foreign key on [Party1_Id] in table 'CourtCase'
ALTER TABLE [dbo].[CourtCase]
ADD CONSTRAINT [FK_CourtPartyCourtCase]
    FOREIGN KEY ([Party1_Id])
    REFERENCES [dbo].[CourtParty]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CourtPartyCourtCase'
CREATE INDEX [IX_FK_CourtPartyCourtCase]
ON [dbo].[CourtCase]
    ([Party1_Id]);
GO

-- Creating foreign key on [Party2_Id] in table 'CourtCase'
ALTER TABLE [dbo].[CourtCase]
ADD CONSTRAINT [FK_CourtPartyCourtCase1]
    FOREIGN KEY ([Party2_Id])
    REFERENCES [dbo].[CourtParty]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CourtPartyCourtCase1'
CREATE INDEX [IX_FK_CourtPartyCourtCase1]
ON [dbo].[CourtCase]
    ([Party2_Id]);
GO

-- Creating foreign key on [AttorneyForChild_Id] in table 'CaseHistory'
ALTER TABLE [dbo].[CaseHistory]
ADD CONSTRAINT [FK_dbo_CaseHistory_dbo_Attorneys_AttorneyForChild_Id]
    FOREIGN KEY ([AttorneyForChild_Id])
    REFERENCES [dbo].[Attorneys]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CaseHistory_dbo_Attorneys_AttorneyForChild_Id'
CREATE INDEX [IX_FK_dbo_CaseHistory_dbo_Attorneys_AttorneyForChild_Id]
ON [dbo].[CaseHistory]
    ([AttorneyForChild_Id]);
GO

-- Creating foreign key on [Attorney_Id] in table 'CourtPartyAttorneyData'
ALTER TABLE [dbo].[CourtPartyAttorneyData]
ADD CONSTRAINT [FK_dbo_CourtPartyAttorneyData_dbo_Attorneys_Attorney_Id]
    FOREIGN KEY ([Attorney_Id])
    REFERENCES [dbo].[Attorneys]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CourtPartyAttorneyData_dbo_Attorneys_Attorney_Id'
CREATE INDEX [IX_FK_dbo_CourtPartyAttorneyData_dbo_Attorneys_Attorney_Id]
ON [dbo].[CourtPartyAttorneyData]
    ([Attorney_Id]);
GO

-- Creating foreign key on [Party1Attorney_Id] in table 'CaseHistory'
ALTER TABLE [dbo].[CaseHistory]
ADD CONSTRAINT [FK_dbo_CaseHistory_dbo_CourtPartyAttorneyData_Party1Attorney_Id]
    FOREIGN KEY ([Party1Attorney_Id])
    REFERENCES [dbo].[CourtPartyAttorneyData]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CaseHistory_dbo_CourtPartyAttorneyData_Party1Attorney_Id'
CREATE INDEX [IX_FK_dbo_CaseHistory_dbo_CourtPartyAttorneyData_Party1Attorney_Id]
ON [dbo].[CaseHistory]
    ([Party1Attorney_Id]);
GO

-- Creating foreign key on [Party2Attorney_Id] in table 'CaseHistory'
ALTER TABLE [dbo].[CaseHistory]
ADD CONSTRAINT [FK_dbo_CaseHistory_dbo_CourtPartyAttorneyData_Party2Attorney_Id]
    FOREIGN KEY ([Party2Attorney_Id])
    REFERENCES [dbo].[CourtPartyAttorneyData]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CaseHistory_dbo_CourtPartyAttorneyData_Party2Attorney_Id'
CREATE INDEX [IX_FK_dbo_CaseHistory_dbo_CourtPartyAttorneyData_Party2Attorney_Id]
ON [dbo].[CaseHistory]
    ([Party2Attorney_Id]);
GO

-- Creating foreign key on [ThirdPartyData_Id] in table 'CaseHistory'
ALTER TABLE [dbo].[CaseHistory]
ADD CONSTRAINT [FK_dbo_CaseHistory_dbo_ThirdPartyData_ThirdPartyData_Id]
    FOREIGN KEY ([ThirdPartyData_Id])
    REFERENCES [dbo].[ThirdPartyData]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CaseHistory_dbo_ThirdPartyData_ThirdPartyData_Id'
CREATE INDEX [IX_FK_dbo_CaseHistory_dbo_ThirdPartyData_ThirdPartyData_Id]
ON [dbo].[CaseHistory]
    ([ThirdPartyData_Id]);
GO

-- Creating foreign key on [Party1_Id] in table 'CourtCase'
ALTER TABLE [dbo].[CourtCase]
ADD CONSTRAINT [FK_dbo_CourtCase_dbo_CourtParty_Party1_Id]
    FOREIGN KEY ([Party1_Id])
    REFERENCES [dbo].[CourtParty]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CourtCase_dbo_CourtParty_Party1_Id'
CREATE INDEX [IX_FK_dbo_CourtCase_dbo_CourtParty_Party1_Id]
ON [dbo].[CourtCase]
    ([Party1_Id]);
GO

-- Creating foreign key on [Party2_Id] in table 'CourtCase'
ALTER TABLE [dbo].[CourtCase]
ADD CONSTRAINT [FK_dbo_CourtCase_dbo_CourtParty_Party2_Id]
    FOREIGN KEY ([Party2_Id])
    REFERENCES [dbo].[CourtParty]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CourtCase_dbo_CourtParty_Party2_Id'
CREATE INDEX [IX_FK_dbo_CourtCase_dbo_CourtParty_Party2_Id]
ON [dbo].[CourtCase]
    ([Party2_Id]);
GO

-- Creating foreign key on [CourtCaseId] in table 'AdditionalPartySet'
ALTER TABLE [dbo].[AdditionalPartySet]
ADD CONSTRAINT [FK_CourtCaseAdditionalParty]
    FOREIGN KEY ([CourtCaseId])
    REFERENCES [dbo].[CourtCase]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CourtCaseAdditionalParty'
CREATE INDEX [IX_FK_CourtCaseAdditionalParty]
ON [dbo].[AdditionalPartySet]
    ([CourtCaseId]);
GO

-- Creating foreign key on [Id] in table 'AdditionalPartySet_Child'
ALTER TABLE [dbo].[AdditionalPartySet_Child]
ADD CONSTRAINT [FK_Child_inherits_AdditionalParty]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[AdditionalPartySet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'AdditionalPartySet_OtherProtected'
ALTER TABLE [dbo].[AdditionalPartySet_OtherProtected]
ADD CONSTRAINT [FK_OtherProtected_inherits_AdditionalParty]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[AdditionalPartySet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'AdditionalPartySet_Interpreter'
ALTER TABLE [dbo].[AdditionalPartySet_Interpreter]
ADD CONSTRAINT [FK_Interpreter_inherits_AdditionalParty]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[AdditionalPartySet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------