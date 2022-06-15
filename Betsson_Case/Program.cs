using Betsson_Case.Database;
using Betsson_Case.Model;
using CsvHelper;
using Microsoft.Extensions.Configuration;
using System.Globalization;

Console.WriteLine("Hello, Betsson!");
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); //this line is added for the labels without timezone

//I added json file that holds to necessary file paths dynamically.
var configuration = new ConfigurationBuilder()
     .SetBasePath(Directory.GetCurrentDirectory())
     .AddJsonFile($"appSettings.json");
var config = configuration.Build();

var folderPath = config["ConnectionStrings:FolderPath"];
var processedFolderPath = config["ConnectionStrings:ProcessedFolder"];
var errorFolderPath = config["ConnectionStrings:ErrorFolder"];

int fileCountInFolder = Directory.GetFiles(folderPath, "*", SearchOption.TopDirectoryOnly).Length;

for (int i = 1; i <= fileCountInFolder; i++) //this for loop makes sure that every single file is counted and iterated
{
    var csvFile = string.Format(config["ConnectionStrings:CsvFilesPath"], i); //this line takes the root path and changes the csv files name dynamically according to its number located at the end of file

    using (var streamReader = new StreamReader(csvFile))
    {
        using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
        {
            var records = csvReader.GetRecords<CsvModel>().ToList(); //It includes postgres table creating codes
            if (records.Count > 0)
            {
                foreach (var record in records)
                {
                    using (var db = new ApplicationDbContext())
                    {
                        try
                        {
                            db.Add(record);
                            db.SaveChanges();
                            Console.WriteLine($"Record added OrderId: {record.OrderID}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred while adding the orderId: {record.OrderID}. Error: {ex.Message}");
                        }

                    }
                }

                if (Directory.Exists(processedFolderPath))
                {
                    CopyFiles(csvFile, folderPath, processedFolderPath);
                }
                else
                {
                    DirectoryInfo di = Directory.CreateDirectory(processedFolderPath);
                    CopyFiles(csvFile, folderPath, processedFolderPath);

                }
            }
            else
            {
                if (Directory.Exists(errorFolderPath))
                {
                    CopyFiles(csvFile, folderPath, errorFolderPath);
                }
                else
                {
                    DirectoryInfo di = Directory.CreateDirectory(errorFolderPath);
                    CopyFiles(csvFile, folderPath, errorFolderPath);
                }
            }
        }
    }
}
Console.Read();

void CopyFiles(string filePath, string sourcePath, string targetPath)
{
    var fileName = Path.GetFileName(filePath);
    string sourceFile = Path.Combine(sourcePath, fileName);
    string destinationFile = Path.Combine(targetPath, fileName);
    File.Copy(sourceFile, destinationFile, true);
    Console.WriteLine($"{fileName} file copied.");
}