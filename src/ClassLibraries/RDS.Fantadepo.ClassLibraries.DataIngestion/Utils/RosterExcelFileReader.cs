using ExcelDataReader;
using RDS.Fantadepo.Models.Models;
using System.Data;
using System.Text;

namespace RDS.Fantadepo.ClassLibraries.DataIngestion.Utils
{
    public static class RosterExcelFileReader
    {
        public static IEnumerable<Team> GetTeamsWithCoachesFromDataTable(DataTable dt)
        {
            foreach (var r in dt.Rows.Cast<DataRow>().Skip(1))
            {
                var team = new Team
                {
                    Name = r[CellIndex.TeamSheetTeamNameCellIndex].ToString() ?? string.Empty,
                    TeamPlayers = []
                };

                AddCoachToTeam(r, team);
                AddPlayersToTeam(r, team);

                yield return team;
            }
        }

        private static void AddPlayersToTeam(DataRow r, Team team)
        {
            team.TeamPlayers = [];

            for (var i = CellIndex.TeamSheetPlayerNameStartCellIndex; i < CellIndex.TeamSheetPlayerNameEndCellIndex; i++)
            {
                var playerName = r[i].ToString()!.Trim();

                if (!string.IsNullOrWhiteSpace(playerName))
                {
                    team.TeamPlayers.Add(new TeamPlayer { Player = new Player { Lastname = playerName } });
                }
            }
        }

        private static void AddCoachToTeam(DataRow r, Team team)
        {
            var coachName = r[CellIndex.TeamSheetCoachNameCellIndex].ToString()!.Split(" ", StringSplitOptions.TrimEntries);

            if (coachName != null)
            {
                team.Coach = new Coach
                {
                    FirstName = coachName[0],
                    LastName = coachName[1]
                };
            }
        }

        public static IEnumerable<Player> GetPlayersFromDataTable(DataTable dt)
        {
            foreach (var r in dt.Rows.Cast<DataRow>().Skip(1))
            {
                var playerName = r[CellIndex.PlayerSheetPlayerNameCellIndex].ToString()!.Split(" ", StringSplitOptions.TrimEntries);
                yield return new Player
                {
                    Firstname = playerName[0],
                    Lastname = playerName[1]
                };
            }
        }
    }
}
