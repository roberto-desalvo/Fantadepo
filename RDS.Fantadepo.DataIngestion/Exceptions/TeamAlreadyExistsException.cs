using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.DataIngestion.Exceptions
{
    public class TeamAlreadyExistsException : Exception
    {
        public TeamAlreadyExistsException() : base("Team cannot be tracked because another team with the same name already exists")
        {
            
        }

        public TeamAlreadyExistsException(string message) : base(message)
        {
            
        }
    }
}
