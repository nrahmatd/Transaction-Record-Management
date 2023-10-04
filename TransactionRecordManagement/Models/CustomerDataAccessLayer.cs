using MySql.Data.MySqlClient;
using System.Data;
using TransactionRecordManagement.Utils;

namespace TransactionRecordManagement.Models
{
    public class CustomerDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<Customer> GetAllCustomer()
        {
            List<Customer> customerList = new List<Customer>();

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("spGetAllCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Customer customer = new Customer();

                    customer.AccountId = Convert.ToInt32(rdr["AccountId"]);
                    customer.Name = rdr["Name"].ToString();

                    customerList.Add(customer);
                }
                con.Close();
            }
            return customerList;
        }

        public void AddCustomer(Customer customer)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("spAddCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_Name", customer.Name);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("spUpdateCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_AccountId", customer.AccountId);
                cmd.Parameters.AddWithValue("p_Name", customer.Name);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Customer GetCustomerData(int? AccountId)
        {
            Customer customer= new Customer();

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM customers WHERE AccountId= " + AccountId;
                MySqlCommand cmd = new MySqlCommand(sqlQuery, con);

                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    customer.AccountId = Convert.ToInt32(rdr["AccountId"]);
                    customer.Name = rdr["Name"].ToString();
                }
            }
            return customer;
        }

        public void DeleteCustomer(int? AccountId)
        {

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("spDeleteCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_Id", AccountId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
