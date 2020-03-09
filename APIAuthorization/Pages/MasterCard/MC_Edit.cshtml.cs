using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAuthorization.Data;
using APIAuthorization.Models.MasterCard;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace APIAuthorization
{
    public class MC_EditModel : PageModel
    {


        private MC_AuthSettingContext _db;

        public MC_EditModel(MC_AuthSettingContext db)
        {
            _db = db;
        }

        [BindProperty]
        public MC_PaymentDetails MC_PaymentDetails { get; set; }

        [BindProperty]
        public Guid MC_PaymentDetails_Id { get; set; }

        [BindProperty]
        public MC_PaymentTransactionType PaymentTransactionType { get; set; }

        public async Task OnGet(Guid id)
        {
            //PaymentDetails = JsonConverter.DeserializeObject<PaymentDetails>(authsetting.VALUE);
            //return PaymentDetails;

            var authSetting = await _db.MasterCard_AuthorizationSettings.FindAsync(id);

            MC_PaymentDetails_Id = authSetting.KEY;

            PaymentTransactionType = JsonConvert.DeserializeObject<MC_PaymentTransactionType>(authSetting.VALUE);
            MC_PaymentDetails = JsonConvert.DeserializeObject<MC_PaymentDetails>(authSetting.VALUE);

        }

        public async Task<IActionResult> OnPost(Guid id)
        {
            if (ModelState.IsValid)
            {

                var AuthSettings = new MC_AuthSetting
                {
                    KEY = id,
                    VALUE = JsonConvert.SerializeObject(MC_PaymentDetails)
                };
                _db.MasterCard_AuthorizationSettings.Update(AuthSettings);
                await _db.SaveChangesAsync();


            }
            return RedirectToPage("MC_Index");
        }

    }
}