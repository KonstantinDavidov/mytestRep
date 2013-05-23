--[dbo].[CourtCaseStatuses]

DECLARE @CaseStatusNewId int = 1
DECLARE @CaseStatusReissuedId int = 10
DECLARE @CaseStatusActiveId int = 20
DECLARE @CaseStatusDroppedId int = 30
DECLARE @CaseStatusDismissedId int = 40

if not exists (Select 1 from [dbo].[CourtCaseStatuses] where Id = @CaseStatusNewId)
    insert into [dbo].[CourtCaseStatuses] (Id, CaseStatus)
        values (@CaseStatusNewId, N'New')
if not exists (Select 1 from [dbo].[CourtCaseStatuses] where Id = @CaseStatusReissuedId)
    insert into [dbo].[CourtCaseStatuses] (Id, CaseStatus)
        values (@CaseStatusReissuedId, N'Reissued')
if not exists (Select 1 from [dbo].[CourtCaseStatuses] where Id = @CaseStatusActiveId)
    insert into [dbo].[CourtCaseStatuses] (Id, CaseStatus)
        values (@CaseStatusActiveId, N'Active')
if not exists (Select 1 from [dbo].[CourtCaseStatuses] where Id = @CaseStatusDroppedId)
    insert into [dbo].[CourtCaseStatuses] (Id, CaseStatus)
        values (@CaseStatusDroppedId, N'Dropped')
if not exists (Select 1 from [dbo].[CourtCaseStatuses] where Id = @CaseStatusDismissedId)
    insert into [dbo].[CourtCaseStatuses] (Id, CaseStatus)
        values (@CaseStatusDismissedId, N'Dismissed')

--[dbo].[Designations]
DECLARE @DesignationNoneId int = 1
DECLARE @DesignationPlaintiffId int = 10
DECLARE @DesignationRespondentId int = 20

if not exists (Select 1 from [dbo].[Designations] where Id = @DesignationNoneId)
    insert into [dbo].[Designations] (Id, Designation)
        values (@DesignationNoneId, N'None')
if not exists (Select 1 from [dbo].[Designations] where Id = @DesignationPlaintiffId)
    insert into [dbo].[Designations] (Id, Designation)
        values (@DesignationPlaintiffId, N'Plaintiff')
if not exists (Select 1 from [dbo].[Designations] where Id = @DesignationRespondentId)
    insert into [dbo].[Designations] (Id, Designation)
        values (@DesignationRespondentId, N'Respondent')

--[dbo].[ParticipantRoles]
DECLARE @ParticipantRoleProtectedId int = 1
DECLARE @ParticipantRolerestrainedId int = 10
DECLARE @ParticipantRoleAdditionalProtectedId int = 20

if not exists (Select 1 from [dbo].[ParticipantRoles] where Id = @ParticipantRoleProtectedId)
    insert into [dbo].[ParticipantRoles] (Id, ParticipantRole)
        values (@ParticipantRoleProtectedId, N'Protected')
if not exists (Select 1 from [dbo].[ParticipantRoles] where Id = @ParticipantRolerestrainedId)
    insert into [dbo].[ParticipantRoles] (Id, ParticipantRole)
        values (@ParticipantRolerestrainedId, N'Restrained')
if not exists (Select 1 from [dbo].[ParticipantRoles] where Id = @ParticipantRoleAdditionalProtectedId)
    insert into [dbo].[ParticipantRoles] (Id, ParticipantRole)
        values (@ParticipantRoleAdditionalProtectedId, N'Additional Protected')

--[dbo].[Sex]
DECLARE @SexMaleId int = 1
DECLARE @SexFemaleId int = 10
DECLARE @SexUnknownId int = 20

if not exists (Select 1 from [dbo].[Sex] where Id = @SexMaleId)
    insert into [dbo].[Sex] (Id, Sex)
        values (@SexMaleId, N'Male')
if not exists (Select 1 from [dbo].[Sex] where Id = @SexFemaleId)
    insert into [dbo].[Sex] (Id, Sex)
        values (@SexFemaleId, N'Female')
if not exists (Select 1 from [dbo].[Sex] where Id = @SexUnknownId)
    insert into [dbo].[Sex] (Id, Sex)
        values (@SexUnknownId, N'Unknown')

--[dbo].[HairColor]
DECLARE @HairColorBlack int = 1
DECLARE @HairColorBlonde int = 10
DECLARE @HairColorBlue int = 20
DECLARE @HairColorBrown int = 30
DECLARE @HairColorGreen int = 40
DECLARE @HairColorGrey int = 50
DECLARE @HairColorOrange int = 60
DECLARE @HairColorPurple int = 70
DECLARE @HairColorPink int = 80
DECLARE @HairColorRed int = 90
DECLARE @HairColorSandy int = 100
DECLARE @HairColorWhite int = 110
DECLARE @HairColorUnknown int = 120

if not exists (select 1 from [dbo].[HairColor] where Id = @HairColorBlack)
    insert into [dbo].[HairColor] (Id, Color)
        values (@HairColorBlack, N'Black')
if not exists (select 1 from [dbo].[HairColor] where Id = @HairColorBlonde)
    insert into [dbo].[HairColor] (Id, Color)
        values (@HairColorBlonde, N'Blonde')
if not exists (select 1 from [dbo].[HairColor] where Id = @HairColorBlue)
    insert into [dbo].[HairColor] (Id, Color)
        values (@HairColorBlue, N'Blue')
if not exists (select 1 from [dbo].[HairColor] where Id = @HairColorBrown)
    insert into [dbo].[HairColor] (Id, Color)
        values (@HairColorBrown, N'Brown')
if not exists (select 1 from [dbo].[HairColor] where Id = @HairColorGreen)
    insert into [dbo].[HairColor] (Id, Color)
        values (@HairColorGreen, N'Green')
if not exists (select 1 from [dbo].[HairColor] where Id = @HairColorGrey)
    insert into [dbo].[HairColor] (Id, Color)
        values (@HairColorGrey, N'Grey')
if not exists (select 1 from [dbo].[HairColor] where Id = @HairColorOrange)
    insert into [dbo].[HairColor] (Id, Color)
        values (@HairColorOrange, N'Orange')
if not exists (select 1 from [dbo].[HairColor] where Id = @HairColorPurple)
    insert into [dbo].[HairColor] (Id, Color)
        values (@HairColorPurple, N'Purple')
if not exists (select 1 from [dbo].[HairColor] where Id = @HairColorPink)
    insert into [dbo].[HairColor] (Id, Color)
        values (@HairColorPink, N'Pink')
if not exists (select 1 from [dbo].[HairColor] where Id = @HairColorRed)
    insert into [dbo].[HairColor] (Id, Color)
        values (@HairColorRed, N'Red')
if not exists (select 1 from [dbo].[HairColor] where Id = @HairColorSandy)
    insert into [dbo].[HairColor] (Id, Color)
        values (@HairColorSandy, N'Sandy')
if not exists (select 1 from [dbo].[HairColor] where Id = @HairColorWhite)
    insert into [dbo].[HairColor] (Id, Color)
        values (@HairColorWhite, N'White')
if not exists (select 1 from [dbo].[HairColor] where Id = @HairColorUnknown)
    insert into [dbo].[HairColor] (Id, Color)
        values (@HairColorUnknown, N'Unknown')

-- [dbo].[EyesColor]
DECLARE @EyesColorBlue int = 1
DECLARE @EyesColorBlack int = 10
DECLARE @EyesColorBrown int = 20
DECLARE @EyesColorGreen int = 30
DECLARE @EyesColorGrey int = 40
DECLARE @EyesColorHazel int = 50
DECLARE @EyesColorMaroon int = 60
DECLARE @EyesColorMulticolored int = 70
DEClARE @EyesColorPink int = 80
DECLARE @EyesColorUnknown int = 90

if not exists (Select 1 from [dbo].[EyesColor] where id = @EyesColorBlue)
    insert into [dbo].[EyesColor] (Id, Color)
        values (@EyesColorBlue, N'Blue')
if not exists (Select 1 from [dbo].[EyesColor] where id = @EyesColorBlack)
    insert into [dbo].[EyesColor] (Id, Color)
        values (@EyesColorBlack, N'Black')
if not exists (Select 1 from [dbo].[EyesColor] where id = @EyesColorBrown)
    insert into [dbo].[EyesColor] (Id, Color)
        values (@EyesColorBrown, N'Brown')
if not exists (Select 1 from [dbo].[EyesColor] where id = @EyesColorGreen)
    insert into [dbo].[EyesColor] (Id, Color)
        values (@EyesColorGreen, N'Green')
if not exists (Select 1 from [dbo].[EyesColor] where id = @EyesColorGrey)
    insert into [dbo].[EyesColor] (Id, Color)
        values (@EyesColorGrey, N'Grey')
if not exists (Select 1 from [dbo].[EyesColor] where id = @EyesColorHazel)
    insert into [dbo].[EyesColor] (Id, Color)
        values (@EyesColorHazel, N'Hazel')
if not exists (Select 1 from [dbo].[EyesColor] where id = @EyesColorMaroon)
    insert into [dbo].[EyesColor] (Id, Color)
        values (@EyesColorMaroon, N'Maroon')
if not exists (Select 1 from [dbo].[EyesColor] where id = @EyesColorMulticolored)
    insert into [dbo].[EyesColor] (Id, Color)
        values (@EyesColorMulticolored, N'Multicolored')
if not exists (Select 1 from [dbo].[EyesColor] where id = @EyesColorPink)
    insert into [dbo].[EyesColor] (Id, Color)
        values (@EyesColorPink, N'Pink')
if not exists (Select 1 from [dbo].[EyesColor] where id = @EyesColorUnknown)
    insert into [dbo].[EyesColor] (Id, Color)
        values (@EyesColorUnknown, N'Unknown')

--[dbo].[Races]
DECLARE @RaceOtherAsian int = 1
DECLARE @RaceBlack int = 10
DECLARE @RaceChineese int = 20
DECLARE @RaceCambodian int = 30
DECLARE @RaceFilipino int = 40
DECLARE @RaceGuamanian int = 50
DECLARE @RaceHispanic int = 60
DECLARE @RaceIndian int = 70
DECLARE @RaceJapanese int = 80
DECLARE @RaceKorean int = 90
DECLARE @RaceLaotian int = 100
DECLARE @RacePacificIslander int = 110
DECLARE @RaceSamoan int = 120
DECLARE @RaceHawaiian int = 130
DECLARE @RaceVietnamese int = 140
DECLARE @RaceWhite int = 150
DECLARE @RaceOther int = 160
DECLARE @RaceUnknown int = 170
DECLARE @RaceAsianIndian int = 180

if not exists (Select 1 from [dbo].[Races] where Id = @RaceOtherAsian)
    insert into [dbo].[Races] (Id, Race)
        values (@RaceOtherAsian, N'Other Asian')
if not exists (Select 1 from [dbo].[Races] where Id = @RaceBlack)
    insert into [dbo].[Races] (Id, Race)
        values (@RaceBlack, N'Black')
if not exists (Select 1 from [dbo].[Races] where Id = @RaceChineese)
    insert into [dbo].[Races] (Id, Race)
        values (@RaceChineese, N'Chinese')
if not exists (Select 1 from [dbo].[Races] where Id = @RaceCambodian)
    insert into [dbo].[Races] (Id, Race)
        values (@RaceCambodian, N'Cambodian')
if not exists (Select 1 from [dbo].[Races] where Id = @RaceFilipino)
    insert into [dbo].[Races] (Id, Race)
        values (@RaceFilipino, N'Filipino')
if not exists (Select 1 from [dbo].[Races] where Id = @RaceGuamanian)
    insert into [dbo].[Races] (Id, Race)
        values (@RaceGuamanian, N'Guamanian')
if not exists (Select 1 from [dbo].[Races] where Id = @RaceHispanic)
    insert into [dbo].[Races] (Id, Race)
        values (@RaceHispanic, N'Hispanic')
if not exists (Select 1 from [dbo].[Races] where Id = @RaceIndian)
    insert into [dbo].[Races] (Id, Race)
        values (@RaceIndian, N'Indian')
if not exists (Select 1 from [dbo].[Races] where Id = @RaceJapanese)
    insert into [dbo].[Races] (Id, Race)
        values (@RaceJapanese, N'Japanese')
if not exists (Select 1 from [dbo].[Races] where Id = @RaceKorean)
    insert into [dbo].[Races] (Id, Race)
        values (@RaceKorean, N'Korean')
if not exists (Select 1 from [dbo].[Races] where Id = @RaceLaotian)
    insert into [dbo].[Races] (Id, Race)
        values (@RaceLaotian, N'Laotian')
if not exists (Select 1 from [dbo].[Races] where Id = @RacePacificIslander)
    insert into [dbo].[Races] (Id, Race)
        values (@RacePacificIslander, N'Pacific Islander')
if not exists (Select 1 from [dbo].[Races] where Id = @RaceSamoan)
    insert into [dbo].[Races] (Id, Race)
        values (@RaceSamoan, N'Samoan')
if not exists (Select 1 from [dbo].[Races] where Id = @RaceHawaiian)
    insert into [dbo].[Races] (Id, Race)
        values (@RaceHawaiian, N'Hawaiian')
if not exists (Select 1 from [dbo].[Races] where Id = @RaceVietnamese)
    insert into [dbo].[Races] (Id, Race)
        values (@RaceVietnamese, N'Vietnamese')
if not exists (Select 1 from [dbo].[Races] where Id = @RaceWhite)
    insert into [dbo].[Races] (Id, Race)
        values (@RaceWhite, N'White')
if not exists (Select 1 from [dbo].[Races] where Id = @RaceOther)
    insert into [dbo].[Races] (Id, Race)
        values (@RaceOther, N'Other')
if not exists (Select 1 from [dbo].[Races] where Id = @RaceUnknown)
    insert into [dbo].[Races] (Id, Race)
        values (@RaceUnknown, N'Unknown')
if not exists (Select 1 from [dbo].[Races] where Id = @RaceAsianIndian)
    insert into [dbo].[Races] (Id, Race)
        values (@RaceAsianIndian, N'Asian Indian')