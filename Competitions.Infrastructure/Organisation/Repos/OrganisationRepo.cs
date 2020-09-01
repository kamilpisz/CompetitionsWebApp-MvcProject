
using Competitions.Application.Organisation.Repos;
using Competitions.Domain.Organisation;
using Competitions.Infrastructure._Persistence;
using Competitions.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Competitions.Infrastructure.Organisation.Repos
{
    public class OrganisationRepo : RepositoryTemplate<OrganisationM>, IOrganisationRepo
    {
        public OrganisationRepo(AppDbContext db) : base(db)
        {

        }
    }
}