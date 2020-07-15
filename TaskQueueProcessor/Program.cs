using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.Json;
using System.IO;
using System.Linq;
using Mighty;

namespace TaskQueueProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Console.WriteLine("Hello World!");


            /*

                   string path = @"C:\Users\amccaff\src\TQP\TaskQueueProcessor\TaskQueueProcessor\sample.json";

                   string json = File.ReadAllText(path);
                   TestRun testRun = TestRun.generateTestRun(json);
               Console.WriteLine(testRun.DateTimeStamp);
               Console.WriteLine(testRun.TestCases.ElementAt(0).BitstringMCVEstimateMode);
               Console.WriteLine(testRun.TestCases.ElementAt(0).TestResults.ElementAt(0).AvgCollision);
            */

            // MightyOrm db = new MightyOrm("Server=localhost\\SQLEXPRESS;Database=TaskQueueProcessor;ProviderName=System.Data.SqlClient;User=user;Password=user","TestResult","TestResultID");

            // Object thing = db.Execute("SELECT * FROM TaskQueue");
            // Object thing = db.Single("SELECT * FROM TaskQueue WHERE 1=1");
            // dynamic tq = db.Single("SELECT * FROM TaskQueue WHERE TaskID = 1");

            //dynamic tq = db.Single(1);

            //TaskQueue taskQueue = (TaskQueue) tq;
            //Console.WriteLine($"{tq.TaskType}");
            /*
            TestRun tr = new TestRun();
            tr.Category = 1;
            tr.Sha256 = "FakeShaHereAgain";
            tr.Filename = "filename2.txt";
            DatabaseConnector.storeTestRun(db, tr);
            */
            /*
            TestCase tc = new TestCase();
            tc.BinLrsRes = 0.12345;
            tc.TestCaseDesc = "Look at me!";
            //db.TableName = "TestCase";
            //db.PrimaryKeyInfo = "TestCaseID";
            DatabaseConnector.storeTestCase(db,tc,"2");
            */
            /*
            //TestResult tr = new TestResult();
            tr.Compression = 0.0123456;
            tr.Iteration = "123";

            DatabaseConnector.storeTestResult(db, tr, "1");
            */

            //  MightyOrm dbTestRun = new MightyOrm("Server=localhost\\SQLEXPRESS;Database=TaskQueueProcessor;ProviderName=System.Data.SqlClient;User=user;Password=user", "TestRun", "TestRunID");
            //  MightyOrm dbTestCase = new MightyOrm("Server=localhost\\SQLEXPRESS;Database=TaskQueueProcessor;ProviderName=System.Data.SqlClient;User=user;Password=user", "TestCase", "TestCaseID");
            //  MightyOrm dbTestResult = new MightyOrm("Server=localhost\\SQLEXPRESS;Database=TaskQueueProcessor;ProviderName=System.Data.SqlClient;User=user;Password=user", "TestResult", "TestResultID");
            /*

              TestRun tr = new TestRun();
              tr.Category = 2;
              tr.Sha256 = "FakeSha256";
              tr.Filename = "file.txt";

              TestCase tc = new TestCase();
              tc.TestCaseDesc = "Check out my fake description";
              tc.HOriginal = 1.23456;
              tc.HBitstring = 0.0001;

              TestResult testResult = new TestResult();
              testResult.Iteration = "123";
              testResult.Excursion = 0.5;

              tc.TestResults.Add(testResult);
              tr.TestCases.Add(tc);

              // DatabaseConnector.storeTestRun(dbTestRun, dbTestCase, dbTestResult, tr);

              DatabaseConnector.storeTestRun(tr);
            */

            Console.WriteLine(DatabaseConnector.isTaskQueueEmpty());
            Console.WriteLine(DatabaseConnector.getNextTaskQueueItem().CreatedOn);

        }
    }
}
