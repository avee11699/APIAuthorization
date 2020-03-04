using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAuthorization.Data;
using APIAuthorization.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace APIAuthorization
{
    public class CreateModel : PageModel
    {
        private readonly AuthSettingContext _db;

        public CreateModel(AuthSettingContext db)
        {
            _db = db;
        }
        [BindProperty]
        public PaymentDetails PaymentDetails { get; set; } 
        [BindProperty]
        public Payment_facilitator_details Payment_facilitator_details { get; set; } 

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var key = Guid.NewGuid();
                PaymentDetails.id = key.ToString();
                PaymentDetails.Payment_facilitator_details = Payment_facilitator_details;
                PaymentDetails.created_date = DateTime.Now.ToString();
                var authSettings = new authsetting 
                {
                   KEY = key, 
                   VALUE = JsonConvert.SerializeObject(PaymentDetails)
                };      
                await _db.AuthorizationSettings.AddAsync(authSettings);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}