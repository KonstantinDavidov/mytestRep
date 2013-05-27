--[dbo].[CourtCaseStatuse]

DECLARE @CaseStatusNewId int = 1
DECLARE @CaseStatusReissuedId int = 10
DECLARE @CaseStatusActiveId int = 20
DECLARE @CaseStatusDroppedId int = 30
DECLARE @CaseStatusDismissedId int = 40

if not exists (Select 1 from [dbo].[CourtCaseStatuse] where Id = @CaseStatusNewId)
    insert into [dbo].[CourtCaseStatuse] (Id, CaseStatus)
        values (@CaseStatusNewId, N'New')
if not exists (Select 1 from [dbo].[CourtCaseStatuse] where Id = @CaseStatusReissuedId)
    insert into [dbo].[CourtCaseStatuse] (Id, CaseStatus)
        values (@CaseStatusReissuedId, N'Reissued')
if not exists (Select 1 from [dbo].[CourtCaseStatuse] where Id = @CaseStatusActiveId)
    insert into [dbo].[CourtCaseStatuse] (Id, CaseStatus)
        values (@CaseStatusActiveId, N'Active')
if not exists (Select 1 from [dbo].[CourtCaseStatuse] where Id = @CaseStatusDroppedId)
    insert into [dbo].[CourtCaseStatuse] (Id, CaseStatus)
        values (@CaseStatusDroppedId, N'Dropped')
if not exists (Select 1 from [dbo].[CourtCaseStatuse] where Id = @CaseStatusDismissedId)
    insert into [dbo].[CourtCaseStatuse] (Id, CaseStatus)
        values (@CaseStatusDismissedId, N'Dismissed')

--[dbo].[Designation]
DECLARE @DesignationNoneId int = 1
DECLARE @DesignationPlaintiffId int = 10
DECLARE @DesignationRespondentId int = 20

if not exists (Select 1 from [dbo].[Designation] where Id = @DesignationNoneId)
    insert into [dbo].[Designation] (Id, Designation)
        values (@DesignationNoneId, N'None')
if not exists (Select 1 from [dbo].[Designation] where Id = @DesignationPlaintiffId)
    insert into [dbo].[Designation] (Id, Designation)
        values (@DesignationPlaintiffId, N'Plaintiff')
if not exists (Select 1 from [dbo].[Designation] where Id = @DesignationRespondentId)
    insert into [dbo].[Designation] (Id, Designation)
        values (@DesignationRespondentId, N'Respondent')

--[dbo].[ParticipantRole]
DECLARE @ParticipantRoleProtectedId int = 1
DECLARE @ParticipantRolerestrainedId int = 10
DECLARE @ParticipantRoleAdditionalProtectedId int = 20

if not exists (Select 1 from [dbo].[ParticipantRole] where Id = @ParticipantRoleProtectedId)
    insert into [dbo].[ParticipantRole] (Id, ParticipantRole)
        values (@ParticipantRoleProtectedId, N'Protected')
if not exists (Select 1 from [dbo].[ParticipantRole] where Id = @ParticipantRolerestrainedId)
    insert into [dbo].[ParticipantRole] (Id, ParticipantRole)
        values (@ParticipantRolerestrainedId, N'Restrained')
if not exists (Select 1 from [dbo].[ParticipantRole] where Id = @ParticipantRoleAdditionalProtectedId)
    insert into [dbo].[ParticipantRole] (Id, ParticipantRole)
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

--[dbo].[Race]
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
DECLARE @Raceamoan int = 120
DECLARE @RaceHawaiian int = 130
DECLARE @RaceVietnamese int = 140
DECLARE @RaceWhite int = 150
DECLARE @RaceOther int = 160
DECLARE @RaceUnknown int = 170
DECLARE @RaceAsianIndian int = 180

if not exists (Select 1 from [dbo].[Race] where Id = @RaceOtherAsian)
    insert into [dbo].[Race] (Id, Race)
        values (@RaceOtherAsian, N'Other Asian')
if not exists (Select 1 from [dbo].[Race] where Id = @RaceBlack)
    insert into [dbo].[Race] (Id, Race)
        values (@RaceBlack, N'Black')
if not exists (Select 1 from [dbo].[Race] where Id = @RaceChineese)
    insert into [dbo].[Race] (Id, Race)
        values (@RaceChineese, N'Chinese')
if not exists (Select 1 from [dbo].[Race] where Id = @RaceCambodian)
    insert into [dbo].[Race] (Id, Race)
        values (@RaceCambodian, N'Cambodian')
if not exists (Select 1 from [dbo].[Race] where Id = @RaceFilipino)
    insert into [dbo].[Race] (Id, Race)
        values (@RaceFilipino, N'Filipino')
if not exists (Select 1 from [dbo].[Race] where Id = @RaceGuamanian)
    insert into [dbo].[Race] (Id, Race)
        values (@RaceGuamanian, N'Guamanian')
if not exists (Select 1 from [dbo].[Race] where Id = @RaceHispanic)
    insert into [dbo].[Race] (Id, Race)
        values (@RaceHispanic, N'Hispanic')
if not exists (Select 1 from [dbo].[Race] where Id = @RaceIndian)
    insert into [dbo].[Race] (Id, Race)
        values (@RaceIndian, N'Indian')
if not exists (Select 1 from [dbo].[Race] where Id = @RaceJapanese)
    insert into [dbo].[Race] (Id, Race)
        values (@RaceJapanese, N'Japanese')
if not exists (Select 1 from [dbo].[Race] where Id = @RaceKorean)
    insert into [dbo].[Race] (Id, Race)
        values (@RaceKorean, N'Korean')
if not exists (Select 1 from [dbo].[Race] where Id = @RaceLaotian)
    insert into [dbo].[Race] (Id, Race)
        values (@RaceLaotian, N'Laotian')
if not exists (Select 1 from [dbo].[Race] where Id = @RacePacificIslander)
    insert into [dbo].[Race] (Id, Race)
        values (@RacePacificIslander, N'Pacific Islander')
if not exists (Select 1 from [dbo].[Race] where Id = @Raceamoan)
    insert into [dbo].[Race] (Id, Race)
        values (@Raceamoan, N'Samoan')
if not exists (Select 1 from [dbo].[Race] where Id = @RaceHawaiian)
    insert into [dbo].[Race] (Id, Race)
        values (@RaceHawaiian, N'Hawaiian')
if not exists (Select 1 from [dbo].[Race] where Id = @RaceVietnamese)
    insert into [dbo].[Race] (Id, Race)
        values (@RaceVietnamese, N'Vietnamese')
if not exists (Select 1 from [dbo].[Race] where Id = @RaceWhite)
    insert into [dbo].[Race] (Id, Race)
        values (@RaceWhite, N'White')
if not exists (Select 1 from [dbo].[Race] where Id = @RaceOther)
    insert into [dbo].[Race] (Id, Race)
        values (@RaceOther, N'Other')
if not exists (Select 1 from [dbo].[Race] where Id = @RaceUnknown)
    insert into [dbo].[Race] (Id, Race)
        values (@RaceUnknown, N'Unknown')
if not exists (Select 1 from [dbo].[Race] where Id = @RaceAsianIndian)
    insert into [dbo].[Race] (Id, Race)
        values (@RaceAsianIndian, N'Asian Indian')