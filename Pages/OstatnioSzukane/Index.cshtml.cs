#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EFDemo.Data;
using EFDemo.Models;

namespace EFDemo.Pages.OstatnioSzukane
{
    public class IndexModel : PageModel
    {
        private readonly EFDemo.Data.PeopleContext _context;

        public IndexModel(EFDemo.Data.PeopleContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; }

        public async Task OnGetAsync()
        {
            Person = await _context.Person.OrderByDescending(p => p.Data).Take(20).ToListAsync();
            
        }
    }
}
