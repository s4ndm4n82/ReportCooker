using RptFunctionsSetClass;

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
                                    "TimeSpent"};

RptFunctionsSet.MainBanner();

RptFunctionsSet.ServerSelectMenu();