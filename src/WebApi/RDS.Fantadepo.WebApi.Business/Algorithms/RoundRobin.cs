using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.Business.Algorithms
{
    public class RoundRobin<T>
    {
        public class Element
        {
            public T Item { get; set; }
            public bool IsFakeItem { get; set; }

            public override bool Equals(object? obj)
            {
                if (obj == null)
                {
                    return false;
                }
                if (obj is Element element)
                {
                    if (element.IsFakeItem)
                    {
                        return this.IsFakeItem;
                    }

                    if (this.IsFakeItem)
                    {
                        return element.IsFakeItem;
                    }

                    return element.Item.Equals(this.Item);
                }
                return false;
            }
        }

        public static RoundRobin<T> Instance => new();

        public List<List<(Element, Element)>> DoubleRoundRobin(List<T> items)
        {
            var final = new List<List<(Element, Element)>>();
            var list = SimpleRoundRobin(items);
            final.AddRange(list);

            foreach (var innerList in list)
            {
                var currentList = new List<(Element, Element)>();
                foreach (var couple in innerList)
                {
                    var reversed = (couple.Item2, couple.Item1);
                    currentList.Add(reversed);
                }
                final.Add(currentList);
            }

            return final;
        }

        public List<List<(Element, Element)>> SimpleRoundRobin(List<T> items)
        {
            var list = items.Select(item => new Element { Item = item }).ToList();

            if (list.Count == 0 || list.Count == 1)
            {
                return [];
            }
            if (list.Count == 2)
            {
                return [[(list[0], list[1])]];
            }

            var odd = items.Count % 2 != 0;
            if (odd)
            {
                var fakeElement = new Element { IsFakeItem = true };
                list.Add(fakeElement);
            }

            var result = SimpleRoundRobin(list);

            if (odd)
            {
                result = RemoveFakeItems(result);
            }

            return result;
        }

        private List<List<(Element, Element)>> RemoveFakeItems(List<List<(Element, Element)>> list)
        {
            var result = new List<List<(Element, Element)>>();
            foreach (var innerList in list)
            {
                var currentList = new List<(Element, Element)>();
                foreach (var couple in innerList)
                {
                    if (couple.Item1.IsFakeItem || couple.Item2.IsFakeItem)
                    {
                        continue;
                    }
                    currentList.Add(couple);
                }
                result.Add(currentList);
            }
            return result;
        }

        private List<List<(Element, Element)>> SimpleRoundRobin(List<Element> items)
        {
            var original = items[^1];
            var list = new List<List<(Element, Element)>>();

            do
            {
                var currentList = new List<(Element, Element)>();
                for (var i = 0; i < (items.Count / 2); i++)
                {
                    currentList.Add((items[i], items[items.Count - i - 1]));
                }
                list.Add(currentList);
            }
            while (Rotate(items, original));

            return list;
        }

        private bool Rotate(List<Element> items, Element original)
        {
            if (items[^2].Equals(original))
            {
                return false;
            }

            for (var i = 1; i < items.Count - 1; i++)
            {
                Swap(items, i, items.Count - 1);
            }

            return true;
        }

        private void Swap(List<Element> list, int pos1, int pos2)
        {
            var temp = list[pos1];
            list[pos1] = list[pos2];
            list[pos2] = temp;
        }
    }
}
