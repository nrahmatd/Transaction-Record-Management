namespace TransactionRecordManagement.Utils
{
    public class ConnectionString
    {
        private static string cName = "Data Source=localhost; Database=transactionrecordmanagement; User ID=root; Password=";

        public static string CName {  get { return cName; } }
    }
}
