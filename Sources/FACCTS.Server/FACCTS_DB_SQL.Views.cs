//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.18033
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: System.Data.Mapping.EntityViewGenerationAttribute(typeof(Edm_EntityMappingGeneratedViews.ViewsForBaseEntitySets7602B18C9B54E59ACB9864A788E3D0BD14CED9C928C7E125A5534028EDE115CD))]

namespace Edm_EntityMappingGeneratedViews
{
    
    
    /// <Summary>
    /// Тип содержит представления для наборов EntitySets и AssociationSets, созданные во время разработки.
    /// </Summary>
    public sealed class ViewsForBaseEntitySets7602B18C9B54E59ACB9864A788E3D0BD14CED9C928C7E125A5534028EDE115CD : System.Data.Mapping.EntityViewContainer
    {
        
        /// <Summary>
        /// Конструктор хранит представления для экстентов и значения хэша, созданные на основе замыканий и представлений метаданных и сопоставлений.
        /// </Summary>
        public ViewsForBaseEntitySets7602B18C9B54E59ACB9864A788E3D0BD14CED9C928C7E125A5534028EDE115CD()
        {
            this.EdmEntityContainerName = "FACCTS_DB_SQLContext";
            this.StoreEntityContainerName = "FACCTS_DB_SQLStoreContainer";
            this.HashOverMappingClosure = "fd4251f997693f78cbcc62b38ae156af173d754a3dc75e8cb4e0686b4f4f5798";
            this.HashOverAllExtentViews = "ca60fd87a5f1b6978692816372849802bb614b6fe2ad486411f2a0bc58c232c5";
            this.ViewCount = 12;
        }
        
        /// <Summary>
        /// Метод возвращает представление для указанного индекса.
        /// </Summary>
        protected override System.Collections.Generic.KeyValuePair<string, string> GetViewAt(int index)
        {
            if ((index == 0))
            {
                return GetView0();
            }
            if ((index == 1))
            {
                return GetView1();
            }
            if ((index == 2))
            {
                return GetView2();
            }
            if ((index == 3))
            {
                return GetView3();
            }
            if ((index == 4))
            {
                return GetView4();
            }
            if ((index == 5))
            {
                return GetView5();
            }
            if ((index == 6))
            {
                return GetView6();
            }
            if ((index == 7))
            {
                return GetView7();
            }
            if ((index == 8))
            {
                return GetView8();
            }
            if ((index == 9))
            {
                return GetView9();
            }
            if ((index == 10))
            {
                return GetView10();
            }
            if ((index == 11))
            {
                return GetView11();
            }
            throw new System.IndexOutOfRangeException();
        }
        
        /// <Summary>
        /// возвратить представление для FACCTS_DB_SQLStoreContainer.ProfileData
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView0()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("FACCTS_DB_SQLStoreContainer.ProfileData", @"
    SELECT VALUE -- Constructing ProfileData
        [FACCTS_DB_SQL.Store.ProfileData](T1.ProfileData_pId, T1.ProfileData_Profile, T1.ProfileData_Name, T1.ProfileData_ValueString, T1.ProfileData_ValueBinary)
    FROM (
        SELECT 
            T.pId AS ProfileData_pId, 
            T.Profile AS ProfileData_Profile, 
            T.Name AS ProfileData_Name, 
            T.ValueString AS ProfileData_ValueString, 
            T.ValueBinary AS ProfileData_ValueBinary, 
            True AS _from0
        FROM FACCTS_DB_SQLContext.ProfileData AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// возвратить представление для FACCTS_DB_SQLStoreContainer.Profiles
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView1()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("FACCTS_DB_SQLStoreContainer.Profiles", @"
    SELECT VALUE -- Constructing Profiles
        [FACCTS_DB_SQL.Store.Profiles](T1.Profiles_pId, T1.Profiles_Username, T1.Profiles_ApplicationName, T1.Profiles_IsAnonymous, T1.Profiles_LastActivityDate, T1.Profiles_LastUpdatedDate)
    FROM (
        SELECT 
            T.pId AS Profiles_pId, 
            T.Username AS Profiles_Username, 
            T.ApplicationName AS Profiles_ApplicationName, 
            T.IsAnonymous AS Profiles_IsAnonymous, 
            T.LastActivityDate AS Profiles_LastActivityDate, 
            T.LastUpdatedDate AS Profiles_LastUpdatedDate, 
            True AS _from0
        FROM FACCTS_DB_SQLContext.Profiles AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// возвратить представление для FACCTS_DB_SQLContext.ProfileData
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView2()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("FACCTS_DB_SQLContext.ProfileData", @"
    SELECT VALUE -- Constructing ProfileData
        [FACCTS_DB_SQL.ProfileData](T1.ProfileData_pId, T1.ProfileData_Profile, T1.ProfileData_Name, T1.ProfileData_ValueString, T1.ProfileData_ValueBinary)
    FROM (
        SELECT 
            T.pId AS ProfileData_pId, 
            T.Profile AS ProfileData_Profile, 
            T.Name AS ProfileData_Name, 
            T.ValueString AS ProfileData_ValueString, 
            T.ValueBinary AS ProfileData_ValueBinary, 
            True AS _from0
        FROM FACCTS_DB_SQLStoreContainer.ProfileData AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// возвратить представление для FACCTS_DB_SQLContext.Profiles
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView3()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("FACCTS_DB_SQLContext.Profiles", @"
    SELECT VALUE -- Constructing Profiles
        [FACCTS_DB_SQL.Profiles](T1.Profiles_pId, T1.Profiles_Username, T1.Profiles_ApplicationName, T1.Profiles_IsAnonymous, T1.Profiles_LastActivityDate, T1.Profiles_LastUpdatedDate)
    FROM (
        SELECT 
            T.pId AS Profiles_pId, 
            T.Username AS Profiles_Username, 
            T.ApplicationName AS Profiles_ApplicationName, 
            T.IsAnonymous AS Profiles_IsAnonymous, 
            T.LastActivityDate AS Profiles_LastActivityDate, 
            T.LastUpdatedDate AS Profiles_LastUpdatedDate, 
            True AS _from0
        FROM FACCTS_DB_SQLStoreContainer.Profiles AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// возвратить представление для FACCTS_DB_SQLStoreContainer.Roles
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView4()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("FACCTS_DB_SQLStoreContainer.Roles", @"
    SELECT VALUE -- Constructing Roles
        [FACCTS_DB_SQL.Store.Roles](T1.Roles_Rolename, T1.Roles_ApplicationName)
    FROM (
        SELECT 
            T.Rolename AS Roles_Rolename, 
            T.ApplicationName AS Roles_ApplicationName, 
            True AS _from0
        FROM FACCTS_DB_SQLContext.Roles AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// возвратить представление для FACCTS_DB_SQLStoreContainer.UsersInRoles
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView5()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("FACCTS_DB_SQLStoreContainer.UsersInRoles", @"
    SELECT VALUE -- Constructing UsersInRoles
        [FACCTS_DB_SQL.Store.UsersInRoles](T1.UsersInRoles_Username, T1.UsersInRoles_Rolename, T1.UsersInRoles_ApplicationName)
    FROM (
        SELECT 
            T.Username AS UsersInRoles_Username, 
            T.Rolename AS UsersInRoles_Rolename, 
            T.ApplicationName AS UsersInRoles_ApplicationName, 
            True AS _from0
        FROM FACCTS_DB_SQLContext.UsersInRoles AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// возвратить представление для FACCTS_DB_SQLContext.Roles
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView6()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("FACCTS_DB_SQLContext.Roles", @"
    SELECT VALUE -- Constructing Roles
        [FACCTS_DB_SQL.Roles](T1.Roles_Rolename, T1.Roles_ApplicationName)
    FROM (
        SELECT 
            T.Rolename AS Roles_Rolename, 
            T.ApplicationName AS Roles_ApplicationName, 
            True AS _from0
        FROM FACCTS_DB_SQLStoreContainer.Roles AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// возвратить представление для FACCTS_DB_SQLContext.UsersInRoles
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView7()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("FACCTS_DB_SQLContext.UsersInRoles", @"
    SELECT VALUE -- Constructing UsersInRoles
        [FACCTS_DB_SQL.UsersInRoles](T1.UsersInRoles_Username, T1.UsersInRoles_Rolename, T1.UsersInRoles_ApplicationName)
    FROM (
        SELECT 
            T.Username AS UsersInRoles_Username, 
            T.Rolename AS UsersInRoles_Rolename, 
            T.ApplicationName AS UsersInRoles_ApplicationName, 
            True AS _from0
        FROM FACCTS_DB_SQLStoreContainer.UsersInRoles AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// возвратить представление для FACCTS_DB_SQLStoreContainer.Sessions
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView8()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("FACCTS_DB_SQLStoreContainer.Sessions", @"
    SELECT VALUE -- Constructing Sessions
        [FACCTS_DB_SQL.Store.Sessions](T1.Sessions_SessionId, T1.Sessions_ApplicationName, T1.Sessions_Created, T1.Sessions_Expires, T1.Sessions_Timeout, T1.Sessions_Locked, T1.Sessions_LockId, T1.Sessions_LockDate, T1.Sessions_Data, T1.Sessions_Flags)
    FROM (
        SELECT 
            T.SessionId AS Sessions_SessionId, 
            T.ApplicationName AS Sessions_ApplicationName, 
            T.Created AS Sessions_Created, 
            T.Expires AS Sessions_Expires, 
            T.Timeout AS Sessions_Timeout, 
            T.Locked AS Sessions_Locked, 
            T.LockId AS Sessions_LockId, 
            T.LockDate AS Sessions_LockDate, 
            T.Data AS Sessions_Data, 
            T.Flags AS Sessions_Flags, 
            True AS _from0
        FROM FACCTS_DB_SQLContext.Sessions AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// возвратить представление для FACCTS_DB_SQLContext.Sessions
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView9()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("FACCTS_DB_SQLContext.Sessions", @"
    SELECT VALUE -- Constructing Sessions
        [FACCTS_DB_SQL.Sessions](T1.Sessions_SessionId, T1.Sessions_ApplicationName, T1.Sessions_Created, T1.Sessions_Expires, T1.Sessions_Timeout, T1.Sessions_Locked, T1.Sessions_LockId, T1.Sessions_LockDate, T1.Sessions_Data, T1.Sessions_Flags)
    FROM (
        SELECT 
            T.SessionId AS Sessions_SessionId, 
            T.ApplicationName AS Sessions_ApplicationName, 
            T.Created AS Sessions_Created, 
            T.Expires AS Sessions_Expires, 
            T.Timeout AS Sessions_Timeout, 
            T.Locked AS Sessions_Locked, 
            T.LockId AS Sessions_LockId, 
            T.LockDate AS Sessions_LockDate, 
            T.Data AS Sessions_Data, 
            T.Flags AS Sessions_Flags, 
            True AS _from0
        FROM FACCTS_DB_SQLStoreContainer.Sessions AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// возвратить представление для FACCTS_DB_SQLStoreContainer.Users
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView10()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("FACCTS_DB_SQLStoreContainer.Users", "\r\n    SELECT VALUE -- Constructing Users\r\n        [FACCTS_DB_SQL.Store.Users](T1." +
                    "Users_pId, T1.Users_Username, T1.Users_ApplicationName, T1.Users_Email, T1.Users" +
                    "_Comment, T1.Users_Password, T1.Users_PasswordQuestion, T1.Users_PasswordAnswer," +
                    " T1.Users_IsApproved, T1.Users_LastActivityDate, T1.Users_LastLoginDate, T1.User" +
                    "s_LastPasswordChangedDate, T1.Users_CreationDate, T1.Users_IsOnLine, T1.Users_Is" +
                    "LockedOut, T1.Users_LastLockedOutDate, T1.Users_FailedPasswordAttemptCount, T1.U" +
                    "sers_FailedPasswordAttemptWindowStart, T1.Users_FailedPasswordAnswerAttemptCount" +
                    ", T1.Users_FailedPasswordAnswerAttemptWindowStart)\r\n    FROM (\r\n        SELECT \r" +
                    "\n            T.pId AS Users_pId, \r\n            T.Username AS Users_Username, \r\n " +
                    "           T.ApplicationName AS Users_ApplicationName, \r\n            T.Email AS " +
                    "Users_Email, \r\n            T.Comment AS Users_Comment, \r\n            T.Password " +
                    "AS Users_Password, \r\n            T.PasswordQuestion AS Users_PasswordQuestion, \r" +
                    "\n            T.PasswordAnswer AS Users_PasswordAnswer, \r\n            T.IsApprove" +
                    "d AS Users_IsApproved, \r\n            T.LastActivityDate AS Users_LastActivityDat" +
                    "e, \r\n            T.LastLoginDate AS Users_LastLoginDate, \r\n            T.LastPas" +
                    "swordChangedDate AS Users_LastPasswordChangedDate, \r\n            T.CreationDate " +
                    "AS Users_CreationDate, \r\n            T.IsOnLine AS Users_IsOnLine, \r\n           " +
                    " T.IsLockedOut AS Users_IsLockedOut, \r\n            T.LastLockedOutDate AS Users_" +
                    "LastLockedOutDate, \r\n            T.FailedPasswordAttemptCount AS Users_FailedPas" +
                    "swordAttemptCount, \r\n            T.FailedPasswordAttemptWindowStart AS Users_Fai" +
                    "ledPasswordAttemptWindowStart, \r\n            T.FailedPasswordAnswerAttemptCount " +
                    "AS Users_FailedPasswordAnswerAttemptCount, \r\n            T.FailedPasswordAnswerA" +
                    "ttemptWindowStart AS Users_FailedPasswordAnswerAttemptWindowStart, \r\n           " +
                    " True AS _from0\r\n        FROM FACCTS_DB_SQLContext.Users AS T\r\n    ) AS T1");
        }
        
        /// <Summary>
        /// возвратить представление для FACCTS_DB_SQLContext.Users
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView11()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("FACCTS_DB_SQLContext.Users", "\r\n    SELECT VALUE -- Constructing Users\r\n        [FACCTS_DB_SQL.Users](T1.Users_" +
                    "pId, T1.Users_Username, T1.Users_ApplicationName, T1.Users_Email, T1.Users_Comme" +
                    "nt, T1.Users_Password, T1.Users_PasswordQuestion, T1.Users_PasswordAnswer, T1.Us" +
                    "ers_IsApproved, T1.Users_LastActivityDate, T1.Users_LastLoginDate, T1.Users_Last" +
                    "PasswordChangedDate, T1.Users_CreationDate, T1.Users_IsOnLine, T1.Users_IsLocked" +
                    "Out, T1.Users_LastLockedOutDate, T1.Users_FailedPasswordAttemptCount, T1.Users_F" +
                    "ailedPasswordAttemptWindowStart, T1.Users_FailedPasswordAnswerAttemptCount, T1.U" +
                    "sers_FailedPasswordAnswerAttemptWindowStart)\r\n    FROM (\r\n        SELECT \r\n     " +
                    "       T.pId AS Users_pId, \r\n            T.Username AS Users_Username, \r\n       " +
                    "     T.ApplicationName AS Users_ApplicationName, \r\n            T.Email AS Users_" +
                    "Email, \r\n            T.Comment AS Users_Comment, \r\n            T.Password AS Use" +
                    "rs_Password, \r\n            T.PasswordQuestion AS Users_PasswordQuestion, \r\n     " +
                    "       T.PasswordAnswer AS Users_PasswordAnswer, \r\n            T.IsApproved AS U" +
                    "sers_IsApproved, \r\n            T.LastActivityDate AS Users_LastActivityDate, \r\n " +
                    "           T.LastLoginDate AS Users_LastLoginDate, \r\n            T.LastPasswordC" +
                    "hangedDate AS Users_LastPasswordChangedDate, \r\n            T.CreationDate AS Use" +
                    "rs_CreationDate, \r\n            T.IsOnLine AS Users_IsOnLine, \r\n            T.IsL" +
                    "ockedOut AS Users_IsLockedOut, \r\n            T.LastLockedOutDate AS Users_LastLo" +
                    "ckedOutDate, \r\n            T.FailedPasswordAttemptCount AS Users_FailedPasswordA" +
                    "ttemptCount, \r\n            T.FailedPasswordAttemptWindowStart AS Users_FailedPas" +
                    "swordAttemptWindowStart, \r\n            T.FailedPasswordAnswerAttemptCount AS Use" +
                    "rs_FailedPasswordAnswerAttemptCount, \r\n            T.FailedPasswordAnswerAttempt" +
                    "WindowStart AS Users_FailedPasswordAnswerAttemptWindowStart, \r\n            True " +
                    "AS _from0\r\n        FROM FACCTS_DB_SQLStoreContainer.Users AS T\r\n    ) AS T1");
        }
    }
}
