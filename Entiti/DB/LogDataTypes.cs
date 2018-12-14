using System;
using System.Collections.Generic;

namespace Entiti.DB
{
    public partial class LogDataTypes
    {
        public LogDataTypes()
        {
            Logs = new HashSet<Logs>();
        }

        public int LogDataTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<Logs> Logs { get; set; }
    }
}
