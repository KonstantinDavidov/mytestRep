using CsvHelper;
using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityServer.Repositories.Sql;

namespace FACCTS.Server.Model
{
    [Export]
    public class FacctsDatabaseInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {

        protected override void Seed(DatabaseContext context)
        {
            using (IdentityServerConfigurationContext idCtx = IdentityServerConfigurationContext.Get())
            {
                ConfigurationDatabaseInitializer IdCtxInit = new ConfigurationDatabaseInitializer();
                IdCtxInit.InitializeDatabase(idCtx);
            }
            SeedFacctsDefaultData(context as DatabaseContext);
            base.Seed(context);
            
        }

        protected virtual void SeedFacctsDefaultData(DatabaseContext context)
        {
            SeedCaseStatuses(context);
            SeedDesignations(context);
            SeedEyeColors(context);
            SeedHairColor(context);
            SeedParticipantRole(context);
            SeedRace(context);
            SeedSex(context);
        }

        private void SeedSex(DatabaseContext context)
        {
            GetRecords<Sex>("Sex.csv")
                .Aggregate(context.Sex, (dbset, record) =>
                {
                    dbset.Add(record);
                    return dbset;
                }
                );
        }



        private void SeedRace(DatabaseContext context)
        {
            GetRecords<Race>("Race.csv")
                .Aggregate(context.Races, (dbset, record) =>
                {
                    dbset.Add(record);
                    return dbset;
                });
        }

        private void SeedParticipantRole(DatabaseContext context)
        {
            GetRecords<ParticipantRole>("ParticipantRole.csv")
                .Aggregate(context.ParticipantRoles, (dbset, record) =>
                {
                    dbset.Add(record);
                    return dbset;
                });
        }

        private void SeedHairColor(DatabaseContext context)
        {
            GetRecords<HairColor>("HairColor.csv")
                .Aggregate(context.HairColor, (dbset, record) =>
                {
                    dbset.Add(record);
                    return dbset;
                }
                );
        }

        private void SeedEyeColors(DatabaseContext context)
        {
            GetRecords<EyesColor>("EyesColor.csv")
                .Aggregate(context.EyesColor, (dbset, record) =>
                {
                    dbset.Add(record);
                    return dbset;
                });
        }

        private void SeedDesignations(DatabaseContext context)
        {
            GetRecords<Designation>("Designation.csv")
                .Aggregate(context.Designations, (dbset, record) =>
                {
                    dbset.Add(record);
                    return dbset;
                });
        }

        private void SeedCaseStatuses(DatabaseContext context)
        {
            GetRecords<CourtCaseStatus>("CourtCaseStatus.csv")
                .Aggregate(context.CourtCaseStatuses, (dbset, record) =>
                {
                    dbset.Add(record);
                    return dbset;
                });
        }

        private IEnumerable<T> GetRecords<T>(string resourceCsvFileName)
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


        private CsvReader GetReaderFor(string resourceName)
        {
            using (Stream stream = Assembly.GetExecutingAssembly()
                               .GetManifestResourceStream(string.Format("{0}.{1}.{2}", "FACCTS.Server.Model", "DeployData", resourceName)))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    return new CsvReader(sr);
                }
                
            }
        }
       
    }
}
