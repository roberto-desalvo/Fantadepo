using RDS.Fantadepo.Business.Helpers;

namespace RDS.Fantadepo.Business.Models
{
    public class Performance
    {
        public Player Player { get; set; } = new();
        public Score Score { get; set; } = new();
    }
}
