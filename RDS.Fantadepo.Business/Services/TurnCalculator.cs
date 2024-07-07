using RDS.Fantadepo.Business.Helpers;
using RDS.Fantadepo.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Services
{
    public class TurnCalculator
    {
        public static IEnumerable<MatchResult> GetTurnResults(Turn turn)
        {
            var scores = new Dictionary<Player, decimal>(); 

            for(int i = 0; i < turn.Scores.Count; i++)
            {
                var player = turn.Scores.ElementAt(i).Key;
                var score = ScoreHelper.GetFinalScore(turn.Scores.ElementAt(i).Value);
                scores.Add(player, score);
            }

            var result = Enumerable.Empty<MatchResult>();

            foreach(var match in turn.Matches)
            {
                var matchResult = new MatchResult { Match = match };

                decimal team1Score = 0; 
                decimal team2Score = 0;
                foreach (var player in match.Team1.Players)
                {
                    team1Score += scores[player];
                }

                foreach (var player in match.Team2.Players)
                {
                    team2Score += scores[player];
                }

                if(team1Score > team2Score)
                {
                    matchResult.Winner = match.Team1;
                    matchResult.WinnerScore = team1Score;
                    matchResult.LoserScore = team2Score;
                }
                else if(team2Score > team1Score)
                {
                    matchResult.Winner = match.Team2;
                    matchResult.WinnerScore = team2Score;
                    matchResult.LoserScore = team1Score;
                }
                else // draw
                {
                    matchResult.Winner = null;
                    matchResult.WinnerScore = team1Score;
                    matchResult.LoserScore = team1Score;
                }

                result.Append(matchResult);
            }

            return result;
        }
    }
}
