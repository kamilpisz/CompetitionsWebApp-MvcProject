
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Competitions.Domain.Participant;
using Competitions.Domain.Competition;
using Competitions.Domain.Organisation;


namespace Competitions.Infrastructure._Persistence
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        
        protected AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Participant> ParticipantDB { get; set; }
        public DbSet<Competition> CompetitionDB { get; set; }
        public DbSet<CompetitionParticipants> CompetitionParticipantsDB { get; set; }
        public DbSet<Organisation> OrganisationDB { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            throw new Exception("This method must be overriden as we have database typenames which need to be defined");
        }

    }

    public class dbSQLServer : AppDbContext
    {

        public dbSQLServer(DbContextOptions<dbSQLServer> options) : base(options)
        {
            

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<CompetitionParticipants>()
                            .HasKey(sc => new { sc.ParticipantId, sc.CompetitionId });


        }

    }

    public class AppDbContextPostGresSQL : AppDbContext
    {
        /// <summary>
        /// Options will be of this specific type and we pass this to the protected not typed base class constructor
        /// </summary>
        
        public AppDbContextPostGresSQL(DbContextOptions<AppDbContextPostGresSQL> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
