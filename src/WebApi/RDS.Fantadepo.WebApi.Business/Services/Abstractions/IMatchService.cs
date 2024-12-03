using RDS.Fantadepo.WebApi.DataAccess.Entities;

namespace RDS.Fantadepo.WebApi.Business.Services.Abstractions
{
    public interface IMatchService
    {
        Task<Match?> CalculateMatch(int id);
    }
}