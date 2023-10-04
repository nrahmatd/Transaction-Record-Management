using System.ComponentModel.DataAnnotations;

namespace TransactionRecordManagement.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public string DebitCreditStatus { get; set; }
        public decimal Amount { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
    }
}
