using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace APIAuthorization.Models
{
    public class Payment_facilitator_details
    {
        [DisplayName("Payment Facilitator ID")]
        public string payment_facilitator_id { get; set; }

        [DisplayName("Marketplace ID")]
        public string marketplace_id { get; set; }

        [DisplayName("Sponsor Merchant ID")]
        public string sponsor_merchant_id { get; set; }

    }
}
