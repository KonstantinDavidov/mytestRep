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
            ToTable(DbConsts.SCHELULED_INTEGRATION_TASKS_TABLE_NAME, DbConsts.SCHEMA_NAME);

            HasKey(t => t.Id);

            HasOptional(t => t.User).WithMany().HasForeignKey(t => t.UserId);

            Property(t => t.StartTime).HasColumnName(DbConsts.SCHELULED_INTEGRATION_TASK_START_TIME_COLUMN_NAME);
            Property(t => t.RepeatPeriod).HasColumnName(DbConsts.SCHELULED_INTEGRATION_TASK_REPEAT_PERIOD_COLUMN_NAME);
            Property(t => t.Info).HasColumnName(DbConsts.SCHELULED_INTEGRATION_TASK_INFO_COLUMN_NAME);
            Property(t => t.UserId).HasColumnName(DbConsts.SCHELULED_INTEGRATION_TASK_USER_ID_COLUMN_NAME);
            Property(t => t.Enabled).HasColumnName(DbConsts.SCHELULED_INTEGRATION_TASK_ENABLED_COLUMN_NAME);
            Property(t => t.TaskState).HasColumnName(DbConsts.SCHELULED_INTEGRATION_TASK_TASK_STATE_COLUMN_NAME);

            Ignore(t => t.State);
        }
    }
}
