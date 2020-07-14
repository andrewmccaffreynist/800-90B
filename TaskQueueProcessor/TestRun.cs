using System;
using System.Collections.Generic;
using System.Text.Json;


namespace TaskQueueProcessor
{
    class TestRun
    {
        public int Category { get; set; }
        public String DateTimeStamp { get; set; }
        public String Sha256 { get; set; }
        public String Filename { get; set; }
        public List<TestCase> TestCases { get; set; }

        public TestRun()
        {
            TestCases = new List<TestCase>();
        }

        static public TestRun generateTestRun(String json)
        {

            TestRun testRun = JsonSerializer.Deserialize<TestRun>(json);
            return testRun;
        }




    }
}
