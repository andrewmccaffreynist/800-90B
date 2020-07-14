using System;
using System.Collections.Generic;
using System.Text;

namespace TaskQueueProcessor
{
    class EntropyAssessmentInputParameters
    {
        public string Filename { get; set; }
        public bool InitialOrConditioned { get; set; }
        public bool AllOrTruncatedReadBits { get; set; }
        public int Index { get; set; }
        public int Sample { get; set; }
        public int BitsPerSymbol { get; set; }
        public string LocalType { get; set; }
        

    }
}
