using System.ComponentModel.DataAnnotations;

namespace TransactionRecordManagement.Models
{
    public class Customer
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
    }
}
