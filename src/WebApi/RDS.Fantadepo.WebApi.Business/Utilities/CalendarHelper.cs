using RDS.Fantadepo.WebApi.DataAccess.Entities;
using RDS.Fantadepo.WebApi.Business.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.Business.Helpers
{
    public class CalendarHelper
    {
        public static Season ScheduleTurns(Season season)
        {
            if(season.Teams != null)
            {
                var turns = CreateTurnsWithRoundRobin([.. season.Teams]);
                season.Turns = turns.ToList();
            }
            
            return season;
        }

        public static IEnumerable<Turn> CreateTurnsWithRoundRobin(IList<Team> teams)
        {
            var turns = new List<Turn>();
            var results = RoundRobin<Team>.Instance.DoubleRoundRobin([.. teams]);

            foreach (var list in results)
            {
                var turn = new Turn { Matches = [] };

                foreach (var item in list)
                {
                    var match = new Match
                    {
                        HomeTeamId = item.Item1.Item.Id,
                        HomeTeam = item.Item1.Item,
                        AwayTeamId = item.Item2.Item.Id,
                        AwayTeam = item.Item2.Item,
                    };
                    turn.Matches.Add(match);
                }
                turns.Add(turn);
            }

            return turns;
        }
    }
}
