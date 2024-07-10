using FluentAssertions;
using RDS.Fantadepo.Business.Models;
using RDS.Fantadepo.Business.Services;

namespace RDS.Fantadepo.Business.Tests
{
    public class FantadepoServiceTests
    {
        private static IEnumerable<Team> GetTeams(int count)
        {
            for(int i = 0; i < count; i++)
            {
                yield return new Team { Name = $"{i}" };
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(25)]
        [InlineData(53)]
        public void GetMatches_WhenCalled_ShouldReturnAllCombinations(int count)
        {
            var teams = GetTeams(count);

            var result = FantadepoService.GetAllMatches(teams);

            // simple combinations: n(n - 1) / 2
            var expectedCount = (count * (count - 1)) / 2;

            result.Should().HaveCount(expectedCount);

            foreach(var team in teams)
            {
                result.Where(x => x.Team1.Name == team.Name || x.Team2.Name == team.Name).Should().HaveCount(count - 1);
            }
        }

        [Theory]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(25)]
        [InlineData(53)]
        public void GetTurns_WhenCalled_ShouldReturnAllCombinations(int count)
        {
            var teams = GetTeams(count).ToList();

            var result = FantadepoService.GetTurns(teams);

            // simple combinations: n(n - 1) / 2
            var expectedCount = (count * (count - 1)) / 2;

            result.Should().HaveCount(count % 2 == 0 ? count : count - 1);
            result.Sum(x => x.Matches.Count()).Should().Be(expectedCount);

            foreach(var turn in result)
            {
                turn.Matches.Should().HaveCount(count % 2 == 0 ? count / 2 : (count - 1) / 2);                             
            }
        }
    }
}