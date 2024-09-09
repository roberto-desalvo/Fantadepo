using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.Shared.SearchCriteria.Abstractions
{
    public interface ISearchCriteria
    {
        Dictionary<string, string> GetParameters();
    }
}
