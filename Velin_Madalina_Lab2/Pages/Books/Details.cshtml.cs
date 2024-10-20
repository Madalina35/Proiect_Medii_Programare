using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Velin_Madalina_Lab2.Data;
using Velin_Madalina_Lab2.Models;

namespace Velin_Madalina_Lab2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly Velin_Madalina_Lab2.Data.Velin_Madalina_Lab2Context _context;

        public DetailsModel(Velin_Madalina_Lab2.Data.Velin_Madalina_Lab2Context context)
        {
            _context = context;
        }

        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FirstOrDefaultAsync(m => m.ID == id);
            
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
                ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            }
            return Page();
        }
    }
}
