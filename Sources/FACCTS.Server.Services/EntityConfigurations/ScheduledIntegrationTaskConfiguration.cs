using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using FACCTS.Server.Model.DataModel;

namespace FACCTS.Server.Data.EntityConfigurations
{
    internal class ScheduledIntegrationTaskConfiguration : EntityTypeConfiguration<ScheduledIntegrationTask>
    {
        public ScheduledIntegrationTaskConfiguration()
        {
            ToTable("ScheduledIntegrationTasks");

            HasKey(t => t.Id);

            HasOptional(t => t.User).WithMany().HasForeignKey(t => t.UserId);

            Property(t => t.Info).HasMaxLength(500);
        }
    }
}
