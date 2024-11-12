using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Velin_Madalina_Lab2.Data;
using Velin_Madalina_Lab2.Models;

namespace Velin_Madalina_Lab2.Pages.Members
{
    public class DetailsModel : PageModel
    {
        private readonly Velin_Madalina_Lab2.Data.Velin_Madalina_Lab2Context _context;

        public DetailsModel(Velin_Madalina_Lab2.Data.Velin_Madalina_Lab2Context context)
        {
            _context = context;
        }

        public Member Member { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FirstOrDefaultAsync(m => m.ID == id);
            if (member == null)
            {
                return NotFound();
            }
            else
            {
                Member = member;
            }
            return Page();
        }
    }
}
