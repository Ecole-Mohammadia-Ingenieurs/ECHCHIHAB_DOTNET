using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Soutenances
{
    public class DeleteModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public DeleteModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Soutenance Soutenance { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Soutenance == null)
            {
                return NotFound();
            }

            var soutenance = await _context.Soutenance.FirstOrDefaultAsync(m => m.SoutenanceID == id);

            if (soutenance == null)
            {
                return NotFound();
            }
            else 
            {
                Soutenance = soutenance;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Soutenance == null)
            {
                return NotFound();
            }
            var soutenance = await _context.Soutenance.FindAsync(id);

            if (soutenance != null)
            {
                Soutenance = soutenance;
                _context.Soutenance.Remove(Soutenance);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
