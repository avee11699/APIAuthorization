using APIAuthorization.Models.UserLogin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAuthorization.Data
{
    public class User_LoginContext:DbContext 
    {
        public User_LoginContext(DbContextOptions<User_LoginContext> options) : base(options)
        {
        }
        public DbSet<Login_Details> UserLogin { get; set; }
    }
}
