using RDS.Fantadepo.Business.Helpers;
using RDS.Fantadepo.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Services
{
    public class FantadepoService
    {
        public static IEnumerable<Match> GetAllMatches(IEnumerable<Team> teams)
        {
            var matches = new List<Match>();
            for (int i = 0; i < teams.Count(); i++)
            {
                for (int j = i + 1; j < teams.Count(); j++)
                {
                    matches.Add(new Match { Team1 = teams.ElementAt(i), Team2 = teams.ElementAt(j) });
                }
            }

            return matches;
        }

        public static IEnumerable<Turn> GetTurns(IList<Team> teams)
        {
            var turns = new List<Turn>();
            var n = teams.Count;

            var combinationCount = (n * (n - 1)) / 2;
            var matchCountForTeam = n - 1;
            var matchCountForTurn = n % 2 == 0 ? (n / 2) : (n - 1) / 2;
            var turnsCount = n % 2 == 0 ? n - 1 : n;
            var combinations = GetAllMatches(teams);

            for (int i = 0; i < turnsCount; i++)
            {
                var turn = new Turn();

                foreach (var match in combinations)
                {
                    if (turn.Matches.Count >= matchCountForTeam)
                    {
                        break;
                    }

                    // controlla che il match non sia già in un turno precedente
                    foreach(var t in turns)
                    {
                        var alreadyExists = t.Matches.Any(x => x.Team1.Name == match.Team1.Name && x.Team2.Name == match.Team2.Name);

                        if (!alreadyExists)
                        {
                            // controlla che le squadre del match non stiano già giocando
                            var teamAreAlreadyPlaying = turn.Matches.Any(
                                x => x.Team1.Name == match.Team1.Name 
                            || x.Team1.Name == match.Team2.Name 
                            || x.Team2.Name == match.Team1.Name 
                            || x.Team2.Name == match.Team2.Name);

                            if (!teamAreAlreadyPlaying)
                            {
                                turn.Matches.Add(match);
                            }
                        }
                    }
                }
                turns.Add(turn);
            }

            return turns;
        }

        public static decimal GetTeamScore(Team team, IEnumerable<Performance> performances)
        {
            decimal finalScore = 0;

            foreach (var player in team.Players)
            {
                foreach (var performance in performances)
                {
                    if (performance.Player.Name == player.Name)
                    {
                        finalScore += performance.DecimalScore;
                    }
                }
            }

            return finalScore;
        }
    }
}
