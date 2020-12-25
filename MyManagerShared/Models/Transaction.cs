// Class that represents a transaction between two users

using System;
using System.ComponentModel.DataAnnotations;

namespace MyManagerShared.Models
{
    public class Transaction
    {
        [Key]
        public int transactionID { get; set; }

        [Required]
        public int SenderID { get; set; }

        [Required]
        public int ReceiverID { get; set; }

        public string ReceiverName { get; set; }

        public double Amount { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; }
    }
}
