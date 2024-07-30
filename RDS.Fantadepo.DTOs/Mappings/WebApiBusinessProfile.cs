using AutoMapper;
using RDS.Fantadepo.DataAccess.Entities;
using RDS.Fantadepo.WebApi.Business.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.Business.Models.Mappings
{
    public class WebApiBusinessProfile : Profile
    {
        public WebApiBusinessProfile()
        {
            // data-access -> business
            CreateMap<CoachDto, Coach>();
            CreateMap<MatchDto, Match>();
            CreateMap<PlayerDto, Player>();
            CreateMap<PlayerPerformanceDto, PlayerPerformance>();
            CreateMap<SeasonDto, Season>();
            CreateMap<PlayerAcquisitionDto, PlayerAcquisition>();
            CreateMap<PlayerReleaseDto, PlayerRelease>();
            CreateMap<TeamDto, Team>();
            CreateMap<TeamPlayerDto, TeamPlayer>();
            CreateMap<FieldedTeamPlayerDto, FieldedTeamPlayer>();
            CreateMap<TurnDto, Turn>();

            // business -> data-access 
            CreateMap<Coach, CoachDto>();
            CreateMap<Match, MatchDto>();
            CreateMap<Player, PlayerDto>();
            CreateMap<PlayerPerformance, PlayerPerformanceDto>();
            CreateMap<Season, SeasonDto>();
            CreateMap<PlayerAcquisition, PlayerAcquisitionDto>();
            CreateMap<PlayerRelease, PlayerReleaseDto>();
            CreateMap<Team, TeamDto>();
            CreateMap<TeamPlayer, TeamPlayerDto>();
            CreateMap<FieldedTeamPlayer, FieldedTeamPlayerDto>();
            CreateMap<Turn, TurnDto>();
        }
    }
}
