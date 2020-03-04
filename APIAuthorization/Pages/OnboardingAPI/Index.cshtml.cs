using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAuthorization.Data;
using APIAuthorization.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace APIAuthorization
{
    public class IndexModel : PageModel
    {
        private readonly AuthSettingContext _db;
        public IndexModel(AuthSettingContext db)
        {
            _db = db;
        }

        public IEnumerable<authsetting>AuthSettings { get; set; }

        public async Task OnGet()
        {
            AuthSettings = await _db.AuthorizationSettings.ToListAsync();

        }

        public async Task<IActionResult> OnPostDelete(Guid KEY)
        {
            var api = await _db.AuthorizationSettings.FindAsync(KEY);
            if(api==null)
            {
                return NotFound();
            }
            _db.AuthorizationSettings.Remove(api);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
        //public async Task<IActionResult> onGet(Guid KEY)
        //{
        //    var movies = from KEY in PaymentDetails
        //                 select KEY;

        //    if (!Guid.IsNullOrEmpty(KEY))
        //    {
        //        movies = movies.Where(s => s.VALUE.Contains(KEY));
        //    }

        //    return View(await movies.ToListAsync());
        //}
        
    }
}