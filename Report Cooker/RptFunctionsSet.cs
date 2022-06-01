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

        public static void RptOldServer(List<RptVariablesClass> RptVariablesList)
        {
            string _WorkingDirectory = string.Empty;
            string _CapExecutablePAth = string.Empty;
            string _ExeName = string.Empty;
            string __ReportCreateParam = string.Empty;
            string[] _OutputFolderNames = new string[] { };

            foreach (var RptVariable in RptVariablesList)
            {
                _WorkingDirectory = RptVariable.WorkingDirectory;
                //Console.WriteLine("Working Directory: {0}", RptVariable.WorkingDirectory);
                //Console.WriteLine("Program Path: {0}", RptVariable.CapExecutablePath);
                //Console.WriteLine("Main Rpt Output: {0}", RptVariable.MainReportOutputPath);
                //Console.WriteLine("CAP Path: {0}", RptVariable.CapExecutablePath);

                _OutputFolderNames = RptVariable.ReportOutputFolderNames;
            }

            Console.WriteLine("Working Directory Outside Foreach: {0}", _WorkingDirectory);
            foreach (string _OutputFolderName in _OutputFolderNames)
            {
                Console.WriteLine("Folder name Out side main foreach: {0}", _OutputFolderName);
            }

        }

        public static void RptNewServer()
        {
            Console.WriteLine("Reports from new server.");
        }
    }
}
