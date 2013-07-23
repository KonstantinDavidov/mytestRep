using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACCTS.Server.Model.Enums;
using FACCTS.Server.Model.DataModel;

namespace FACCTS.Server.Integration
{
    internal static class Helpers
    {
        public static TimeSpan GetRepeatTimeInterval(this ScheduledIntegrationTask task)
        {
            switch (task.RepeatPeriod)
            {
                case IntegrationTaskRepeatPeriod.OnceADay:
                    return TimeSpan.FromDays(1);
                case IntegrationTaskRepeatPeriod.OnceAMonth:
                    return task.StartTime.AddMonths(1) - task.StartTime;
                case IntegrationTaskRepeatPeriod.OnceAWeek:
                    return TimeSpan.FromDays(7);
                default:
                    throw new NotImplementedException("Unknown task repeat period");
            }
        }
    }
}