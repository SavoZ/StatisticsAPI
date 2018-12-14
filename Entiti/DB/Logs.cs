using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class Logs
    {
        public long LogId { get; set; }
        public int LogDataTypeId { get; set; }
        public DateTime LogDate { get; set; }
        public int ChangeType { get; set; }
        public long? DetailId { get; set; }
        public string UserId { get; set; }
        public long InstanceId { get; set; }

        public LogDataTypes LogDataType { get; set; }
    }
}
