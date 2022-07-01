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
    public class IndexModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public IndexModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Soutenance> Soutenance { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Soutenance != null)
            {
                Soutenance = await _context.Soutenance
                .Include(s => s.Turor)
                .Include(s => s.stage).ToListAsync();
            }
        }
    }
}
