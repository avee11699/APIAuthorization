using APIAuthorization.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAuthorization.Data
{
        public class AuthSettingContext : DbContext
        {
            public AuthSettingContext(DbContextOptions<AuthSettingContext> options) : base(options)
            {
            }
            public DbSet<authsetting> AuthorizationSettings { get; set; }
        }
    
}
