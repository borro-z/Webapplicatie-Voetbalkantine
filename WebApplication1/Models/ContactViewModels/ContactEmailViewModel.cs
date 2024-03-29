﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.ContactViewModels
{
    public class ContactEmailViewModel
    {
        [Required]
        public  string Naam { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Onderwerp { get; set; }

        [Required]
        public string Bericht { get; set; }
    }
}
