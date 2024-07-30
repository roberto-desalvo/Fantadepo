using AutoMapper;
using RDS.Fantadepo.WebApi.DataAccess.Entities;
using BusinessModels = RDS.Fantadepo.Models.Models;

namespace RDS.Fantadepo.WebApi.Business.Mappings
{
    public class WebApiBusinessProfile : Profile
    {
        public WebApiBusinessProfile()
        {
            // data-access -> business
            CreateMap<Coach, BusinessModels.Coach>();
            CreateMap<Match, BusinessModels.Match>();
            CreateMap<Player, BusinessModels.Player>();
            CreateMap<PlayerPerformance, BusinessModels.PlayerPerformance>();
            CreateMap<Season, BusinessModels.Season>();
            CreateMap<PlayerAcquisition, BusinessModels.PlayerAcquisition>();
            CreateMap<PlayerRelease, BusinessModels.PlayerRelease>();
            CreateMap<Team, BusinessModels.Team>();
            CreateMap<TeamPlayer, BusinessModels.TeamPlayer>();
            CreateMap<FieldedTeamPlayer, BusinessModels.FieldedTeamPlayer>();
            CreateMap<Turn, BusinessModels.Turn>();

            // business -> data-access 
            CreateMap<BusinessModels.Coach, Coach>();
            CreateMap<BusinessModels.Match, Match>();
            CreateMap<BusinessModels.Player, Player>();
            CreateMap<BusinessModels.PlayerPerformance, PlayerPerformance>();
            CreateMap<BusinessModels.Season, Season>();
            CreateMap<BusinessModels.PlayerAcquisition, PlayerAcquisition>();
            CreateMap<BusinessModels.PlayerRelease, PlayerRelease>();
            CreateMap<BusinessModels.Team, Team>();
            CreateMap<BusinessModels.TeamPlayer, TeamPlayer>();
            CreateMap<BusinessModels.FieldedTeamPlayer, FieldedTeamPlayer>();
            CreateMap<BusinessModels.Turn, Turn>();
        }
    }
}
