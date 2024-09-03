using ExcelDataReader;
using RDS.Fantadepo.Models.Models;
using System.Data;
using System.Text;

namespace RDS.Fantadepo.DataIngestion
{
    public static class RosterExcelFileReader
    {
        public static IEnumerable<Team> GetTeamsWithCoachesFromDataTable(DataTable dt)
        {
            foreach (var r in dt.Rows.Cast<DataRow>().Skip(1))
            {
                var team = new Team
                {
                    Name = r[0].ToString() ?? string.Empty,
                    TeamPlayers = []
                };

                AddCoach(r, team);
                AddPlayers(r, team);
                
                yield return team;
            }
        }

        private static void AddPlayers(DataRow r, Team team)
        {
            for(var i = 2; i < 10; i++)
            {
                var playerName = r[i].ToString()!.Trim();

                if (!string.IsNullOrWhiteSpace(playerName))
                {
                    team.TeamPlayers.Add(new TeamPlayer { Player = new Player { Lastname =  playerName } });
                }
            }
        }

        private static void AddCoach(DataRow r, Team team)
        {
            var coachName = r[1].ToString()!.Split(" ", StringSplitOptions.TrimEntries);

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
                var playerName = r[0].ToString()!.Split(" ", StringSplitOptions.TrimEntries);
                yield return new Player
                {
                    Firstname = playerName[0],
                    Lastname = playerName[1]
                };
            }
        }
    }
}
