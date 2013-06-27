using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using FACCTS.Server.Model.DataModel;

namespace FACCTS.Server.Data.EntityConfigurations
{
    internal class ManualIntegrationTaskConfiguration : EntityTypeConfiguration<ManualIntegrationTask>
    {
        public ManualIntegrationTaskConfiguration()
        {
            ToTable("ManualIntegrationTasks");

            HasKey(t => t.Id);

            Property(t => t.Info);

            HasOptional(t => t.User).WithMany().HasForeignKey(t => t.UserId);
        }
    }
}
