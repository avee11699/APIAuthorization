using APIAuthorization.Models.MasterCard;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAuthorization.Data
{
    public class MC_AuthSettingContext: DbContext
    {
        public MC_AuthSettingContext(DbContextOptions<MC_AuthSettingContext> options) : base(options)
        {
        }
        public DbSet<MC_AuthSetting> MasterCard_AuthorizationSettings { get; set; }
    }
}
