using System;
using RptVariables;

namespace RptFunctionsSetClass
{
    internal class RptFunctionsSet
    {
        public static string ProgramfilesPath = Environment.GetEnvironmentVariable("ProgramFiles(x86)");

        //The banner.
        public static void MainBanner()
        {
            var NewLine = Environment.NewLine;
            Console.WriteLine(
                "                                  ******************************************************{0}" +
                "                                  *                                                    *{0}" +
                "                                  *               Manual Reports Generator             *{0}" +
                "                                  *                                                    *{0}" +
                "                                  *      Created by: Sandaruwan Samaraweera            *{0}" +
                "                                  *      Version: 1.0.1                                *{0}" +
                "                                  *                                                    *{0}" +
                "                                  ******************************************************{0}" +
                "------------------------------------------------------------------------------------------------------------------------ {0}", NewLine);

        }

        //Checks and creates the needed folders if missing.
        public static void FolderCheck(string _MainOutputPath, string[] _OutputFolderNames)
        {
            if (!Directory.Exists(_MainOutputPath))
            {
                try
                {
                    Directory.CreateDirectory(_MainOutputPath);
                    Console.WriteLine("Main Report Folder Created at {0}", _MainOutputPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception thrown: {0}", ex.Message);
                }
            }
            
            foreach (string _OuptuFolderName in _OutputFolderNames)
            {
                string _OutputFolderPath = Path.Combine(_MainOutputPath, _OuptuFolderName);

                if (!Directory.Exists(_OutputFolderPath))
                {
                    try
                    {
                        Directory.CreateDirectory(_OutputFolderPath);
                        Console.WriteLine("Folder {0} created at {1}",_OuptuFolderName, _OutputFolderPath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception throen: {0}", ex.Message);
                    }
                }
            }
        }

        //Function to create the reports from the old server.
        public static void RptOldServer(List<RptVariablesClass> RptVariablesList)
        {
            string _WorkingDirectory = string.Empty;
            string _CapExecutablePath = string.Empty;
            string _ExeName = string.Empty;
            string _ReportCreateParam = string.Empty;
            string[] _ReportNames = new string[] { };
            string[] _OutputFolderNames = new string[] { };

            int SelectedReport = -0x1;

            foreach (var RptVariable in RptVariablesList)
            {
                _WorkingDirectory = RptVariable.WorkingDirectory;
                _CapExecutablePath = RptVariable.CapExecutablePath;
                _ExeName = RptVariable.ExeName;
                _ReportCreateParam = RptVariable.ReportCreateParam;

                //String arrays.
                _ReportNames = RptVariable.ReportNames;
                _OutputFolderNames = RptVariable.ReportOutputFolderNames;
            }

            Console.WriteLine("       Select your report.");
            for (int i = 0; i < _ReportNames.Count(); ++i)
            {
                Console.WriteLine("           {0}. {1}", i, _ReportNames[i]);
            }
            Console.Write("Enter report index number: ");            
            SelectedReport = int.Parse(Console.ReadLine());

            switch (SelectedReport)
            {
                //case 0:
                    //TODO: 1. Makes the menu and the function for the old server.
            }
        }

        public static void RptNewServer()
        {
            Console.WriteLine("Reports from new server.");
        }
    }
}
