using AutoMapper;
using Competitions.Domain.Organisation;
using System;
using System.Collections.Generic;
using System.Text;
using AplikacjaASPNET.Views.ViewModels.OrganisationVM;

namespace Competitions.Application._Mappings.Organisation
{
    public class OrganisationMapperProfile : Profile
    {
        public OrganisationMapperProfile()
        {


            CreateMap<OrganisationM, OrganisationCreateVM>();
            CreateMap<OrganisationM, OrganisationEditVM>();
            CreateMap<OrganisationM, OrganisationListVM>();
        }
    }
}
