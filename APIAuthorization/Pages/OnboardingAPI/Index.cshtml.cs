﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAuthorization.Data;
using APIAuthorization.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

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
            var keySearch = new StringValues();

            Request.Query.TryGetValue("KEY",out keySearch);

            if (keySearch.Count>0 && !string.IsNullOrEmpty(keySearch.ToString()))
            {
                var authSettingsDB = (from authsettingtbl in _db.AuthorizationSettings.Where(x => x.KEY == Guid.Parse(keySearch.ToString()))
                              select authsettingtbl).AsEnumerable();
                AuthSettings = authSettingsDB;
            }
            else
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

    }
}