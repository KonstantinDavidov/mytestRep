
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 08/02/2013 18:37:51
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

IF OBJECT_ID(N'[dbo].[FK_dbo_CourtCase_dbo_User_CourtClerk_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtCase] DROP CONSTRAINT [FK_dbo_CourtCase_dbo_User_CourtClerk_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CourtDepartmenets_dbo_CourtCounty_CourtCountyId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtDepartments] DROP CONSTRAINT [FK_dbo_CourtDepartmenets_dbo_CourtCounty_CourtCountyId];
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
IF OBJECT_ID(N'[dbo].[FK_dbo_ManualIntegrationTasks_dbo_User_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ManualIntegrationTasks] DROP CONSTRAINT [FK_dbo_ManualIntegrationTasks_dbo_User_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_ScheduledIntegrationTasks_dbo_User_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScheduledIntegrationTasks] DROP CONSTRAINT [FK_dbo_ScheduledIntegrationTasks_dbo_User_UserId];
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
IF OBJECT_ID(N'[dbo].[FK_dbo_ThirdPartyData_dbo_Attorneys_Attorney_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ThirdPartyData] DROP CONSTRAINT [FK_dbo_ThirdPartyData_dbo_Attorneys_Attorney_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CaseNotes_dbo_User_Author_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CaseNotes] DROP CONSTRAINT [FK_dbo_CaseNotes_dbo_User_Author_Id];
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
IF OBJECT_ID(N'[dbo].[FK_dbo_CourtCase_dbo_CourtParty_Party1_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtCase] DROP CONSTRAINT [FK_dbo_CourtCase_dbo_CourtParty_Party1_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CourtCase_dbo_CourtParty_Party2_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtCase] DROP CONSTRAINT [FK_dbo_CourtCase_dbo_CourtParty_Party2_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_CourtCaseAdditionalParty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonBaseSet] DROP CONSTRAINT [FK_CourtCaseAdditionalParty];
GO
IF OBJECT_ID(N'[dbo].[FK_CH130OrderConductSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_CH130ROOrder] DROP CONSTRAINT [FK_CH130OrderConductSection];
GO
IF OBJECT_ID(N'[dbo].[FK_CH130OrderServiceSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_CH130ROOrder] DROP CONSTRAINT [FK_CH130OrderServiceSection];
GO
IF OBJECT_ID(N'[dbo].[FK_CH130OrderSAOSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_CH130ROOrder] DROP CONSTRAINT [FK_CH130OrderSAOSection];
GO
IF OBJECT_ID(N'[dbo].[FK_CH130OrderNoGunsSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_CH130ROOrder] DROP CONSTRAINT [FK_CH130OrderNoGunsSection];
GO
IF OBJECT_ID(N'[dbo].[FK_CH130OrderOtherOrdersSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_CH130ROOrder] DROP CONSTRAINT [FK_CH130OrderOtherOrdersSection];
GO
IF OBJECT_ID(N'[dbo].[FK_CarposEntrySectionLawEnforcement]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LawEnforcementSet] DROP CONSTRAINT [FK_CarposEntrySectionLawEnforcement];
GO
IF OBJECT_ID(N'[dbo].[FK_CH130OrderCarposEntrySection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_CH130ROOrder] DROP CONSTRAINT [FK_CH130OrderCarposEntrySection];
GO
IF OBJECT_ID(N'[dbo].[FK_CH130OrderExpirationSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_CH130ROOrder] DROP CONSTRAINT [FK_CH130OrderExpirationSection];
GO
IF OBJECT_ID(N'[dbo].[FK_CH130OrderServiceFeesSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_CH130ROOrder] DROP CONSTRAINT [FK_CH130OrderServiceFeesSection];
GO
IF OBJECT_ID(N'[dbo].[FK_CH130OrderAttorneysFeesSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_CH130ROOrder] DROP CONSTRAINT [FK_CH130OrderAttorneysFeesSection];
GO
IF OBJECT_ID(N'[dbo].[FK_CH110OrderConductTROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_CH110TROOrder] DROP CONSTRAINT [FK_CH110OrderConductTROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_CH110OrderSAOTROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_CH110TROOrder] DROP CONSTRAINT [FK_CH110OrderSAOTROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_CH110TROOrderNoGunsSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_CH110TROOrder] DROP CONSTRAINT [FK_CH110TROOrderNoGunsSection];
GO
IF OBJECT_ID(N'[dbo].[FK_CH110TROOrderOtherOrdersTROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_CH110TROOrder] DROP CONSTRAINT [FK_CH110TROOrderOtherOrdersTROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_CH110TROOrderCarposEntryROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_CH110TROOrder] DROP CONSTRAINT [FK_CH110TROOrderCarposEntryROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_CH110TROOrderServiceFeesSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_CH110TROOrder] DROP CONSTRAINT [FK_CH110TROOrderServiceFeesSection];
GO
IF OBJECT_ID(N'[dbo].[FK_CH110TROOrderExpirationSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_CH110TROOrder] DROP CONSTRAINT [FK_CH110TROOrderExpirationSection];
GO
IF OBJECT_ID(N'[dbo].[FK_DV110TROOrderConductDVTROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder] DROP CONSTRAINT [FK_DV110TROOrderConductDVTROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_DV110TROOrderDV110ServiceSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder] DROP CONSTRAINT [FK_DV110TROOrderDV110ServiceSection];
GO
IF OBJECT_ID(N'[dbo].[FK_DV110TROOrderSAOTROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder] DROP CONSTRAINT [FK_DV110TROOrderSAOTROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_DV110TROOrderMoveOutTROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder] DROP CONSTRAINT [FK_DV110TROOrderMoveOutTROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_DV110TROOrderCommunicationsRecordingTROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder] DROP CONSTRAINT [FK_DV110TROOrderCommunicationsRecordingTROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_DV110TROOrderAnimalsTROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder] DROP CONSTRAINT [FK_DV110TROOrderAnimalsTROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_DV110TROOrderOtherOrdersTROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder] DROP CONSTRAINT [FK_DV110TROOrderOtherOrdersTROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_DV110TROOrderNoGunsSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder] DROP CONSTRAINT [FK_DV110TROOrderNoGunsSection];
GO
IF OBJECT_ID(N'[dbo].[FK_DV110TROOrderBatterInterventionSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder] DROP CONSTRAINT [FK_DV110TROOrderBatterInterventionSection];
GO
IF OBJECT_ID(N'[dbo].[FK_DV110TROOrderExpirationSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder] DROP CONSTRAINT [FK_DV110TROOrderExpirationSection];
GO
IF OBJECT_ID(N'[dbo].[FK_PropertyControlROSectionPropertyRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PropertyRecordSet] DROP CONSTRAINT [FK_PropertyControlROSectionPropertyRecord];
GO
IF OBJECT_ID(N'[dbo].[FK_DV110TROOrderPropertyControlTROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder] DROP CONSTRAINT [FK_DV110TROOrderPropertyControlTROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_PaymentsROSectionPaymentRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaymentRecordSet] DROP CONSTRAINT [FK_PaymentsROSectionPaymentRecord];
GO
IF OBJECT_ID(N'[dbo].[FK_DV110TROOrderPaymentsTROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder] DROP CONSTRAINT [FK_DV110TROOrderPaymentsTROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_DV110TROOrderPropertyRestrainingOrdersTROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder] DROP CONSTRAINT [FK_DV110TROOrderPropertyRestrainingOrdersTROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_DV110TROOrderOtherOrdersTROSection1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder] DROP CONSTRAINT [FK_DV110TROOrderOtherOrdersTROSection1];
GO
IF OBJECT_ID(N'[dbo].[FK_DV130ROOrderConductROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder] DROP CONSTRAINT [FK_DV130ROOrderConductROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_DV130ROOrderServiceSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder] DROP CONSTRAINT [FK_DV130ROOrderServiceSection];
GO
IF OBJECT_ID(N'[dbo].[FK_DV130ROOrderSAOROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder] DROP CONSTRAINT [FK_DV130ROOrderSAOROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_DV130ROOrderMoveOutROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder] DROP CONSTRAINT [FK_DV130ROOrderMoveOutROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_DV130ROOrderCommunicationsRecordingROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder] DROP CONSTRAINT [FK_DV130ROOrderCommunicationsRecordingROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_DV130ROOrderAnimalsROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder] DROP CONSTRAINT [FK_DV130ROOrderAnimalsROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_DV130ROOrderOtherOrdersROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder] DROP CONSTRAINT [FK_DV130ROOrderOtherOrdersROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_DV130ROOrderBatterInterventionSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder] DROP CONSTRAINT [FK_DV130ROOrderBatterInterventionSection];
GO
IF OBJECT_ID(N'[dbo].[FK_DV130ROOrderNoGunsSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder] DROP CONSTRAINT [FK_DV130ROOrderNoGunsSection];
GO
IF OBJECT_ID(N'[dbo].[FK_DV130ROOrderExpirationSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder] DROP CONSTRAINT [FK_DV130ROOrderExpirationSection];
GO
IF OBJECT_ID(N'[dbo].[FK_DV130ROOrderPropertyControlROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder] DROP CONSTRAINT [FK_DV130ROOrderPropertyControlROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_DV130ROOrderPaymentsROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder] DROP CONSTRAINT [FK_DV130ROOrderPaymentsROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_DV130ROOrderPropertyRestrainingOrdersROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder] DROP CONSTRAINT [FK_DV130ROOrderPropertyRestrainingOrdersROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_DV130ROOrderOtherOrdersROSection1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder] DROP CONSTRAINT [FK_DV130ROOrderOtherOrdersROSection1];
GO
IF OBJECT_ID(N'[dbo].[FK_EA110TROOrderConductTROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_EA110TROOrder] DROP CONSTRAINT [FK_EA110TROOrderConductTROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_EA110TROOrderSAOEATROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_EA110TROOrder] DROP CONSTRAINT [FK_EA110TROOrderSAOEATROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_EA110TROOrderMoveOutTROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_EA110TROOrder] DROP CONSTRAINT [FK_EA110TROOrderMoveOutTROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_EA110TROOrderNoGunsEASection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_EA110TROOrder] DROP CONSTRAINT [FK_EA110TROOrderNoGunsEASection];
GO
IF OBJECT_ID(N'[dbo].[FK_EA110TROOrderCarposEntrySection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_EA110TROOrder] DROP CONSTRAINT [FK_EA110TROOrderCarposEntrySection];
GO
IF OBJECT_ID(N'[dbo].[FK_EA110TROOrderServiceFeesSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_EA110TROOrder] DROP CONSTRAINT [FK_EA110TROOrderServiceFeesSection];
GO
IF OBJECT_ID(N'[dbo].[FK_EA110TROOrderOtherOrdersTROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_EA110TROOrder] DROP CONSTRAINT [FK_EA110TROOrderOtherOrdersTROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_EA110TROOrderExpirationSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_EA110TROOrder] DROP CONSTRAINT [FK_EA110TROOrderExpirationSection];
GO
IF OBJECT_ID(N'[dbo].[FK_EA130ROOrderConductROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_EA130ROOrder] DROP CONSTRAINT [FK_EA130ROOrderConductROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_EA130ROOrderServiceSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_EA130ROOrder] DROP CONSTRAINT [FK_EA130ROOrderServiceSection];
GO
IF OBJECT_ID(N'[dbo].[FK_EA130ROOrderSAOEAROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_EA130ROOrder] DROP CONSTRAINT [FK_EA130ROOrderSAOEAROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_EA130ROOrderNoGunsEASection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_EA130ROOrder] DROP CONSTRAINT [FK_EA130ROOrderNoGunsEASection];
GO
IF OBJECT_ID(N'[dbo].[FK_EA130ROOrderServiceFeesEA130Section]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_EA130ROOrder] DROP CONSTRAINT [FK_EA130ROOrderServiceFeesEA130Section];
GO
IF OBJECT_ID(N'[dbo].[FK_EA130ROOrderOtherOrdersROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_EA130ROOrder] DROP CONSTRAINT [FK_EA130ROOrderOtherOrdersROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_EA130ROOrderExpirationSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_EA130ROOrder] DROP CONSTRAINT [FK_EA130ROOrderExpirationSection];
GO
IF OBJECT_ID(N'[dbo].[FK_CourtCaseThirdPartyData]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtCase] DROP CONSTRAINT [FK_CourtCaseThirdPartyData];
GO
IF OBJECT_ID(N'[dbo].[FK_CourtCaseAttorneys]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtCase] DROP CONSTRAINT [FK_CourtCaseAttorneys];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Appearances_dbo_Hearings_HearingId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Appearance] DROP CONSTRAINT [FK_dbo_Appearances_dbo_Hearings_HearingId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CourtOrders_dbo_CourtOrders_ParentOrderId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtOrders] DROP CONSTRAINT [FK_dbo_CourtOrders_dbo_CourtOrders_ParentOrderId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CourtOrders_dbo_Hearings_HearingId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtOrders] DROP CONSTRAINT [FK_dbo_CourtOrders_dbo_Hearings_HearingId];
GO
IF OBJECT_ID(N'[dbo].[FK_AppearancesPersonBase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Appearance] DROP CONSTRAINT [FK_AppearancesPersonBase];
GO
IF OBJECT_ID(N'[dbo].[FK_CourtCaseHearings]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Hearings] DROP CONSTRAINT [FK_CourtCaseHearings];
GO
IF OBJECT_ID(N'[dbo].[FK_HearingsCaseHistory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CaseHistory] DROP CONSTRAINT [FK_HearingsCaseHistory];
GO
IF OBJECT_ID(N'[dbo].[FK_CaseHistoryUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CaseHistory] DROP CONSTRAINT [FK_CaseHistoryUser];
GO
IF OBJECT_ID(N'[dbo].[FK_CourtPartyAttorneys]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourtParty] DROP CONSTRAINT [FK_CourtPartyAttorneys];
GO
IF OBJECT_ID(N'[dbo].[FK_CourtOrdersOrderBase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet] DROP CONSTRAINT [FK_CourtOrdersOrderBase];
GO
IF OBJECT_ID(N'[dbo].[FK_Attorneys_inherits_PersonBase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonBaseSet_Attorneys] DROP CONSTRAINT [FK_Attorneys_inherits_PersonBase];
GO
IF OBJECT_ID(N'[dbo].[FK_CH130ROOrder_inherits_OrderBase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_CH130ROOrder] DROP CONSTRAINT [FK_CH130ROOrder_inherits_OrderBase];
GO
IF OBJECT_ID(N'[dbo].[FK_ConductROSection_inherits_ConductBase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConductBaseSet_ConductROSection] DROP CONSTRAINT [FK_ConductROSection_inherits_ConductBase];
GO
IF OBJECT_ID(N'[dbo].[FK_SAOROSection_inherits_SAOEAROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SAOEAROSectionSet_SAOROSection] DROP CONSTRAINT [FK_SAOROSection_inherits_SAOEAROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_CH110TROOrder_inherits_OrderBase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_CH110TROOrder] DROP CONSTRAINT [FK_CH110TROOrder_inherits_OrderBase];
GO
IF OBJECT_ID(N'[dbo].[FK_ConductTROSection_inherits_ConductROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConductBaseSet_ConductTROSection] DROP CONSTRAINT [FK_ConductTROSection_inherits_ConductROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_SAOTROSection_inherits_SAOROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SAOEAROSectionSet_SAOTROSection] DROP CONSTRAINT [FK_SAOTROSection_inherits_SAOROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_OtherOrdersTROSection_inherits_OtherOrdersROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OtherOrdersROSectionSet_OtherOrdersTROSection] DROP CONSTRAINT [FK_OtherOrdersTROSection_inherits_OtherOrdersROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_DV110TROOrder_inherits_OrderBase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder] DROP CONSTRAINT [FK_DV110TROOrder_inherits_OrderBase];
GO
IF OBJECT_ID(N'[dbo].[FK_ConductDVROSection_inherits_ConductBase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConductBaseSet_ConductDVROSection] DROP CONSTRAINT [FK_ConductDVROSection_inherits_ConductBase];
GO
IF OBJECT_ID(N'[dbo].[FK_ConductDVTROSection_inherits_ConductDVROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConductBaseSet_ConductDVTROSection] DROP CONSTRAINT [FK_ConductDVTROSection_inherits_ConductDVROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_MoveOutTROSection_inherits_MoveOutROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MoveOutROSectionSet_MoveOutTROSection] DROP CONSTRAINT [FK_MoveOutTROSection_inherits_MoveOutROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_CommunicationsRecordingTROSection_inherits_CommunicationsRecordingROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CommunicationsRecordingROSectionSet_CommunicationsRecordingTROSection] DROP CONSTRAINT [FK_CommunicationsRecordingTROSection_inherits_CommunicationsRecordingROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_AnimalsTROSection_inherits_AnimalsROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AnimalsROSectionSet_AnimalsTROSection] DROP CONSTRAINT [FK_AnimalsTROSection_inherits_AnimalsROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_PropertyControlTROSection_inherits_PropertyControlROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PropertyControlROSectionSet_PropertyControlTROSection] DROP CONSTRAINT [FK_PropertyControlTROSection_inherits_PropertyControlROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_PaymentsTROSection_inherits_PaymentsROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaymentsROSectionSet_PaymentsTROSection] DROP CONSTRAINT [FK_PaymentsTROSection_inherits_PaymentsROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_PropertyRestrainingOrdersTROSection_inherits_PropertyRestrainingOrdersROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PropertyRestrainingOrdersROSectionSet_PropertyRestrainingOrdersTROSection] DROP CONSTRAINT [FK_PropertyRestrainingOrdersTROSection_inherits_PropertyRestrainingOrdersROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_DV130ROOrder_inherits_OrderBase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder] DROP CONSTRAINT [FK_DV130ROOrder_inherits_OrderBase];
GO
IF OBJECT_ID(N'[dbo].[FK_EA110TROOrder_inherits_OrderBase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_EA110TROOrder] DROP CONSTRAINT [FK_EA110TROOrder_inherits_OrderBase];
GO
IF OBJECT_ID(N'[dbo].[FK_SAOEATROSection_inherits_SAOEAROSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SAOEAROSectionSet_SAOEATROSection] DROP CONSTRAINT [FK_SAOEATROSection_inherits_SAOEAROSection];
GO
IF OBJECT_ID(N'[dbo].[FK_NoGunsEASection_inherits_NoGunsSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NoGunsSectionSet_NoGunsEASection] DROP CONSTRAINT [FK_NoGunsEASection_inherits_NoGunsSection];
GO
IF OBJECT_ID(N'[dbo].[FK_EA130ROOrder_inherits_OrderBase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderBaseSet_EA130ROOrder] DROP CONSTRAINT [FK_EA130ROOrder_inherits_OrderBase];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceFeesEA130Section_inherits_ServiceFeesSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServiceFeesSectionSet_ServiceFeesEA130Section] DROP CONSTRAINT [FK_ServiceFeesEA130Section_inherits_ServiceFeesSection];
GO
IF OBJECT_ID(N'[dbo].[FK_Child_inherits_PersonBase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonBaseSet_Child] DROP CONSTRAINT [FK_Child_inherits_PersonBase];
GO
IF OBJECT_ID(N'[dbo].[FK_OtherProtected_inherits_PersonBase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonBaseSet_OtherProtected] DROP CONSTRAINT [FK_OtherProtected_inherits_PersonBase];
GO
IF OBJECT_ID(N'[dbo].[FK_Interpreter_inherits_PersonBase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonBaseSet_Interpreter] DROP CONSTRAINT [FK_Interpreter_inherits_PersonBase];
GO
IF OBJECT_ID(N'[dbo].[FK_AppearanceWithSworn_inherits_Appearance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Appearance_AppearanceWithSworn] DROP CONSTRAINT [FK_AppearanceWithSworn_inherits_Appearance];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AdfsIntegrationConfiguration]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdfsIntegrationConfiguration];
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
IF OBJECT_ID(N'[dbo].[CourtCounty]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourtCounty];
GO
IF OBJECT_ID(N'[dbo].[CourtDepartments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourtDepartments];
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
IF OBJECT_ID(N'[dbo].[ThirdPartyData]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ThirdPartyData];
GO
IF OBJECT_ID(N'[dbo].[PersonBaseSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonBaseSet];
GO
IF OBJECT_ID(N'[dbo].[ServiceSectionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServiceSectionSet];
GO
IF OBJECT_ID(N'[dbo].[NoGunsSectionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NoGunsSectionSet];
GO
IF OBJECT_ID(N'[dbo].[OtherOrdersROSectionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OtherOrdersROSectionSet];
GO
IF OBJECT_ID(N'[dbo].[CarposEntrySectionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarposEntrySectionSet];
GO
IF OBJECT_ID(N'[dbo].[LawEnforcementSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LawEnforcementSet];
GO
IF OBJECT_ID(N'[dbo].[ExpirationSectionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExpirationSectionSet];
GO
IF OBJECT_ID(N'[dbo].[ServiceFeesSectionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServiceFeesSectionSet];
GO
IF OBJECT_ID(N'[dbo].[AttorneysFeesSectionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AttorneysFeesSectionSet];
GO
IF OBJECT_ID(N'[dbo].[ConductBaseSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConductBaseSet];
GO
IF OBJECT_ID(N'[dbo].[DV110ServiceSectionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DV110ServiceSectionSet];
GO
IF OBJECT_ID(N'[dbo].[MoveOutROSectionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MoveOutROSectionSet];
GO
IF OBJECT_ID(N'[dbo].[CommunicationsRecordingROSectionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CommunicationsRecordingROSectionSet];
GO
IF OBJECT_ID(N'[dbo].[AnimalsROSectionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AnimalsROSectionSet];
GO
IF OBJECT_ID(N'[dbo].[BatterInterventionSectionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BatterInterventionSectionSet];
GO
IF OBJECT_ID(N'[dbo].[PropertyControlROSectionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PropertyControlROSectionSet];
GO
IF OBJECT_ID(N'[dbo].[PropertyRecordSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PropertyRecordSet];
GO
IF OBJECT_ID(N'[dbo].[PaymentsROSectionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentsROSectionSet];
GO
IF OBJECT_ID(N'[dbo].[PaymentRecordSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentRecordSet];
GO
IF OBJECT_ID(N'[dbo].[PropertyRestrainingOrdersROSectionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PropertyRestrainingOrdersROSectionSet];
GO
IF OBJECT_ID(N'[dbo].[SAOEAROSectionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SAOEAROSectionSet];
GO
IF OBJECT_ID(N'[dbo].[Appearance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Appearance];
GO
IF OBJECT_ID(N'[dbo].[CourtOrders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourtOrders];
GO
IF OBJECT_ID(N'[dbo].[OrderBaseSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderBaseSet];
GO
IF OBJECT_ID(N'[dbo].[PersonBaseSet_Attorneys]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonBaseSet_Attorneys];
GO
IF OBJECT_ID(N'[dbo].[OrderBaseSet_CH130ROOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderBaseSet_CH130ROOrder];
GO
IF OBJECT_ID(N'[dbo].[ConductBaseSet_ConductROSection]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConductBaseSet_ConductROSection];
GO
IF OBJECT_ID(N'[dbo].[SAOEAROSectionSet_SAOROSection]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SAOEAROSectionSet_SAOROSection];
GO
IF OBJECT_ID(N'[dbo].[OrderBaseSet_CH110TROOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderBaseSet_CH110TROOrder];
GO
IF OBJECT_ID(N'[dbo].[ConductBaseSet_ConductTROSection]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConductBaseSet_ConductTROSection];
GO
IF OBJECT_ID(N'[dbo].[SAOEAROSectionSet_SAOTROSection]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SAOEAROSectionSet_SAOTROSection];
GO
IF OBJECT_ID(N'[dbo].[OtherOrdersROSectionSet_OtherOrdersTROSection]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OtherOrdersROSectionSet_OtherOrdersTROSection];
GO
IF OBJECT_ID(N'[dbo].[OrderBaseSet_DV110TROOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderBaseSet_DV110TROOrder];
GO
IF OBJECT_ID(N'[dbo].[ConductBaseSet_ConductDVROSection]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConductBaseSet_ConductDVROSection];
GO
IF OBJECT_ID(N'[dbo].[ConductBaseSet_ConductDVTROSection]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConductBaseSet_ConductDVTROSection];
GO
IF OBJECT_ID(N'[dbo].[MoveOutROSectionSet_MoveOutTROSection]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MoveOutROSectionSet_MoveOutTROSection];
GO
IF OBJECT_ID(N'[dbo].[CommunicationsRecordingROSectionSet_CommunicationsRecordingTROSection]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CommunicationsRecordingROSectionSet_CommunicationsRecordingTROSection];
GO
IF OBJECT_ID(N'[dbo].[AnimalsROSectionSet_AnimalsTROSection]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AnimalsROSectionSet_AnimalsTROSection];
GO
IF OBJECT_ID(N'[dbo].[PropertyControlROSectionSet_PropertyControlTROSection]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PropertyControlROSectionSet_PropertyControlTROSection];
GO
IF OBJECT_ID(N'[dbo].[PaymentsROSectionSet_PaymentsTROSection]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentsROSectionSet_PaymentsTROSection];
GO
IF OBJECT_ID(N'[dbo].[PropertyRestrainingOrdersROSectionSet_PropertyRestrainingOrdersTROSection]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PropertyRestrainingOrdersROSectionSet_PropertyRestrainingOrdersTROSection];
GO
IF OBJECT_ID(N'[dbo].[OrderBaseSet_DV130ROOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderBaseSet_DV130ROOrder];
GO
IF OBJECT_ID(N'[dbo].[OrderBaseSet_EA110TROOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderBaseSet_EA110TROOrder];
GO
IF OBJECT_ID(N'[dbo].[SAOEAROSectionSet_SAOEATROSection]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SAOEAROSectionSet_SAOEATROSection];
GO
IF OBJECT_ID(N'[dbo].[NoGunsSectionSet_NoGunsEASection]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NoGunsSectionSet_NoGunsEASection];
GO
IF OBJECT_ID(N'[dbo].[OrderBaseSet_EA130ROOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderBaseSet_EA130ROOrder];
GO
IF OBJECT_ID(N'[dbo].[ServiceFeesSectionSet_ServiceFeesEA130Section]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServiceFeesSectionSet_ServiceFeesEA130Section];
GO
IF OBJECT_ID(N'[dbo].[PersonBaseSet_Child]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonBaseSet_Child];
GO
IF OBJECT_ID(N'[dbo].[PersonBaseSet_OtherProtected]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonBaseSet_OtherProtected];
GO
IF OBJECT_ID(N'[dbo].[PersonBaseSet_Interpreter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonBaseSet_Interpreter];
GO
IF OBJECT_ID(N'[dbo].[Appearance_AppearanceWithSworn]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Appearance_AppearanceWithSworn];
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

-- Creating table 'CaseHistory'
CREATE TABLE [dbo].[CaseHistory] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Date] datetime  NULL,
    [CaseHistoryEvent] int  NOT NULL,
    [CCPOR_ID] nvarchar(30)  NULL,
    [MergeCaseId] bigint  NULL,
    [CourtCaseId] bigint  NOT NULL,
    [CourtClerkId] bigint  NULL,
    [CCPORId] nvarchar(30)  NULL,
    [HearingId] bigint  NULL
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
    [CourtCase_Id1] bigint  NULL,
    [CourtCaseId] bigint  NOT NULL
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
    [CourtClerkId] bigint  NULL,
    [Party1_Id] bigint  NULL,
    [Party2_Id] bigint  NULL,
    [CourtCounty_Id] bigint  NULL,
    [RestrainingPartyIdentificationInformation_IDType] int  NOT NULL,
    [RestrainingPartyIdentificationInformation_IDNumber] nvarchar(max)  NOT NULL,
    [RestrainingPartyIdentificationInformation_IDIssuedDate] datetime  NULL,
    [ThirdPartyDataId] bigint  NULL,
    [RP_IDType] int  NOT NULL,
    [RP_IDNumber] nvarchar(max)  NULL,
    [RP_IssuedDate] datetime  NULL,
    [AttorneyForChild_Id] bigint  NULL
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

-- Creating table 'CourtDepartments'
CREATE TABLE [dbo].[CourtDepartments] (
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
    [Weight] decimal(18,2)  NOT NULL,
    [HeightFt] decimal(18,2)  NOT NULL,
    [HeightIns] decimal(18,2)  NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [Age] int  NOT NULL,
    [HairColor_Id] bigint  NULL,
    [EyesColor_Id] bigint  NULL,
    [Race_Id] bigint  NULL,
    [ParticipantRole] int  NOT NULL,
    [Sex] int  NOT NULL,
    [ParentRole] nvarchar(50)  NULL,
    [EntityType] int  NOT NULL,
    [Email] nvarchar(max)  NULL,
    [RelationToOtherParty] nvarchar(max)  NULL,
    [AddressInfo_StreetAddress] nvarchar(max)  NOT NULL,
    [AddressInfo_City] nvarchar(max)  NOT NULL,
    [AddressInfo_USAState] int  NOT NULL,
    [AddressInfo_ZipCode] nvarchar(max)  NOT NULL,
    [AddressInfo_Phone] nvarchar(max)  NOT NULL,
    [AddressInfo_Fax] nvarchar(max)  NOT NULL,
    [AddressInfo_AddressType] int  NULL,
    [Designation] int  NULL,
    [IsProPer] bit  NOT NULL,
    [AttorneysId] bigint  NULL
);
GO

-- Creating table 'Courtrooms'
CREATE TABLE [dbo].[Courtrooms] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [RoomName] nvarchar(100)  NULL,
    [CourtLocation_Id] bigint  NULL,
    [JudgeName] nvarchar(max)  NOT NULL
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
    [Courtroom_Id] bigint  NULL,
    [HearingIssue_PermanentRO] bit  NOT NULL,
    [HearingIssue_ChildCustodyOrChildVisitation] bit  NOT NULL,
    [HearingIssue_ChildSupport] bit  NOT NULL,
    [HearingIssue_SpousalSupport] bit  NOT NULL,
    [HearingIssue_IsOtherIssue] bit  NOT NULL,
    [HearingIssue_OtheIssueText] nvarchar(max)  NOT NULL,
    [Department_Id] bigint  NULL,
    [Session] int  NOT NULL,
    [CourtDepartmentId] bigint  NULL,
    [CourtCaseId] bigint  NOT NULL
);
GO

-- Creating table 'ThirdPartyData'
CREATE TABLE [dbo].[ThirdPartyData] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [IsThirdPartyProPer] bit  NOT NULL,
    [IsThirdPartyRequestorInEACase] bit  NOT NULL,
    [Attorney_Id] bigint  NULL,
    [IsThirdpartyProPer] bit  NOT NULL
);
GO

-- Creating table 'PersonBaseSet'
CREATE TABLE [dbo].[PersonBaseSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [EntityType] int  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [PartyFor] int  NOT NULL,
    [Contact] nvarchar(max)  NOT NULL,
    [CourtCaseId] bigint  NOT NULL,
    [Sex] int  NOT NULL,
    [DateOfBirth] datetime  NULL,
    [Age] int  NULL,
    [AddressInfo_StreetAddress] nvarchar(max)  NOT NULL,
    [AddressInfo_City] nvarchar(max)  NOT NULL,
    [AddressInfo_USAState] int  NOT NULL,
    [AddressInfo_ZipCode] nvarchar(max)  NOT NULL,
    [AddressInfo_Phone] nvarchar(max)  NOT NULL,
    [AddressInfo_Fax] nvarchar(max)  NOT NULL,
    [AddressInfo_AddressType] int  NULL,
    [Email] nvarchar(max)  NOT NULL,
    [PersonType] int  NOT NULL
);
GO

-- Creating table 'ServiceSectionSet'
CREATE TABLE [dbo].[ServiceSectionSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Service] int  NULL
);
GO

-- Creating table 'NoGunsSectionSet'
CREATE TABLE [dbo].[NoGunsSectionSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Requested] bit  NOT NULL
);
GO

-- Creating table 'OtherOrdersROSectionSet'
CREATE TABLE [dbo].[OtherOrdersROSectionSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Attached] bit  NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [Requested] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CarposEntrySectionSet'
CREATE TABLE [dbo].[CarposEntrySectionSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [EntryType] int  NULL
);
GO

-- Creating table 'LawEnforcementSet'
CREATE TABLE [dbo].[LawEnforcementSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Agency] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [CarposEntrySectionId] bigint  NOT NULL
);
GO

-- Creating table 'ExpirationSectionSet'
CREATE TABLE [dbo].[ExpirationSectionSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Expires] bit  NOT NULL,
    [DateTime] datetime  NULL
);
GO

-- Creating table 'ServiceFeesSectionSet'
CREATE TABLE [dbo].[ServiceFeesSectionSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Ordered] bit  NOT NULL,
    [BasedOnViolence] bit  NOT NULL,
    [Waiver] bit  NOT NULL
);
GO

-- Creating table 'AttorneysFeesSectionSet'
CREATE TABLE [dbo].[AttorneysFeesSectionSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [PaidBy] int  NOT NULL,
    [PaidTo] int  NOT NULL,
    [LawyersFees] bit  NOT NULL,
    [CourtCosts] bit  NOT NULL
);
GO

-- Creating table 'ConductBaseSet'
CREATE TABLE [dbo].[ConductBaseSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [NoHarass] bit  NOT NULL,
    [NoContact] bit  NOT NULL,
    [NoLocate] bit  NOT NULL,
    [Requested] bit  NOT NULL
);
GO

-- Creating table 'DV110ServiceSectionSet'
CREATE TABLE [dbo].[DV110ServiceSectionSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Service] int  NOT NULL
);
GO

-- Creating table 'MoveOutROSectionSet'
CREATE TABLE [dbo].[MoveOutROSectionSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Requested] bit  NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [Attached] bit  NOT NULL
);
GO

-- Creating table 'CommunicationsRecordingROSectionSet'
CREATE TABLE [dbo].[CommunicationsRecordingROSectionSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Requested] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AnimalsROSectionSet'
CREATE TABLE [dbo].[AnimalsROSectionSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Requested] bit  NOT NULL,
    [Distance] decimal(18,0)  NOT NULL,
    [Text] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BatterInterventionSectionSet'
CREATE TABLE [dbo].[BatterInterventionSectionSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Requested] bit  NOT NULL
);
GO

-- Creating table 'PropertyControlROSectionSet'
CREATE TABLE [dbo].[PropertyControlROSectionSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Requested] bit  NOT NULL
);
GO

-- Creating table 'PropertyRecordSet'
CREATE TABLE [dbo].[PropertyRecordSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Item] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [PropertyControSectionId] bigint  NOT NULL
);
GO

-- Creating table 'PaymentsROSectionSet'
CREATE TABLE [dbo].[PaymentsROSectionSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Requested] bit  NOT NULL
);
GO

-- Creating table 'PaymentRecordSet'
CREATE TABLE [dbo].[PaymentRecordSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [DebtItem] nvarchar(max)  NOT NULL,
    [PaymentTo] nvarchar(max)  NOT NULL,
    [PaymentFor] nvarchar(max)  NOT NULL,
    [PaymentFrom] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [PaymentsROSectionId] bigint  NOT NULL
);
GO

-- Creating table 'PropertyRestrainingOrdersROSectionSet'
CREATE TABLE [dbo].[PropertyRestrainingOrdersROSectionSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Requested] bit  NOT NULL,
    [IsParty1] bit  NOT NULL,
    [IsParty2] bit  NOT NULL
);
GO

-- Creating table 'SAOEAROSectionSet'
CREATE TABLE [dbo].[SAOEAROSectionSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Requested] bit  NOT NULL,
    [FromPerson] bit  NOT NULL,
    [FromWork] bit  NOT NULL,
    [FromHome] bit  NOT NULL,
    [FromVehicle] bit  NOT NULL,
    [FromOtherProtected] bit  NOT NULL,
    [OtherRequested] bit  NOT NULL,
    [OtherText] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Appearance'
CREATE TABLE [dbo].[Appearance] (
    [PersonId] bigint  NOT NULL,
    [HearingId] bigint  NOT NULL
);
GO

-- Creating table 'CourtOrders'
CREATE TABLE [dbo].[CourtOrders] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [OrderType] int  NOT NULL,
    [ParentOrderId] bigint  NULL,
    [XMLContent] nvarchar(max)  NULL,
    [IsSigned] bit  NOT NULL,
    [ServerFileName] nvarchar(255)  NULL,
    [HearingId] bigint  NOT NULL
);
GO

-- Creating table 'OrderBaseSet'
CREATE TABLE [dbo].[OrderBaseSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'CourtCaseHeadingSet'
CREATE TABLE [dbo].[CourtCaseHeadingSet] (
    [CourtCaseId] bigint IDENTITY(1,1) NOT NULL,
    [CaseNumber] nvarchar(max)  NOT NULL,
    [CaseStatus] int  NOT NULL,
    [Date] datetime  NULL,
    [Order] nvarchar(max)  NOT NULL,
    [Party1Name] nvarchar(max)  NOT NULL,
    [Party2Name] nvarchar(max)  NOT NULL,
    [CourtClerkId] bigint  NULL,
    [CCPOR_ID] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PersonBaseSet_Attorneys'
CREATE TABLE [dbo].[PersonBaseSet_Attorneys] (
    [FirmName] nvarchar(100)  NULL,
    [StateBarId] nvarchar(50)  NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'OrderBaseSet_CH130ROOrder'
CREATE TABLE [dbo].[OrderBaseSet_CH130ROOrder] (
    [Id] bigint  NOT NULL,
    [ConductSection_Id] bigint  NOT NULL,
    [ServiceSection_Id] bigint  NOT NULL,
    [SAOSection_Id] bigint  NOT NULL,
    [NoGunsSection_Id] bigint  NOT NULL,
    [OtherOrdersSection_Id] bigint  NOT NULL,
    [CarposEntrySection_Id] bigint  NOT NULL,
    [ExpirationSection_Id] bigint  NOT NULL,
    [ServiceFeesSection_Id] bigint  NOT NULL,
    [AttorneysFeesSection_Id] bigint  NOT NULL
);
GO

-- Creating table 'ConductBaseSet_ConductROSection'
CREATE TABLE [dbo].[ConductBaseSet_ConductROSection] (
    [AppliedToOtherProtected] bit  NOT NULL,
    [OtherRequested] bit  NOT NULL,
    [OtherText] nvarchar(max)  NOT NULL,
    [OtherAttached] bit  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'SAOEAROSectionSet_SAOROSection'
CREATE TABLE [dbo].[SAOEAROSectionSet_SAOROSection] (
    [Distance] decimal(18,0)  NOT NULL,
    [FromChildSchool] bit  NOT NULL,
    [FromChildCare] bit  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'OrderBaseSet_CH110TROOrder'
CREATE TABLE [dbo].[OrderBaseSet_CH110TROOrder] (
    [Id] bigint  NOT NULL,
    [ConductTROSection_Id] bigint  NOT NULL,
    [SAOTROSection_Id] bigint  NOT NULL,
    [NoGunsSection_Id] bigint  NOT NULL,
    [OtherOrdersTROSection_Id] bigint  NOT NULL,
    [CarposEntryROSection_Id] bigint  NOT NULL,
    [ServiceFeesSection_Id] bigint  NOT NULL,
    [ExpirationSection_Id] bigint  NOT NULL
);
GO

-- Creating table 'ConductBaseSet_ConductTROSection'
CREATE TABLE [dbo].[ConductBaseSet_ConductTROSection] (
    [OrderState] int  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'SAOEAROSectionSet_SAOTROSection'
CREATE TABLE [dbo].[SAOEAROSectionSet_SAOTROSection] (
    [OrderState] int  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'OtherOrdersROSectionSet_OtherOrdersTROSection'
CREATE TABLE [dbo].[OtherOrdersROSectionSet_OtherOrdersTROSection] (
    [OrderState] int  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'OrderBaseSet_DV110TROOrder'
CREATE TABLE [dbo].[OrderBaseSet_DV110TROOrder] (
    [Id] bigint  NOT NULL,
    [ConductDVTROSection_Id] bigint  NOT NULL,
    [DV110ServiceSection_Id] bigint  NOT NULL,
    [SAOTROSection_Id] bigint  NOT NULL,
    [MoveOutTROSection_Id] bigint  NOT NULL,
    [CommunicationsRecordingTROSection_Id] bigint  NOT NULL,
    [AnimalsTROSection_Id] bigint  NOT NULL,
    [OtherOrdersTROSection_Id] bigint  NOT NULL,
    [NoGunsSection_Id] bigint  NOT NULL,
    [BatterInterventionSection_Id] bigint  NOT NULL,
    [ExpirationSection_Id] bigint  NOT NULL,
    [PropertyControlTROSection_Id] bigint  NOT NULL,
    [PaymentsTROSection_Id] bigint  NOT NULL,
    [PropertyRestrainingOrdersTROSection_Id] bigint  NOT NULL,
    [OtherPropertyOrdersTROSection_Id] bigint  NOT NULL
);
GO

-- Creating table 'ConductBaseSet_ConductDVROSection'
CREATE TABLE [dbo].[ConductBaseSet_ConductDVROSection] (
    [ExceptionForCCCV] nvarchar(max)  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'ConductBaseSet_ConductDVTROSection'
CREATE TABLE [dbo].[ConductBaseSet_ConductDVTROSection] (
    [OrderState] int  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'MoveOutROSectionSet_MoveOutTROSection'
CREATE TABLE [dbo].[MoveOutROSectionSet_MoveOutTROSection] (
    [OrderState] int  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'CommunicationsRecordingROSectionSet_CommunicationsRecordingTROSection'
CREATE TABLE [dbo].[CommunicationsRecordingROSectionSet_CommunicationsRecordingTROSection] (
    [OrderState] int  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'AnimalsROSectionSet_AnimalsTROSection'
CREATE TABLE [dbo].[AnimalsROSectionSet_AnimalsTROSection] (
    [OrderState] int  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'PropertyControlROSectionSet_PropertyControlTROSection'
CREATE TABLE [dbo].[PropertyControlROSectionSet_PropertyControlTROSection] (
    [OrderState] int  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'PaymentsROSectionSet_PaymentsTROSection'
CREATE TABLE [dbo].[PaymentsROSectionSet_PaymentsTROSection] (
    [OrderState] int  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'PropertyRestrainingOrdersROSectionSet_PropertyRestrainingOrdersTROSection'
CREATE TABLE [dbo].[PropertyRestrainingOrdersROSectionSet_PropertyRestrainingOrdersTROSection] (
    [OrderState] int  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'OrderBaseSet_DV130ROOrder'
CREATE TABLE [dbo].[OrderBaseSet_DV130ROOrder] (
    [Id] bigint  NOT NULL,
    [ConductROSection_Id] bigint  NOT NULL,
    [ServiceSection_Id] bigint  NOT NULL,
    [SAOROSection_Id] bigint  NOT NULL,
    [MoveOutROSection_Id] bigint  NOT NULL,
    [CommunicationsRecordingROSection_Id] bigint  NOT NULL,
    [AnimalsROSection_Id] bigint  NOT NULL,
    [OtherOrdersROSection_Id] bigint  NOT NULL,
    [BatterInterventionSection_Id] bigint  NOT NULL,
    [NoGunsSection_Id] bigint  NOT NULL,
    [ExpirationSection_Id] bigint  NOT NULL,
    [PropertyControlROSection_Id] bigint  NOT NULL,
    [PaymentsROSection_Id] bigint  NOT NULL,
    [PropertyRestrainingOrdersROSection_Id] bigint  NOT NULL,
    [OtherPropertyOrdersROSection_Id] bigint  NOT NULL
);
GO

-- Creating table 'OrderBaseSet_EA110TROOrder'
CREATE TABLE [dbo].[OrderBaseSet_EA110TROOrder] (
    [ElderlyPartyPresent] bit  NOT NULL,
    [ProtectedName] nvarchar(max)  NOT NULL,
    [Id] bigint  NOT NULL,
    [ConductTROSection_Id] bigint  NOT NULL,
    [SAOEATROSection_Id] bigint  NOT NULL,
    [MoveOutTROSection_Id] bigint  NOT NULL,
    [NoGunsEASection_Id] bigint  NOT NULL,
    [CarposEntrySection_Id] bigint  NOT NULL,
    [ServiceFeesSection_Id] bigint  NOT NULL,
    [OtherOrdersTROSection_Id] bigint  NOT NULL,
    [ExpirationSection_Id] bigint  NOT NULL
);
GO

-- Creating table 'SAOEAROSectionSet_SAOEATROSection'
CREATE TABLE [dbo].[SAOEAROSectionSet_SAOEATROSection] (
    [OrderState] int  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'NoGunsSectionSet_NoGunsEASection'
CREATE TABLE [dbo].[NoGunsSectionSet_NoGunsEASection] (
    [NoIssued] bit  NOT NULL,
    [FinancialAbuseOnly] bit  NOT NULL,
    [NoGunsOrder] bit  NOT NULL,
    [HasInfo] bit  NOT NULL,
    [NoFInancialAbuse] bit  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'OrderBaseSet_EA130ROOrder'
CREATE TABLE [dbo].[OrderBaseSet_EA130ROOrder] (
    [Id] bigint  NOT NULL,
    [ConductROSection_Id] bigint  NOT NULL,
    [ServiceSection_Id] bigint  NOT NULL,
    [SAOEAROSection_Id] bigint  NOT NULL,
    [NoGunsEASection_Id] bigint  NOT NULL,
    [ServiceFeesEA130Section_Id] bigint  NOT NULL,
    [OtherOrdersROSection_Id] bigint  NOT NULL,
    [ExpirationSection_Id] bigint  NOT NULL
);
GO

-- Creating table 'ServiceFeesSectionSet_ServiceFeesEA130Section'
CREATE TABLE [dbo].[ServiceFeesSectionSet_ServiceFeesEA130Section] (
    [NoServiceFee] bit  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'PersonBaseSet_Child'
CREATE TABLE [dbo].[PersonBaseSet_Child] (
    [RelationToProtected] int  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'PersonBaseSet_OtherProtected'
CREATE TABLE [dbo].[PersonBaseSet_OtherProtected] (
    [RelationToProtected] int  NOT NULL,
    [IsHouseHold] bit  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'PersonBaseSet_Interpreter'
CREATE TABLE [dbo].[PersonBaseSet_Interpreter] (
    [Language] nvarchar(max)  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'Appearance_AppearanceWithSworn'
CREATE TABLE [dbo].[Appearance_AppearanceWithSworn] (
    [Sworn] bit  NOT NULL,
    [PersonId] bigint  NOT NULL,
    [HearingId] bigint  NOT NULL
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

-- Creating primary key on [Id] in table 'CourtCounty'
ALTER TABLE [dbo].[CourtCounty]
ADD CONSTRAINT [PK_CourtCounty]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CourtDepartments'
ALTER TABLE [dbo].[CourtDepartments]
ADD CONSTRAINT [PK_CourtDepartments]
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

-- Creating primary key on [Id] in table 'ThirdPartyData'
ALTER TABLE [dbo].[ThirdPartyData]
ADD CONSTRAINT [PK_ThirdPartyData]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonBaseSet'
ALTER TABLE [dbo].[PersonBaseSet]
ADD CONSTRAINT [PK_PersonBaseSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ServiceSectionSet'
ALTER TABLE [dbo].[ServiceSectionSet]
ADD CONSTRAINT [PK_ServiceSectionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'NoGunsSectionSet'
ALTER TABLE [dbo].[NoGunsSectionSet]
ADD CONSTRAINT [PK_NoGunsSectionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OtherOrdersROSectionSet'
ALTER TABLE [dbo].[OtherOrdersROSectionSet]
ADD CONSTRAINT [PK_OtherOrdersROSectionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CarposEntrySectionSet'
ALTER TABLE [dbo].[CarposEntrySectionSet]
ADD CONSTRAINT [PK_CarposEntrySectionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LawEnforcementSet'
ALTER TABLE [dbo].[LawEnforcementSet]
ADD CONSTRAINT [PK_LawEnforcementSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ExpirationSectionSet'
ALTER TABLE [dbo].[ExpirationSectionSet]
ADD CONSTRAINT [PK_ExpirationSectionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ServiceFeesSectionSet'
ALTER TABLE [dbo].[ServiceFeesSectionSet]
ADD CONSTRAINT [PK_ServiceFeesSectionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AttorneysFeesSectionSet'
ALTER TABLE [dbo].[AttorneysFeesSectionSet]
ADD CONSTRAINT [PK_AttorneysFeesSectionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ConductBaseSet'
ALTER TABLE [dbo].[ConductBaseSet]
ADD CONSTRAINT [PK_ConductBaseSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DV110ServiceSectionSet'
ALTER TABLE [dbo].[DV110ServiceSectionSet]
ADD CONSTRAINT [PK_DV110ServiceSectionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MoveOutROSectionSet'
ALTER TABLE [dbo].[MoveOutROSectionSet]
ADD CONSTRAINT [PK_MoveOutROSectionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CommunicationsRecordingROSectionSet'
ALTER TABLE [dbo].[CommunicationsRecordingROSectionSet]
ADD CONSTRAINT [PK_CommunicationsRecordingROSectionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AnimalsROSectionSet'
ALTER TABLE [dbo].[AnimalsROSectionSet]
ADD CONSTRAINT [PK_AnimalsROSectionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BatterInterventionSectionSet'
ALTER TABLE [dbo].[BatterInterventionSectionSet]
ADD CONSTRAINT [PK_BatterInterventionSectionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PropertyControlROSectionSet'
ALTER TABLE [dbo].[PropertyControlROSectionSet]
ADD CONSTRAINT [PK_PropertyControlROSectionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PropertyRecordSet'
ALTER TABLE [dbo].[PropertyRecordSet]
ADD CONSTRAINT [PK_PropertyRecordSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PaymentsROSectionSet'
ALTER TABLE [dbo].[PaymentsROSectionSet]
ADD CONSTRAINT [PK_PaymentsROSectionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PaymentRecordSet'
ALTER TABLE [dbo].[PaymentRecordSet]
ADD CONSTRAINT [PK_PaymentRecordSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PropertyRestrainingOrdersROSectionSet'
ALTER TABLE [dbo].[PropertyRestrainingOrdersROSectionSet]
ADD CONSTRAINT [PK_PropertyRestrainingOrdersROSectionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SAOEAROSectionSet'
ALTER TABLE [dbo].[SAOEAROSectionSet]
ADD CONSTRAINT [PK_SAOEAROSectionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [PersonId], [HearingId] in table 'Appearance'
ALTER TABLE [dbo].[Appearance]
ADD CONSTRAINT [PK_Appearance]
    PRIMARY KEY CLUSTERED ([PersonId], [HearingId] ASC);
GO

-- Creating primary key on [Id] in table 'CourtOrders'
ALTER TABLE [dbo].[CourtOrders]
ADD CONSTRAINT [PK_CourtOrders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderBaseSet'
ALTER TABLE [dbo].[OrderBaseSet]
ADD CONSTRAINT [PK_OrderBaseSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [CourtCaseId] in table 'CourtCaseHeadingSet'
ALTER TABLE [dbo].[CourtCaseHeadingSet]
ADD CONSTRAINT [PK_CourtCaseHeadingSet]
    PRIMARY KEY CLUSTERED ([CourtCaseId] ASC);
GO

-- Creating primary key on [Id] in table 'PersonBaseSet_Attorneys'
ALTER TABLE [dbo].[PersonBaseSet_Attorneys]
ADD CONSTRAINT [PK_PersonBaseSet_Attorneys]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderBaseSet_CH130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_CH130ROOrder]
ADD CONSTRAINT [PK_OrderBaseSet_CH130ROOrder]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ConductBaseSet_ConductROSection'
ALTER TABLE [dbo].[ConductBaseSet_ConductROSection]
ADD CONSTRAINT [PK_ConductBaseSet_ConductROSection]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SAOEAROSectionSet_SAOROSection'
ALTER TABLE [dbo].[SAOEAROSectionSet_SAOROSection]
ADD CONSTRAINT [PK_SAOEAROSectionSet_SAOROSection]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderBaseSet_CH110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_CH110TROOrder]
ADD CONSTRAINT [PK_OrderBaseSet_CH110TROOrder]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ConductBaseSet_ConductTROSection'
ALTER TABLE [dbo].[ConductBaseSet_ConductTROSection]
ADD CONSTRAINT [PK_ConductBaseSet_ConductTROSection]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SAOEAROSectionSet_SAOTROSection'
ALTER TABLE [dbo].[SAOEAROSectionSet_SAOTROSection]
ADD CONSTRAINT [PK_SAOEAROSectionSet_SAOTROSection]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OtherOrdersROSectionSet_OtherOrdersTROSection'
ALTER TABLE [dbo].[OtherOrdersROSectionSet_OtherOrdersTROSection]
ADD CONSTRAINT [PK_OtherOrdersROSectionSet_OtherOrdersTROSection]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderBaseSet_DV110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder]
ADD CONSTRAINT [PK_OrderBaseSet_DV110TROOrder]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ConductBaseSet_ConductDVROSection'
ALTER TABLE [dbo].[ConductBaseSet_ConductDVROSection]
ADD CONSTRAINT [PK_ConductBaseSet_ConductDVROSection]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ConductBaseSet_ConductDVTROSection'
ALTER TABLE [dbo].[ConductBaseSet_ConductDVTROSection]
ADD CONSTRAINT [PK_ConductBaseSet_ConductDVTROSection]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MoveOutROSectionSet_MoveOutTROSection'
ALTER TABLE [dbo].[MoveOutROSectionSet_MoveOutTROSection]
ADD CONSTRAINT [PK_MoveOutROSectionSet_MoveOutTROSection]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CommunicationsRecordingROSectionSet_CommunicationsRecordingTROSection'
ALTER TABLE [dbo].[CommunicationsRecordingROSectionSet_CommunicationsRecordingTROSection]
ADD CONSTRAINT [PK_CommunicationsRecordingROSectionSet_CommunicationsRecordingTROSection]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AnimalsROSectionSet_AnimalsTROSection'
ALTER TABLE [dbo].[AnimalsROSectionSet_AnimalsTROSection]
ADD CONSTRAINT [PK_AnimalsROSectionSet_AnimalsTROSection]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PropertyControlROSectionSet_PropertyControlTROSection'
ALTER TABLE [dbo].[PropertyControlROSectionSet_PropertyControlTROSection]
ADD CONSTRAINT [PK_PropertyControlROSectionSet_PropertyControlTROSection]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PaymentsROSectionSet_PaymentsTROSection'
ALTER TABLE [dbo].[PaymentsROSectionSet_PaymentsTROSection]
ADD CONSTRAINT [PK_PaymentsROSectionSet_PaymentsTROSection]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PropertyRestrainingOrdersROSectionSet_PropertyRestrainingOrdersTROSection'
ALTER TABLE [dbo].[PropertyRestrainingOrdersROSectionSet_PropertyRestrainingOrdersTROSection]
ADD CONSTRAINT [PK_PropertyRestrainingOrdersROSectionSet_PropertyRestrainingOrdersTROSection]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderBaseSet_DV130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder]
ADD CONSTRAINT [PK_OrderBaseSet_DV130ROOrder]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderBaseSet_EA110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_EA110TROOrder]
ADD CONSTRAINT [PK_OrderBaseSet_EA110TROOrder]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SAOEAROSectionSet_SAOEATROSection'
ALTER TABLE [dbo].[SAOEAROSectionSet_SAOEATROSection]
ADD CONSTRAINT [PK_SAOEAROSectionSet_SAOEATROSection]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'NoGunsSectionSet_NoGunsEASection'
ALTER TABLE [dbo].[NoGunsSectionSet_NoGunsEASection]
ADD CONSTRAINT [PK_NoGunsSectionSet_NoGunsEASection]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderBaseSet_EA130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_EA130ROOrder]
ADD CONSTRAINT [PK_OrderBaseSet_EA130ROOrder]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ServiceFeesSectionSet_ServiceFeesEA130Section'
ALTER TABLE [dbo].[ServiceFeesSectionSet_ServiceFeesEA130Section]
ADD CONSTRAINT [PK_ServiceFeesSectionSet_ServiceFeesEA130Section]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonBaseSet_Child'
ALTER TABLE [dbo].[PersonBaseSet_Child]
ADD CONSTRAINT [PK_PersonBaseSet_Child]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonBaseSet_OtherProtected'
ALTER TABLE [dbo].[PersonBaseSet_OtherProtected]
ADD CONSTRAINT [PK_PersonBaseSet_OtherProtected]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonBaseSet_Interpreter'
ALTER TABLE [dbo].[PersonBaseSet_Interpreter]
ADD CONSTRAINT [PK_PersonBaseSet_Interpreter]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [PersonId], [HearingId] in table 'Appearance_AppearanceWithSworn'
ALTER TABLE [dbo].[Appearance_AppearanceWithSworn]
ADD CONSTRAINT [PK_Appearance_AppearanceWithSworn]
    PRIMARY KEY CLUSTERED ([PersonId], [HearingId] ASC);
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

-- Creating foreign key on [CourtClerkId] in table 'CourtCase'
ALTER TABLE [dbo].[CourtCase]
ADD CONSTRAINT [FK_dbo_CourtCase_dbo_User_CourtClerk_UserId]
    FOREIGN KEY ([CourtClerkId])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CourtCase_dbo_User_CourtClerk_UserId'
CREATE INDEX [IX_FK_dbo_CourtCase_dbo_User_CourtClerk_UserId]
ON [dbo].[CourtCase]
    ([CourtClerkId]);
GO

-- Creating foreign key on [CourtCountyId] in table 'CourtDepartments'
ALTER TABLE [dbo].[CourtDepartments]
ADD CONSTRAINT [FK_dbo_CourtDepartmenets_dbo_CourtCounty_CourtCountyId]
    FOREIGN KEY ([CourtCountyId])
    REFERENCES [dbo].[CourtCounty]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CourtDepartmenets_dbo_CourtCounty_CourtCountyId'
CREATE INDEX [IX_FK_dbo_CourtDepartmenets_dbo_CourtCounty_CourtCountyId]
ON [dbo].[CourtDepartments]
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

-- Creating foreign key on [MergeCaseId] in table 'CaseHistory'
ALTER TABLE [dbo].[CaseHistory]
ADD CONSTRAINT [FK_dbo_CaseHistory_dbo_CourtCase_MergeCase_Id]
    FOREIGN KEY ([MergeCaseId])
    REFERENCES [dbo].[CourtCase]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CaseHistory_dbo_CourtCase_MergeCase_Id'
CREATE INDEX [IX_FK_dbo_CaseHistory_dbo_CourtCase_MergeCase_Id]
ON [dbo].[CaseHistory]
    ([MergeCaseId]);
GO

-- Creating foreign key on [Department_Id] in table 'Hearings'
ALTER TABLE [dbo].[Hearings]
ADD CONSTRAINT [FK_dbo_Hearings_dbo_CourtDepartmenets_Department_Id]
    FOREIGN KEY ([Department_Id])
    REFERENCES [dbo].[CourtDepartments]
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

-- Creating foreign key on [Attorney_Id] in table 'ThirdPartyData'
ALTER TABLE [dbo].[ThirdPartyData]
ADD CONSTRAINT [FK_dbo_ThirdPartyData_dbo_Attorneys_Attorney_Id]
    FOREIGN KEY ([Attorney_Id])
    REFERENCES [dbo].[PersonBaseSet_Attorneys]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_ThirdPartyData_dbo_Attorneys_Attorney_Id'
CREATE INDEX [IX_FK_dbo_ThirdPartyData_dbo_Attorneys_Attorney_Id]
ON [dbo].[ThirdPartyData]
    ([Attorney_Id]);
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

-- Creating foreign key on [CourtCaseId] in table 'CaseHistory'
ALTER TABLE [dbo].[CaseHistory]
ADD CONSTRAINT [FK_dbo_CaseHistory_dbo_CourtCase_CourtCase_Id]
    FOREIGN KEY ([CourtCaseId])
    REFERENCES [dbo].[CourtCase]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CaseHistory_dbo_CourtCase_CourtCase_Id'
CREATE INDEX [IX_FK_dbo_CaseHistory_dbo_CourtCase_CourtCase_Id]
ON [dbo].[CaseHistory]
    ([CourtCaseId]);
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

-- Creating foreign key on [CourtCaseId] in table 'PersonBaseSet'
ALTER TABLE [dbo].[PersonBaseSet]
ADD CONSTRAINT [FK_CourtCaseAdditionalParty]
    FOREIGN KEY ([CourtCaseId])
    REFERENCES [dbo].[CourtCase]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CourtCaseAdditionalParty'
CREATE INDEX [IX_FK_CourtCaseAdditionalParty]
ON [dbo].[PersonBaseSet]
    ([CourtCaseId]);
GO

-- Creating foreign key on [ConductSection_Id] in table 'OrderBaseSet_CH130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_CH130ROOrder]
ADD CONSTRAINT [FK_CH130OrderConductSection]
    FOREIGN KEY ([ConductSection_Id])
    REFERENCES [dbo].[ConductBaseSet_ConductROSection]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CH130OrderConductSection'
CREATE INDEX [IX_FK_CH130OrderConductSection]
ON [dbo].[OrderBaseSet_CH130ROOrder]
    ([ConductSection_Id]);
GO

-- Creating foreign key on [ServiceSection_Id] in table 'OrderBaseSet_CH130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_CH130ROOrder]
ADD CONSTRAINT [FK_CH130OrderServiceSection]
    FOREIGN KEY ([ServiceSection_Id])
    REFERENCES [dbo].[ServiceSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CH130OrderServiceSection'
CREATE INDEX [IX_FK_CH130OrderServiceSection]
ON [dbo].[OrderBaseSet_CH130ROOrder]
    ([ServiceSection_Id]);
GO

-- Creating foreign key on [SAOSection_Id] in table 'OrderBaseSet_CH130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_CH130ROOrder]
ADD CONSTRAINT [FK_CH130OrderSAOSection]
    FOREIGN KEY ([SAOSection_Id])
    REFERENCES [dbo].[SAOEAROSectionSet_SAOROSection]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CH130OrderSAOSection'
CREATE INDEX [IX_FK_CH130OrderSAOSection]
ON [dbo].[OrderBaseSet_CH130ROOrder]
    ([SAOSection_Id]);
GO

-- Creating foreign key on [NoGunsSection_Id] in table 'OrderBaseSet_CH130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_CH130ROOrder]
ADD CONSTRAINT [FK_CH130OrderNoGunsSection]
    FOREIGN KEY ([NoGunsSection_Id])
    REFERENCES [dbo].[NoGunsSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CH130OrderNoGunsSection'
CREATE INDEX [IX_FK_CH130OrderNoGunsSection]
ON [dbo].[OrderBaseSet_CH130ROOrder]
    ([NoGunsSection_Id]);
GO

-- Creating foreign key on [OtherOrdersSection_Id] in table 'OrderBaseSet_CH130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_CH130ROOrder]
ADD CONSTRAINT [FK_CH130OrderOtherOrdersSection]
    FOREIGN KEY ([OtherOrdersSection_Id])
    REFERENCES [dbo].[OtherOrdersROSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CH130OrderOtherOrdersSection'
CREATE INDEX [IX_FK_CH130OrderOtherOrdersSection]
ON [dbo].[OrderBaseSet_CH130ROOrder]
    ([OtherOrdersSection_Id]);
GO

-- Creating foreign key on [CarposEntrySectionId] in table 'LawEnforcementSet'
ALTER TABLE [dbo].[LawEnforcementSet]
ADD CONSTRAINT [FK_CarposEntrySectionLawEnforcement]
    FOREIGN KEY ([CarposEntrySectionId])
    REFERENCES [dbo].[CarposEntrySectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CarposEntrySectionLawEnforcement'
CREATE INDEX [IX_FK_CarposEntrySectionLawEnforcement]
ON [dbo].[LawEnforcementSet]
    ([CarposEntrySectionId]);
GO

-- Creating foreign key on [CarposEntrySection_Id] in table 'OrderBaseSet_CH130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_CH130ROOrder]
ADD CONSTRAINT [FK_CH130OrderCarposEntrySection]
    FOREIGN KEY ([CarposEntrySection_Id])
    REFERENCES [dbo].[CarposEntrySectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CH130OrderCarposEntrySection'
CREATE INDEX [IX_FK_CH130OrderCarposEntrySection]
ON [dbo].[OrderBaseSet_CH130ROOrder]
    ([CarposEntrySection_Id]);
GO

-- Creating foreign key on [ExpirationSection_Id] in table 'OrderBaseSet_CH130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_CH130ROOrder]
ADD CONSTRAINT [FK_CH130OrderExpirationSection]
    FOREIGN KEY ([ExpirationSection_Id])
    REFERENCES [dbo].[ExpirationSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CH130OrderExpirationSection'
CREATE INDEX [IX_FK_CH130OrderExpirationSection]
ON [dbo].[OrderBaseSet_CH130ROOrder]
    ([ExpirationSection_Id]);
GO

-- Creating foreign key on [ServiceFeesSection_Id] in table 'OrderBaseSet_CH130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_CH130ROOrder]
ADD CONSTRAINT [FK_CH130OrderServiceFeesSection]
    FOREIGN KEY ([ServiceFeesSection_Id])
    REFERENCES [dbo].[ServiceFeesSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CH130OrderServiceFeesSection'
CREATE INDEX [IX_FK_CH130OrderServiceFeesSection]
ON [dbo].[OrderBaseSet_CH130ROOrder]
    ([ServiceFeesSection_Id]);
GO

-- Creating foreign key on [AttorneysFeesSection_Id] in table 'OrderBaseSet_CH130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_CH130ROOrder]
ADD CONSTRAINT [FK_CH130OrderAttorneysFeesSection]
    FOREIGN KEY ([AttorneysFeesSection_Id])
    REFERENCES [dbo].[AttorneysFeesSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CH130OrderAttorneysFeesSection'
CREATE INDEX [IX_FK_CH130OrderAttorneysFeesSection]
ON [dbo].[OrderBaseSet_CH130ROOrder]
    ([AttorneysFeesSection_Id]);
GO

-- Creating foreign key on [ConductTROSection_Id] in table 'OrderBaseSet_CH110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_CH110TROOrder]
ADD CONSTRAINT [FK_CH110OrderConductTROSection]
    FOREIGN KEY ([ConductTROSection_Id])
    REFERENCES [dbo].[ConductBaseSet_ConductTROSection]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CH110OrderConductTROSection'
CREATE INDEX [IX_FK_CH110OrderConductTROSection]
ON [dbo].[OrderBaseSet_CH110TROOrder]
    ([ConductTROSection_Id]);
GO

-- Creating foreign key on [SAOTROSection_Id] in table 'OrderBaseSet_CH110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_CH110TROOrder]
ADD CONSTRAINT [FK_CH110OrderSAOTROSection]
    FOREIGN KEY ([SAOTROSection_Id])
    REFERENCES [dbo].[SAOEAROSectionSet_SAOTROSection]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CH110OrderSAOTROSection'
CREATE INDEX [IX_FK_CH110OrderSAOTROSection]
ON [dbo].[OrderBaseSet_CH110TROOrder]
    ([SAOTROSection_Id]);
GO

-- Creating foreign key on [NoGunsSection_Id] in table 'OrderBaseSet_CH110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_CH110TROOrder]
ADD CONSTRAINT [FK_CH110TROOrderNoGunsSection]
    FOREIGN KEY ([NoGunsSection_Id])
    REFERENCES [dbo].[NoGunsSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CH110TROOrderNoGunsSection'
CREATE INDEX [IX_FK_CH110TROOrderNoGunsSection]
ON [dbo].[OrderBaseSet_CH110TROOrder]
    ([NoGunsSection_Id]);
GO

-- Creating foreign key on [OtherOrdersTROSection_Id] in table 'OrderBaseSet_CH110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_CH110TROOrder]
ADD CONSTRAINT [FK_CH110TROOrderOtherOrdersTROSection]
    FOREIGN KEY ([OtherOrdersTROSection_Id])
    REFERENCES [dbo].[OtherOrdersROSectionSet_OtherOrdersTROSection]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CH110TROOrderOtherOrdersTROSection'
CREATE INDEX [IX_FK_CH110TROOrderOtherOrdersTROSection]
ON [dbo].[OrderBaseSet_CH110TROOrder]
    ([OtherOrdersTROSection_Id]);
GO

-- Creating foreign key on [CarposEntryROSection_Id] in table 'OrderBaseSet_CH110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_CH110TROOrder]
ADD CONSTRAINT [FK_CH110TROOrderCarposEntryROSection]
    FOREIGN KEY ([CarposEntryROSection_Id])
    REFERENCES [dbo].[CarposEntrySectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CH110TROOrderCarposEntryROSection'
CREATE INDEX [IX_FK_CH110TROOrderCarposEntryROSection]
ON [dbo].[OrderBaseSet_CH110TROOrder]
    ([CarposEntryROSection_Id]);
GO

-- Creating foreign key on [ServiceFeesSection_Id] in table 'OrderBaseSet_CH110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_CH110TROOrder]
ADD CONSTRAINT [FK_CH110TROOrderServiceFeesSection]
    FOREIGN KEY ([ServiceFeesSection_Id])
    REFERENCES [dbo].[ServiceFeesSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CH110TROOrderServiceFeesSection'
CREATE INDEX [IX_FK_CH110TROOrderServiceFeesSection]
ON [dbo].[OrderBaseSet_CH110TROOrder]
    ([ServiceFeesSection_Id]);
GO

-- Creating foreign key on [ExpirationSection_Id] in table 'OrderBaseSet_CH110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_CH110TROOrder]
ADD CONSTRAINT [FK_CH110TROOrderExpirationSection]
    FOREIGN KEY ([ExpirationSection_Id])
    REFERENCES [dbo].[ExpirationSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CH110TROOrderExpirationSection'
CREATE INDEX [IX_FK_CH110TROOrderExpirationSection]
ON [dbo].[OrderBaseSet_CH110TROOrder]
    ([ExpirationSection_Id]);
GO

-- Creating foreign key on [ConductDVTROSection_Id] in table 'OrderBaseSet_DV110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder]
ADD CONSTRAINT [FK_DV110TROOrderConductDVTROSection]
    FOREIGN KEY ([ConductDVTROSection_Id])
    REFERENCES [dbo].[ConductBaseSet_ConductDVTROSection]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV110TROOrderConductDVTROSection'
CREATE INDEX [IX_FK_DV110TROOrderConductDVTROSection]
ON [dbo].[OrderBaseSet_DV110TROOrder]
    ([ConductDVTROSection_Id]);
GO

-- Creating foreign key on [DV110ServiceSection_Id] in table 'OrderBaseSet_DV110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder]
ADD CONSTRAINT [FK_DV110TROOrderDV110ServiceSection]
    FOREIGN KEY ([DV110ServiceSection_Id])
    REFERENCES [dbo].[DV110ServiceSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV110TROOrderDV110ServiceSection'
CREATE INDEX [IX_FK_DV110TROOrderDV110ServiceSection]
ON [dbo].[OrderBaseSet_DV110TROOrder]
    ([DV110ServiceSection_Id]);
GO

-- Creating foreign key on [SAOTROSection_Id] in table 'OrderBaseSet_DV110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder]
ADD CONSTRAINT [FK_DV110TROOrderSAOTROSection]
    FOREIGN KEY ([SAOTROSection_Id])
    REFERENCES [dbo].[SAOEAROSectionSet_SAOTROSection]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV110TROOrderSAOTROSection'
CREATE INDEX [IX_FK_DV110TROOrderSAOTROSection]
ON [dbo].[OrderBaseSet_DV110TROOrder]
    ([SAOTROSection_Id]);
GO

-- Creating foreign key on [MoveOutTROSection_Id] in table 'OrderBaseSet_DV110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder]
ADD CONSTRAINT [FK_DV110TROOrderMoveOutTROSection]
    FOREIGN KEY ([MoveOutTROSection_Id])
    REFERENCES [dbo].[MoveOutROSectionSet_MoveOutTROSection]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV110TROOrderMoveOutTROSection'
CREATE INDEX [IX_FK_DV110TROOrderMoveOutTROSection]
ON [dbo].[OrderBaseSet_DV110TROOrder]
    ([MoveOutTROSection_Id]);
GO

-- Creating foreign key on [CommunicationsRecordingTROSection_Id] in table 'OrderBaseSet_DV110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder]
ADD CONSTRAINT [FK_DV110TROOrderCommunicationsRecordingTROSection]
    FOREIGN KEY ([CommunicationsRecordingTROSection_Id])
    REFERENCES [dbo].[CommunicationsRecordingROSectionSet_CommunicationsRecordingTROSection]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV110TROOrderCommunicationsRecordingTROSection'
CREATE INDEX [IX_FK_DV110TROOrderCommunicationsRecordingTROSection]
ON [dbo].[OrderBaseSet_DV110TROOrder]
    ([CommunicationsRecordingTROSection_Id]);
GO

-- Creating foreign key on [AnimalsTROSection_Id] in table 'OrderBaseSet_DV110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder]
ADD CONSTRAINT [FK_DV110TROOrderAnimalsTROSection]
    FOREIGN KEY ([AnimalsTROSection_Id])
    REFERENCES [dbo].[AnimalsROSectionSet_AnimalsTROSection]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV110TROOrderAnimalsTROSection'
CREATE INDEX [IX_FK_DV110TROOrderAnimalsTROSection]
ON [dbo].[OrderBaseSet_DV110TROOrder]
    ([AnimalsTROSection_Id]);
GO

-- Creating foreign key on [OtherOrdersTROSection_Id] in table 'OrderBaseSet_DV110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder]
ADD CONSTRAINT [FK_DV110TROOrderOtherOrdersTROSection]
    FOREIGN KEY ([OtherOrdersTROSection_Id])
    REFERENCES [dbo].[OtherOrdersROSectionSet_OtherOrdersTROSection]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV110TROOrderOtherOrdersTROSection'
CREATE INDEX [IX_FK_DV110TROOrderOtherOrdersTROSection]
ON [dbo].[OrderBaseSet_DV110TROOrder]
    ([OtherOrdersTROSection_Id]);
GO

-- Creating foreign key on [NoGunsSection_Id] in table 'OrderBaseSet_DV110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder]
ADD CONSTRAINT [FK_DV110TROOrderNoGunsSection]
    FOREIGN KEY ([NoGunsSection_Id])
    REFERENCES [dbo].[NoGunsSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV110TROOrderNoGunsSection'
CREATE INDEX [IX_FK_DV110TROOrderNoGunsSection]
ON [dbo].[OrderBaseSet_DV110TROOrder]
    ([NoGunsSection_Id]);
GO

-- Creating foreign key on [BatterInterventionSection_Id] in table 'OrderBaseSet_DV110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder]
ADD CONSTRAINT [FK_DV110TROOrderBatterInterventionSection]
    FOREIGN KEY ([BatterInterventionSection_Id])
    REFERENCES [dbo].[BatterInterventionSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV110TROOrderBatterInterventionSection'
CREATE INDEX [IX_FK_DV110TROOrderBatterInterventionSection]
ON [dbo].[OrderBaseSet_DV110TROOrder]
    ([BatterInterventionSection_Id]);
GO

-- Creating foreign key on [ExpirationSection_Id] in table 'OrderBaseSet_DV110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder]
ADD CONSTRAINT [FK_DV110TROOrderExpirationSection]
    FOREIGN KEY ([ExpirationSection_Id])
    REFERENCES [dbo].[ExpirationSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV110TROOrderExpirationSection'
CREATE INDEX [IX_FK_DV110TROOrderExpirationSection]
ON [dbo].[OrderBaseSet_DV110TROOrder]
    ([ExpirationSection_Id]);
GO

-- Creating foreign key on [PropertyControSectionId] in table 'PropertyRecordSet'
ALTER TABLE [dbo].[PropertyRecordSet]
ADD CONSTRAINT [FK_PropertyControlROSectionPropertyRecord]
    FOREIGN KEY ([PropertyControSectionId])
    REFERENCES [dbo].[PropertyControlROSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PropertyControlROSectionPropertyRecord'
CREATE INDEX [IX_FK_PropertyControlROSectionPropertyRecord]
ON [dbo].[PropertyRecordSet]
    ([PropertyControSectionId]);
GO

-- Creating foreign key on [PropertyControlTROSection_Id] in table 'OrderBaseSet_DV110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder]
ADD CONSTRAINT [FK_DV110TROOrderPropertyControlTROSection]
    FOREIGN KEY ([PropertyControlTROSection_Id])
    REFERENCES [dbo].[PropertyControlROSectionSet_PropertyControlTROSection]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV110TROOrderPropertyControlTROSection'
CREATE INDEX [IX_FK_DV110TROOrderPropertyControlTROSection]
ON [dbo].[OrderBaseSet_DV110TROOrder]
    ([PropertyControlTROSection_Id]);
GO

-- Creating foreign key on [PaymentsROSectionId] in table 'PaymentRecordSet'
ALTER TABLE [dbo].[PaymentRecordSet]
ADD CONSTRAINT [FK_PaymentsROSectionPaymentRecord]
    FOREIGN KEY ([PaymentsROSectionId])
    REFERENCES [dbo].[PaymentsROSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PaymentsROSectionPaymentRecord'
CREATE INDEX [IX_FK_PaymentsROSectionPaymentRecord]
ON [dbo].[PaymentRecordSet]
    ([PaymentsROSectionId]);
GO

-- Creating foreign key on [PaymentsTROSection_Id] in table 'OrderBaseSet_DV110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder]
ADD CONSTRAINT [FK_DV110TROOrderPaymentsTROSection]
    FOREIGN KEY ([PaymentsTROSection_Id])
    REFERENCES [dbo].[PaymentsROSectionSet_PaymentsTROSection]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV110TROOrderPaymentsTROSection'
CREATE INDEX [IX_FK_DV110TROOrderPaymentsTROSection]
ON [dbo].[OrderBaseSet_DV110TROOrder]
    ([PaymentsTROSection_Id]);
GO

-- Creating foreign key on [PropertyRestrainingOrdersTROSection_Id] in table 'OrderBaseSet_DV110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder]
ADD CONSTRAINT [FK_DV110TROOrderPropertyRestrainingOrdersTROSection]
    FOREIGN KEY ([PropertyRestrainingOrdersTROSection_Id])
    REFERENCES [dbo].[PropertyRestrainingOrdersROSectionSet_PropertyRestrainingOrdersTROSection]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV110TROOrderPropertyRestrainingOrdersTROSection'
CREATE INDEX [IX_FK_DV110TROOrderPropertyRestrainingOrdersTROSection]
ON [dbo].[OrderBaseSet_DV110TROOrder]
    ([PropertyRestrainingOrdersTROSection_Id]);
GO

-- Creating foreign key on [OtherPropertyOrdersTROSection_Id] in table 'OrderBaseSet_DV110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder]
ADD CONSTRAINT [FK_DV110TROOrderOtherOrdersTROSection1]
    FOREIGN KEY ([OtherPropertyOrdersTROSection_Id])
    REFERENCES [dbo].[OtherOrdersROSectionSet_OtherOrdersTROSection]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV110TROOrderOtherOrdersTROSection1'
CREATE INDEX [IX_FK_DV110TROOrderOtherOrdersTROSection1]
ON [dbo].[OrderBaseSet_DV110TROOrder]
    ([OtherPropertyOrdersTROSection_Id]);
GO

-- Creating foreign key on [ConductROSection_Id] in table 'OrderBaseSet_DV130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder]
ADD CONSTRAINT [FK_DV130ROOrderConductROSection]
    FOREIGN KEY ([ConductROSection_Id])
    REFERENCES [dbo].[ConductBaseSet_ConductROSection]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV130ROOrderConductROSection'
CREATE INDEX [IX_FK_DV130ROOrderConductROSection]
ON [dbo].[OrderBaseSet_DV130ROOrder]
    ([ConductROSection_Id]);
GO

-- Creating foreign key on [ServiceSection_Id] in table 'OrderBaseSet_DV130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder]
ADD CONSTRAINT [FK_DV130ROOrderServiceSection]
    FOREIGN KEY ([ServiceSection_Id])
    REFERENCES [dbo].[ServiceSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV130ROOrderServiceSection'
CREATE INDEX [IX_FK_DV130ROOrderServiceSection]
ON [dbo].[OrderBaseSet_DV130ROOrder]
    ([ServiceSection_Id]);
GO

-- Creating foreign key on [SAOROSection_Id] in table 'OrderBaseSet_DV130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder]
ADD CONSTRAINT [FK_DV130ROOrderSAOROSection]
    FOREIGN KEY ([SAOROSection_Id])
    REFERENCES [dbo].[SAOEAROSectionSet_SAOROSection]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV130ROOrderSAOROSection'
CREATE INDEX [IX_FK_DV130ROOrderSAOROSection]
ON [dbo].[OrderBaseSet_DV130ROOrder]
    ([SAOROSection_Id]);
GO

-- Creating foreign key on [MoveOutROSection_Id] in table 'OrderBaseSet_DV130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder]
ADD CONSTRAINT [FK_DV130ROOrderMoveOutROSection]
    FOREIGN KEY ([MoveOutROSection_Id])
    REFERENCES [dbo].[MoveOutROSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV130ROOrderMoveOutROSection'
CREATE INDEX [IX_FK_DV130ROOrderMoveOutROSection]
ON [dbo].[OrderBaseSet_DV130ROOrder]
    ([MoveOutROSection_Id]);
GO

-- Creating foreign key on [CommunicationsRecordingROSection_Id] in table 'OrderBaseSet_DV130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder]
ADD CONSTRAINT [FK_DV130ROOrderCommunicationsRecordingROSection]
    FOREIGN KEY ([CommunicationsRecordingROSection_Id])
    REFERENCES [dbo].[CommunicationsRecordingROSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV130ROOrderCommunicationsRecordingROSection'
CREATE INDEX [IX_FK_DV130ROOrderCommunicationsRecordingROSection]
ON [dbo].[OrderBaseSet_DV130ROOrder]
    ([CommunicationsRecordingROSection_Id]);
GO

-- Creating foreign key on [AnimalsROSection_Id] in table 'OrderBaseSet_DV130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder]
ADD CONSTRAINT [FK_DV130ROOrderAnimalsROSection]
    FOREIGN KEY ([AnimalsROSection_Id])
    REFERENCES [dbo].[AnimalsROSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV130ROOrderAnimalsROSection'
CREATE INDEX [IX_FK_DV130ROOrderAnimalsROSection]
ON [dbo].[OrderBaseSet_DV130ROOrder]
    ([AnimalsROSection_Id]);
GO

-- Creating foreign key on [OtherOrdersROSection_Id] in table 'OrderBaseSet_DV130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder]
ADD CONSTRAINT [FK_DV130ROOrderOtherOrdersROSection]
    FOREIGN KEY ([OtherOrdersROSection_Id])
    REFERENCES [dbo].[OtherOrdersROSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV130ROOrderOtherOrdersROSection'
CREATE INDEX [IX_FK_DV130ROOrderOtherOrdersROSection]
ON [dbo].[OrderBaseSet_DV130ROOrder]
    ([OtherOrdersROSection_Id]);
GO

-- Creating foreign key on [BatterInterventionSection_Id] in table 'OrderBaseSet_DV130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder]
ADD CONSTRAINT [FK_DV130ROOrderBatterInterventionSection]
    FOREIGN KEY ([BatterInterventionSection_Id])
    REFERENCES [dbo].[BatterInterventionSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV130ROOrderBatterInterventionSection'
CREATE INDEX [IX_FK_DV130ROOrderBatterInterventionSection]
ON [dbo].[OrderBaseSet_DV130ROOrder]
    ([BatterInterventionSection_Id]);
GO

-- Creating foreign key on [NoGunsSection_Id] in table 'OrderBaseSet_DV130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder]
ADD CONSTRAINT [FK_DV130ROOrderNoGunsSection]
    FOREIGN KEY ([NoGunsSection_Id])
    REFERENCES [dbo].[NoGunsSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV130ROOrderNoGunsSection'
CREATE INDEX [IX_FK_DV130ROOrderNoGunsSection]
ON [dbo].[OrderBaseSet_DV130ROOrder]
    ([NoGunsSection_Id]);
GO

-- Creating foreign key on [ExpirationSection_Id] in table 'OrderBaseSet_DV130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder]
ADD CONSTRAINT [FK_DV130ROOrderExpirationSection]
    FOREIGN KEY ([ExpirationSection_Id])
    REFERENCES [dbo].[ExpirationSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV130ROOrderExpirationSection'
CREATE INDEX [IX_FK_DV130ROOrderExpirationSection]
ON [dbo].[OrderBaseSet_DV130ROOrder]
    ([ExpirationSection_Id]);
GO

-- Creating foreign key on [PropertyControlROSection_Id] in table 'OrderBaseSet_DV130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder]
ADD CONSTRAINT [FK_DV130ROOrderPropertyControlROSection]
    FOREIGN KEY ([PropertyControlROSection_Id])
    REFERENCES [dbo].[PropertyControlROSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV130ROOrderPropertyControlROSection'
CREATE INDEX [IX_FK_DV130ROOrderPropertyControlROSection]
ON [dbo].[OrderBaseSet_DV130ROOrder]
    ([PropertyControlROSection_Id]);
GO

-- Creating foreign key on [PaymentsROSection_Id] in table 'OrderBaseSet_DV130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder]
ADD CONSTRAINT [FK_DV130ROOrderPaymentsROSection]
    FOREIGN KEY ([PaymentsROSection_Id])
    REFERENCES [dbo].[PaymentsROSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV130ROOrderPaymentsROSection'
CREATE INDEX [IX_FK_DV130ROOrderPaymentsROSection]
ON [dbo].[OrderBaseSet_DV130ROOrder]
    ([PaymentsROSection_Id]);
GO

-- Creating foreign key on [PropertyRestrainingOrdersROSection_Id] in table 'OrderBaseSet_DV130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder]
ADD CONSTRAINT [FK_DV130ROOrderPropertyRestrainingOrdersROSection]
    FOREIGN KEY ([PropertyRestrainingOrdersROSection_Id])
    REFERENCES [dbo].[PropertyRestrainingOrdersROSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV130ROOrderPropertyRestrainingOrdersROSection'
CREATE INDEX [IX_FK_DV130ROOrderPropertyRestrainingOrdersROSection]
ON [dbo].[OrderBaseSet_DV130ROOrder]
    ([PropertyRestrainingOrdersROSection_Id]);
GO

-- Creating foreign key on [OtherPropertyOrdersROSection_Id] in table 'OrderBaseSet_DV130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder]
ADD CONSTRAINT [FK_DV130ROOrderOtherOrdersROSection1]
    FOREIGN KEY ([OtherPropertyOrdersROSection_Id])
    REFERENCES [dbo].[OtherOrdersROSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DV130ROOrderOtherOrdersROSection1'
CREATE INDEX [IX_FK_DV130ROOrderOtherOrdersROSection1]
ON [dbo].[OrderBaseSet_DV130ROOrder]
    ([OtherPropertyOrdersROSection_Id]);
GO

-- Creating foreign key on [ConductTROSection_Id] in table 'OrderBaseSet_EA110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_EA110TROOrder]
ADD CONSTRAINT [FK_EA110TROOrderConductTROSection]
    FOREIGN KEY ([ConductTROSection_Id])
    REFERENCES [dbo].[ConductBaseSet_ConductTROSection]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EA110TROOrderConductTROSection'
CREATE INDEX [IX_FK_EA110TROOrderConductTROSection]
ON [dbo].[OrderBaseSet_EA110TROOrder]
    ([ConductTROSection_Id]);
GO

-- Creating foreign key on [SAOEATROSection_Id] in table 'OrderBaseSet_EA110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_EA110TROOrder]
ADD CONSTRAINT [FK_EA110TROOrderSAOEATROSection]
    FOREIGN KEY ([SAOEATROSection_Id])
    REFERENCES [dbo].[SAOEAROSectionSet_SAOEATROSection]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EA110TROOrderSAOEATROSection'
CREATE INDEX [IX_FK_EA110TROOrderSAOEATROSection]
ON [dbo].[OrderBaseSet_EA110TROOrder]
    ([SAOEATROSection_Id]);
GO

-- Creating foreign key on [MoveOutTROSection_Id] in table 'OrderBaseSet_EA110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_EA110TROOrder]
ADD CONSTRAINT [FK_EA110TROOrderMoveOutTROSection]
    FOREIGN KEY ([MoveOutTROSection_Id])
    REFERENCES [dbo].[MoveOutROSectionSet_MoveOutTROSection]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EA110TROOrderMoveOutTROSection'
CREATE INDEX [IX_FK_EA110TROOrderMoveOutTROSection]
ON [dbo].[OrderBaseSet_EA110TROOrder]
    ([MoveOutTROSection_Id]);
GO

-- Creating foreign key on [NoGunsEASection_Id] in table 'OrderBaseSet_EA110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_EA110TROOrder]
ADD CONSTRAINT [FK_EA110TROOrderNoGunsEASection]
    FOREIGN KEY ([NoGunsEASection_Id])
    REFERENCES [dbo].[NoGunsSectionSet_NoGunsEASection]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EA110TROOrderNoGunsEASection'
CREATE INDEX [IX_FK_EA110TROOrderNoGunsEASection]
ON [dbo].[OrderBaseSet_EA110TROOrder]
    ([NoGunsEASection_Id]);
GO

-- Creating foreign key on [CarposEntrySection_Id] in table 'OrderBaseSet_EA110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_EA110TROOrder]
ADD CONSTRAINT [FK_EA110TROOrderCarposEntrySection]
    FOREIGN KEY ([CarposEntrySection_Id])
    REFERENCES [dbo].[CarposEntrySectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EA110TROOrderCarposEntrySection'
CREATE INDEX [IX_FK_EA110TROOrderCarposEntrySection]
ON [dbo].[OrderBaseSet_EA110TROOrder]
    ([CarposEntrySection_Id]);
GO

-- Creating foreign key on [ServiceFeesSection_Id] in table 'OrderBaseSet_EA110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_EA110TROOrder]
ADD CONSTRAINT [FK_EA110TROOrderServiceFeesSection]
    FOREIGN KEY ([ServiceFeesSection_Id])
    REFERENCES [dbo].[ServiceFeesSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EA110TROOrderServiceFeesSection'
CREATE INDEX [IX_FK_EA110TROOrderServiceFeesSection]
ON [dbo].[OrderBaseSet_EA110TROOrder]
    ([ServiceFeesSection_Id]);
GO

-- Creating foreign key on [OtherOrdersTROSection_Id] in table 'OrderBaseSet_EA110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_EA110TROOrder]
ADD CONSTRAINT [FK_EA110TROOrderOtherOrdersTROSection]
    FOREIGN KEY ([OtherOrdersTROSection_Id])
    REFERENCES [dbo].[OtherOrdersROSectionSet_OtherOrdersTROSection]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EA110TROOrderOtherOrdersTROSection'
CREATE INDEX [IX_FK_EA110TROOrderOtherOrdersTROSection]
ON [dbo].[OrderBaseSet_EA110TROOrder]
    ([OtherOrdersTROSection_Id]);
GO

-- Creating foreign key on [ExpirationSection_Id] in table 'OrderBaseSet_EA110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_EA110TROOrder]
ADD CONSTRAINT [FK_EA110TROOrderExpirationSection]
    FOREIGN KEY ([ExpirationSection_Id])
    REFERENCES [dbo].[ExpirationSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EA110TROOrderExpirationSection'
CREATE INDEX [IX_FK_EA110TROOrderExpirationSection]
ON [dbo].[OrderBaseSet_EA110TROOrder]
    ([ExpirationSection_Id]);
GO

-- Creating foreign key on [ConductROSection_Id] in table 'OrderBaseSet_EA130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_EA130ROOrder]
ADD CONSTRAINT [FK_EA130ROOrderConductROSection]
    FOREIGN KEY ([ConductROSection_Id])
    REFERENCES [dbo].[ConductBaseSet_ConductROSection]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EA130ROOrderConductROSection'
CREATE INDEX [IX_FK_EA130ROOrderConductROSection]
ON [dbo].[OrderBaseSet_EA130ROOrder]
    ([ConductROSection_Id]);
GO

-- Creating foreign key on [ServiceSection_Id] in table 'OrderBaseSet_EA130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_EA130ROOrder]
ADD CONSTRAINT [FK_EA130ROOrderServiceSection]
    FOREIGN KEY ([ServiceSection_Id])
    REFERENCES [dbo].[ServiceSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EA130ROOrderServiceSection'
CREATE INDEX [IX_FK_EA130ROOrderServiceSection]
ON [dbo].[OrderBaseSet_EA130ROOrder]
    ([ServiceSection_Id]);
GO

-- Creating foreign key on [SAOEAROSection_Id] in table 'OrderBaseSet_EA130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_EA130ROOrder]
ADD CONSTRAINT [FK_EA130ROOrderSAOEAROSection]
    FOREIGN KEY ([SAOEAROSection_Id])
    REFERENCES [dbo].[SAOEAROSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EA130ROOrderSAOEAROSection'
CREATE INDEX [IX_FK_EA130ROOrderSAOEAROSection]
ON [dbo].[OrderBaseSet_EA130ROOrder]
    ([SAOEAROSection_Id]);
GO

-- Creating foreign key on [NoGunsEASection_Id] in table 'OrderBaseSet_EA130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_EA130ROOrder]
ADD CONSTRAINT [FK_EA130ROOrderNoGunsEASection]
    FOREIGN KEY ([NoGunsEASection_Id])
    REFERENCES [dbo].[NoGunsSectionSet_NoGunsEASection]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EA130ROOrderNoGunsEASection'
CREATE INDEX [IX_FK_EA130ROOrderNoGunsEASection]
ON [dbo].[OrderBaseSet_EA130ROOrder]
    ([NoGunsEASection_Id]);
GO

-- Creating foreign key on [ServiceFeesEA130Section_Id] in table 'OrderBaseSet_EA130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_EA130ROOrder]
ADD CONSTRAINT [FK_EA130ROOrderServiceFeesEA130Section]
    FOREIGN KEY ([ServiceFeesEA130Section_Id])
    REFERENCES [dbo].[ServiceFeesSectionSet_ServiceFeesEA130Section]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EA130ROOrderServiceFeesEA130Section'
CREATE INDEX [IX_FK_EA130ROOrderServiceFeesEA130Section]
ON [dbo].[OrderBaseSet_EA130ROOrder]
    ([ServiceFeesEA130Section_Id]);
GO

-- Creating foreign key on [OtherOrdersROSection_Id] in table 'OrderBaseSet_EA130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_EA130ROOrder]
ADD CONSTRAINT [FK_EA130ROOrderOtherOrdersROSection]
    FOREIGN KEY ([OtherOrdersROSection_Id])
    REFERENCES [dbo].[OtherOrdersROSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EA130ROOrderOtherOrdersROSection'
CREATE INDEX [IX_FK_EA130ROOrderOtherOrdersROSection]
ON [dbo].[OrderBaseSet_EA130ROOrder]
    ([OtherOrdersROSection_Id]);
GO

-- Creating foreign key on [ExpirationSection_Id] in table 'OrderBaseSet_EA130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_EA130ROOrder]
ADD CONSTRAINT [FK_EA130ROOrderExpirationSection]
    FOREIGN KEY ([ExpirationSection_Id])
    REFERENCES [dbo].[ExpirationSectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EA130ROOrderExpirationSection'
CREATE INDEX [IX_FK_EA130ROOrderExpirationSection]
ON [dbo].[OrderBaseSet_EA130ROOrder]
    ([ExpirationSection_Id]);
GO

-- Creating foreign key on [ThirdPartyDataId] in table 'CourtCase'
ALTER TABLE [dbo].[CourtCase]
ADD CONSTRAINT [FK_CourtCaseThirdPartyData]
    FOREIGN KEY ([ThirdPartyDataId])
    REFERENCES [dbo].[ThirdPartyData]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CourtCaseThirdPartyData'
CREATE INDEX [IX_FK_CourtCaseThirdPartyData]
ON [dbo].[CourtCase]
    ([ThirdPartyDataId]);
GO

-- Creating foreign key on [AttorneyForChild_Id] in table 'CourtCase'
ALTER TABLE [dbo].[CourtCase]
ADD CONSTRAINT [FK_CourtCaseAttorneys]
    FOREIGN KEY ([AttorneyForChild_Id])
    REFERENCES [dbo].[PersonBaseSet_Attorneys]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CourtCaseAttorneys'
CREATE INDEX [IX_FK_CourtCaseAttorneys]
ON [dbo].[CourtCase]
    ([AttorneyForChild_Id]);
GO

-- Creating foreign key on [HearingId] in table 'Appearance'
ALTER TABLE [dbo].[Appearance]
ADD CONSTRAINT [FK_dbo_Appearances_dbo_Hearings_HearingId]
    FOREIGN KEY ([HearingId])
    REFERENCES [dbo].[Hearings]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Appearances_dbo_Hearings_HearingId'
CREATE INDEX [IX_FK_dbo_Appearances_dbo_Hearings_HearingId]
ON [dbo].[Appearance]
    ([HearingId]);
GO

-- Creating foreign key on [ParentOrderId] in table 'CourtOrders'
ALTER TABLE [dbo].[CourtOrders]
ADD CONSTRAINT [FK_dbo_CourtOrders_dbo_CourtOrders_ParentOrderId]
    FOREIGN KEY ([ParentOrderId])
    REFERENCES [dbo].[CourtOrders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CourtOrders_dbo_CourtOrders_ParentOrderId'
CREATE INDEX [IX_FK_dbo_CourtOrders_dbo_CourtOrders_ParentOrderId]
ON [dbo].[CourtOrders]
    ([ParentOrderId]);
GO

-- Creating foreign key on [HearingId] in table 'CourtOrders'
ALTER TABLE [dbo].[CourtOrders]
ADD CONSTRAINT [FK_dbo_CourtOrders_dbo_Hearings_HearingId]
    FOREIGN KEY ([HearingId])
    REFERENCES [dbo].[Hearings]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CourtOrders_dbo_Hearings_HearingId'
CREATE INDEX [IX_FK_dbo_CourtOrders_dbo_Hearings_HearingId]
ON [dbo].[CourtOrders]
    ([HearingId]);
GO

-- Creating foreign key on [PersonId] in table 'Appearance'
ALTER TABLE [dbo].[Appearance]
ADD CONSTRAINT [FK_AppearancesPersonBase]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[PersonBaseSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [CourtCaseId] in table 'Hearings'
ALTER TABLE [dbo].[Hearings]
ADD CONSTRAINT [FK_CourtCaseHearings]
    FOREIGN KEY ([CourtCaseId])
    REFERENCES [dbo].[CourtCase]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CourtCaseHearings'
CREATE INDEX [IX_FK_CourtCaseHearings]
ON [dbo].[Hearings]
    ([CourtCaseId]);
GO

-- Creating foreign key on [HearingId] in table 'CaseHistory'
ALTER TABLE [dbo].[CaseHistory]
ADD CONSTRAINT [FK_HearingsCaseHistory]
    FOREIGN KEY ([HearingId])
    REFERENCES [dbo].[Hearings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HearingsCaseHistory'
CREATE INDEX [IX_FK_HearingsCaseHistory]
ON [dbo].[CaseHistory]
    ([HearingId]);
GO

-- Creating foreign key on [CourtClerkId] in table 'CaseHistory'
ALTER TABLE [dbo].[CaseHistory]
ADD CONSTRAINT [FK_CaseHistoryUser]
    FOREIGN KEY ([CourtClerkId])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CaseHistoryUser'
CREATE INDEX [IX_FK_CaseHistoryUser]
ON [dbo].[CaseHistory]
    ([CourtClerkId]);
GO

-- Creating foreign key on [AttorneysId] in table 'CourtParty'
ALTER TABLE [dbo].[CourtParty]
ADD CONSTRAINT [FK_CourtPartyAttorneys]
    FOREIGN KEY ([AttorneysId])
    REFERENCES [dbo].[PersonBaseSet_Attorneys]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CourtPartyAttorneys'
CREATE INDEX [IX_FK_CourtPartyAttorneys]
ON [dbo].[CourtParty]
    ([AttorneysId]);
GO

-- Creating foreign key on [Id] in table 'OrderBaseSet'
ALTER TABLE [dbo].[OrderBaseSet]
ADD CONSTRAINT [FK_CourtOrdersOrderBase]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[CourtOrders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'PersonBaseSet_Attorneys'
ALTER TABLE [dbo].[PersonBaseSet_Attorneys]
ADD CONSTRAINT [FK_Attorneys_inherits_PersonBase]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PersonBaseSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'OrderBaseSet_CH130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_CH130ROOrder]
ADD CONSTRAINT [FK_CH130ROOrder_inherits_OrderBase]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[OrderBaseSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'ConductBaseSet_ConductROSection'
ALTER TABLE [dbo].[ConductBaseSet_ConductROSection]
ADD CONSTRAINT [FK_ConductROSection_inherits_ConductBase]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[ConductBaseSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'SAOEAROSectionSet_SAOROSection'
ALTER TABLE [dbo].[SAOEAROSectionSet_SAOROSection]
ADD CONSTRAINT [FK_SAOROSection_inherits_SAOEAROSection]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[SAOEAROSectionSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'OrderBaseSet_CH110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_CH110TROOrder]
ADD CONSTRAINT [FK_CH110TROOrder_inherits_OrderBase]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[OrderBaseSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'ConductBaseSet_ConductTROSection'
ALTER TABLE [dbo].[ConductBaseSet_ConductTROSection]
ADD CONSTRAINT [FK_ConductTROSection_inherits_ConductROSection]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[ConductBaseSet_ConductROSection]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'SAOEAROSectionSet_SAOTROSection'
ALTER TABLE [dbo].[SAOEAROSectionSet_SAOTROSection]
ADD CONSTRAINT [FK_SAOTROSection_inherits_SAOROSection]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[SAOEAROSectionSet_SAOROSection]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'OtherOrdersROSectionSet_OtherOrdersTROSection'
ALTER TABLE [dbo].[OtherOrdersROSectionSet_OtherOrdersTROSection]
ADD CONSTRAINT [FK_OtherOrdersTROSection_inherits_OtherOrdersROSection]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[OtherOrdersROSectionSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'OrderBaseSet_DV110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV110TROOrder]
ADD CONSTRAINT [FK_DV110TROOrder_inherits_OrderBase]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[OrderBaseSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'ConductBaseSet_ConductDVROSection'
ALTER TABLE [dbo].[ConductBaseSet_ConductDVROSection]
ADD CONSTRAINT [FK_ConductDVROSection_inherits_ConductBase]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[ConductBaseSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'ConductBaseSet_ConductDVTROSection'
ALTER TABLE [dbo].[ConductBaseSet_ConductDVTROSection]
ADD CONSTRAINT [FK_ConductDVTROSection_inherits_ConductDVROSection]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[ConductBaseSet_ConductDVROSection]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'MoveOutROSectionSet_MoveOutTROSection'
ALTER TABLE [dbo].[MoveOutROSectionSet_MoveOutTROSection]
ADD CONSTRAINT [FK_MoveOutTROSection_inherits_MoveOutROSection]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[MoveOutROSectionSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'CommunicationsRecordingROSectionSet_CommunicationsRecordingTROSection'
ALTER TABLE [dbo].[CommunicationsRecordingROSectionSet_CommunicationsRecordingTROSection]
ADD CONSTRAINT [FK_CommunicationsRecordingTROSection_inherits_CommunicationsRecordingROSection]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[CommunicationsRecordingROSectionSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'AnimalsROSectionSet_AnimalsTROSection'
ALTER TABLE [dbo].[AnimalsROSectionSet_AnimalsTROSection]
ADD CONSTRAINT [FK_AnimalsTROSection_inherits_AnimalsROSection]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[AnimalsROSectionSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'PropertyControlROSectionSet_PropertyControlTROSection'
ALTER TABLE [dbo].[PropertyControlROSectionSet_PropertyControlTROSection]
ADD CONSTRAINT [FK_PropertyControlTROSection_inherits_PropertyControlROSection]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PropertyControlROSectionSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'PaymentsROSectionSet_PaymentsTROSection'
ALTER TABLE [dbo].[PaymentsROSectionSet_PaymentsTROSection]
ADD CONSTRAINT [FK_PaymentsTROSection_inherits_PaymentsROSection]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PaymentsROSectionSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'PropertyRestrainingOrdersROSectionSet_PropertyRestrainingOrdersTROSection'
ALTER TABLE [dbo].[PropertyRestrainingOrdersROSectionSet_PropertyRestrainingOrdersTROSection]
ADD CONSTRAINT [FK_PropertyRestrainingOrdersTROSection_inherits_PropertyRestrainingOrdersROSection]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PropertyRestrainingOrdersROSectionSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'OrderBaseSet_DV130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_DV130ROOrder]
ADD CONSTRAINT [FK_DV130ROOrder_inherits_OrderBase]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[OrderBaseSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'OrderBaseSet_EA110TROOrder'
ALTER TABLE [dbo].[OrderBaseSet_EA110TROOrder]
ADD CONSTRAINT [FK_EA110TROOrder_inherits_OrderBase]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[OrderBaseSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'SAOEAROSectionSet_SAOEATROSection'
ALTER TABLE [dbo].[SAOEAROSectionSet_SAOEATROSection]
ADD CONSTRAINT [FK_SAOEATROSection_inherits_SAOEAROSection]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[SAOEAROSectionSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'NoGunsSectionSet_NoGunsEASection'
ALTER TABLE [dbo].[NoGunsSectionSet_NoGunsEASection]
ADD CONSTRAINT [FK_NoGunsEASection_inherits_NoGunsSection]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[NoGunsSectionSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'OrderBaseSet_EA130ROOrder'
ALTER TABLE [dbo].[OrderBaseSet_EA130ROOrder]
ADD CONSTRAINT [FK_EA130ROOrder_inherits_OrderBase]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[OrderBaseSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'ServiceFeesSectionSet_ServiceFeesEA130Section'
ALTER TABLE [dbo].[ServiceFeesSectionSet_ServiceFeesEA130Section]
ADD CONSTRAINT [FK_ServiceFeesEA130Section_inherits_ServiceFeesSection]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[ServiceFeesSectionSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'PersonBaseSet_Child'
ALTER TABLE [dbo].[PersonBaseSet_Child]
ADD CONSTRAINT [FK_Child_inherits_PersonBase]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PersonBaseSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'PersonBaseSet_OtherProtected'
ALTER TABLE [dbo].[PersonBaseSet_OtherProtected]
ADD CONSTRAINT [FK_OtherProtected_inherits_PersonBase]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PersonBaseSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'PersonBaseSet_Interpreter'
ALTER TABLE [dbo].[PersonBaseSet_Interpreter]
ADD CONSTRAINT [FK_Interpreter_inherits_PersonBase]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PersonBaseSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PersonId], [HearingId] in table 'Appearance_AppearanceWithSworn'
ALTER TABLE [dbo].[Appearance_AppearanceWithSworn]
ADD CONSTRAINT [FK_AppearanceWithSworn_inherits_Appearance]
    FOREIGN KEY ([PersonId], [HearingId])
    REFERENCES [dbo].[Appearance]
        ([PersonId], [HearingId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------