using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAuthorization.Data;
using APIAuthorization.Models;
using APIAuthorization.Models.MasterCard;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

namespace APIAuthorization
{
    public class MC_IndexModel : PageModel
    {
        private readonly MC_AuthSettingContext _db;
        public MC_IndexModel(MC_AuthSettingContext db)
        {
            _db = db;
        }

        [BindProperty(SupportsGet = true)]

        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 3;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        public IEnumerable<authsetting> AuthSettings { get; set; }

        public IEnumerable<MC_AuthSetting> MC_AuthSettings { get; set; }

        public async Task OnGet()
        {
            var keySearch = new StringValues();

            Request.Query.TryGetValue("KEY", out keySearch);

            if (keySearch.Count > 0 && !string.IsNullOrEmpty(keySearch.ToString()))
            {
                Guid guidVal;
                Guid.TryParse(keySearch.ToString(), out guidVal);
                if (guidVal != new Guid())
                {
                    var authSettingsDB = (from authsettingtbl in _db.MasterCard_AuthorizationSettings.Where(x => x.KEY == Guid.Parse(keySearch.ToString()))
                                          select authsettingtbl).AsEnumerable();
                    MC_AuthSettings = authSettingsDB;
                }
                else
                {
                    var authsettingsDB = (from authsettingtbl in _db.MasterCard_AuthorizationSettings.Where(x => x.VALUE.Contains(keySearch.ToString()))
                                          select authsettingtbl).AsEnumerable();
                    MC_AuthSettings = authsettingsDB;

                }
                    
            }
            else
                MC_AuthSettings = await _db.MasterCard_AuthorizationSettings.ToListAsync();
                Count = MC_AuthSettings.Count();
            MC_AuthSettings = MC_AuthSettings.OrderBy(x => x.KEY).Skip((CurrentPage - 1) * PageSize).Take(PageSize).AsEnumerable();

        }

        public async Task<IActionResult> OnPostDelete(Guid KEY)
        {
            var api = await _db.MasterCard_AuthorizationSettings.FindAsync(KEY);
            if (api == null)
            {
                return NotFound();
            }
            _db.MasterCard_AuthorizationSettings.Remove(api);
            await _db.SaveChangesAsync();

            return RedirectToPage("MC_Index");
        }

    }
}