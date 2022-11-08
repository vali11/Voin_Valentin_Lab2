﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Voin_Valentin_Lab2.Data;
using Voin_Valentin_Lab2.Models;

namespace Voin_Valentin_Lab2.Pages.Members
{
    public class CreateModel : PageModel
    {
        private readonly Voin_Valentin_Lab2.Data.Voin_Valentin_Lab2Context _context;

        public CreateModel(Voin_Valentin_Lab2.Data.Voin_Valentin_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Member Member { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Member.Add(Member);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
