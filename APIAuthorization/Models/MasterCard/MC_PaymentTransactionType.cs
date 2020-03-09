using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace APIAuthorization.Models.MasterCard
{
    public class MC_PaymentTransactionType
    {
        [DisplayName("Indicator")]
        public string Indicator { get; set; }

        [DisplayName("Merchant Category Code")]
        public int MerchantCategoryCode { get; set; }

        
    }
}
