using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Competitions.Infrastructure.Organisation.Repos;
using Competitions.Application.Organisation.Repos;
using Microsoft.Extensions.DependencyInjection;
using Competitions.Application.Participant.Repos;
using Competitions.Application.Competition.Repos;
using Competitions.Infrastructure.Competition.Repos;

namespace AplikacjaASPNET.UpConfig.DI
{
    public static class RepositoryInjection
    {
        public static void InjectRepository(this IServiceCollection services)
        {
            services.AddScoped<IOrganisationRepo, OrganisationRepo>();
            services.AddScoped<IParticipantRepo, ParticipantRepo>();
            services.AddScoped<ICompetitionRepo, CompetitionRepo>();


        }



    }
}
