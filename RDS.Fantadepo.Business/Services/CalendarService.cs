using RDS.Fantadepo.Business.Helpers;
using RDS.Fantadepo.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Services
{
    public static class CalendarService
    {
        public static IEnumerable<Turn> GetTurns(IList<Team> teams)
        {
            var list = Helper.DeepCopyList(teams).ToList();
            var turns = new List<Turn>();

            switch (list.Count)
            {
                case 1:
                    return [];

                case 2:
                    return
                [
                    new() { Matches = [ new() { Team1 = list.First(), Team2 = list.Last() }]},
                    new() { Matches = [ new() { Team2 = list.First(), Team1 = list.Last() }]},
                ];

                default:
                    if (list.Count % 2 != 0)
                    {
                        var fakeTeam = new Team { Name = "Fake" };
                        list.Add(fakeTeam);
                        var temp = DoubleRoundRobinEven(list);
                        foreach (var turn in temp)
                        {
                            if (turn.Matches.Any(m => IsSameTeam(m.Team1, fakeTeam) || IsSameTeam(m.Team2, fakeTeam)))
                            {
                                turn.Matches.Remove(turn.Matches.First(m => IsSameTeam(m.Team1, fakeTeam) || IsSameTeam(m.Team2, fakeTeam)));
                                turns.Add(turn);
                            }
                        }
                    }
                    else
                    {
                        turns = DoubleRoundRobinEven(list).ToList();
                    }
                    break;

            }

            return turns;
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
                    if (i == list1.Count - 1)
                    {
                        newList2.Add(list1.ElementAt(list1.Count - 1));
                    }
                    else
                    {
                        newList2.Add(list2.ElementAt(i + 1));
                    }

                    if (i == 0)
                    {
                        newList1.Add(list1.ElementAt(i));
                    }
                    else if (i == 1)
                    {
                        newList1.Add(list2.ElementAt(i - 1));
                    }
                    else
                    {
                        newList1.Add(list1.ElementAt(i - 1));
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

        private static bool IsSameTeam(Team team1, Team team2)
        {
            return team1.Name == team2.Name;
        }
    }
}
