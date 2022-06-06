using Microsoft.Extensions.Configuration;
using RptFunctionsSetClass;
using RptVariables;

var _AppConfig = LoadAppSecrets();

if(_AppConfig == null)
{
    Console.WriteLine("User secrets not set or cannot be found.");
    return;
}

var _DataBaseUser = _AppConfig["DataBaseUser"];
var _DataBaseTableV2 = _AppConfig["DataBaseTableV2"];
var _DataBaseTableV1 = _AppConfig["DataBaseTableV1"];
var _DataBaseAddress = _AppConfig["DataBaseAddress"];
var _DataBasePassword = _AppConfig["DataBasePassword"];

string? ProgramfilesPath = Environment.GetEnvironmentVariable("ProgramFiles(x86)");

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

static IConfigurationRoot? LoadAppSecrets()
{
    var AppConfig = new ConfigurationBuilder()
                    .AddUserSecrets<Program>()
                    .Build();

    if (string.IsNullOrEmpty(AppConfig["DataBaseUser"])||
        string.IsNullOrEmpty(AppConfig["DataBaseTableV2"])||
        string.IsNullOrEmpty(AppConfig["DataBaseTableV1"])||
        string.IsNullOrEmpty(AppConfig["DataBaseAddress"])||
        string.IsNullOrEmpty(AppConfig["DataBasePassword"]))
    {
        return null;
    }

    return AppConfig;
}