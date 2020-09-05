using AutoMapper;
using Competitions.Domain.Competition;
using Competitions.Domain.Competition.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Competitions.Application.Competition
{
    public class CompetitionDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public CompetitionCategoryE Category { get; set; }
        public string Adres { get; set; }
        public string Organiser { get; set; }

        //public virtual ICollection<CompetitionParticipations> CompetitionParticipations { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CompetitionM, CompetitionDTO>().ReverseMap();
        }
    }
}
