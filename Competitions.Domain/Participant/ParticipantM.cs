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
        [Required]
        public string LastName { get; set; }
        [Required]
        public string ClassCode { get; set; }
        [Required]
        public string Email { get; set; }

        //public virtual ICollection<CompetitionParticipations> CompetitionParticipations { get; set; }





        public ParticipantM()
        {

        }


    }
}
