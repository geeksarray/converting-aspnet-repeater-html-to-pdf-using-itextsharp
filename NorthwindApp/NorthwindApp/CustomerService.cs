using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace NorthwindApp
{
    public static class CustomerService
    {
        public static List<Customer> GetAllCustomers(int pageIndex, int pageSize)
        {
            List<Customer> lstCustomers = new List<Customer>();   
            SqlConnection cnNorthwind = new SqlConnection();
            
            try
            {
                cnNorthwind.ConnectionString = ConfigurationManager.ConnectionStrings["cnNorthwind"].ToString();
                SqlCommand cmdCustomers = new SqlCommand();
                cmdCustomers.CommandType = CommandType.StoredProcedure;
                cmdCustomers.CommandText = "GetAllCustomers";
                cmdCustomers.Parameters.Add(new SqlParameter("PageIndex", pageIndex));
                cmdCustomers.Parameters.Add(new SqlParameter("PageSize", pageSize));
                cmdCustomers.Connection = cnNorthwind;
                cnNorthwind.Open();

                IDataReader reader = cmdCustomers.ExecuteReader(CommandBehavior.SequentialAccess);

                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.CustomerID = reader.GetString(reader.GetOrdinal("CustomerID"));
                    customer.CompanyName = reader.GetString(reader.GetOrdinal("CompanyName"));
                    customer.ContactName = reader.GetString(reader.GetOrdinal("ContactName"));
                    customer.ContactTitle = reader.GetString(reader.GetOrdinal("ContactTitle"));
                    customer.Address = reader.GetString(reader.GetOrdinal("Address"));
                    customer.City = reader.GetString(reader.GetOrdinal("City"));
                    customer.Country = reader.GetString(reader.GetOrdinal("Country"));
                    
                    lstCustomers.Add(customer);   
                }
                reader.Close(); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {   
                cnNorthwind.Close();
                cnNorthwind.Dispose(); 
            }
            return lstCustomers; 
        }

        public static int GetCustomerCount()
        {
            int customerCount = 0;
            SqlConnection cnNorthwind = new SqlConnection();

            try
            {
                cnNorthwind.ConnectionString = ConfigurationManager.ConnectionStrings["cnNorthwind"].ToString();
                SqlCommand cmdCustomers = new SqlCommand();
                cmdCustomers.CommandType = CommandType.StoredProcedure;
                cmdCustomers.CommandText = "GetAllCustomerCount";
                cmdCustomers.Connection = cnNorthwind;
                cnNorthwind.Open();

                int.TryParse(Convert.ToString(cmdCustomers.ExecuteScalar()), out customerCount); 

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnNorthwind.Close();
                cnNorthwind.Dispose();
            }
            return customerCount; 
        }
    }
}