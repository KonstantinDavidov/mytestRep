﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace Faccts.Model.Entities
{
    public partial class FACCTS_DBEntities : ObjectContext
    {
        public const string ConnectionString = "name=FACCTS_DBEntities";
        public const string ContainerName = "FACCTS_DBEntities";
    
        #region Constructors
    
        public FACCTS_DBEntities()
            : base(ConnectionString, ContainerName)
        {
            Initialize();
        }
    
        public FACCTS_DBEntities(string connectionString)
            : base(connectionString, ContainerName)
        {
            Initialize();
        }
    
        public FACCTS_DBEntities(EntityConnection connection)
            : base(connection, ContainerName)
        {
            Initialize();
        }
    
        private void Initialize()
        {
            // Creating proxies requires the use of the ProxyDataContractResolver and
            // may allow lazy loading which can expand the loaded graph during serialization.
            ContextOptions.ProxyCreationEnabled = false;
            ObjectMaterialized += new ObjectMaterializedEventHandler(HandleObjectMaterialized);
        }
    
        private void HandleObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
            var entity = e.Entity as IObjectWithChangeTracker;
            if (entity != null)
            {
                bool changeTrackingEnabled = entity.ChangeTracker.ChangeTrackingEnabled;
                try
                {
                    entity.MarkAsUnchanged();
                }
                finally
                {
                    entity.ChangeTracker.ChangeTrackingEnabled = changeTrackingEnabled;
                }
                this.StoreReferenceKeyValues(entity);
            }
        }

        #endregion

        #region ObjectSet Properties
    
        public ObjectSet<C__MigrationHistory> C__MigrationHistory
        {
            get { return _c__MigrationHistory  ?? (_c__MigrationHistory = CreateObjectSet<C__MigrationHistory>("C__MigrationHistory")); }
        }
        private ObjectSet<C__MigrationHistory> _c__MigrationHistory;
    
        public ObjectSet<AdfsIntegrationConfiguration> AdfsIntegrationConfiguration
        {
            get { return _adfsIntegrationConfiguration  ?? (_adfsIntegrationConfiguration = CreateObjectSet<AdfsIntegrationConfiguration>("AdfsIntegrationConfiguration")); }
        }
        private ObjectSet<AdfsIntegrationConfiguration> _adfsIntegrationConfiguration;
    
        public ObjectSet<Appearances> Appearances
        {
            get { return _appearances  ?? (_appearances = CreateObjectSet<Appearances>("Appearances")); }
        }
        private ObjectSet<Appearances> _appearances;
    
        public ObjectSet<Attorneys> Attorneys
        {
            get { return _attorneys  ?? (_attorneys = CreateObjectSet<Attorneys>("Attorneys")); }
        }
        private ObjectSet<Attorneys> _attorneys;
    
        public ObjectSet<CaseHistory> CaseHistory
        {
            get { return _caseHistory  ?? (_caseHistory = CreateObjectSet<CaseHistory>("CaseHistory")); }
        }
        private ObjectSet<CaseHistory> _caseHistory;
    
        public ObjectSet<CaseNotes> CaseNotes
        {
            get { return _caseNotes  ?? (_caseNotes = CreateObjectSet<CaseNotes>("CaseNotes")); }
        }
        private ObjectSet<CaseNotes> _caseNotes;
    
        public ObjectSet<CaseRecord> CaseRecord
        {
            get { return _caseRecord  ?? (_caseRecord = CreateObjectSet<CaseRecord>("CaseRecord")); }
        }
        private ObjectSet<CaseRecord> _caseRecord;
    
        public ObjectSet<Children> Children
        {
            get { return _children  ?? (_children = CreateObjectSet<Children>("Children")); }
        }
        private ObjectSet<Children> _children;
    
        public ObjectSet<Client> Client
        {
            get { return _client  ?? (_client = CreateObjectSet<Client>("Client")); }
        }
        private ObjectSet<Client> _client;
    
        public ObjectSet<ClientCertificates> ClientCertificates
        {
            get { return _clientCertificates  ?? (_clientCertificates = CreateObjectSet<ClientCertificates>("ClientCertificates")); }
        }
        private ObjectSet<ClientCertificates> _clientCertificates;
    
        public ObjectSet<CodeToken> CodeToken
        {
            get { return _codeToken  ?? (_codeToken = CreateObjectSet<CodeToken>("CodeToken")); }
        }
        private ObjectSet<CodeToken> _codeToken;
    
        public ObjectSet<CourtCase> CourtCase
        {
            get { return _courtCase  ?? (_courtCase = CreateObjectSet<CourtCase>("CourtCase")); }
        }
        private ObjectSet<CourtCase> _courtCase;
    
        public ObjectSet<CourtCaseStatus> CourtCaseStatus
        {
            get { return _courtCaseStatus  ?? (_courtCaseStatus = CreateObjectSet<CourtCaseStatus>("CourtCaseStatus")); }
        }
        private ObjectSet<CourtCaseStatus> _courtCaseStatus;
    
        public ObjectSet<CourtCounty> CourtCounty
        {
            get { return _courtCounty  ?? (_courtCounty = CreateObjectSet<CourtCounty>("CourtCounty")); }
        }
        private ObjectSet<CourtCounty> _courtCounty;
    
        public ObjectSet<CourtLocations> CourtLocations
        {
            get { return _courtLocations  ?? (_courtLocations = CreateObjectSet<CourtLocations>("CourtLocations")); }
        }
        private ObjectSet<CourtLocations> _courtLocations;
    
        public ObjectSet<CourtParty> CourtParty
        {
            get { return _courtParty  ?? (_courtParty = CreateObjectSet<CourtParty>("CourtParty")); }
        }
        private ObjectSet<CourtParty> _courtParty;
    
        public ObjectSet<Courtrooms> Courtrooms
        {
            get { return _courtrooms  ?? (_courtrooms = CreateObjectSet<Courtrooms>("Courtrooms")); }
        }
        private ObjectSet<Courtrooms> _courtrooms;
    
        public ObjectSet<Delegation> Delegation
        {
            get { return _delegation  ?? (_delegation = CreateObjectSet<Delegation>("Delegation")); }
        }
        private ObjectSet<Delegation> _delegation;
    
        public ObjectSet<Designation> Designation
        {
            get { return _designation  ?? (_designation = CreateObjectSet<Designation>("Designation")); }
        }
        private ObjectSet<Designation> _designation;
    
        public ObjectSet<DiagnosticsConfiguration> DiagnosticsConfiguration
        {
            get { return _diagnosticsConfiguration  ?? (_diagnosticsConfiguration = CreateObjectSet<DiagnosticsConfiguration>("DiagnosticsConfiguration")); }
        }
        private ObjectSet<DiagnosticsConfiguration> _diagnosticsConfiguration;
    
        public ObjectSet<EyesColor> EyesColor
        {
            get { return _eyesColor  ?? (_eyesColor = CreateObjectSet<EyesColor>("EyesColor")); }
        }
        private ObjectSet<EyesColor> _eyesColor;
    
        public ObjectSet<FederationMetadataConfiguration> FederationMetadataConfiguration
        {
            get { return _federationMetadataConfiguration  ?? (_federationMetadataConfiguration = CreateObjectSet<FederationMetadataConfiguration>("FederationMetadataConfiguration")); }
        }
        private ObjectSet<FederationMetadataConfiguration> _federationMetadataConfiguration;
    
        public ObjectSet<FormField> FormField
        {
            get { return _formField  ?? (_formField = CreateObjectSet<FormField>("FormField")); }
        }
        private ObjectSet<FormField> _formField;
    
        public ObjectSet<GlobalConfiguration> GlobalConfiguration
        {
            get { return _globalConfiguration  ?? (_globalConfiguration = CreateObjectSet<GlobalConfiguration>("GlobalConfiguration")); }
        }
        private ObjectSet<GlobalConfiguration> _globalConfiguration;
    
        public ObjectSet<HairColor> HairColor
        {
            get { return _hairColor  ?? (_hairColor = CreateObjectSet<HairColor>("HairColor")); }
        }
        private ObjectSet<HairColor> _hairColor;
    
        public ObjectSet<IdentityProvider> IdentityProvider
        {
            get { return _identityProvider  ?? (_identityProvider = CreateObjectSet<IdentityProvider>("IdentityProvider")); }
        }
        private ObjectSet<IdentityProvider> _identityProvider;
    
        public ObjectSet<Interpreters> Interpreters
        {
            get { return _interpreters  ?? (_interpreters = CreateObjectSet<Interpreters>("Interpreters")); }
        }
        private ObjectSet<Interpreters> _interpreters;
    
        public ObjectSet<KeyMaterialConfiguration> KeyMaterialConfiguration
        {
            get { return _keyMaterialConfiguration  ?? (_keyMaterialConfiguration = CreateObjectSet<KeyMaterialConfiguration>("KeyMaterialConfiguration")); }
        }
        private ObjectSet<KeyMaterialConfiguration> _keyMaterialConfiguration;
    
        public ObjectSet<OAuth2Configuration> OAuth2Configuration
        {
            get { return _oAuth2Configuration  ?? (_oAuth2Configuration = CreateObjectSet<OAuth2Configuration>("OAuth2Configuration")); }
        }
        private ObjectSet<OAuth2Configuration> _oAuth2Configuration;
    
        public ObjectSet<OtherProtected> OtherProtected
        {
            get { return _otherProtected  ?? (_otherProtected = CreateObjectSet<OtherProtected>("OtherProtected")); }
        }
        private ObjectSet<OtherProtected> _otherProtected;
    
        public ObjectSet<ParticipantRole> ParticipantRole
        {
            get { return _participantRole  ?? (_participantRole = CreateObjectSet<ParticipantRole>("ParticipantRole")); }
        }
        private ObjectSet<ParticipantRole> _participantRole;
    
        public ObjectSet<Race> Race
        {
            get { return _race  ?? (_race = CreateObjectSet<Race>("Race")); }
        }
        private ObjectSet<Race> _race;
    
        public ObjectSet<RelyingParties> RelyingParties
        {
            get { return _relyingParties  ?? (_relyingParties = CreateObjectSet<RelyingParties>("RelyingParties")); }
        }
        private ObjectSet<RelyingParties> _relyingParties;
    
        public ObjectSet<Role> Role
        {
            get { return _role  ?? (_role = CreateObjectSet<Role>("Role")); }
        }
        private ObjectSet<Role> _role;
    
        public ObjectSet<Sex> Sex
        {
            get { return _sex  ?? (_sex = CreateObjectSet<Sex>("Sex")); }
        }
        private ObjectSet<Sex> _sex;
    
        public ObjectSet<SimpleHttpConfiguration> SimpleHttpConfiguration
        {
            get { return _simpleHttpConfiguration  ?? (_simpleHttpConfiguration = CreateObjectSet<SimpleHttpConfiguration>("SimpleHttpConfiguration")); }
        }
        private ObjectSet<SimpleHttpConfiguration> _simpleHttpConfiguration;
    
        public ObjectSet<User> User
        {
            get { return _user  ?? (_user = CreateObjectSet<User>("User")); }
        }
        private ObjectSet<User> _user;
    
        public ObjectSet<Witnesses> Witnesses
        {
            get { return _witnesses  ?? (_witnesses = CreateObjectSet<Witnesses>("Witnesses")); }
        }
        private ObjectSet<Witnesses> _witnesses;
    
        public ObjectSet<WSFederationConfiguration> WSFederationConfiguration
        {
            get { return _wSFederationConfiguration  ?? (_wSFederationConfiguration = CreateObjectSet<WSFederationConfiguration>("WSFederationConfiguration")); }
        }
        private ObjectSet<WSFederationConfiguration> _wSFederationConfiguration;
    
        public ObjectSet<WSTrustConfiguration> WSTrustConfiguration
        {
            get { return _wSTrustConfiguration  ?? (_wSTrustConfiguration = CreateObjectSet<WSTrustConfiguration>("WSTrustConfiguration")); }
        }
        private ObjectSet<WSTrustConfiguration> _wSTrustConfiguration;

        #endregion

    }
}
