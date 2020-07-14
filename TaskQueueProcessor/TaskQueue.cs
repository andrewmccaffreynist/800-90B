using System;
using System.Collections.Generic;
using System.Text;

namespace TaskQueueProcessor
{
    class TaskQueue
    {
        public long TaskID { get; set; }
        public string TaskType { get; set; }
        public long DataFileId { get; set; }
        public bool InitialOrConditioned { get; set; }
        public bool AllOrTruncatedReadBits { get; set; }
        public int Index { get; set; }
        public int Samples { get; set; }
        public int Status { get; set; }
        public int BitsPerSignal { get; set; }
        public string CreatedOn { get; set; }


    }
}
