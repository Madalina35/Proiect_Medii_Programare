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

namespace Velin_Madalina_Lab2.Pages.Borrowings
{
    public class EditModel : PageModel
    {
        private readonly Velin_Madalina_Lab2.Data.Velin_Madalina_Lab2Context _context;

        public EditModel(Velin_Madalina_Lab2.Data.Velin_Madalina_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookList = _context.Book
                 .Include(b => b.Author)
                 .Select(x => new
                 {
                     x.ID,
                     BookFullName = x.Title + " - " + x.Author.LastName + " " + x.Author.FirstName
                 });

            var borrowing =  await _context.Borrowing
                .Include(b => b.Member)
                .Include(b=> b.Book)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (borrowing == null)
            {
                return NotFound();
            }

            Borrowing = borrowing;
            ViewData["BookID"] = new SelectList(bookList, "ID", "BookFullName");
            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowingToUpdate = await _context.Borrowing
                .Include(b => b.Member)
                .Include(b=> b.Book)
                .FirstOrDefaultAsync(bo => bo.ID == id);

            if (borrowingToUpdate == null)
            {
                return NotFound();
            }

            if(await TryUpdateModelAsync<Borrowing>(
                borrowingToUpdate,
                "Borrowing",
                i => i.MemberID, i => i.BookID, i => i.ReturnDate))
            {
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }

        private bool BorrowingExists(int id)
        {
            return _context.Borrowing.Any(e => e.ID == id);
        }
    }
}
