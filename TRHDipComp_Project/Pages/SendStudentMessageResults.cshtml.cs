﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TRHDipComp_Project.Pages
{
    public class SendStudentMessageResultsModel : PageModel
    {

        [TempData]
        public string MessageResults { get; set; } 

        public void OnGet()
        {

        }
    }
}