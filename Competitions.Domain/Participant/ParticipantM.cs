using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Competitions.Domain._Common;

namespace Competitions.Domain.Participant
{
    public class ParticipantM : EntityBaseM
    {
        
        public string FirstName { get; set; }
      
        public string LastName { get; set; }
       
        public string ClassCode { get; set; }
        
        public string Email { get; set; }

        //public virtual ICollection<CompetitionParticipations> CompetitionParticipations { get; set; }





        public ParticipantM()
        {

        }


    }
}
