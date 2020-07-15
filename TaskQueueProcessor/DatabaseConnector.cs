using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Mighty;

namespace TaskQueueProcessor
{
    class DatabaseConnector
    {

        public static MightyOrm createConnectionTestRun()
        {
            return new MightyOrm("Server=localhost\\SQLEXPRESS;Database=TaskQueueProcessor;ProviderName=System.Data.SqlClient;User=user;Password=user", "TestRun", "TestRunID");
        }

        public static MightyOrm createConnectionTestCase()
        {
            return new MightyOrm("Server=localhost\\SQLEXPRESS;Database=TaskQueueProcessor;ProviderName=System.Data.SqlClient;User=user;Password=user", "TestCase", "TestCaseID");
        }

        public static MightyOrm createConnectionTestResult()
        {
            return new MightyOrm("Server=localhost\\SQLEXPRESS;Database=TaskQueueProcessor;ProviderName=System.Data.SqlClient;User=user;Password=user", "TestResult", "TestResultID");

        }

        public static MightyOrm<TaskQueueItem> createConnectionTaskQueueItem()
        {
            return new MightyOrm<TaskQueueItem>("Server=localhost\\SQLEXPRESS;Database=TaskQueueProcessor;ProviderName=System.Data.SqlClient;User=user;Password=user", "TaskQueue", "TaskQueueID");

        }

        public static void storeTestRun(TestRun tr)
        {

            MightyOrm db = DatabaseConnector.createConnectionTestRun();
            MightyOrm dbTc = DatabaseConnector.createConnectionTestCase();
            MightyOrm dbTestResult = DatabaseConnector.createConnectionTestResult();

            var insert = db.New();
            insert.Category = tr.Category;
            insert.Sha256 = tr.Sha256;
            insert.Filename = tr.Filename;
            db.Insert(insert);

            List<TestCase> testCases = tr.TestCases;
            if(testCases != null && testCases.Count > 0)
            {
                foreach (TestCase tc in testCases)
                {
                    DatabaseConnector.storeTestCase(dbTc, dbTestResult, tc, insert.TestRunID);
                }
            }

            Console.WriteLine(insert.TestRunID);

        }

        private static void storeTestCase(MightyOrm db, MightyOrm dbTr, TestCase tc, int trID)
        {
            var insert = db.New();
            insert.TestRunID = trID;
            insert.TestCaseDesc = tc.TestCaseDesc;
            insert.HOriginal = tc.HOriginal;
            insert.HBitString = tc.HBitstring;
            insert.HAssessed = tc.HAssessed;
            insert.RetMinEntropy = tc.RetMinEntropy;
            insert.DataWordSize = tc.DataWordSize;
            insert.BinTTupleRes = tc.BinTTupleRes;
            insert.TTupleRes = tc.TTupleRes;
            insert.BinLrsRes = tc.BinLrsRes;
            insert.LrsRes = tc.LrsRes;
            insert.Mean = tc.Mean;
            insert.Median = tc.Median;
            insert.Binary = tc.Binary;

            insert.LiteralMCVEstimateMode = tc.LiteralMCVEstimateMode;
            insert.LiteralMCVEstimatePHat = tc.LiteralMCVEstimatePHat;
            insert.LiteralMCVEstimatePU = tc.LiteralMCVEstimatePU;
            insert.BitstringMCVEstimateMode = tc.BitstringMCVEstimateMode;
            insert.BitstringMCVEstimatePHat = tc.BitstringMCVEstimatePHat;
            insert.BitstringMCVEstimatePU = tc.BitstringMCVEstimatePU;
            insert.ChiSquareIndependenceScore = tc.ChiSquareIndependenceScore;
            insert.ChiSquareIndependenceDegressOfFreedom = tc.ChiSquareIndependenceDegressOfFreedom;
            insert.ChiSquareIndependencePValue = tc.ChiSquareIndependencePValue;
            insert.ChiSquareGoodnessOfFitScore = tc.ChiSquareGoodnessOfFitScore;
            insert.ChiSquareGoodnessOfFitDegressOfFreedom = tc.ChiSquareGoodnessOfFitDegressOfFreedom;
            insert.ChiSquareGoodnessOfFit_p_value = tc.ChiSquareGoodnessOfFit_p_value;
            insert.PassedChiSquareTests = tc.PassedChiSquareTests;
            insert.LongestRepeatedSubstringPCol = tc.LongestRepeatedSubstringPCol;
            insert.LongestRepeatedSubstringLengthOfLrs = tc.LongestRepeatedSubstringLengthOfLrs;
            insert.LongestRepeatedSubstringPRX1 = tc.LongestRepeatedSubstringPRX1;
            insert.PassedLengthLongestRepeatedSubstringTest = tc.PassedLengthLongestRepeatedSubstringTest;
            insert.PassedIidPermutationTests = tc.PassedIidPermutationTests;

            db.Insert(insert);

            List<TestResult> testResults = tc.TestResults;
            if (testResults != null && testResults.Count > 0)
            {
                foreach (TestResult tr in testResults)
                {
                    DatabaseConnector.storeTestResult(dbTr, tr, insert.TestCaseID);
                }
            }

            Console.WriteLine(insert.TestCaseID);

        }

        private static void storeTestResult(MightyOrm db, TestResult tr, int tcID)
        {
            var insert = db.New();

            insert.TestCaseID = tcID;
            insert.Iteration = tr.Iteration;
            insert.Excursion = tr.Excursion;
            insert.NumDirectionalRuns = tr.NumDirectionalRuns;
            insert.LenDirectionalRuns = tr.LenDirectionalRuns;
            insert.NumIncreasesDecreases = tr.NumIncreasesDecreases;
            insert.NumRunsMedian = tr.NumRunsMedian;
            insert.LenRunsMedian = tr.LenRunsMedian;
            insert.AvgCollision = tr.AvgCollision;
            insert.MaxCollision = tr.MaxCollision;
            insert.Periodicity1 = tr.Periodicity1;
            insert.Periodicity2 = tr.Periodicity2;
            insert.Periodicity8 = tr.Periodicity8;
            insert.Periodicity16 = tr.Periodicity16;
            insert.Periodicity32 = tr.Periodicity32;
            insert.Covariance1 = tr.Covariance1;
            insert.Covariance2 = tr.Covariance2;
            insert.Covariance8 = tr.Covariance8;
            insert.Covariance16 = tr.Covariance16;
            insert.Covariance32 = tr.Covariance32;
            insert.Compression = tr.Compression;
            db.Insert(insert);

            Console.WriteLine(insert.TestResultID);
            
        }

        public static bool isTaskQueueEmpty()
        {
            MightyOrm<TaskQueueItem> db = DatabaseConnector.createConnectionTaskQueueItem();
            // TaskQueueItem tq = db.Single("SELECT * from TaskQueue");

            TaskQueueItem tq = db.Single("");
            if (tq == null)
                return true;
            else
                return false;

        }

        public static TaskQueueItem getNextTaskQueueItem()
        {
            MightyOrm<TaskQueueItem> db = DatabaseConnector.createConnectionTaskQueueItem();
            // TaskQueueItem tq = db.Single("SELECT * from TaskQueue");
            TaskQueueItem tq = db.Single("");

            return tq;
        }
        public static bool removeTaskQueueItem(int taskQueueID)
        {
            MightyOrm<TaskQueueItem> db = DatabaseConnector.createConnectionTaskQueueItem();
            int numberRemoved = db.Delete(taskQueueID);
            if (numberRemoved > 0)
                return true;
            else
                return false;

        }


        static void main(String[] args)
        {
        }

    }
}
