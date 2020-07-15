using System;
using System.Collections.Generic;

namespace TaskQueueProcessor
{
    class TestCase
    {
        public String TestCaseDesc { get; set; }

        public double HOriginal { get; set; } = -1.0;
        public double HBitstring { get; set; } = -1.0;
        public double HAssessed { get; set; } = -1.0;

        public double RetMinEntropy { get; set; } = -1.0;
        public double DataWordSize { get; set; } = -1.0;
        public double BinTTupleRes { get; set; } = -1.0;
        public double TTupleRes { get; set; } = -1.0;
        public double BinLrsRes { get; set; } = -1.0;
        public double LrsRes { get; set; } = -1.0;

        public double Mean { get; set; } = -1.0;
        public double Median { get; set; } = -1.0;
        public int Binary { get; set; } = -1;

        public double LiteralMCVEstimateMode { get; set; } = -1.0;
        public double LiteralMCVEstimatePHat { get; set; } = -1.0;
        public double LiteralMCVEstimatePU { get; set; } = -1.0;

        public double BitstringMCVEstimateMode { get; set; } = -1.0;
        public double BitstringMCVEstimatePHat { get; set; } = -1.0;
        public double BitstringMCVEstimatePU { get; set; } = -1.0;

        public double ChiSquareIndependenceScore { get; set; } = -1.0;
        public double ChiSquareIndependenceDegressOfFreedom { get; set; } = -1.0;
        public double ChiSquareIndependencePValue { get; set; } = -1.0;

        public double ChiSquareGoodnessOfFitScore { get; set; } = -1.0;
        public double ChiSquareGoodnessOfFitDegressOfFreedom { get; set; } = -1.0;
        public double ChiSquareGoodnessOfFit_p_value { get; set; } = -1.0;

        public int PassedChiSquareTests { get; set; } = -1;

        public double LongestRepeatedSubstringPCol { get; set; } = -1.0;
        public double LongestRepeatedSubstringLengthOfLrs { get; set; } = -1.0;
        public double LongestRepeatedSubstringPRX1 { get; set; } = -1.0;

        public int PassedLengthLongestRepeatedSubstringTest { get; set; } = -1;

        public int PassedIidPermutationTests { get; set; } = -1;
        public List<TestResult> TestResults { get; set; }

        public TestCase()
        {
            TestResults = new List<TestResult>();
        }

    }
}
