﻿using LXxUS.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LXxUS.Models.ViewModel
{
    public class AccountVM
    {
        public ApplicationUser User { get; set; }
        public List<string> Roles { get; set; }
    }
}