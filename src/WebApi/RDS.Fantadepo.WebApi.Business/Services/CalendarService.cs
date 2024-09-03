using RDS.Fantadepo.Models.Models;
using RDS.Fantadepo.WebApi.Business.Algorithms;
using RDS.Fantadepo.WebApi.Business.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.Business.Services
{
    public class CalendarService
    {
        public static CalendarService Instance => new();

        public IEnumerable<Turn> CreateTurnsWithRoundRobin(IList<Team> teams)
        {
            var turns = new List<Turn>();
            var results = RoundRobin<Team>.Instance.DoubleRoundRobin(teams.ToList());

            foreach(var list in results)
            {
                var turn = new Turn { Matches = [] };

                foreach(var item in list)
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
