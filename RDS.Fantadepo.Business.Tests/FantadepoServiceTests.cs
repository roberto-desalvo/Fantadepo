using FluentAssertions;

namespace RDS.Fantadepo.Business.Tests
{
    public class FantadepoServiceTests
    {
        //private static IEnumerable<Team> GetTeams(int count)
        //{
        //    for (int i = 0; i < count; i++)
        //    {
        //        yield return new Team { Name = $"{i}" };
        //    }
        //}

        //public static IEnumerable<object[]> GetRandomCount()
        //{
        //    var randomCount = new Random().Next(5, 10);

        //    for (int i = 0; i < randomCount; i++)
        //    {
        //        yield return new object[] { new Random().Next(2, 100) };
        //    }
        //}

        //[Theory]
        //[MemberData(nameof(GetRandomCount))]
        //public void GetTurns_WhenCalled_ShouldReturnAllMatches(int count)
        //{
        //    var teams = GetTeams(count).ToList();
        //    var expectedMatchCount = count * (count - 1);

        //    var turns = CalendarService.GetTurns(teams);
            
        //    turns.SelectMany(x => x.Matches).Should().HaveCount(expectedMatchCount);
        //}

        //[Theory]
        //[MemberData(nameof(GetRandomCount))]
        //public void GetTurns_WhenCalled_ShouldReturnAllMatchesWithNoRepetitions(int count)
        //{
        //    var teams = GetTeams(count).ToList();

        //    var turns = CalendarService.GetTurns(teams);

        //    turns.SelectMany(x => x.Matches).Should().OnlyHaveUniqueItems();
        //}

        //[Theory]
        //[MemberData(nameof(GetRandomCount))]
        //public void GetTurns_WhenCalled_AllTeamsShouldPlayRightNumberOfMatches(int count)
        //{
        //    var teams = GetTeams(count).ToList();
        //    var expectedMatchCount = (count - 1) * 2;

        //    var turns = CalendarService.GetTurns(teams);

        //    foreach(var team in teams)
        //    {
        //        var matches = turns.SelectMany(x => x.Matches).Where(x => x.Team1.Name == team.Name || x.Team2.Name == team.Name);
        //        matches.Should().HaveCount(expectedMatchCount);
        //    }
        //}

        //[Theory]
        //[MemberData(nameof(GetRandomCount))]        
        //public void GetTurns_WhenCalled_EveryTurnShouldHaveExpectedMatchesNumber(int count)
        //{
        //    var teams = GetTeams(count).ToList();
        //    var expectedMatchesCount = count % 2 == 0 ? count / 2 : (count - 1) / 2;

        //    var turns = CalendarService.GetTurns(teams);

        //    foreach(var turn in turns)
        //    {
        //        turn.Matches.Should().HaveCount(expectedMatchesCount);
        //    }
        //}

        //[Theory]
        //[MemberData(nameof(GetRandomCount))]
        //public void GetTurns_WhenCalled_ShouldHaveExpectedTurnsNumber(int count)
        //{
        //    var teams = GetTeams(count).ToList();
        //    var expectedTurnCount = count % 2 == 0 ? (count - 1) * 2 : count * 2;

        //    var turns = CalendarService.GetTurns(teams);
                        
        //    turns.Should().HaveCount(expectedTurnCount);
        //}
    }
}