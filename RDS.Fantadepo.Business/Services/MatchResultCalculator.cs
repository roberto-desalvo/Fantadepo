using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDS.Fantadepo.Business.Models;

namespace RDS.Fantadepo.Business.Services
{
    public static class MatchResultCalculator
    {
        public static bool IsDraw(Match match, IList<Performance> performances)
        {
            return GetWinner(match, performances) == null;
        }

        public static Team? GetWinner(Match match, IList<Performance> performances)
        {
            var score1 = GetTeamScore(match.Team1, performances);
            var score2 = GetTeamScore(match.Team2, performances);

            return score1 == score2 ? null : score1 > score2 ? match.Team1 : match.Team2;
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
                        finalScore += GetScoreAsDecimal(performance.Score);
                    }
                }
            }

            return finalScore;
        }

        public static decimal GetScoreAsDecimal(Score score)
        {
            decimal final = 0;
            final += score.Goals * 2;
            final += score.OwnGoals * -1;
            final += score.Assists * 1;
            final += (decimal)(score.YellowCards * -0.5);
            final += (decimal)(score.RedCards * -1.5);
            final += score.ScoredPenalties * 1;
            final += score.ScoredFreeKicks * 2;
            final += (decimal)(score.FailedPenalties * -1.5);
            final += (decimal)(score.FailedFreeKicks * -0.5);

            if (score.IsGoalKeeper)
            {
                final += score.SavedPenalties * 2;
                final += score.SavedFreeKicks * 1;

                var concededGoalsScore = score.ConcededGoals switch
                {
                    0 => 10,
                    1 => 8,
                    2 => 6,
                    3 => 4,
                    4 => 2,
                    5 => 1,
                    6 => -1,
                    7 => -2,
                    8 => -3,
                    9 => -4,
                    10 => -5,
                    _ => 0
                };

                if (score.ConcededGoals > 10)
                {
                    concededGoalsScore = -5;
                }

                final += concededGoalsScore;
            }

            if (final < (decimal)0.5)
            {
                final = (decimal)0.5;
            }

            return final;
        }
    }
}
