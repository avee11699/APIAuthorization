using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using APIAuthorization.Data;
using APIAuthorization.Models.UserLogin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace APIAuthorization
{
    public class UserLoginModel : PageModel
    {
        private readonly User_LoginContext _db;

        public UserLoginModel(User_LoginContext db)
        {
            _db = db;
        }
        [Required]
        [BindProperty]
        public string Username { get; set; }
        [Required]
        [BindProperty]
        public string Password { get; set; }
        public async Task  OnGet(string Username, string Password)
        {

        }

        public async Task<IActionResult> OnPost(string Username,string Password)
        {
            if (!string.IsNullOrEmpty(Username)&& !string.IsNullOrEmpty(Password))
            {

                var userLogin = await _db.UserLogin.FindAsync(Username);

                if (userLogin != null && Password==userLogin.Password)
                {
                    //if (Session["UserName"] != null)
                    //{
                    //    tbUserName.Text = Session["UserName"].ToString();
                    //}
                    //if (Session["Pwd"] != null)
                    //{
                    //    tbpwd.Text = Session["Pwd"].ToString();
                    //}
                    return RedirectToPage("/MasterCard/MC_Index");

                }

                //TODO: Exception for login fail 

                return RedirectToPage("UserLogin");

            }
            else
            {
                return Page();
            }
        }
    }
    
}