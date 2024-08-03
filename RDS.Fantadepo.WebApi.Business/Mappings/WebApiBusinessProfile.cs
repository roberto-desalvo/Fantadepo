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
            CreateMap<Coach, BusinessModels.Coach>()
                .ForPath(dest => dest.Team, opt => opt.MapFrom(src => src.Team));

            CreateMap<Team, BusinessModels.Team>()
                .ForPath(dest => dest.Coach, opt => opt.MapFrom(src => src.Coach))
                .ForPath(dest => dest.Season, opt => opt.MapFrom(src => src.Season))
                .ForPath(dest => dest.AwayMatches, opt => opt.MapFrom(src => src.AwayMatches))
                .ForPath(dest => dest.HomeMatches, opt => opt.MapFrom(src => src.HomeMatches));

            CreateMap<Match, BusinessModels.Match>();
            CreateMap<Player, BusinessModels.Player>();
            CreateMap<PlayerPerformance, BusinessModels.PlayerPerformance>();
            CreateMap<Season, BusinessModels.Season>();
            CreateMap<PlayerAcquisition, BusinessModels.PlayerAcquisition>();
            CreateMap<PlayerRelease, BusinessModels.PlayerRelease>();
            
            CreateMap<TeamPlayer, BusinessModels.TeamPlayer>();
            CreateMap<FieldedTeamPlayer, BusinessModels.FieldedTeamPlayer>();
            CreateMap<Turn, BusinessModels.Turn>();

            // business -> data-access 
            CreateMap<BusinessModels.Coach, Coach>()
                .ForPath(dest => dest.Team, opt => opt.MapFrom(src => src.Team));

            CreateMap<BusinessModels.Team, Team>()
               .ForPath(dest => dest.Coach, opt => opt.MapFrom(src => src.Coach))
               .ForPath(dest => dest.Season, opt => opt.MapFrom(src => src.Season))
               .ForPath(dest => dest.AwayMatches, opt => opt.MapFrom(src => src.AwayMatches))
               .ForPath(dest => dest.HomeMatches, opt => opt.MapFrom(src => src.HomeMatches));

            CreateMap<BusinessModels.Match, Match>();
            CreateMap<BusinessModels.Player, Player>();
            CreateMap<BusinessModels.PlayerPerformance, PlayerPerformance>();
            CreateMap<BusinessModels.Season, Season>();
            CreateMap<BusinessModels.PlayerAcquisition, PlayerAcquisition>();
            CreateMap<BusinessModels.PlayerRelease, PlayerRelease>();
           
            CreateMap<BusinessModels.TeamPlayer, TeamPlayer>();
            CreateMap<BusinessModels.FieldedTeamPlayer, FieldedTeamPlayer>();
            CreateMap<BusinessModels.Turn, Turn>();
        }
    }
}
