using System;
using System.Collections.Generic;
using System.Text;

namespace TaskQueueProcessor
{
    class TestResult
    {
        public String Iteration { get; set; }

        public double Excursion { get; set; } = -1.0;
        public double NumDirectionalRuns { get; set; } = -1.0;
        public double LenDirectionalRuns { get; set; } = -1.0;
        public double NumIncreasesDecreases { get; set; } = -1.0;
        public double NumRunsMedian { get; set; } = -1.0;
        public double LenRunsMedian { get; set; } = -1.0;
        public double AvgCollision { get; set; } = -1.0;
        public double MaxCollision { get; set; } = -1.0;
        public double Periodicity1 { get; set; } = -1.0;
        public double Periodicity2 { get; set; } = -1.0;
        public double Periodicity8 { get; set; } = -1.0;
        public double Periodicity16 { get; set; } = -1.0;
        public double Periodicity32 { get; set; } = -1.0;
        public double Covariance1 { get; set; } = -1.0;
        public double Covariance2 { get; set; } = -1.0;
        public double Covariance8 { get; set; } = -1.0;
        public double Covariance16 { get; set; } = -1.0;
        public double Covariance32 { get; set; } = -1.0;
        public double Compression { get; set; } = -1.0;


    }
}
