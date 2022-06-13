using System.Diagnostics;
using System.Text.RegularExpressions;
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
        public static async Task RptOldServerAsync(List<RptVariablesClass> RptVariablesList, string __DataBaseUser, string __DataBaseTable, string __DataBaseAddress, string __DataBasePassword)
        {
            string RptStartDate             = string.Empty;
            string RptEndDate               = string.Empty;
            string _WorkingDirectory        = string.Empty;
            string _CapExecutablePath       = string.Empty;
            string _ExeName                 = string.Empty;
            string _ReportCreateParam       = string.Empty;
            string _ReportName              = string.Empty;
            string _OutputFolderName        = string.Empty;
            string[] _ReportNames           = new string[] { };
            string[] _OutputFolderNames     = new string[] { };

            int SelectedReport = -0x1; //Minux one in hexa.

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

            while (SelectedReport != -3)
            {
                Console.WriteLine("       Select your report.");
                for (int i = 0; i < _ReportNames.Count(); i++)
                {
                    Console.WriteLine("           {0}. {1}", i, _ReportNames[i]);
                }
                Console.WriteLine("           b. Go Back to Server Selection.");
                Console.WriteLine("           x. Exit.");
                Console.Write("{0}Enter report index number: ", Environment.NewLine);

                string? UserRptChoice = Console.ReadLine()!;

                if (UserRptChoice == "x" || UserRptChoice == "X")
                {
                    UserRptChoice = "-3";
                }

                if (UserRptChoice == "b" || UserRptChoice == "B")
                {
                    UserRptChoice = "-2";
                }

                SelectedReport = int.Parse(UserRptChoice);

                for (int i = 0; i < _ReportNames.Count(); i++)
                {
                    if (i == SelectedReport)
                    {
                        _ReportName = Regex.Replace(_ReportNames[i], @"\s+", string.Empty);

                        for (int j = 0; j < _OutputFolderNames.Count(); j++)
                        {
                            if (j == i)
                            {
                                _OutputFolderName = _OutputFolderNames[j];
                            }
                        }

                        break;
                    }
                }
                
                if (_ReportName != string.Empty)
                {
                    Console.WriteLine("Enter Start and End Date. Use the Format dd.mm.yyyy");
                    Console.Write("Enter Report Start Date: ");
                    RptStartDate = Console.ReadLine()!;
                    Console.WriteLine(Environment.NewLine);
                    Console.Write("Enter Report End Date: ");
                    RptEndDate = Console.ReadLine()!;
                }
                //TODO: 1. Need stop the function from running regardless of option selected or not.
                //TODO: 2. Check for valid entries using the same loop like _ReportNames.Count() != SelectedReport || SelectedReport != -3 || SelectedReport != -2.
                await RunCapReportMaker(_CapExecutablePath, _ExeName, _ReportCreateParam, _ReportName, _OutputFolderName, __DataBaseUser, __DataBaseTable, __DataBaseAddress, __DataBasePassword);
            }            
        }

        public static void RptNewServer()
        {
            Console.WriteLine("Reports from new server.");
        }

        public static async Task RunCapReportMaker(string CapPath, string CapExeName, string CapArgs, string RptName, string RptOutFolder, string DBUser, string DBTable, string DBAddress, string DBPass)
        {
            try
            {
                var FullPathToCap = Path.Combine(CapPath, CapExeName);

                Console.WriteLine("CAP Path: {0}", FullPathToCap);

                Process CallCapProcess = new Process();

                CallCapProcess.StartInfo.FileName = FullPathToCap;
                CallCapProcess.StartInfo.Arguments = $"{CapArgs} {RptName}";
            }
            catch (Exception ex)
            {

            }
        }
    }
}
