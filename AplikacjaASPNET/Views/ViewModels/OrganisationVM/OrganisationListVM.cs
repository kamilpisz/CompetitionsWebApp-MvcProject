using Competitions.Domain.Organisation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AplikacjaASPNET.Views.ViewModels.OrganisationVM
{
    public class OrganisationListVM 
    {
        public string OrganisationCategory { get; set; }
        public string searchString { get; set; }
        public SelectList Categories { get; set; }
        public List<OrganisationM> Organisations { get; set; }
    }
}
