using System;
using System.Collections.Generic;
using System.Text;

namespace TaskQueueProcessor
{
    class EntropyAssessment
    {


        static public string runEntropyAssessment(EntropyAssessmentInputParameters input)
        {
            string result = "";
            
            
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            if (input.LocalType.Equals("non_iid"))
                startInfo.FileName = "ea_non_iid.exe";
            else
                startInfo.FileName = "ea_iid.exe";

            StringBuilder arguments = new StringBuilder();
            if (input.InitialOrConditioned)
                arguments.Append("-i ");
            else
                arguments.Append("-c ");
            if (input.AllOrTruncatedReadBits)
                arguments.Append("-a ");
            else
                arguments.Append("-t ");

            if (input.Index != -1 && input.Sample != -1)
            {
                arguments.Append("-l ");
                arguments.Append(input.Index);
                arguments.Append(",");
                arguments.Append(input.Sample);
                arguments.Append(" ");
            }
            arguments.Append(input.Filename);
            arguments.Append(" ");

            if (input.BitsPerSymbol != -1)
            {
                arguments.Append(input.BitsPerSymbol);
                arguments.Append(" ");
            }

            startInfo.Arguments = arguments.ToString();
            
            process.StartInfo = startInfo;
            process.Start();


            process.WaitForExit();

            // TODO: Parse JSON file

            return result;
        }


    }
}
