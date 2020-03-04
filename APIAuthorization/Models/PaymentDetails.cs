using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIAuthorization.Models
{
    public class PaymentDetails
    {
        
        [DisplayName("ID")]
        public string id { get; set; }
        
        [Required]
        [DisplayName("Account Active")]
        public Boolean is_active { get; set; }

        [DisplayName("Purchase Type")]
        public string purchase_type { get; set; }

        [DisplayName("Purchase Identifier")]
        public string purchase_identifier { get; set; }
        
        [DisplayName("Payment Facilitator Details")]
        public Payment_facilitator_details Payment_facilitator_details { get; set; }
        
        [DisplayName("Created Date")]
        public string created_date { get; set; }
        [DisplayName("Modified Date")]
        public string modified_date { get; set; }
        
        

    }
}
