using ExcelDataReader;
using RDS.Fantadepo.ClassLibraries.DataIngestion.Abstractions;
using RDS.Fantadepo.ClassLibraries.DataIngestion.Utils;
using RDS.Fantadepo.Shared.Models;
using System.Data;
using System.Text;

namespace RDS.Fantadepo.DataIngestion
{
    public class FantadepoExcelFileReader : IFantadepoExcelFileReader
    {
        private readonly IEnumerable<DataTable> dataTables;

        public FantadepoExcelFileReader(string path)
        {
            dataTables = GetDataTablesFromFile(path) ?? throw new ArgumentException("Unable to retrieve data tables from the excel file specified");
        }

        private static IEnumerable<DataTable>? GetDataTablesFromFile(string path)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using var stream = File.Open(path, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateReader(stream);

            var dataTables = reader.AsDataSet().Tables.Cast<DataTable>();
            return dataTables;
        }

        public IEnumerable<Player> GetPlayersFromRosterFile()
        {
            var dt = dataTables.ElementAt(SheetIndex.RosterFilePlayerSheetIndex);
            return RosterExcelFileReader.GetPlayersFromDataTable(dt);
        }

        public IEnumerable<Team> GetTeamsWithCoachesFromRosterFile()
        {
            var dt = dataTables.ElementAt(SheetIndex.RosterFileTeamSheetIndex);
            return RosterExcelFileReader.GetTeamsWithCoachesFromDataTable(dt);
        }
    }
}
