﻿using AplikacjaASPNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaASPNET.Views.ViewModels
{
    public class CompetitionEditViewModel : CompetitionCreateViewModel
    {
        public int Id { get; set; }
        public string TitlePage { get; set; }
    }
}
