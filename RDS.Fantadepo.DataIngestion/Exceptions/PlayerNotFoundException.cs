using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.DataIngestion.Exceptions
{
    public class PlayerNotFoundException : Exception
    {

        public PlayerNotFoundException() : base("The player was not found")
        {
            
        }
        public PlayerNotFoundException(string message) : base(message)
        {
        }
    }
}
