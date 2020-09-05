using AutoMapper;
using Competitions.Domain.Organisation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Competitions.Application.Organisation.DTO
{
    public class OrganisationDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Category { get; set; }
        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrganisationM, OrganisationDTO>().ReverseMap();
        }
    }

}
