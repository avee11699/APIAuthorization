using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace APIAuthorization.Models.MasterCard
{
    public class MC_PaymentDetails
    {
        [DisplayName("Payment Identifier")]
        public string PaymentIdentifier { get; set; }

        [DisplayName("Payment Facilitator ID")]
        public int PaymentFacilitatorId { get; set; }

        [DisplayName("Sub-Merchant ID")]
        public int SubMerchantId { get; set; }

        [DisplayName("Independant Sales Org ID")]
        public int IndependantSalesOrgId { get; set; }

        [DisplayName("Sponsor Merchant ID")]
        public int SponsorMerchantId { get; set; }

        [DisplayName("Marketplace ID")]
        public int MarketplaceId { get; set; }

        [DisplayName("Payment Transaction Type")]
        public MC_PaymentTransactionType PaymentTransactionType { get; set; }

        [DisplayName("AFT")]
        public MC_aft aft { get; set; }
    }
}
