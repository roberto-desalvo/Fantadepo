using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDS.Fantadepo.Business.Models;

namespace RDS.Fantadepo.Business.Services
{
    public class MatchResultCalculator
    {
        private readonly Match _match;
        private readonly IList<Performance> _performances;
        
        public MatchResultCalculator(Match match, IList<Performance> performances)
        {
            _match = match ?? throw new ArgumentNullException(nameof(match));
            _performances = performances?? throw new ArgumentNullException(nameof(performances));
        }

        public bool IsDraw()
        {
            var score1 = FantadepoService.GetTeamScore(_match.Team1, _performances);
            var score2 = FantadepoService.GetTeamScore(_match.Team2, _performances);

            return score1 == score2;
        }

        public Team? GetWinner()
        {
            var score1 = FantadepoService.GetTeamScore(_match.Team1, _performances);
            var score2 = FantadepoService.GetTeamScore(_match.Team2, _performances);

            if(score1 > score2)
            {
                return _match.Team1;
            }
            else if(score1 < score2)
            {
                return _match.Team2;
            }
            else
            {
                return null;
            }
        }
    }
}
