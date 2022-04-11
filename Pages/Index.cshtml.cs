using EFDemo.Data;
using EFDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace EFDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PeopleContext _context;
        public IList<Person> People { get; set; }
        public IndexModel(ILogger<IndexModel> logger, PeopleContext context)
        {
            _logger = logger;
            _context = context;
        }


        public void OnGet()
        {

        }
        [BindProperty]
        public Person Person { get; set; }
        public IActionResult OnPost()
        {
            //People = _context.Person.ToList();
            if (!ModelState.IsValid)
            {
                return Page();
            }
                    
            Person.SprawdzPrzestepnosc();
            TempData["AlertMessage"] = Person.FirstName +" " + Person.LastName + " urodzil/a sie w " + Person.RokUrodzenia +". Byl to rok " +Person.Rok ;
            if (ModelState.IsValid)
            {
                _context.Person.Add(Person);
                _context.SaveChanges();
                var Data = HttpContext.Session.GetString("Data");
                if (Data == null)
                {
                    People = new List<Person>();
                    People.Add(Person);
                    HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(People));

                }
                else
                {
                    People = JsonConvert.DeserializeObject<List<Person>>(Data);
                    People.Add(Person);
                    HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(People));

                }
            }

            return RedirectToPage("./Index");
        }

    }
}