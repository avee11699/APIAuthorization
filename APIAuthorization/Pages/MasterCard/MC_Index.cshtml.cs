using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAuthorization.Data;
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

        public IEnumerable<MC_AuthSetting> MC_AuthSettings { get; set; }

        public async Task OnGet()
        {
            var keySearch = new StringValues();

            Request.Query.TryGetValue("KEY", out keySearch);

            if (keySearch.Count > 0 && !string.IsNullOrEmpty(keySearch.ToString()))
            {
                var authSettingsDB = (from authsettingtbl in _db.MasterCard_AuthorizationSettings.Where(x => x.KEY == Guid.Parse(keySearch.ToString()))
                                      select authsettingtbl).AsEnumerable();
                MC_AuthSettings = authSettingsDB;
            }
            else
                MC_AuthSettings = await _db.MasterCard_AuthorizationSettings.ToListAsync();

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