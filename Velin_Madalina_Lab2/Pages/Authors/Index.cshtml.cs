using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Velin_Madalina_Lab2.Data;
using Velin_Madalina_Lab2.Models;

namespace Velin_Madalina_Lab2.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly Velin_Madalina_Lab2.Data.Velin_Madalina_Lab2Context _context;

        public IndexModel(Velin_Madalina_Lab2.Data.Velin_Madalina_Lab2Context context)
        {
            _context = context;
        }

        public IList<Author> Author { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Author = await _context.Author.ToListAsync();
        }
    }
}
