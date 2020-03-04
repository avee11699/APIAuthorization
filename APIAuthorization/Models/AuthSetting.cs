using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIAuthorization.Models
{
    public class authsetting
    {
        [Key]
        public Guid KEY { get; set; }
        public string VALUE { get; set; }
    }

    public class AuthSettingPostman
    {
        [Key]
        public Guid KEY { get; set; }
        
        [Required]
        public PaymentDetails VALUE { get; set; }

        public Payment_facilitator_details PaymentDetails { get; set; }

    }
}
