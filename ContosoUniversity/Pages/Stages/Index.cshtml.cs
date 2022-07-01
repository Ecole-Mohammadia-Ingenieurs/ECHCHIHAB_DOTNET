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
    public class IndexModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public IndexModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Stage> Stage { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Stage != null)
            {
                Stage = await _context.Stage
                .Include(s => s.Instructor)
                .Include(s => s.Student).ToListAsync();
            }
        }
    }
}
