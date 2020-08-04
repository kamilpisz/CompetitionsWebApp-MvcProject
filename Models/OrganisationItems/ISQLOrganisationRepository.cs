using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaASPNET.Models.OrganisationItems
{
    public interface ISQLOrganisationRepository
    {
        Organisation GetById(int id);
        IEnumerable<Organisation> GetAllOrganisation();
        Organisation Edit(Organisation EditOrganisation);
        Organisation Delete(int id);
        Organisation Create(Organisation nowyOrganisation);
        IQueryable<string> GetAllCategories();

    }
}
