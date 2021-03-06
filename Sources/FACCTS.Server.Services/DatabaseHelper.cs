﻿using FACCTS.Server.Common;
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
using System.Xml;
using Thinktecture.IdentityModel;
using Thinktecture.IdentityModel.Constants;
using CsvHelper;
using FACCTS.Server.Model.Enums;
using System.Xml.Linq;

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

        private static void AddCourtMembers(DatabaseContext context)
        {
            var courtMember1 = new CourtMember
            {
                Username = "DemoCourtMember1",
                FirstName = "f1",
                LastName = "l1",
                IsApproved = true,
                IsAvilable = true,          
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
                IsAvilable = false,
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
            SeedFacctsConfiguration(context);
            //SeedDesignations(context);
            SeedEyeColors(context);
            SeedHairColor(context);
            SeedRace(context);
            SeedPdfForm(context);
            SeedCourtCounties(context);
            SeedMembershipProviderData(context);
            SeedPermissions(context);
            SeedRolePermissions(context);
        }

        private static void SeedFacctsConfiguration(DatabaseContext context)
        {
            context.FACCTSConfiguration.Add(new FACCTSConfiguration()
            {
                CaseNumberAutoGeneration = true,
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





        private static void SeedRace(DatabaseContext context)
        {
            GetRecords<Race>("Race.csv")
                .Aggregate(context.Races, (dbset, record) =>
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
            AddCourtMembers(context);
            AddTestConfiguration(context);
            AddtestCourtDepartments(context);
            AddTestCourtLocations(context);
            AddTestCaseRecord(context);
        }

        private static string ChoisePartyName(string input)
        {
            switch (input)
            {
                case "party1": return "p1";
                case "party2": return "p2";
            }
            return "";
        }
        /// <summary>
        /// Initializing Party1 and Party2 from XML data
        /// </summary>
        /// <param name="nodeName">name of current xml-node</param>
        /// <param name="elements">list of xml-elements</param>
        /// <param name="test">Court Party object</param>
        /// <param name="context">DataBaseContext object</param>
        /// <returns>return an initialized variable CourtParty</returns>
        private static CourtParty TakeParty(string nodeName, XElement file, CourtParty test, DatabaseContext context)
        {
            string partyName = ChoisePartyName(nodeName);
            foreach (var el in file.Elements("parties").Elements(nodeName))
            {
                if (!el.Element(partyName + "FirstName").Value.Equals(""))
                {
                    test = new CourtParty()
                    {
                        FirstName = el.Element(partyName + "FirstName").Value,
                        MiddleName = el.Element(partyName + "MiddleName").Value,
                        LastName = el.Element(partyName + "LastName").Value,
                        ParticipantRole = (el.Element(partyName + "Role").Value != "") ? (ParticipantRole)Enum.Parse(typeof(ParticipantRole), el.Element(partyName + "Role").Value) : ParticipantRole.AFS,
                        Designation = (el.Element(partyName + "Designation").Value != "") ? (Designation)Enum.Parse(typeof(Designation), el.Element(partyName + "Designation").Value) : Designation.None,
                        Description = el.Element(partyName + "Description").Value,
                        RelationToOtherParty = el.Element(partyName + "Relationship").Value,//
                        HairColor = context.HairColor.FirstOrDefault(),
                        EyesColor = context.EyesColor.FirstOrDefault(),
                        Sex = (el.Element(partyName + "Sex").Value != "") ? (Gender)Enum.Parse(typeof(Gender), el.Element(partyName + "Sex").Value) : Gender.X,
                        Race = (el.Element(partyName + "Race").Value != "") ? context.Races.FirstOrDefault() : context.Races.FirstOrDefault(),
                        Age = (el.Element(partyName + "Age").Value != "") ? Convert.ToInt32(el.Element(partyName + "Age").Value) : 0,
                        ParentRole = el.Element(partyName + "Parentrole").Value,
                        Weight = (el.Element(partyName + "Weight").Value != "") ? Convert.ToDecimal(el.Element(partyName + "Weight").Value) : 0,
                        HeightFt = (el.Element(partyName + "HeightFeet").Value != "") ? Convert.ToDecimal(el.Element(partyName + "HeightFeet").Value) : 0,
                        HeightIns = (el.Element(partyName + "HeightInch").Value != "") ? Convert.ToDecimal(el.Element(partyName + "HeightInch").Value) : 0,
                        DateOfBirth = (el.Element(partyName + "DOB").Value != "") ? DateTime.Parse(el.Element(partyName + "DOB").Value, new System.Globalization.CultureInfo("en-US", true), System.Globalization.DateTimeStyles.AssumeLocal) : DateTime.Now,//DateTime.Now,
                        AddressInfo = new AddressInfo
                        {
                            StreetAddress = el.Element(partyName + "AddressStreet").Value,
                            City = el.Element(partyName + "AddressCity").Value,
                            USAState = (USAState)Enum.Parse(typeof(USAState), el.Element(partyName + "AddressState").Value),
                            ZipCode = el.Element(partyName + "AddressPostal").Value,
                            Phone = el.Element(partyName + "Phone").Value,
                            Fax = el.Element(partyName + "Fax").Value,
                        },
                        Email = el.Element(partyName + "Email").Value,
                        IsProPer = el.Element(partyName + "ProPer").Value.Equals("yes") ? true : false
                    };

                    if (el.Element(partyName + "Attorney").Value.Equals("yes"))
                    {
                        Attorney at = new Attorney()
                        {
                            FirstName = el.Element(partyName + "AttorneyFirstName").Value,
                            LastName = el.Element(partyName + "AttorneyLastName").Value,
                            StateBarId = el.Element(partyName + "AttorneyBarID").Value,
                            FirmName = el.Element(partyName + "AttorneyFirmName").Value,
                            AddressInfo = new AddressInfo()
                            {
                                StreetAddress = el.Element(partyName + "AttorneyAddressStreet").Value,
                                City = el.Element(partyName + "AttorneyAddressCity").Value,
                                USAState = (USAState)Enum.Parse(typeof(USAState), el.Element(partyName + "AttorneyAddressState").Value),
                                ZipCode = el.Element(partyName + "AttorneyAddressPostal").Value,
                                Phone = el.Element(partyName + "AttorneyPhone").Value,
                                Fax = el.Element(partyName + "AttorneyFax").Value,
                            },
                            Email = el.Element(partyName + "AttorneyEmail").Value
                        };
                        test.Attorney = at;
                    }
                }
            }
            return test;
        }

        /// <summary>
        /// Initializing of ThirdPartyData variable
        /// </summary>
        /// <param name="nodeName">current xml-node</param>
        /// <param name="elements">list of xml-elements</param>
        /// <param name="thirdPartyData">input variable of ThirdPartyData type</param>
        /// <returns>returns an initialized variable of ThirdPartyData type</returns>
        private static ThirdPartyData TakeThirdParty(string nodeName, XElement file, ThirdPartyData thirdPartyData)
        {
            ThirdPartyData test = thirdPartyData;
            foreach (var el in file.Elements("parties").Elements(nodeName))
            {  
                test = new ThirdPartyData()
                {
                    IsProPer = el.Element("p3ProPer").Value.Equals("yes") ? true : false,
                    IsRequestorInEACase = el.Element("p3RequestorAttorney").Value.Equals("yes") ? true : false,
                    Attorney = new Attorney()
                    {
                        FirstName = el.Element("p3AttorneyFirstName").Value,
                        LastName = el.Element("p3AttorneyLastName").Value,
                        StateBarId = el.Element("p3AttorneyBarID").Value,
                        FirmName = el.Element("p3AttorneyFirmName").Value,
                        AddressInfo = new AddressInfo()
                        {
                            StreetAddress = el.Element("p3AttorneyAddressStreet").Value,
                            City = el.Element("p3AttorneyAddressCity").Value,
                            USAState = (!el.Element("p3AttorneyAddressState").Value.Equals("")) ? (USAState)Enum.Parse(typeof(USAState), el.Element("p3AttorneyAddressState").Value) : USAState.AK,
                            ZipCode = el.Element("p3AttorneyAddressPostal").Value,
                            Phone = el.Element("p3AttorneyFax").Value,
                            Fax = el.Element("p3AttorneyFirmName").Value,
                        },
                        Email = el.Element("p3AttorneyEmail").Value
                    },
                };
            }
            return test;
        }

        /// <summary>
        /// An overloaded function. Initializing of Child collection
        /// </summary>
        /// <param name="nodeName">current xml-node list</param>
        /// <param name="elements">list of xml-elements</param>
        /// <param name="children">list of Children</param>
        /// <returns>returns initialized list of Children</returns>
        private static ICollection<Child> TakeOtherInParty(string nodeName, XElement file, ICollection<Child> children)
        {
            List<Child> test = (List<Child>)children;
            try
            {
                foreach (var el in file.Elements().Descendants(nodeName).Elements())
                {
                    Child ch = new Child()
                    {
                        EntityType = (el.Element("entity").Value != "") ? (FACCTS.Server.Model.Enums.FACCTSEntity)Enum.Parse(typeof(FACCTS.Server.Model.Enums.FACCTSEntity), el.Element("entity").Value) : FACCTSEntity.ENTITY,
                        FirstName = el.Element("firstname").Value,
                        LastName = el.Element("lastname").Value,
                        RelationshipToProtected = (el.Element("relationship").Value.Equals("Son") || el.Element("relationship").Value.Equals("Daughter")) ? Model.Enums.Relationship.C : ((el.Element("relationship").Value != "") ? (Model.Enums.Relationship)Enum.Parse(typeof(Model.Enums.Relationship), el.Element("relationship").Value) : Relationship.S),
                        DateOfBirth = (el.Element("dateofbirth").Value != "") ? DateTime.Parse(el.Element("dateofbirth").Value, new System.Globalization.CultureInfo("en-US", true), System.Globalization.DateTimeStyles.AssumeLocal) : DateTime.Now,//DateTime.Now,
                        Sex = (el.Element("sex").Value != "") ? (Gender)Enum.Parse(typeof(Gender), el.Element("sex").Value) : Gender.X
                    };
                    test.Add(ch);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return test;
        }

        /// <summary>
        /// An overloaded function. Initializing of OtherProtected collection
        /// </summary>
        /// <param name="nodeName">current xml-node list</param>
        /// <param name="elements">list of xml-elements</param>
        /// <param name="otherProtected">list of OtherProtected</param>
        /// <returns>returns initialized list of OtherProtected</returns>
        private static ICollection<OtherProtected> TakeOtherInParty(string nodeName, XElement file, ICollection<OtherProtected> otherProtected)
        {
            List<OtherProtected> test = (List<OtherProtected>)otherProtected;
            try
            {
                foreach (var el in file.Elements().Descendants(nodeName).Elements())
                {
                    OtherProtected ch = new OtherProtected()
                    {
                        EntityType = (el.Element("entity").Value != "") ? (FACCTSEntity)Enum.Parse(typeof(FACCTSEntity), el.Element("entity").Value) : FACCTSEntity.ENTITY,
                        FirstName = el.Element("firstname").Value,
                        LastName = el.Element("lastname").Value,
                        RelationshipToPlaintiff = (el.Element("relationship").Value != "") ? getRelationship(el.Element("relationship").Value) : Relationship.O,
                        IsHouseHold = el.Element("household").Value.ToString().Equals("true") ? true : false,
                        Sex = (el.Element("sex").Value != "") ? (Gender)Enum.Parse(typeof(Gender), el.Element("sex").Value) : Gender.X
                    };
                    test.Add(ch);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return test;
        }

        /// <summary>
        /// An overloaded function. Initializing of Witness collection
        /// </summary>
        /// <param name="nodeName">current xml-node list</param>
        /// <param name="elements">list of xml-elements</param>
        /// <param name="otherProtected">list of Witness</param>
        /// <returns>returns initialized list of Witness</returns>
        private static ICollection<Witness> TakeOtherInParty(string nodeName, XElement file, ICollection<Witness> witness)
        {
            List<Witness> test = (List<Witness>)witness;

            foreach (var el in file.Elements().Descendants(nodeName).Elements())
            {
                Witness op = new Witness()
                {
                    EntityType = (el.Element("entity").Value != "") ? (FACCTSEntity)Enum.Parse(typeof(FACCTSEntity), el.Element("entity").Value) : FACCTSEntity.ENTITY,
                    FirstName = el.Element("firstname").Value,
                    LastName = el.Element("lastname").Value,
                    // WitnessFor = (l.ElementAt(5).Value != "") ? (PartyFor)Enum.Parse(typeof(PartyFor), l.ElementAt(5).Value) : PartyFor.Party1,
                    Contact = el.Element("contactinfo").Value
                };

                test.Add(op);
            }
            return test;
        }

        /// <summary>
        /// An overloaded function. Initializing of Interpreter collection
        /// </summary>
        /// <param name="nodeName">current xml-node list</param>
        /// <param name="elements">list of xml-elements</param>
        /// <param name="otherProtected">list of Interpreter</param>
        /// <returns>returns initialized list of Interpreter</returns>
        private static ICollection<Interpreter> TakeOtherInParty(string nodeName, XElement file, ICollection<Interpreter> interpreter)
        {
            List<Interpreter> test = (List<Interpreter>)interpreter;

            foreach (var el in file.Elements().Descendants(nodeName).Elements())
            {
                Interpreter op = new Interpreter()
                {
                    EntityType = (el.Element("entity").Value != "") ? (FACCTSEntity)Enum.Parse(typeof(FACCTSEntity), el.Element("entity").Value) : FACCTSEntity.ENTITY,
                    FirstName = el.Element("firstname").Value,
                    LastName = el.Element("lastname").Value,
                    //  InterpreterFor = (l.ElementAt(5).Value != "") ? (PartyFor)Enum.Parse(typeof(PartyFor), l.ElementAt(5).Value) : PartyFor.Party1,
                    Language = el.Element("language").Value
                };

                test.Add(op);
            }
            return test;
        }

        /// <summary>
        /// An overloaded function. Initializing of CaseNote collection
        /// </summary>
        /// <param name="nodeName">current xml-node list</param>
        /// <param name="elements">list of xml-elements</param>
        /// <param name="otherProtected">list of CaseNote</param>
        /// <returns>returns initialized list of CaseNote</returns>
        private static ICollection<CaseNote> TakeOtherInParty(string nodeName, XElement file, ICollection<CaseNote> caseNote, CourtCase testCourtCase)
        {
            List<CaseNote> test = (List<CaseNote>)caseNote;

            foreach (var el in file.Elements(nodeName).Elements())
            {
                CaseNote op = new CaseNote()
                {
                    Author = new User()
                    {
                        Username = el.Element("userid").Value,
                        LastLoginDate = (el.Element("lastdate").Value != "")
                                        ?
                                        DateTime.Parse(
                                                        el.Element("lastdate").Value, new System.Globalization.CultureInfo("en-US", true),
                                                        System.Globalization.DateTimeStyles.AssumeLocal
                                                        )
                                        : DateTime.Now,
                        State = ObjectState.Added,      
                    },
                };
                Roles.AddUserToRole(op.Author.Username, el.Element("userrole").Value);
                test.Add(op);
            }
            return test;
        }

        /// <summary>
        /// An overloaded function. Initializing of CaseHistory collection
        /// </summary>
        /// <param name="nodeName">current xml-node list</param>
        /// <param name="elements">list of xml-elements</param>
        /// <param name="otherProtected">list of CaseHistory</param>
        /// <returns>returns initialized list of CaseHistory</returns>
        private static ICollection<CaseHistory> TakeOtherInParty(string nodeName, XElement file, ICollection<CaseHistory> caseHistory, CourtCase courtCase)
        {
            List<CaseHistory> test = (List<CaseHistory>)caseHistory;

            foreach (var el in file.Elements(nodeName).Elements())
            {
                if (el.Name.ToString().Equals("currentevent"))
                {
                    continue;
                }
                else
                {
                    if (!(el.Element("date").Value == ""))
                    {
                        CaseHistory ch = new CaseHistory();
                        if (el.Element("event").Value.Equals("Hearing"))
                        {
                            Hearing hearing = new Hearing()
                            {
                                HearingDate = (el.Element("date").Value != "")
                                                            ?
                                                                DateTime.Parse(
                                                                el.Element("date").Value, new System.Globalization.CultureInfo("en-US", true),
                                                                System.Globalization.DateTimeStyles.AssumeLocal
                                                                )
                                                            :
                                                                DateTime.Now,
                                HearingIssues = new HearingIssue()
                                {
                                    ChildCustodyOrChildVisitation = true,
                                    ChildSupport = false,
                                    IsOtherIssue = true,
                                    OtheIssueText = "Issue1",
                                    PermanentRO = true,
                                    SpousalSupport = true
                                },
                                CourtCase = courtCase
                            };
                            ch.Hearing = hearing;
                            ch.CaseHistoryEvent = CaseHistoryEvent.Hearing;
                        }
                        else
                        {
                            ch.CaseHistoryEvent = (el.Element("event").Value != "")
                                ?
                                ((el.Element("event").Value.Equals("NewFile") || el.Element("event").Value.Equals("New File")) ? CaseHistoryEvent.File : (CaseHistoryEvent)Enum.Parse(typeof(CaseHistoryEvent), el.Element("event").Value))
                                :
                                CaseHistoryEvent.File;
                        }

                        ch.Date = (el.Element("date").Value != "")
                                            ?
                                                DateTime.Parse(
                                                            el.Element("date").Value, new System.Globalization.CultureInfo("en-US", true),
                                                            System.Globalization.DateTimeStyles.AssumeLocal
                                                )
                                            :
                                                DateTime.Now;
                        // ch.CaseHistoryEvent =  CaseHistoryEvent.Hearing;
                        ch.CCPOR_ID = el.Element("orders").Value;
                        test.Add(ch);
                    }
                }
            }
            return test;
        }

        private static Relationship getRelationship(string input)
        {
            switch (input)
            {
                case "Friend": return FACCTS.Server.Model.Enums.Relationship.F;
                case "Child": return FACCTS.Server.Model.Enums.Relationship.C;
                case "Parent": return FACCTS.Server.Model.Enums.Relationship.P;
                case "Sibling": return FACCTS.Server.Model.Enums.Relationship.S;
                case "Other Relative": return FACCTS.Server.Model.Enums.Relationship.O;
            }
            return Relationship.O;
        }

        private static void AddTestCaseRecord(DatabaseContext context)
        {
            List<XElement> files = new List<XElement>();
            XElement file1 = XElement.Load("..\\..\\TestDeployData\\22-1212.xml");
            XElement file2 = XElement.Load("..\\..\\TestDeployData\\22-1234.xml");
            XElement file3 = XElement.Load("..\\..\\TestDeployData\\22-1235.xml");
            XElement file4 = XElement.Load("..\\..\\TestDeployData\\22-1251.xml");
            XElement file5 = XElement.Load("..\\..\\TestDeployData\\22-1252.xml");
            XElement file6 = XElement.Load("..\\..\\TestDeployData\\22-1254.xml");
            XElement file7 = XElement.Load("..\\..\\TestDeployData\\22-1267.xml");
            XElement file8 = XElement.Load("..\\..\\TestDeployData\\22-1295.xml");
            XElement file9 = XElement.Load("..\\..\\TestDeployData\\22-1297.xml");
            XElement file10 = XElement.Load("..\\..\\TestDeployData\\22-9999.xml");
            XElement file11 = XElement.Load("..\\..\\TestDeployData\\22-12512.xml");
            files.Add(file1);
            files.Add(file2);
            files.Add(file3);
            files.Add(file4);
            files.Add(file5);
            files.Add(file6);
            files.Add(file7);
            files.Add(file8);
            files.Add(file9);
            files.Add(file10);
            files.Add(file11);

            foreach (var file in files)
            {
                CourtCase testCourtCase = new CourtCase();

                foreach (var el in file.Elements("caseheader"))
                {
                    testCourtCase.CaseNumber = el.Element("caseNumber").Value;
                }

                //take party 1
                testCourtCase.Party1 = new CourtParty();
                testCourtCase.Party1.Attorney = new Attorney();
                testCourtCase.Party1 = TakeParty("party1", file, testCourtCase.Party1, context);
                //take party2
                testCourtCase.Party2 = new CourtParty();
                testCourtCase.Party2.Attorney = new Attorney();
                testCourtCase.Party2 = TakeParty("party2", file, testCourtCase.Party2, context);
                //take party3 
                testCourtCase.ThirdPartyData = new ThirdPartyData();
                testCourtCase.ThirdPartyData = TakeThirdParty("party3", file, testCourtCase.ThirdPartyData);

                //take childattorney
                testCourtCase.Children = new List<Child>();
                testCourtCase.Children = TakeOtherInParty("children", file, testCourtCase.Children);
                
                //take otherProtected
                testCourtCase.OtherProtected = new List<OtherProtected>();
                testCourtCase.OtherProtected = TakeOtherInParty("otherprotected", file, testCourtCase.OtherProtected);
                
                //take whithness
                testCourtCase.Witnesses = new List<Witness>();
                testCourtCase.Witnesses = TakeOtherInParty("witness", file, testCourtCase.Witnesses);

                //take interpreter
                testCourtCase.Interpreters = new List<Interpreter>();
                testCourtCase.Interpreters = TakeOtherInParty("interpreter", file, testCourtCase.Interpreters);
                //***************END PARTIES****************//
                testCourtCase.CaseNotes = new List<CaseNote>();
                testCourtCase.CaseNotes = TakeOtherInParty("casenotes", file, testCourtCase.CaseNotes, testCourtCase);

                context.CourtCases.Add(testCourtCase);
                //  context.Set<Appearance>().Add(appearance);
                testCourtCase.RestrainingPartyIdentificationInformation = new RestrainingPartyIdentificationInformation()
                {
                    IDNumber = "123",
                    IDType = Model.Enums.IdentificationIDType.AF,
                    IssuedDate = DateTime.Now
                };
                testCourtCase.LastAction = CourtAction.Docketed;
                testCourtCase.CaseHistory = new List<CaseHistory>();
                testCourtCase.CaseHistory = TakeOtherInParty("casehistory", file, testCourtCase.CaseHistory, testCourtCase);
                context.SaveChanges();
            }

            //IEnumerable<XElement> elements = caseRecords.Elements();
            // CourtCase testCourtCase = new CourtCase();
  

            /*
            Gender testSex = Gender.F;
            Designation testDesignation = Designation.None;
            EyesColor testEyesColor = context.EyesColor.FirstOrDefault();
            HairColor testHairColor = context.HairColor.FirstOrDefault();
            Race testRace = context.Races.FirstOrDefault();

            Attorney testAttorney = new Attorney()
            {
                AddressInfo = new AddressInfo
                {
                    City = "Saratov",
                    Fax = "12345",
                    Phone = "89043434123",
                    USAState = USAState.CA,
                    StreetAddress = "MainStreet",
                    ZipCode = "12345"
                },
                Email = "test@test.test",
                FirmName = "WornerBrothers",
                FirstName = "Grigory",
                LastName = "Rusputin",
                StateBarId = "Bar"
            };
             * */
            //testCaseRecord.AttorneyForChild = testAttorney;
            //testCaseRecord.Children = new List<Child>()
            //{ new Child()
            //    { 
            //        DateOfBirth =DateTime.Now,
            //        EntityType = Model.Enums.FACCTSEntity.PERSON,
            //        FirstName = "Marry",
            //        LastName = "Yang",
            //        RelationshipToProtected = Model.Enums.Relationship.C,
            //        Sex = testSex
            //    }
            //};
            //testCourtCase.CourtCounty = context.CourtCounties.FirstOrDefault();
            /*
            testCourtCase.OtherProtected = new List<OtherProtected>(){
                new OtherProtected(){
                    DateOfBirth = DateTime.Now,
                    FirstName = "Allan",
                    LastName="Dallas",
                    Sex = testSex,
                    RelationshipToPlaintiff = Model.Enums.Relationship.F,
                    Age = 10,
                    IsHouseHold = true
                },
               
            };

            testCourtCase.Children = new List<Child>()
            {
                 new Child(){
                    DateOfBirth = DateTime.Now,
                    FirstName = "Marta",
                    LastName="Dallas",
                    Sex = testSex,
                    RelationshipToProtected = Model.Enums.Relationship.C,
                    Age = 1,
                },
                new Child(){
                    DateOfBirth = DateTime.Now,
                    FirstName = "Den",
                    LastName="Dallas",
                    Sex = testSex,
                    RelationshipToProtected = Model.Enums.Relationship.C,
                    Age = 7,
                }
            };
            */
            /*
            testCourtCase.Party1 = new CourtParty()
            {
                AddressInfo = new AddressInfo
                {
                    StreetAddress = "Some address1",
                    City = "NY",
                    Fax = "12345",
                    Phone = "12345",
                    USAState = USAState.NJ,
                    ZipCode = "410001",
                },
                Age = 45,
                //Attorney = testAttorney,                
                DateOfBirth = DateTime.Now,
                Description = "Some description",
                Designation = testDesignation,
                EyesColor = testEyesColor,
                FirstName = "Sarah",
                HairColor = testHairColor,
                //HasAttorney = true,
                HeightFt = 5,
                HeightIns = 3,
                LastName = "Connor",
                MiddleName = "J",
                ParticipantRole = ParticipantRole.PPSC,
                Race = testRace,
                Sex = testSex,
                Weight = 56,
                RelationToOtherParty = "Wife"
            };
            testCourtCase.Party2 = new CourtParty()
            {
                AddressInfo = new AddressInfo
                {
                    StreetAddress = "Some address2",
                    City = "NY",
                    Fax = "12345",
                    Phone = "12345",
                    USAState = USAState.NJ,
                    ZipCode = "410001",
                },
                Age = 15,
                //Attorney = testAttorney,
                DateOfBirth = DateTime.Now,
                Description = "Some description",
                Designation = testDesignation,
                EyesColor = testEyesColor,
                FirstName = "John",
                HairColor = testHairColor,
                //HasAttorney = true,
                HeightFt = 5,
                HeightIns = 3,
                LastName = "Connor",
                MiddleName = "J",
                ParticipantRole = ParticipantRole.RESPER,
                Race = testRace,
                Sex = testSex,
                Weight = 56,
                RelationToOtherParty = "Allien"
            };
             * */
            //testCourtCase.Witnesses = new List<Witness>(){
            //    new Witness()
            //    {
            //        Contact = "Contact",
            //        Designation = testDesignation,
            //        EntityType = Model.Enums.FACCTSEntity.ENTITY,
            //        FirstName = "Witney",
            //        LastName = "Huiston",
            //        WitnessFor = testCourtCase.Party2
            //    }
            //};
            /*
            testCourtCase.RestrainingPartyIdentificationInformation = new RestrainingPartyIdentificationInformation()
                {
                    IDNumber = "123",
                    IDType = Model.Enums.IdentificationIDType.AF,
                    IssuedDate = DateTime.Now
                };

            testCourtCase.CaseHistory = new List<CaseHistory>();
            var hearing = new Hearing()
                {
                    HearingDate = DateTime.Now,
                    HearingIssues = new HearingIssue()
                    {
                        ChildCustodyOrChildVisitation = true,
                        ChildSupport = false,
                        IsOtherIssue = true,
                        OtheIssueText = "Issue1",
                        PermanentRO = true,
                        SpousalSupport = true
                    }
                };
            testCourtCase.CaseHistory.Add(new CaseHistory()
            {
                Date = DateTime.Now,
                CaseHistoryEvent = Model.Enums.CaseHistoryEvent.New,
                Hearing = hearing
            });

            var appearance = new AppearanceWithSworn
            {
                Person = testCourtCase.Party1,
                Hearing = hearing,
                Sworn = true
            };
            */
            // testCourtCase.CaseNumber = "22-3456";

        }

        private static void AddTestCourtLocations(DatabaseContext context)
        {
            var cc = context.FACCTSConfiguration.First().CurrentCourtCounty;
            List<CourtLocation> courtLocations = new List<CourtLocation>()
            {
                new CourtLocation()
                {
                    Description = "Main Court",
                    Name = "Main CourtHouse",
                    StreetAddress = "26323 South Alisio",
                    PostalCode = "92034",
                    City = "Alisio Viejo",
                    CourtRooms = new List<CourtRoom>()
                    {
                        new CourtRoom()
                        {
                            Name = "Courtroom A",
                            Judge = new CourtMember(){FirstName ="Thomas", LastName= "Jefferson"}
                        },
                        new CourtRoom()
                        {
                            Name = "Courtroom B",
                            Judge = new CourtMember(){FirstName ="George", LastName= "Harrison"}
                        }
                    }
                },
                new CourtLocation()
                {
                    Description = "South Court",
                    Name = "South County Location" ,
                    StreetAddress = "100 S Main Street",
                    City = "Orange",
                    PostalCode = "92111",
                    CourtRooms = new List<CourtRoom>()
                    {
                        new CourtRoom()
                        {
                            Name = "Courtroom 1",
                            Judge = new CourtMember(){FirstName ="Clara", LastName= "Zetkin"}
                        }
                    }
                }
            };
            if (cc != null)
            {
                cc = context.CourtCounties.Attach(cc);

                courtLocations.ForEach(x =>
                {
                    var proxy = context.CourtLocations.Create();
                    proxy.Description = x.Description;
                    proxy.Name = x.Name;
                    proxy.StreetAddress = x.StreetAddress;
                    proxy.PostalCode = x.PostalCode;
                    proxy.City = x.City;
                    context.Entry(cc).Collection(y => y.CourtLocations).Load();
                    cc.CourtLocations.Add(proxy);
                    if (x.CourtRooms != null)
                    {
                        proxy.CourtRooms = new HashSet<CourtRoom>();
                        foreach (var cr in x.CourtRooms)
                        {
                            context.Courtrooms.Add(cr);
                            proxy.CourtRooms.Add(cr);
                        }
                    }
                });
            }
        }

        private static void AddtestCourtDepartments(DatabaseContext context)
        {
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
            var cc = context.FACCTSConfiguration.First().CurrentCourtCounty;

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

        private static void AddTestConfiguration(DatabaseContext context)
        {
            FACCTSConfiguration config = context.FACCTSConfiguration.FirstOrDefault();
            if (config != null)
            {
                config = context.FACCTSConfiguration.Attach(config);
                var currentCourtCounty = context.CourtCounties.FirstOrDefault(x => x.CourtCode == "01200");
                currentCourtCounty = context.CourtCounties.Attach(currentCourtCounty);
                config.CurrentCourtCounty = currentCourtCounty;
            }
        }
        #endregion
    }
}
