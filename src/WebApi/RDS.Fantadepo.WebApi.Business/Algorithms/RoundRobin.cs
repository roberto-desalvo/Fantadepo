using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.Business.Algorithms
{
    public class RoundRobin<T>
        where T : ICloneable
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
                    if (element.IsFakeItem == this.IsFakeItem && this.IsFakeItem)
                    {
                        return true;
                    }

                    if(this.Item == null && element.Item == null) 
                    {
                        return true;
                    }

                    return element.Item.Equals(this.Item);
                }
                return false;
            }
        }

        public static RoundRobin<T> Instance => new();

        public List<List<(Element, Element)>> DoubleRoundRobin(List<T> items)
        {
            var list = SimpleRoundRobin(items);

            foreach (var innerList in list)
            {
                var currentList = new List<(Element, Element)>();
                foreach (var couple in innerList)
                {
                    var reversed = (couple.Item2, couple.Item1);
                    currentList.Add(reversed);
                }
                list.Add(currentList);
            }

            return list;
        }

        public List<List<(Element, Element)>> SimpleRoundRobin(List<T> items)
        {
            var list = items.Select(item => new Element { Item = item }).ToList();

            if (items.Count % 2 != 0)
            {
                var fakeElement = new Element { IsFakeItem = true };
                list.Add(fakeElement);
            }

            var result = SimpleRoundRobin(list);
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
