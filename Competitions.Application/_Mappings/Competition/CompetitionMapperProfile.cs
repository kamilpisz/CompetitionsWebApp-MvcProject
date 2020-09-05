using AutoMapper;
using Competitions.Domain.Competition;
using System;
using System.Collections.Generic;
using System.Text;

namespace Competitions.Application._Mappings.Competition
{
    public class CompetitionMapperProfile : Profile
    {
        public CompetitionMapperProfile()
        {

        
        CreateMap<CompetitionM, CompetitionCreateVM>();
        CreateMap<CompetitionM, CompetitionEditVM>();
        CreateMap<CompetitionM, CompetitionListVM>();
        }
    }
}
