
using Competitions.Domain.Participant;
using Competitions.Infrastructure._Persistence;
using Competitions.Infrastructure.Base;
using Competitions.Application.Participant.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Competitions.Infrastructure.Participant.Repos
{
    public class ParticipantRepo : RepositoryTemplate<ParticipantM>, IParticipantRepo
    {
        public ParticipantRepo(AppDbContext db) : base(db)
        {

        }
    }
}


