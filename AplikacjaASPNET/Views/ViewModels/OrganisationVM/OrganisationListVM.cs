using AplikacjaASPNET.Models.OrganisationItems;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaASPNET.Views.ViewModels.OrganisationVM
{
    public class OrganisationListVM : Organisation
    {
        public string OrganisationCategory { get; set; }
        public string searchString { get; set; }
        public SelectList Categories { get; set; }
        public List<Organisation> Organisations { get; set; }
    }
}
