using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Data.EntityConfigurations
{
    internal class DbConsts
    {
        public const string SCHEMA_NAME = "dbo";

        public const string ID_COLUMN_NAME = "Id";

        public const string MANUAL_INTEGRATION_TASKS_TABLE_NAME = "ManualIntegrationTasks";
        public const string MANUAL_INTEGRATION_TASK_RECEIVE_TIME_COLUMN_NAME = "ReceiveTime";
        public const string MANUAL_INTEGRATION_TASK_START_TIME_COLUMN_NAME = "StartTime";
        public const string MANUAL_INTEGRATION_TASK_END_TIME_COLUMN_NAME = "EndTime";
        public const string MANUAL_INTEGRATION_TASK_INFO_COLUMN_NAME = "Info";
        public const string MANUAL_INTEGRATION_TASK_USER_ID_COLUMN_NAME = "UserId";
        public const string MANUAL_INTEGRATION_TASK_TASK_STATE_COLUMN_NAME = "TaskState";

        public const string SCHELULED_INTEGRATION_TASKS_TABLE_NAME = "ScheduledIntegrationTasks";
        public const string SCHELULED_INTEGRATION_TASK_START_TIME_COLUMN_NAME = "StartTime";
        public const string SCHELULED_INTEGRATION_TASK_REPEAT_PERIOD_COLUMN_NAME = "RepeatPeriod";
        public const string SCHELULED_INTEGRATION_TASK_INFO_COLUMN_NAME = "Info";
        public const string SCHELULED_INTEGRATION_TASK_USER_ID_COLUMN_NAME = "UserId";
        public const string SCHELULED_INTEGRATION_TASK_TASK_STATE_COLUMN_NAME = "TaskState";
        public const string SCHELULED_INTEGRATION_TASK_ENABLED_COLUMN_NAME = "Enabled";

        public const string MASTER_ORDERS_TABLE_NAME = "MasterOrders";
        public const string MASTER_ORDERS_ORDER_TYPE_COLUMN_NAME = "OrderType";
        public const string MASTER_ORDERS_XML_CONTENT_COLUMN_NAME = "XMLContent";
        public const string MASTER_ORDERS_IS_SIGNED_COLUMN_NAME = "IsSigned";
        public const string MASTER_ORDERS_SERVER_FILE_NAME_COLUMN_NAME = "ServerFileName";

        public const string ATTACHMENT_ORDERS_TABLE_NAME = "AttachmentOrders";
        public const string ATTACHMENT_ORDERS_ORDER_TYPE_COLUMN_NAME = "OrderType";
        public const string ATTACHMENT_ORDERS_XML_CONTENT_COLUMN_NAME = "XMLContent";
        public const string ATTACHMENT_ORDERS_SERVER_FILE_NAME_COLUMN_NAME = "ServerFileName";
    }
}
