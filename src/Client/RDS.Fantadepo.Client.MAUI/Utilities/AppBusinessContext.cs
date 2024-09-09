using RDS.Fantadepo.Shared.Models;

namespace RDS.Fantadepo.Client.MAUI.Utilities
{
    public static class AppBusinessContext
    {
        public static Season CurrentSeason { get; set; } = new();
    }
}
