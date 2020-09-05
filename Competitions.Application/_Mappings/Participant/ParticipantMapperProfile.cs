using AutoMapper;
using Competitions.Domain.Participant;
using System;
using System.Collections.Generic;
using System.Text;

namespace Competitions.Application._Mappings.Participant
{
    public class ParticipantMapperProfile : Profile
    {
        public ParticipantMapperProfile()
        {

        
        CreateMap<ParticipantM, ParticipantCreateVM>();
            CreateMap<ParticipantM, ParticipantEditVM>();
            CreateMap<ParticipantM, ParticipantListVM>();
        }
    }
}
