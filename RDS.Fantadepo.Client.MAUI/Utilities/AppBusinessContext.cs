using RDS.Fantadepo.Models.Models;

namespace RDA.Fantadepo.Client.MAUI
{
    public static class AppBusinessContext
    {
        public static Season CurrentSeason { get; set; } = new();
    }
}
