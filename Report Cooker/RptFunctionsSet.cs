using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RptFunctionsSetClass
{
    internal class RptFunctionsSet
    {
        //The banner.
        public static void MainBannaer()
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
    }
}
