using CsvHelper;
using FACCTS.Server.Common;
using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Model.DataModel.Configuration;
using FACCTS.Server.Model.Membership;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Thinktecture.IdentityModel.Constants;

namespace FACCTS.Server.Model
{
    internal static class DatabaseHelper
    {
        public static void SeedDatabase(DatabaseContext context)
        {
            SeedDefaultData(context);
            SeedFacctsDefaultData(context);
        }

        private static void SeedDefaultData(DatabaseContext context)
        {
            // test data
            var entry = ConfigurationManager.AppSettings["idsrv:CreateTestDataOnInitialization"];

            if (entry != null)
            {
                bool createData = false;
                if (bool.TryParse(entry, out createData))
                {
                    if (createData)
                    {
                        // test configuration
                        context.GlobalConfiguration.Add(CreateTestGlobalConfiguration());
                        context.WSFederation.Add(CreateTestWSFederationConfiguration());
                        context.WSTrust.Add(CreateTestWSTrustConfiguration());
                        context.FederationMetadata.Add(CreateTestFederationMetadataConfiguration());
                        context.OAuth2.Add(CreateTestOAuth2Configuration());
                        context.AdfsIntegration.Add(CreateTestAdfsIntegrationConfiguration());
                        context.SimpleHttp.Add(CreateTestSimpleHttpConfiguration());
                        context.Diagnostics.Add(CreateTestDiagnosticsConfiguration());

                        // test data
                        CreateTestRelyingParties().ForEach(rp => context.RelyingParties.Add(rp));
                        CreateTestIdentityProviders().ForEach(idp => context.IdentityProviders.Add(idp));
                        CreateTestDelegationSettings().ForEach(d => context.Delegation.Add(d));
                        CreateTestClientCertificateSettings().ForEach(cc => context.ClientCertificates.Add(cc));
                        CreateTestClients().ForEach(c => context.Clients.Add(c));

                        return;
                    }
                }
            }

            // default configuration
            context.GlobalConfiguration.Add(CreateDefaultGlobalConfiguration());
            context.WSFederation.Add(CreateDefaultWSFederationConfiguration());
            context.WSTrust.Add(CreateDefaultWSTrustConfiguration());
            context.FederationMetadata.Add(CreateDefaultFederationMetadataConfiguration());
            context.OAuth2.Add(CreateDefaultOAuth2Configuration());
            context.AdfsIntegration.Add(CreateDefaultAdfsIntegrationConfiguration());
            context.SimpleHttp.Add(CreateDefaultSimpleHttpConfiguration());
            context.Diagnostics.Add(CreateDefaultDiagnosticsConfiguration());
        }

        #region Default Configuration
        private static GlobalConfiguration CreateDefaultGlobalConfiguration()
        {
            return new GlobalConfiguration
            {
                SiteName = "thinktecture identity server v2",
                IssuerUri = "http://identityserver.v2.thinktecture.com/trust/changethis",
                IssuerContactEmail = "office@thinktecture.com",
                DefaultWSTokenType = TokenTypes.Saml2TokenProfile11,
                DefaultHttpTokenType = TokenTypes.JsonWebToken,
                DefaultTokenLifetime = 10,
                MaximumTokenLifetime = 24,
                SsoCookieLifetime = 10,
                RequireEncryption = false,
                EnforceUsersGroupMembership = true,
                HttpPort = 80,
                HttpsPort = 443,
                EnableClientCertificateAuthentication = false,
                RequireRelyingPartyRegistration = true
            };
        }

        private static WSFederationConfiguration CreateDefaultWSFederationConfiguration()
        {
            return new WSFederationConfiguration
            {
                AllowReplyTo = false,
                EnableAuthentication = true,
                Enabled = true,
                EnableFederation = false,
                EnableHrd = false,
                RequireReplyToWithinRealm = true,
                RequireSslForReplyTo = true
            };
        }

        private static WSTrustConfiguration CreateDefaultWSTrustConfiguration()
        {
            return new WSTrustConfiguration
            {
                Enabled = true,

                EnableClientCertificateAuthentication = false,
                EnableDelegation = true,
                EnableFederatedAuthentication = false,
                EnableMessageSecurity = false,
                EnableMixedModeSecurity = true
            };
        }

        private static OAuth2Configuration CreateDefaultOAuth2Configuration()
        {
            return new OAuth2Configuration
            {
                Enabled = false,
                EnableImplicitFlow = false,
                EnableResourceOwnerFlow = false,
                EnableConsent = true
            };
        }

        private static AdfsIntegrationConfiguration CreateDefaultAdfsIntegrationConfiguration()
        {
            return new AdfsIntegrationConfiguration
            {
                Enabled = false,
                UsernameAuthenticationEnabled = false,
                SamlAuthenticationEnabled = false,
                JwtAuthenticationEnabled = false,
                AuthenticationTokenLifetime = 60,
                PassThruAuthenticationToken = false
            };
        }

        private static SimpleHttpConfiguration CreateDefaultSimpleHttpConfiguration()
        {
            return new SimpleHttpConfiguration
            {
                Enabled = false
            };
        }

        private static FederationMetadataConfiguration CreateDefaultFederationMetadataConfiguration()
        {
            return new FederationMetadataConfiguration
            {
                Enabled = true
            };
        }

        private static DiagnosticsConfiguration CreateDefaultDiagnosticsConfiguration()
        {
            return new DiagnosticsConfiguration
            {
                EnableFederationMessageTracing = false
            };
        }
        #endregion

        #region Test Configuration
        private static GlobalConfiguration CreateTestGlobalConfiguration()
        {
            return new GlobalConfiguration
            {
                SiteName = "thinktecture identity server v2",
                IssuerUri = "http://identityserver.v2.thinktecture.com/trust/changethis",
                IssuerContactEmail = "office@thinktecture.com",
                DefaultWSTokenType = TokenTypes.Saml2TokenProfile11,
                DefaultHttpTokenType = TokenTypes.JsonWebToken,
                DefaultTokenLifetime = 10,
                MaximumTokenLifetime = 24,
                SsoCookieLifetime = 10,
                RequireEncryption = false,
                EnforceUsersGroupMembership = true,
                HttpPort = 80,
                HttpsPort = 443,
                EnableClientCertificateAuthentication = true,
                RequireRelyingPartyRegistration = true
            };
        }

        private static WSFederationConfiguration CreateTestWSFederationConfiguration()
        {
            return new WSFederationConfiguration
            {
                AllowReplyTo = false,
                EnableAuthentication = true,
                Enabled = true,
                EnableFederation = true,
                EnableHrd = true,
                RequireReplyToWithinRealm = true,
                RequireSslForReplyTo = true
            };
        }

        private static WSTrustConfiguration CreateTestWSTrustConfiguration()
        {
            return new WSTrustConfiguration
            {
                Enabled = true,

                EnableClientCertificateAuthentication = true,
                EnableDelegation = true,
                EnableFederatedAuthentication = false,
                EnableMessageSecurity = false,
                EnableMixedModeSecurity = true
            };
        }

        private static OAuth2Configuration CreateTestOAuth2Configuration()
        {
            return new OAuth2Configuration
            {
                Enabled = true,
                EnableImplicitFlow = true,
                EnableResourceOwnerFlow = true,
                EnableCodeFlow = true,
                EnableConsent = true
            };
        }

        private static AdfsIntegrationConfiguration CreateTestAdfsIntegrationConfiguration()
        {
            return new AdfsIntegrationConfiguration
            {
                Enabled = true,
                UsernameAuthenticationEnabled = true,
                SamlAuthenticationEnabled = true,
                JwtAuthenticationEnabled = true,
                AuthenticationTokenLifetime = 60,
                PassThruAuthenticationToken = false,
                UserNameAuthenticationEndpoint = "https://server/adfs/services/trust/13/usernamemixed",
                FederationEndpoint = "https://server/adfs/services/trust/13/issuedtokenmixedsymmetricbasic256",
            };
        }

        private static SimpleHttpConfiguration CreateTestSimpleHttpConfiguration()
        {
            return new SimpleHttpConfiguration
            {
                Enabled = true
            };
        }

        private static FederationMetadataConfiguration CreateTestFederationMetadataConfiguration()
        {
            return new FederationMetadataConfiguration
            {
                Enabled = true
            };
        }

        private static DiagnosticsConfiguration CreateTestDiagnosticsConfiguration()
        {
            return new DiagnosticsConfiguration
            {
                EnableFederationMessageTracing = true
            };
        }
        #endregion

        #region Test Data
        private static List<RelyingParties> CreateTestRelyingParties()
        {
            return new List<RelyingParties>
            {
                new RelyingParties
                {
                    Name = "Web API Security Sample",
                    Enabled = true,
                    Realm = "urn:webapisecurity",
                    SymmetricSigningKey = "fWUU28oBOIcaQuwUKiL01KztD/CsZX83C3I0M1MOYN4=",    
                },
                new RelyingParties
                {
                    Name = "Local Test RP",
                    Enabled = true,
                    Realm = "urn:testrp",
                    ReplyTo = "https://roadie/idsrvrp/"
                },
                new RelyingParties
                {
                    Name = "Test RP (Symmetric Key)",
                    Enabled = true,
                    Realm = "urn:test:symmetric",
                    SymmetricSigningKey = "fWUU28oBOIcaQuwUKiL01KztD/CsZX83C3I0M1MOYN4=",    
                },
                new RelyingParties
                {
                    Name = "Test RP (Asymmetric Key)",
                    Enabled = true,
                    Realm = "urn:test:asymmetric",
                }
            };
        }

        private static List<Delegation> CreateTestDelegationSettings()
        {
            return new List<Delegation>
            {
                new Delegation
                {
                    Description = "Test for Local RP",
                    UserName = "middletier",
                    Realm = "urn:testrp"
                }
            };
        }

        private static List<ClientCertificates> CreateTestClientCertificateSettings()
        {
            return new List<ClientCertificates>
            {
                new ClientCertificates
                {
                    Description = "Test Client Cert Mapping",
                    UserName = "dominick",
                    Thumbprint = "D19126617D55DFB5952F5A86C4EB80C5A00CC917"
                }
            };
        }

        private static List<IdentityProvider> CreateTestIdentityProviders()
        {
            return new List<IdentityProvider>
            {
                new IdentityProvider
                {
                    Name = "adfs",
                    DisplayName = "LeastPrivilege ADFS Server",
                    Enabled = true,
                    ShowInHrdSelection = true,
                    Type = 1,
                    WSFederationEndpoint = "https://adfs.leastprivilege.vm/adfs/ls/",
                    IssuerThumbprint = "cad5731ae474b932631e57feb72d810aea6f0220"
                },
                new IdentityProvider
                {
                    Name = "waad",
                    DisplayName = "Windows Azure Active Directory",
                    Enabled = true,
                    ShowInHrdSelection = true,
                    Type = 1,
                    WSFederationEndpoint = "https://accounts.accesscontrol.windows.net/fe132fb5-4843-41b4-bce8-9366bad88b80/v2/wsfederation",
                    IssuerThumbprint = "3464C5BDD2BE7F2B6112E2F08E9C0024E33D9FE0"
                },
                new IdentityProvider
                {
                    Name = "acs",
                    DisplayName = "Access Control Service",
                    Enabled = true,
                    ShowInHrdSelection = true,
                    Type = 1,
                    WSFederationEndpoint = "https://idsrvwebids.accesscontrol.windows.net/v2/wsfederation",
                    IssuerThumbprint = "5AAD3C5CC1A5A715E791BEA85B4445D3CB29F33F"
                },
                new IdentityProvider
                {
                    Name = "Facebook",
                    DisplayName = "Facebook",
                    Enabled = true,
                    ShowInHrdSelection = true,
                    Type = 2,
                    ClientID = "239987582797347",
                    ClientSecret = "c29a33352a739c2263c8f32c699077d6",
                    OAuth2ProviderType = 2
                },
                new IdentityProvider
                {
                    Name = "Live",
                    DisplayName = "Live",
                    Enabled = true,
                    ShowInHrdSelection = true,
                    Type = 2,
                    ClientID = "00000000480DD362",
                    ClientSecret = "gH9ngNoSaxRrupt3UcynwI2aK8qODZvf",
                    OAuth2ProviderType = 3
                },                
            };
        }

        private static List<Client> CreateTestClients()
        {
            return new List<Client>
            {
                new Client
                {
                    Name = "Win8 Test Client",
                    Description = "Test Client for Windows Store App",
                    RedirectUri = "ms-app://s-1-15-2-756967155-51850-665164220-3494723435-3400456802-3915619528-546309680/",
                    ClientId = "test",
                    ClientSecret = CryptoHelper.HashPassword("secret"),
                    AllowImplicitFlow = true,
                    AllowResourceOwnerFlow = false,
                    AllowCodeFlow = false
                },
                new Client
                {
                    Name = "Code Flow Sample Client",
                    Description = "Code Flow Sample Client",
                    RedirectUri = "https://localhost:44303/callback",
                    ClientId = "codeflowclient",
                    ClientSecret = CryptoHelper.HashPassword("secret"),
                    AllowImplicitFlow = false,
                    AllowResourceOwnerFlow = false,
                    AllowCodeFlow = true,
                    AllowRefreshToken = true
                },
                new Client
                {
                    Name = "Test Client (Test Project)",
                    Description = "Test Client",
                    RedirectUri = "https://foo",
                    ClientId = "testclient",
                    ClientSecret = CryptoHelper.HashPassword("secret"),
                    AllowImplicitFlow = true,
                    AllowResourceOwnerFlow = true,
                    AllowCodeFlow = true,
                    AllowRefreshToken = true
                }
            };
        }
        #endregion


        #region FACCTS default data
        private static void SeedFacctsDefaultData(DatabaseContext context)
        {
            SeedCaseStatuses(context);
            SeedDesignations(context);
            SeedEyeColors(context);
            SeedHairColor(context);
            SeedParticipantRole(context);
            SeedRace(context);
            SeedSex(context);
            SeedPdfForm(context);
            SeedCourtCounties(context);
            SeedMembershipProviderData(context);
            SeedAvailavleCourtOrders(context);
        }

        private static void SeedAvailavleCourtOrders(DatabaseContext context)
        {
            GetRecords<AvailableCourtOrder>("AvailableCourtOrders.csv")
                .Aggregate(context.AvailableCourtOrders, (dbset, record) =>
                {
                    dbset.Add(record);
                    return dbset;
                });
        }

        private static void SeedMembershipProviderData(DatabaseContext context)
        {
            WebSecurity.Register("Demo", "123456", "demo@demo.com", false, "Demo", "Demo");
            GetRecords<Role>("Roles.csv")
                .Aggregate(0, (index, record) =>
                {
                    Roles.CreateRole(record.RoleName);
                    return 0;
                });
            Roles.AddUserToRole("Demo", "Administrator");
        }

        private static void SeedCourtCounties(DatabaseContext context)
        {
            GetRecords<CourtCounty>("CourtCounty.csv")
                .Aggregate(context.CourtCounties, (dbset, record) =>
                {
                    dbset.Add(record);
                    return dbset;
                });
        }

        private static void SeedPdfForm(DatabaseContext context)
        {
            GetRecords<FormField>("pdf_form_fields.csv")
                .Aggregate(context.FormFields, (dbset, record) =>
                {
                    dbset.Add(record);
                    return dbset;
                });
        }

        private static void SeedSex(DatabaseContext context)
        {
            GetRecords<Sex>("Sex.csv")
                .Aggregate(context.Sex, (dbset, record) =>
                {
                    dbset.Add(record);
                    return dbset;
                }
                );
        }



        private static void SeedRace(DatabaseContext context)
        {
            GetRecords<Race>("Race.csv")
                .Aggregate(context.Races, (dbset, record) =>
                {
                    dbset.Add(record);
                    return dbset;
                });
        }

        private static void SeedParticipantRole(DatabaseContext context)
        {
            GetRecords<ParticipantRole>("ParticipantRole.csv")
                .Aggregate(context.ParticipantRoles, (dbset, record) =>
                {
                    dbset.Add(record);
                    return dbset;
                });
        }

        private static void SeedHairColor(DatabaseContext context)
        {
            GetRecords<HairColor>("HairColor.csv")
                .Aggregate(context.HairColor, (dbset, record) =>
                {
                    dbset.Add(record);
                    return dbset;
                }
                );
        }

        private static void SeedEyeColors(DatabaseContext context)
        {
            GetRecords<EyesColor>("EyesColor.csv")
                .Aggregate(context.EyesColor, (dbset, record) =>
                {
                    dbset.Add(record);
                    return dbset;
                });
        }

        private static void SeedDesignations(DatabaseContext context)
        {
            GetRecords<Designation>("Designation.csv")
                .Aggregate(context.Designations, (dbset, record) =>
                {
                    dbset.Add(record);
                    return dbset;
                });
        }

        private static void SeedCaseStatuses(DatabaseContext context)
        {
            GetRecords<CourtCaseStatus>("CourtCaseStatus.csv")
                .Aggregate(context.CourtCaseStatuses, (dbset, record) =>
                {
                    dbset.Add(record);
                    return dbset;
                });
        }

        private static IEnumerable<T> GetRecords<T>(string resourceCsvFileName)
            where T : class
        {
            using (CsvReader csvReader = GetReaderFor(resourceCsvFileName))
            {
                while (csvReader.Read())
                {
                    var record = csvReader.GetRecord<T>();
                    yield return record;
                }
            }
        }


        private static CsvReader GetReaderFor(string resourceName)
        {
            Stream stream = Assembly.GetExecutingAssembly()
                               .GetManifestResourceStream(string.Format("{0}.{1}.{2}", "FACCTS.Server.Model", "DeployData", resourceName));

            StreamReader sr = new StreamReader(stream);

            var csvConfiguration = new CsvHelper.Configuration.CsvConfiguration()
            {
                Delimiter = ";",
            };
            return new CsvReader(sr, csvConfiguration);
        }

        #endregion
    }
}
