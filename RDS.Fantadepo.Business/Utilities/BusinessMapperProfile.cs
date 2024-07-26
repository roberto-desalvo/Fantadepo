using AutoMapper;
using RDS.Fantadepo.Business.Models;
using Entities = RDS.Fantadepo.DataAccess.Entities;

namespace RDS.Fantadepo.Business.Utilities
{
    public class BusinessMapperProfile : Profile
    {
        public BusinessMapperProfile()
        {
            // data-access -> business
            CreateMap<Entities.Coach, Coach>();
            CreateMap<Entities.Match, Match>();
            CreateMap<Entities.Player, Player>();
            CreateMap<Entities.PlayerPerformance, PlayerPerformance>();
            CreateMap<Entities.Season, Season>();
            CreateMap<Entities.PlayerAcquisition, PlayerAcquisition>();
            CreateMap<Entities.PlayerRelease, PlayerRelease>();
            CreateMap<Entities.Team, Team>();
            CreateMap<Entities.TeamPlayer, TeamPlayer>();
            CreateMap<Entities.FieldedTeamPlayer, FieldedTeamPlayer>();
            CreateMap<Entities.Turn, Turn>();

            // business -> data-access 
            CreateMap<Coach, Entities.Coach>();
            CreateMap<Match, Entities.Match>();
            CreateMap<Player, Entities.Player>();
            CreateMap<PlayerPerformance, Entities.PlayerPerformance>();
            CreateMap<Season, Entities.Season>();
            CreateMap<PlayerAcquisition, Entities.PlayerAcquisition>();
            CreateMap<PlayerRelease, Entities.PlayerRelease>();
            CreateMap<Team, Entities.Team>();
            CreateMap<TeamPlayer, Entities.TeamPlayer>();
            CreateMap<FieldedTeamPlayer, Entities.FieldedTeamPlayer>();
            CreateMap<Turn, Entities.Turn>();
        }
    }
}
