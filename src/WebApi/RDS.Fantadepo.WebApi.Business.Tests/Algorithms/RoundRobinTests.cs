using FluentAssertions;
using RDS.Fantadepo.WebApi.Business.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.Business.Tests.Algorithms
{
    public class RoundRobinTests
    {
        public class Item : ICloneable
        {
            public int Id { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            public override bool Equals(object? obj)
            {
                if (obj is Item item)
                {
                    return item?.Id == this?.Id;
                }
                return false;
            }
        }

        private Item GetItem(int id)
        {
            return new Item { Id = id };
        }

        private IEnumerable<Item> GetItems(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return GetItem(i);
            }
        }

        public static IEnumerable<object[]> GetRandomCount()
        {
            //var randomCount = new Random().Next(5, 10);

            //for (int i = 0; i < randomCount; i++)
            //{
            //    yield return new object[] { new Random().Next(2, 100) };
            //}
            yield return new object[] { 8 };
        }

        [Theory]
        [MemberData(nameof(GetRandomCount))]
        public void SimpleRoundRobin_WhenCalled_TotalItemsShouldHaveExpectedCount(int count)
        {
            var items = GetItems(count).ToList();
            var expectedCount = (count * (count - 1)) / 2;

            var result = RoundRobin<Item>.Instance.SimpleRoundRobin(items);

            result.SelectMany(x => x).Count().Should().Be(expectedCount);
        }

        [Theory]
        [MemberData(nameof(GetRandomCount))]
        public void SimpleRoundRobin_WhenCalled_ShouldContainNoRepetitions(int count)
        {
            var items = GetItems(count).ToList();

            var result = RoundRobin<Item>.Instance.SimpleRoundRobin(items);

            result.SelectMany(x => x).Should().OnlyHaveUniqueItems();
        }

        [Theory]
        [MemberData(nameof(GetRandomCount))]
        public void SimpleRoundRobin_WhenCalled_EachItemShouldAppearRightTimes(int count)
        {
            var items = GetItems(count).ToList();
            var expectedCount = (count - 1) * 2;

            var result = RoundRobin<Item>.Instance.SimpleRoundRobin(items);

            foreach (var item in items)
            {
                var actualCount = result.SelectMany(x => x).Where(x =>
                x.Item1.Equals(item) || x.Item2.Equals(item))
                    .Count();
                actualCount.Should().Be(expectedCount);
            }
        }

        [Theory]
        [MemberData(nameof(GetRandomCount))]
        public void SimpleRoundRobin_WhenCalled_EachInnerListShouldHaveExpectedCount(int count)
        {
            var items = GetItems(count).ToList();
            var expectedItemsCountInInnerList = count % 2 == 0 ? count / 2 : (count - 1) / 2;

            var result = RoundRobin<Item>.Instance.SimpleRoundRobin(items);

            foreach (var list in result)
            {
                list.Should().HaveCount(expectedItemsCountInInnerList);
            }
        }

        [Theory]
        [MemberData(nameof(GetRandomCount))]
        public void SimpleRoundRobin_WhenCalled_ShouldHaveExpectedInnerListNumber(int count)
        {
            var items = GetItems(count).ToList();
            var expectedInnerListCount = count % 2 == 0 ? (count - 1) : count;

            var result = RoundRobin<Item>.Instance.SimpleRoundRobin(items);

            result.Should().HaveCount(expectedInnerListCount);
        }

    }
}
