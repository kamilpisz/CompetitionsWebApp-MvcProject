using Competitions.Application.Competition.Repos;
using Competitions.Domain.Competition;
using Competitions.Infrastructure._Persistence;
using Competitions.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Competitions.Infrastructure.Competition.Repos
{
    public class CompetitionRepo : RepositoryTemplate<CompetitionM>, ICompetitionRepo
    {
        public CompetitionRepo(AppDbContext db) : base(db)
        {

        }
    }
}
