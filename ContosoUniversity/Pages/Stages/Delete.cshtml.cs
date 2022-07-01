using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Stages
{
    public class DeleteModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public DeleteModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Stage Stage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Stage == null)
            {
                return NotFound();
            }

            var stage = await _context.Stage.FirstOrDefaultAsync(m => m.StageID == id);

            if (stage == null)
            {
                return NotFound();
            }
            else 
            {
                Stage = stage;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Stage == null)
            {
                return NotFound();
            }
            var stage = await _context.Stage.FindAsync(id);

            if (stage != null)
            {
                Stage = stage;
                _context.Stage.Remove(Stage);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
