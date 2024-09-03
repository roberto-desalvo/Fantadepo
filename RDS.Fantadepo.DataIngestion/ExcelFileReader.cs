using ExcelDataReader;
using RDS.Fantadepo.DataIngestion.Exceptions;
using RDS.Fantadepo.Models.Models;
using RDS.Fantadepo.WebApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Entities = RDS.Fantadepo.WebApi.DataAccess.Entities;

namespace RDS.Fantadepo.DataIngestion
{
    public class ExcelFileReader
    {
        private readonly FantadepoContext _context;

        public ExcelFileReader(FantadepoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<DataTable>? GetDataTablesFromFile(string path)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using var stream = File.Open(path, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateReader(stream);

            var dataTables = reader.AsDataSet().Tables.Cast<DataTable>();
            return dataTables;
        }

        public bool ProcessExcelData(string path, ExcelFileType excelType)
        {
            var dts = GetDataTablesFromFile(path);

            if (dts is null)
            {
                return false;
            }

            if (excelType == ExcelFileType.Roster)
            {
                TrackPlayers(dts.ElementAt(1));
                TrackTeamsWithCoachesAndRosters(dts.ElementAt(0));
            }

            return true;
        }

        private void TrackTeamsWithCoachesAndRosters(DataTable dataTable)
        {
            var teams = RosterExcelFileReader.GetTeamsWithCoachesFromDataTable(dataTable);

            foreach (var team in teams)
            {
                var teamEntity = new Entities.Team();

                if (TeamExists(team))
                {
                    throw new TeamAlreadyExistsException();
                }

                var coach = team.Coach;

                teamEntity.Coach = CoachExists(coach) ?
                    _context.Coaches.First(x => x.FirstName == coach.FirstName && x.LastName == coach.LastName) :
                    new Entities.Coach { FirstName = coach.FirstName, LastName = coach.LastName };

                foreach(var tp in team?.TeamPlayers)
                {
                    var playerName = tp.Player!.Lastname;

                    if (string.IsNullOrWhiteSpace(playerName))
                    {
                        continue;
                    }

                    var playerEntity = _context.Players.FirstOrDefault(x => x.Lastname  == playerName) ?? throw new PlayerNotFoundException();

                    teamEntity.TeamPlayers.Add(new Entities.TeamPlayer { Player = playerEntity });
                }

                _context.Teams.Add(teamEntity);
            }
            _context.SaveChanges();
        }



        private void TrackPlayers(DataTable dt)
        {
            var players = RosterExcelFileReader.GetPlayersFromDataTable(dt);

            foreach (var player in players)
            {
                if (!PlayerExists(player))
                {
                    var entity = new Entities.Player
                    {
                        Firstname = player.Firstname,
                        Lastname = player.Lastname
                    };
                    _context.Players.Add(entity);
                }
            }
            _context.SaveChanges();
        }

        private bool PlayerExists(Player player)
        {
            return _context.Players.Any(x => x.Firstname == player.Firstname && x.Lastname == player.Lastname);
        }
        private bool TeamExists(Team team)
        {
            return _context.Teams.Any(x => x.Name == team.Name);
        }

        private bool CoachExists(Coach coach)
        {
            return _context.Coaches.Any(x => x.FirstName == coach.FirstName && x.LastName == coach.LastName);
        }
    }
}
