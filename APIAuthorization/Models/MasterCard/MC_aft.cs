using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace APIAuthorization.Models.MasterCard
{
    public class MC_aft
    {
     
        [DisplayName("Payment Transaction Type")]
        public string PaymentTransactionType { get; set; }

        [DisplayName("Merchant Code Category")]
        public int MerchantCategoryCode { get; set; }

        [DisplayName("Merchant Name")]
        public string MerchantName { get; set; }
    }
}
