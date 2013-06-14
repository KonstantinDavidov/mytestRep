using FACCTS.Server.Common;
using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Model.DataModel.Configuration;
using FACCTS.Server.Data.Providers.Membership;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Thinktecture.IdentityModel;
using Thinktecture.IdentityModel.Constants;
using CsvHelper;

namespace FACCTS.Server.Data
{
    internal static class DatabaseHelper
    {
        public static void SeedDatabase(DatabaseContext context)
        {
            SeedDefaultData(context);
            SeedSecurityData(context);
            SeedFacctsDefaultData(context);
#if TEST_DATA
            SeedFacctsTestData(context);
#endif
        }

        private static void SeedFacctsTestData(DatabaseContext context)
        {
            var courtMember1 = new CourtMember
                {
                    Username = "DemoCourtMember1",
                    FirstName = "f1",
                    LastName = "l1",
                    IsApproved = true,
                    IsCertified = false,
                    Phone = "222222",
                    Password = "12345"
                };
        
            context.CourtMembers.Add(courtMember1);
            var courtMember2 = new CourtMember
            {
                Username = "DemoCourtMember2",
                FirstName = "f2",
                LastName = "l2",
                IsApproved = true,
                IsCertified = true,
                Substitute = courtMember1,
                Phone = "333333",
                Password = "12345"
            };
            context.CourtMembers.Add(courtMember2);
            context.SaveChanges();
            Roles.AddUserToRole("DemoCourtMember1", "Court Clerk");
            Roles.AddUserToRole("DemoCourtMember2", "Courtroom Clerk");
            context.SaveChanges();
        }

        private static void SeedSecurityData(DatabaseContext context)
        {
            RelyingParties relyingParty = new RelyingParties()
            {
                Name = "FACCTS (URN)",
                Enabled = true,
                Realm = Constants.RelyingParties.FACCTS,
                SymmetricSigningKey = CryptoRandom.CreateRandomKeyString(32),    

            };
            context.RelyingParties.Add(relyingParty);
            Client client = new Client()
            {
                Name = "FACCTS Client Application",
                Description = "Client for the FACCTS application",
                RedirectUri = "http://localhost:50050/callback",
                ClientId = "cce45e00-e8ff-4d0b-be2c-00e63b88c80b",
                ClientSecret = CryptoHelper.HashPassword("0feb1684-cb91-4a90-b5c1-04c7465c8b21"),
                AllowResourceOwnerFlow = true,
                AllowCodeFlow = true,
                AllowImplicitFlow = true,
                AllowRefreshToken = true,
            };
            context.Clients.Add(client);
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
                SiteName = "FACCTS WEP API",
                IssuerUri = "http://opensoftdev.ru/",
                IssuerContactEmail = "office@opensoftdev.ru",
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
                Enabled = true,
                EnableImplicitFlow = true,
                EnableResourceOwnerFlow = true,
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
                EnableFederationMessageTracing = true
            };
        }
        #endregion

        #region Test Configuration
        private static GlobalConfiguration CreateTestGlobalConfiguration()
        {
            return new GlobalConfiguration
            {
                SiteName = "FACCTS WEP API",
                IssuerUri = "http://opensoftdev.ru/",
                IssuerContactEmail = "office@opensoftdev.ru",
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
            SeedPermissions(context);
            SeedRolePermissions(context);
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
            WebSecurity.Register("Demo", "123456", "demo@demo.com", true, "Demo", "Demo");
            WebSecurity.Register("DemoWPF", "123456", "demowpf@demo.com", true, "DemoWPF", "DemoWPF");
            GetRecords<Role>("Roles.csv")
                .Aggregate(0, (index, record) =>
                {
                    Roles.CreateRole(record.RoleName);
                    Role role = context.Roles.Single(r => r.RoleName.Equals(record.RoleName, StringComparison.OrdinalIgnoreCase));
                    role.IsIdentityServerUser = record.IsIdentityServerUser;
                    context.SaveChanges();
                    return 0;
                });
            Roles.AddUserToRole("Demo", "Administrator");
            Roles.AddUserToRole("DemoWPF", "Judicial Officer");
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

        private static void SeedPermissions(DatabaseContext context)
        {
            GetRecords<Permission>("Permissions.csv")
                .Aggregate(context.Permissions, (dbset, record) =>
                {
                    dbset.Add(record);
                    return dbset;
                });
            context.SaveChanges();
        }
        
        private static void SeedRolePermissions(DatabaseContext context)
        {
            //Admin
            //var adminPermissions = context.Permissions.ToList();
            //var admin = context.Roles.Where(r => r.RoleId == 1).FirstOrDefault();
            //if (admin != null) adminPermissions.ForEach(p => admin.Permissions.Add(p));

            context.SaveChanges();
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
                               .GetManifestResourceStream(string.Format("{0}.{1}.{2}", "FACCTS.Server.Data", "DeployData", resourceName));

            StreamReader sr = new StreamReader(stream);

            var csvConfiguration = new CsvHelper.Configuration.CsvConfiguration()
            {
                Delimiter = ";",
            };
            return new CsvReader(sr, csvConfiguration);
        }

        #endregion

        #region FACCTS test data
        private static void SeedFacctsTestData(DatabaseContext context)
        {
            //context.Entry()
            List<CourtDepartment> departments = new List<CourtDepartment>()
            {
                new CourtDepartment()
                {
                    
                    Name = "Family Court",
                    Room = "G2",
                    BranchOfficer = "C Smith",
                    Reporter = "A Smarth",
                },
                new CourtDepartment()
            {
               
                Name = "Family Court",
                Room = "G3",
                BranchOfficer = "C Smith",
                Reporter = "A Smarth",
            },
            new CourtDepartment()
            {
                
                Name = "Family Court",
                Room = "G4",
                BranchOfficer = "C Smith",
                Reporter = "A Smarth",
            }
            };
            var cc = context.CourtCounties.FirstOrDefault(x => x.CourtCode == "01200");
            
            if (cc != null)
            {
                cc = context.CourtCounties.Attach(cc);
                departments.ForEach(d =>
                    {
                        var proxy = context.CourtDepartments.Create();
                        proxy.Name = d.Name;
                        proxy.Room = d.Room;
                        proxy.BranchOfficer = d.BranchOfficer;
                        proxy.Reporter = d.Reporter;
                        proxy = context.CourtDepartments.Add(proxy);
                        context.Entry(cc).Collection(x => x.Departments).Load();
                        cc.Departments.Add(proxy);

                    });
            }
           
        }
        #endregion
    }
}
