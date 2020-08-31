using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Competitions.Domain.Competition.Enums
{
    public enum CompetitionCategoryE : short
    {
        [Display(Name = "Brak danych")]
        None = 0,
        [Display(Name = "Fizyka")]
        Psychics = 1,
        [Display(Name = "Matematyka")]
        Math = 2,
        [Display(Name = "Chemia")]
        Chemistry = 3,
        [Display(Name = "Biologia")]
        Biology = 4,
        [Display(Name = "J.angielski")]
        English = 5,
        [Display(Name = "Technologie")]
        Technology = 6,


    }
}
