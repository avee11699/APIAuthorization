using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAuthorization.Data;
using APIAuthorization.Models;
using APIAuthorization.Models.MasterCard;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace APIAuthorization
{
    public class MC_CreateModel : PageModel
    {
        private readonly MC_AuthSettingContext _db;
         
        public MC_CreateModel(MC_AuthSettingContext db)
        {
            _db = db;
        }
        [BindProperty]
        public MC_PaymentDetails MC_PaymentDetails { get; set; }
        [BindProperty]
        public MC_PaymentTransactionType PaymentTransactionType { get; set; }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var key = Guid.NewGuid();
                //PaymentDetails.id = key.ToString();
                //MC_PaymentDetails.PaymentTransactionType = PaymentTransactionType;
                //PaymentDetails.created_date = DateTime.Now.ToString();
                var AuthSettings = new MC_AuthSetting
                {
                    KEY = key,
                    VALUE = JsonConvert.SerializeObject(MC_PaymentDetails)
                };
                await _db.MasterCard_AuthorizationSettings.AddAsync(AuthSettings);
                await _db.SaveChangesAsync();
                return RedirectToPage("MC_Index");
            }
            else
            {
                return Page();
            }
        }
    }
}