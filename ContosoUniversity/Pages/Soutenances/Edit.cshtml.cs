using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Soutenances
{
    public class EditModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public EditModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Soutenance Soutenance { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Soutenance == null)
            {
                return NotFound();
            }

            var soutenance =  await _context.Soutenance.FirstOrDefaultAsync(m => m.SoutenanceID == id);
            if (soutenance == null)
            {
                return NotFound();
            }
            Soutenance = soutenance;
           ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FirstMidName");
           ViewData["StageID"] = new SelectList(_context.Stages, "StageID", "StageID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Soutenance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoutenanceExists(Soutenance.SoutenanceID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SoutenanceExists(int id)
        {
          return _context.Soutenance.Any(e => e.SoutenanceID == id);
        }
    }
}
