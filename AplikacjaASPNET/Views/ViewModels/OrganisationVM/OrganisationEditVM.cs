using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaASPNET.Views.ViewModels.OrganisationVM
{
    public class OrganisationEditVM : OrganisationCreateVM
    {
        public string TitlePage { get; set; }
        public int Id { get; set; }
    }
}
