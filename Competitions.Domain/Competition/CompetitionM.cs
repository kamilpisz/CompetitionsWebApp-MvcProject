using System;
using System.Collections.Generic;
using System.Text;
using Competitions.Domain._Common;
using Competitions.Domain.Competition.Enums;

namespace Competitions.Domain.Competition
{
    public class CompetitionM : EntityBaseM
    {
       
            public int Id { get; set; }
            public string Name { get; set; }
            public CompetitionCategoryE Category { get; set; }
            public string Adres { get; set; }
            public string Organiser { get; set; }

            //public virtual ICollection<CompetitionParticipations> CompetitionParticipations { get; set; }


            public CompetitionM()
            {

            }

        
    }
}
