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
    public class MC_DetailsModel : PageModel
    {
        private MC_AuthSettingContext _db;

        public MC_DetailsModel(MC_AuthSettingContext db)
        {
            _db = db;
        }

        [BindProperty]
        public MC_PaymentDetails MC_PaymentDetails { get; set; }
        

        [BindProperty]
        public MC_PaymentTransactionType MC_PaymentTransactionType { get; set; }
        public async Task OnGet(Guid id)
        {
            //PaymentDetails = JsonConverter.DeserializeObject<PaymentDetails>(authsetting.VALUE);
            //return PaymentDetails;
            ViewData["PaymentDetailsId"] = id;

            var authSetting = await _db.MasterCard_AuthorizationSettings.FindAsync(id);

            MC_PaymentTransactionType = JsonConvert.DeserializeObject<MC_PaymentTransactionType>(authSetting.VALUE);
            MC_PaymentDetails = JsonConvert.DeserializeObject<MC_PaymentDetails>(authSetting.VALUE);

        }
    }
}