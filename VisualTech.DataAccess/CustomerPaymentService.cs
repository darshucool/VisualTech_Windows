using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using VisualTech.Domain;

namespace VisualTech.DataAccess
{
    public class CustomerPaymentService
    {
        private readonly string _connectionString;

        public CustomerPaymentService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        }

        public int Insert(CustomerPayment payment)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                string sql = @"
INSERT INTO CustomerPayment (CustomerId, Amount, Date)
VALUES (@CustomerId, @Amount, @Date);
SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", payment.CustomerId);
                    cmd.Parameters.AddWithValue("@Amount", payment.Amount);
                    cmd.Parameters.AddWithValue("@Date", payment.Date);

                    object result = cmd.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
        }

        public int SavePaymentAndReduceBalance(CustomerPayment payment)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlTransaction tran = con.BeginTransaction();

                try
                {
                    int paymentId;

                    string insertSql = @"
INSERT INTO CustomerPayment (CustomerId, Amount, Date)
VALUES (@CustomerId, @Amount, @Date);
SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(insertSql, con, tran))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", payment.CustomerId);
                        cmd.Parameters.AddWithValue("@Amount", payment.Amount);
                        cmd.Parameters.AddWithValue("@Date", payment.Date);

                        object result = cmd.ExecuteScalar();
                        paymentId = Convert.ToInt32(result);
                    }

                    string updateSql = @"
UPDATE Customer
SET CurrentBalance = ISNULL(CurrentBalance, 0) - @PaymentAmount,
    ModifiedDate = GETDATE()
WHERE UId = @CustomerId";

                    using (SqlCommand cmd = new SqlCommand(updateSql, con, tran))
                    {
                        cmd.Parameters.AddWithValue("@PaymentAmount", payment.Amount);
                        cmd.Parameters.AddWithValue("@CustomerId", payment.CustomerId);
                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                    return paymentId;
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        public DataTable GetPaymentsByCustomerId(int customerId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                string sql = @"
SELECT 
    UId,
    Date,
    Amount
FROM CustomerPayment
WHERE CustomerId = @CustomerId
ORDER BY Date DESC, UId DESC";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }

        public DataTable GetCustomers()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                string sql = @"
SELECT 
    UId,
    CutomerName
FROM Customer
WHERE ISNULL(Active, 0) = 1
ORDER BY CutomerName";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public decimal GetCustomerCurrentBalance(int customerId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                string sql = @"
SELECT ISNULL(CurrentBalance, 0)
FROM Customer
WHERE UId = @CustomerId";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    object result = cmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                        return 0;

                    return Convert.ToDecimal(result);
                }
            }
        }
    }
}