using ExcelDataReader;
using RDS.Fantadepo.ClassLibraries.DataIngestion.Utils;
using RDS.Fantadepo.Shared.Models;
using System.Data;
using System.IO;
using System.Text;

namespace RDS.Fantadepo.DataIngestion
{
    public static class FantadepoExcelFileReader 
    {        
        private static IEnumerable<DataTable>? GetDataTablesFromFile(string path)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using var stream = File.Open(path, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateReader(stream);

            var dataTables = reader.AsDataSet().Tables.Cast<DataTable>();
            return dataTables;
        }

        public static IEnumerable<Player> GetPlayersFromRosterFile(string path)
        {
            var dataTables = GetDataTablesFromFile(path) ?? throw new ArgumentException("Unable to retrieve data tables from the excel file specified");

            var dt = dataTables.ElementAt(SheetIndex.RosterFilePlayerSheetIndex);
            var players = RosterExcelFileReader.GetPlayersFromDataTable(dt);
            return players;
        }

        public static IEnumerable<Team> GetTeamsWithCoachesFromRosterFile(string path)
        {
            var dataTables = GetDataTablesFromFile(path) ?? throw new ArgumentException("Unable to retrieve data tables from the excel file specified");

            var dt = dataTables.ElementAt(SheetIndex.RosterFileTeamSheetIndex);
            var teams = RosterExcelFileReader.GetTeamsWithCoachesFromDataTable(dt).ToList();
            return teams;
        }
    }
}
