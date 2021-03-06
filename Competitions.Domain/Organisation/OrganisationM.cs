﻿using Competitions.Domain._Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Competitions.Domain.Organisation
{
    public class OrganisationM : EntityBaseM
    {
        public int OrganisationId { get; set; }
        
        public string Name { get; set; }
        public string Category { get; set; }
        public string Address { get; set; }
        
        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }
        public string Description { get; set; }


    }
}
