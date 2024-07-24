using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Business.Helpers
{
    public class BusinessHelper
    {
        public static IList<T> DeepCopyList<T>(IList<T> list)
            where T : ICloneable
        {
            var clones = new List<T>();
            foreach(var item in list)
            {
                clones.Add((T)item.Clone());
            }

            return clones;
        }        
    }
}
