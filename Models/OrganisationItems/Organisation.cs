using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaASPNET.Models.OrganisationItems
{
    public class Organisation
    {
        public int OrganisationId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Category { get; set; }
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
     

    }
}
