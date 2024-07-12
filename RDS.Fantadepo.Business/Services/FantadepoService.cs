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

        // istanzio un nuovo oggetto turno
        // prendo la prossima squadra
        // se la squadra è già stata accoppiata in questo turno, passo alla prossima squadra
        // se invece no
        // // prendo la squadra dopo
        // // se sta già giocando, prendo quella dopo ancora
        // // se invece no, le accoppio
        // // se l'accoppiamento c'è già nei turni precedenti, passo alla prossima squadra
        // // se invece no, aggiungo il match al turno
        // // se ho ciclato tutte le squadre, passo al prossimo turno
        // controllo che tutte le squadre giochino n-1 partite

        //public static IEnumerable<Turn> GetTurns(IList<Team> teams)
        //{
        //    var turns = new List<Turn>();
        //    var expectedTurnCount = teams.Count % 2 == 0 ? teams.Count - 1 : teams.Count;

        //    while (turns.Count != expectedTurnCount)
        //    {
        //        var turn = new Turn();

        //        for (var i = 0; i < teams.Count; i++)
        //        {
        //            var homeTeam = teams.ElementAt(i);

        //            if (IsAlreadyPlaying(homeTeam, turn))
        //            {
        //                continue;
        //            }

        //            var found = false;
        //            var awayTeam = new Team();

        //            for (var j = 0; j < teams.Count; j++)
        //            {
        //                awayTeam = teams.ElementAt(j);

        //                if(!IsSameTeam(homeTeam, awayTeam) && !IsAlreadyPlaying(awayTeam, turn))
        //                {
        //                    found = true;
        //                    break;
        //                }                        
        //            }

        //            if (found)
        //            {
        //                var match = new Match { Team1 = homeTeam, Team2 = awayTeam };

        //                if (!MatchIsAlreadyScheduled(match, turns))
        //                {
        //                    turn.Matches.Add(match);
        //                }
        //            }
        //        }

        //        turns.Add(turn);
        //    }

        //    return turns;
        //}

        //private static bool MatchIsAlreadyScheduled(Match match, List<Turn> turns)
        //{
        //    foreach(var turn in turns)
        //    {
        //        if(turn.Matches.Any(m => IsSameTeam(m.Team1, match.Team1) && IsSameTeam(m.Team2, match.Team2)))
        //        {
        //            return true;
        //        }

        //        if (turn.Matches.Any(m => IsSameTeam(m.Team1, match.Team2) && IsSameTeam(m.Team2, match.Team1)))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //private static bool IsAlreadyPlaying(Team team, Turn turn)
        //{
        //    return turn?.Matches?.Any(m => IsSameTeam(m.Team1, team) || IsSameTeam(m.Team2, team)) ?? false;
        //}

        private static bool IsSameTeam(Team team1, Team team2)
        {
            return team1.Name == team2.Name;
        }


        public static IEnumerable<Turn> GetTurns(IList<Team> teams)
        {
            if (teams.Count % 2 != 0)
            {
                var fakeTeam = new Team { Name = "Fake" };
                teams.Add(fakeTeam);
                var temp = DoubleRoundRobinEven(teams);
                var turns = new List<Turn>();
                foreach (var turn in temp)
                {
                    if (turn.Matches.Any(m => IsSameTeam(m.Team1, fakeTeam) || IsSameTeam(m.Team2, fakeTeam)))
                    {
                        turn.Matches.Remove(turn.Matches.First(m => IsSameTeam(m.Team1, fakeTeam) || IsSameTeam(m.Team2, fakeTeam)));

                        turns.Add(turn);
                    }
                }
                return turns;
            }

            return DoubleRoundRobinEven(teams);
        }

        private static IEnumerable<Turn> DoubleRoundRobinEven(IList<Team> teams)
        {
            var list1 = new List<Team>();
            var list2 = new List<Team>();

            for (int i = 0; i < (teams.Count / 2); i++)
            {
                list1.Add(teams.ElementAt(i));
                list2.Add(teams.ElementAt(teams.Count - i - 1));
            }

            var preDebug1 = string.Join(" - ", list1.Select(x => x.Name).ToList());
            var preDebug2 = string.Join(" - ", list2.Select(x => x.Name).ToList());
            var originalSecondItem = list1.ElementAt(1);

            do
            {
                var turn1 = new Turn();
                var turn2 = new Turn();

                for (int i = 0; i < list1.Count; i++)
                {
                    turn1.Matches.Add(new Match { Team1 = list1.ElementAt(i), Team2 = list2.ElementAt(i) });
                    turn2.Matches.Add(new Match { Team1 = list2.ElementAt(i), Team2 = list1.ElementAt(i) });
                }

                var newList1 = new List<Team>();
                var newList2 = new List<Team>();
                for (int i = 0; i < list1.Count; i++)
                {
                    if(i == 0)
                    {
                        newList1.Add(list1.ElementAt(i));
                        newList2.Add(list2.ElementAt(i + 1));
                    }
                    else if(i == list1.Count - 1)
                    { 
                        newList1.Add(list2.ElementAt(i - 1));
                        newList2.Add(list1.ElementAt(list1.Count - 1));
                    }
                    else
                    {
                        newList1.Add(list2.ElementAt(i - 1));
                        newList2.Add(list2.ElementAt(i + 1));
                    }
                }

                list1 = Helper.DeepCopyList(newList1).ToList();
                list2 = Helper.DeepCopyList(newList2).ToList();

                var debug1 = string.Join(" - ", list1.Select(x => x.Name).ToList());
                var debug2 = string.Join(" - ", list2.Select(x => x.Name).ToList());

                yield return turn1;
                yield return turn2;

            } while (!IsSameTeam(list1.ElementAt(1), originalSecondItem));
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
