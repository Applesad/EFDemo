using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using EFDemo.Models;
namespace EFDemo.Pages
{
    public class SavedInSessionModel : PageModel
    {
        public List<Person>? People = new() { };
        public void OnGet()
        {
            var Data = HttpContext.Session.GetString("Data");
            if (Data != null)
            {
                People = JsonConvert.DeserializeObject<List<Person>>(Data);

            }

        }
    }
}
