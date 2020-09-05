using Competitions.Domain.Organisation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Competitions.Application._Mappings;

namespace AplikacjaASPNET.Views.ViewModels.OrganisationVM
{
    public class OrganisationCreateVM :IMapFrom<OrganisationM>
    {

        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Kategoria")]
        public string Category { get; set; }
        [Display(Name = "Adres")]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Numer Telefonu")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }

    }
}
