using AutoMapper;
using Competitions.Application._Mappings;
using Competitions.Domain.Participant;
using System;
using System.Collections.Generic;
using System.Text;

namespace Competitions.Application.Participant.DTO
{
    public class ParticipantDTO : IMapFrom<ParticipantM>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ClassCode { get; set; }

        public string Email { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<ParticipantM, ParticipantDTO>().ReverseMap();
        }


    }



}
