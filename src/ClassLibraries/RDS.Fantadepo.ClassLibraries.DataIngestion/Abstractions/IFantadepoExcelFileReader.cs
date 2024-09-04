using RDS.Fantadepo.Models.Models;

namespace RDS.Fantadepo.ClassLibraries.DataIngestion.Abstractions
{
    public interface IFantadepoExcelFileReader
    {
        IEnumerable<Player> GetPlayersFromRosterFile();
        IEnumerable<Team> GetTeamsWithCoachesFromRosterFile();
    }
}