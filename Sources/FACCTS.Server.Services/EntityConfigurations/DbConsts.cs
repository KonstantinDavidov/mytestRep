using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Data.EntityConfigurations
{
    internal class DbConsts
    {
        public const string SCHEMA_NAME = "dbo";

        public const string ID_COLUMN_NAME = "Id";

        public const string COURT_CASES_TABLE_NAME = "CourtCases";
        public const string COURT_CASE_CASE_NUMBER_COLUMN_NAME = "CaseNumber";
        public const string COURT_CASE_COURT_CLERK_ID_COLUMN_NAME = "CourtClerkId";
        public const string COURT_CASE_CCPOR_STATUS_COLUMN_NAME = "CCPORStatus";
        public const string COURT_CASE_CCPOR_ID_COLUMN_NAME = "CCPORId";
        public const string COURT_CASE_PARENT_CASE_ID_COLUMN_NAME = "ParentCaseId";
        public const string COURT_CASE_PARTY1_ID_COLUMN_NAME = "Party1Id";
        public const string COURT_CASE_PARTY2_ID_COLUMN_NAME = "Party2Id";
        public const string COURT_CASE_ATTORNEY_FOR_CHILD_ID_COLUMN_NAME = "AttorneyForChildId";
        public const string COURT_CASE_THIRD_PARTY_DATA_ID_COLUMN_NAME = "ThirdPartyDataId";

        public const string HEARINGS_TABLE_NAME = "Hearings";
        public const string HEARING_HEARING_DATE_COLUMN_NAME = "HearingDate";
        public const string HEARING_COURTROOM_ID_COLUMN_NAME = "CourtroomId";
        public const string HEARING_COURT_DEPARTMENT_ID_COLUMN_NAME = "CourtDepartmentId";
        public const string HEARING_JUDGE_COLUMN_NAME = "Judge";
        public const string HEARING_SESSION_COLUMN_NAME = "Session";
        public const string HEARING_COURT_CASE_ID_COLUMN_NAME = "CourtCaseId";

        public const string CASE_HISTORY_TABLE_NAME = "CaseHistory";
        public const string CASE_HISTORY_DATE_COLUMN_NAME = "Date";
        public const string CASE_HISTORY_CASE_HISTORY_EVENT_COLUMN_NAME = "CaseHistoryEvent";
        public const string CASE_HISTORY_COURT_CLERK_ID_COLUMN_NAME = "CourtClerkId";
        public const string CASE_HISTORY_CCPOR_ID_COLUMN_NAME = "CCPORId";
        public const string CASE_HISTORY_COURT_CASE_ID_COLUMN_NAME = "CourtCaseId";
        public const string CASE_HISTORY_MERGE_CASE_ID_COLUMN_NAME = "MergeCaseId";
        public const string CASE_HISTORY_HEARING_ID_COLUMN_NAME = "HearingId";

        public const string MANUAL_INTEGRATION_TASKS_TABLE_NAME = "ManualIntegrationTasks";
        public const string MANUAL_INTEGRATION_TASK_RECEIVE_TIME_COLUMN_NAME = "ReceiveTime";
        public const string MANUAL_INTEGRATION_TASK_START_TIME_COLUMN_NAME = "StartTime";
        public const string MANUAL_INTEGRATION_TASK_END_TIME_COLUMN_NAME = "EndTime";
        public const string MANUAL_INTEGRATION_TASK_INFO_COLUMN_NAME = "Info";
        public const string MANUAL_INTEGRATION_TASK_USER_ID_COLUMN_NAME = "UserId";
        public const string MANUAL_INTEGRATION_TASK_TASK_STATE_COLUMN_NAME = "TaskState";

        public const string SCHELULED_INTEGRATION_TASKS_TABLE_NAME = "ScheduledIntegrationTasks";
        public const string SCHELULED_INTEGRATION_TASK_START_TIME_COLUMN_NAME = "StartTime";
        public const string SCHELULED_INTEGRATION_TASK_REPEAT_PERIOD_COLUMN_NAME = "RepeatPeriod";
        public const string SCHELULED_INTEGRATION_TASK_INFO_COLUMN_NAME = "Info";
        public const string SCHELULED_INTEGRATION_TASK_USER_ID_COLUMN_NAME = "UserId";
        public const string SCHELULED_INTEGRATION_TASK_TASK_STATE_COLUMN_NAME = "TaskState";
        public const string SCHELULED_INTEGRATION_TASK_ENABLED_COLUMN_NAME = "Enabled";

        public const string COURT_ORDERS_TABLE_NAME = "CourtOrders";
        public const string COURT_ORDER_ORDER_TYPE_COLUMN_NAME = "OrderType";
        public const string COURT_ORDER_XML_CONTENT_COLUMN_NAME = "XMLContent";
        public const string COURT_ORDER_IS_SIGNED_COLUMN_NAME = "IsSigned";
        public const string COURT_ORDER_SERVER_FILE_NAME_COLUMN_NAME = "ServerFileName";
        public const string COURT_ORDER_PARENT_ORDER_ID_COLUMN_NAME = "ParentOrderId";
        public const string COURT_ORDER_HEARING_ID_COLUMN_NAME = "HearingId";

        public const string PERSONS_TABLE_NAME = "Persons";
        public const string PERSON_DISCRIMINATOR_COLUMN = "PersonType";
        public const string PERSON_FIRST_NAME_COLUMN_NAME = "FirstName";
        public const string PERSON_LAST_NAME_COLUMN_NAME = "LastName";
        public const string PERSON_ENTITY_TYPE_COLUMN_NAME = "EntityType";
        public const string PERSON_COURT_CASE_ID_COLUMN_NAME = "CourtCaseId";
        public const string PERSON_DATE_OF_BIRTH_COLUMN_NAME = "DateOfBirth";
        public const string PERSON_CONTACT_COLUMN_NAME = "Contact";
        public const string PERSON_COURT_PARTY_ID_COLUMN_NAME = "CourtPartyId";
        public const string PERSON_SEX_COLUMN_NAME = "Sex";
        public const string PERSON_EMAIL_COLUMN_NAME = "Email";
        public const string PERSON_AGE_COLUMN_NAME = "Age";
        public const string CHILD_RELATIONSHIP_TO_PROTECTED_COLUMN_NAME = "RelationshipToProtected";
        public const string OTHER_PROTECTED_RELATIONSHIP_TO_PLAINTIFF_COLUMN_NAME = "RelationshipToPlaintiff";
        public const string OTHER_PROTECTED_IS_HOUSE_HOLD_COLUMN_NAME = "IsHouseHold";
        public const string INTERPRETER_LANGUAGE_COLUMN_NAME = "Language";
        public const string ATTORNEY_FIRM_NAME_COLUMN_NAME = "FirmName";
        public const string ATTORNEY_STATE_BAR_ID_COLUMN_NAME = "StateBarId";
        public const string COURT_PARTY_MIDDLE_NAME_COLUMN_NAME = "MiddleName";
        public const string COURT_PARTY_DESCRIPTION_COLUMN_NAME = "Description";
        public const string COURT_PARTY_PARTICIPANT_ROLE_COLUMN_NAME = "ParticipantRole";
        public const string COURT_PARTY_DESIGNATION_COLUMN_NAME = "Designation";
        public const string COURT_PARTY_PARENT_ROLE_COLUMN_NAME = "ParentRole";
        public const string COURT_PARTY_RELATION_TO_OTHER_PARTY_COLUMN_NAME = "RelationToOtherParty";
        public const string COURT_PARTY_WEIGHT_COLUMN_NAME = "Weight";
        public const string COURT_PARTY_HEIGHT_FT_COLUMN_NAME = "HeightFt";
        public const string COURT_PARTY_HEIGHT_INS_COLUMN_NAME = "HeightIns";
        public const string COURT_PARTY_HAIR_COLOR_ID_COLUMN_NAME = "HairColorId";
        public const string COURT_PARTY_EYES_CLOR_ID_COLUMN_NAME = "EyesColorId";
        public const string COURT_PARTY_RACE_ID_COLUMN_NAME = "RaceId";

        public const string ADDRESS_INFO_STREET_ADDRESS_COLUMN_NAME = "StreetAddress";
        public const string ADDRESS_INFO_CITY_COLUMN_NAME = "City";
        public const string ADDRESS_INFO_USA_STATE_COLUMN_NAME = "USAState";
        public const string ADDRESS_INFO_ZIP_CODE_COLUMN_NAME = "ZipCode";
        public const string ADDRESS_INFO_PHONE_COLUMN_NAME = "Phone";
        public const string ADDRESS_INFO_FAX_COLUMN_NAME = "Fax";
    }
}
