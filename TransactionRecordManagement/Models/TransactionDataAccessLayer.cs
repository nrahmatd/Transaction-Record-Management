using MySql.Data.MySqlClient;
using System.Data;
using TransactionRecordManagement.Utils;

namespace TransactionRecordManagement.Models
{
    public class TransactionDataAccessLayer
    {
        string connectionString = ConnectionString.CName;
        CustomerDataAccessLayer _customerDataLayer = new CustomerDataAccessLayer();

        public IEnumerable<Transaction> GetAllTransaction()
        {

            List<Transaction> transactionList = new List<Transaction>();

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("spGetAllTransaction", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Transaction transaction = new Transaction();

                    transaction.TransactionId = Convert.ToInt32(rdr["TransactionId"]);
                    transaction.TransactionDate = Convert.ToDateTime(rdr["TransactionDate"]);
                    transaction.Description = rdr["Description"].ToString();
                    transaction.DebitCreditStatus = rdr["DebitCreditsStatus"].ToString();
                    transaction.Amount = Convert.ToDecimal(rdr["Amount"]);
                    transaction.AccountName = _customerDataLayer.GetCustomerData(Convert.ToInt32(rdr["AccountId"])).Name;

                    transactionList.Add(transaction);
                }
                con.Close();
            }
            return transactionList;
        }

        public void AddTransaction(Transaction transaction)
        {
            using(MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("spAddTransaction", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_TransactionDate", transaction.TransactionDate);
                cmd.Parameters.AddWithValue("p_Description", transaction.Description);
                cmd.Parameters.AddWithValue("p_DebitCreditStatus", transaction.DebitCreditStatus);
                cmd.Parameters.AddWithValue("p_Amount", transaction.Amount);
                cmd.Parameters.AddWithValue("p_AccountId", transaction.AccountId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateTransaction(Transaction transaction)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("spUpdateTransaction", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_TransactionId", transaction.TransactionId);
                cmd.Parameters.AddWithValue("p_TransactionDate", transaction.TransactionDate);
                cmd.Parameters.AddWithValue("p_Description", transaction.Description);
                cmd.Parameters.AddWithValue("p_DebitCreditStatus", transaction.DebitCreditStatus);
                cmd.Parameters.AddWithValue("p_Amount", transaction.Amount);
                cmd.Parameters.AddWithValue("p_AccountId", transaction.AccountId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }



        public Transaction GetTransactionData(int? id)
        {
            Transaction transaction = new Transaction();

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM transaction WHERE TransactionId= " + id;
                MySqlCommand cmd = new MySqlCommand(sqlQuery, con);

                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    transaction.TransactionId = Convert.ToInt32(rdr["TransactionId"]);
                    transaction.TransactionDate = Convert.ToDateTime(rdr["TransactionDate"]);
                    transaction.Description = rdr["Description"].ToString();
                    transaction.DebitCreditStatus = rdr["DebitCreditsStatus"].ToString();
                    transaction.Amount = Convert.ToDecimal(rdr["Amount"]);
                    transaction.AccountId = Convert.ToInt32(rdr["AccountId"]);
                }
            }
            return transaction;
        }

        public void DeleteTransaction(int? id)
        {

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("spDeleteTransaction", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_TransactionId", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}
