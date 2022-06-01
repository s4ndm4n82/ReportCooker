using RptFunctionsSetClass;
using RptVariables;

string? ProgramfilesPath = Environment.GetEnvironmentVariable("ProgramFiles(x86)");
/*
//Variable declaration.
//For the MC.
string WorkingDirectory = Directory.GetCurrentDirectory(); //Current working directory.
string? ProgramfilesPath = Environment.GetEnvironmentVariable("ProgramFiles(x86)"); //Program Files path from Windows.
string CapExecutablePath = @$"{ProgramfilesPath}\Navitro\CAP\"; //Concating the path with the program files path.
string ExeName = "ManagementConsole.exe"; //CAP execuable name.
string ReportCreateParam = "/CreateReport"; //Report parametere.

//TODO: For database detail get from secrets.

//Used field.
string UsedFieldName = "Voucher Type";

//Main report output folder path.
string MainReportOutputPath = Path.Combine(WorkingDirectory,"Reports");

//Report output type array.
string[] ReportOutTypes = new string[] { "PDF", "EXCEL", "WORD" };

//Report name array.
string[] ReportNames = new string[] {"Items Per Job",
                                    "Items Per Job Detailed",
                                    "Imported Exported",
                                    "GroupBy Fields",
                                    "Group By Fields Job Columns",
                                    "Group By Fields Job Columns",
                                    "Audit Log Field Changes",
                                    "Audit Log Count",
                                    "Time Spent"};

//Report output folder nmaes.
string[] ReportOutputFolderNames = new string[] {"ItemsPerJob",
                                    "ItemsPerJobDetailed",
                                    "ImportedExported",
                                    "GroupByFields",
                                    "GroupByFieldsJobColumns",
                                    "GroupByFieldsJobColumns",
                                    "AuditLogFieldChanges",
                                    "AuditLogCount",
                                    "TimeSpent"};*/

List <RptVariablesClass> RptVariablesList = new List<RptVariablesClass>
{
    new RptVariablesClass
    {
        WorkingDirectory            = Directory.GetCurrentDirectory(),
        CapExecutablePath           = @$"{ProgramfilesPath}\Navitro\CAP\",
        ExeName                     = "ManagementConsole.exe",
        ReportCreateParam           = "/CreateReport",
        UsedFieldName               = "Voucher Type",
        MainReportOutputPath        = Path.Combine(Directory.GetCurrentDirectory(), "Reports"),
        ReportNames                 = new string[] {"Items Per Job",
                                        "Items Per Job Detailed",
                                        "Imported Exported",
                                        "GroupBy Fields",
                                        "Group By Fields Job Columns",
                                        "Group By Fields Job Columns",
                                        "Audit Log Field Changes",
                                        "Audit Log Count",
                                        "Time Spent"},
        ReportOutputFolderNames     = new string[] {"ItemsPerJob",
                                        "ItemsPerJobDetailed",
                                        "ImportedExported",
                                        "GroupByFields",
                                        "GroupByFieldsJobColumns",
                                        "GroupByFieldsJobColumns",
                                        "AuditLogFieldChanges",
                                        "AuditLogCount",
                                        "TimeSpent"}
    }


};

var Choice = -0x1;
var NewLine = Environment.NewLine;

while (Choice != 0)
{
    //Console.Clear();

    RptFunctionsSet.MainBanner();

    Console.WriteLine(
    "       Select a server, from below.{0}" +
    "           1. Navitro-02 Server (Old Server).{0}" +
    "           2. DCProd-01 Server (New Server).{0}" +
    "           x. Exit Program{0}", NewLine);

    Console.Write("       Enter your choice: ");
    string? StringChoice = Console.ReadLine();

    if ((StringChoice == "x") || (StringChoice == "X"))
    {
        StringChoice = "0";
    }

    Choice = int.Parse(StringChoice);

    switch (Choice)
    {
        case 0:
            Console.WriteLine("{0}       Good Bye ... !", NewLine);
            Thread.Sleep(1500);
            break;

        case 1:
            RptFunctionsSet.RptOldServer(RptVariablesList);
            Choice = 0;
            break;

        case 2:
            RptFunctionsSet.RptNewServer();
            Choice = 0;
            break;

        default:
            Console.WriteLine("{0}       Invalid choice try again.", NewLine);
            Thread.Sleep(1500);
            break;
    }
}