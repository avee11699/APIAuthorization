using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAuthorization.Data;
using APIAuthorization.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace APIAuthorization
{
    public class EditModel : PageModel
    {
        private AuthSettingContext _db;

        public EditModel(AuthSettingContext db)
        {
            _db = db;
        }

        [BindProperty]
        public PaymentDetails PaymentDetails { get; set; }

        [BindProperty]
        public Payment_facilitator_details Payment_facilitator_details { get; set; }

        public async Task OnGet(Guid id)
        {
            //PaymentDetails = JsonConverter.DeserializeObject<PaymentDetails>(authsetting.VALUE);
            //return PaymentDetails;

            var authSetting = await _db.AuthorizationSettings.FindAsync(id);
            
            Payment_facilitator_details = JsonConvert.DeserializeObject<Payment_facilitator_details>(authSetting.VALUE);
            PaymentDetails = JsonConvert.DeserializeObject<PaymentDetails>(authSetting.VALUE);

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                //var key = Guid.NewGuid();
                //PaymentDetails.id = key.ToString();
                PaymentDetails.modified_date = DateTime.Now.ToString();
                var authSettings = new authsetting
                {
                    KEY = Guid.Parse(PaymentDetails.id),
                    VALUE = JsonConvert.SerializeObject(PaymentDetails)
                };
                 _db.AuthorizationSettings.Update(authSettings);
                await _db.SaveChangesAsync();

            }
                return RedirectToPage("Index");
        }
    }
}