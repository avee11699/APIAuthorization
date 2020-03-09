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
    public class DetailsModel : PageModel
    {
        private AuthSettingContext _db;

        public DetailsModel(AuthSettingContext db)
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
            ViewData["PaymentDetailsId"] = id;
            var authSetting = await _db.AuthorizationSettings.FindAsync(id);

            Payment_facilitator_details = JsonConvert.DeserializeObject<Payment_facilitator_details>(authSetting.VALUE);
            PaymentDetails = JsonConvert.DeserializeObject<PaymentDetails>(authSetting.VALUE);

        }
    }
}