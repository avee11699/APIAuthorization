using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIAuthorization.Models.MasterCard
{
    public class MC_AuthSetting
    {
        [Key]
        public Guid KEY { get; set; }
        public string VALUE { get; set; }
    }
    public class MC_Attibutes
    {
        [Key]
        public Guid KEY { get; set; }

        public MC_PaymentDetails VALUE { get; set; }

        public MC_PaymentTransactionType MC_PaymentDetails { get; set; }

        //public MC_aft MC_PaymentDetails { get; set; }
    }
}

