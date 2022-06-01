﻿using System;
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
            foreach (var RptVariable in RptVariablesList)
            {
                Console.WriteLine("Working Directory: {0}", RptVariable.WorkingDirectory);
                Console.WriteLine("Program Path: {0}", RptVariable.CapExecutablePath);
                Console.WriteLine("Main Rpt Output: {0}", RptVariable.MainReportOutputPath);
                Console.WriteLine("CAP Path: {0}", RptVariable.CapExecutablePath);

                foreach (var RptFile in RptVariable.ReportOutputFolderNames)
                {
                    Console.WriteLine("Report Folders: {0}", RptFile);
                }
            }
        }

        public static void RptNewServer()
        {
            Console.WriteLine("Reports from new server.");
        }
    }
}
