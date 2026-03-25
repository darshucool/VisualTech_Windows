using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualTech.Domain;

namespace VisualTech.DataAccess
{
    public class CustomerService:CoreService
    {
        private readonly string _connectionString;

        public CustomerService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        }
        public List<Customer> GetAllActive()
        {
            string query = @"
                SELECT UId, CutomerName, CompanyName, HomeAddress, OfficeAddress,
                       MobileNo, Landline, Email, Active, CurrentBalance
                FROM Customer
                WHERE Active = 1
                ORDER BY CutomerName ASC";

            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer
                        {
                            UId = Convert.ToInt32(reader["UId"]),
                            CutomerName = reader["CutomerName"]?.ToString(),
                            CompanyName = reader["CompanyName"]?.ToString(),
                            HomeAddress = reader["HomeAddress"]?.ToString(),
                            OfficeAddress = reader["OfficeAddress"]?.ToString(),
                            MobileNo = reader["MobileNo"]?.ToString(),
                            Landline = reader["Landline"]?.ToString(),
                            Email = reader["Email"]?.ToString(),
                            Active = Convert.ToBoolean(reader["Active"]),
                            CurrentBalance = reader["CurrentBalance"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["CurrentBalance"])
                        });
                    }
                }
            }

            return customers;
        }
        public List<Customer> GetAll()
        {
            string query = "SELECT * FROM Customer where Active='TRUE' order by CutomerName ASC";
            List<Customer> categories = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(new Customer
                            {
                                UId = Convert.ToInt32(reader["UId"]),
                                CutomerName = reader["CutomerName"].ToString(),
                                CompanyName = reader["CompanyName"].ToString(),
                                HomeAddress = reader["HomeAddress"].ToString(),
                                OfficeAddress = reader["OfficeAddress"].ToString(),
                                MobileNo = reader["MobileNo"].ToString(),
                                Landline = reader["Landline"].ToString(),
                                Email = reader["Email"].ToString(),
                                Active = Convert.ToBoolean(reader["Active"]),
                                CurrentBalance = Convert.ToDecimal(reader["CurrentBalance"]),
                                CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                                CreatedBy = reader["CreatedBy"].ToString(),
                                ModifiedBy = reader["ModifiedBy"].ToString()
                            });
                        }
                    }
                }
            }
            return categories; // Return the list of categories
        }
        public int Insert(Customer Customer)
        {
            string query = @"INSERT INTO Customer (CutomerName,CompanyName,HomeAddress,OfficeAddress,MobileNo,Landline,Email,CurrentBalance, Active, CreatedDate, CreatedBy)
                         VALUES (@CutomerName,@CompanyName,@HomeAddress,@OfficeAddress,@MobileNo,@Landline,@Email,@CurrentBalance, @Active, @CreatedDate, @CreatedBy);
                         SELECT SCOPE_IDENTITY();";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@CutomerName", Customer.CutomerName),
            new SqlParameter("@CompanyName", Customer.CompanyName),
            new SqlParameter("@HomeAddress", Customer.HomeAddress),
            new SqlParameter("@OfficeAddress", Customer.OfficeAddress),
            new SqlParameter("@MobileNo", Customer.MobileNo),
            new SqlParameter("@Landline", Customer.Landline),
            new SqlParameter("@Email", Customer.Email),
            new SqlParameter("@CurrentBalance", Customer.CurrentBalance),
            new SqlParameter("@Active", Customer.Active),
            new SqlParameter("@CreatedDate", Customer.CreatedDate),
            new SqlParameter("@CreatedBy", Customer.CreatedBy),
            };

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    connection.Open();

                    // ExecuteScalar to get the newly inserted UId
                    object result = command.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
        }

        // Update method
        public int Update(Customer Customer)
        {
            string query = @"UPDATE Customer
                         SET CutomerName = @CutomerName, 
                             CompanyName = @CompanyName, 
                             HomeAddress = @HomeAddress, 
                             OfficeAddress = @OfficeAddress, 
                             MobileNo = @MobileNo, 
                             Landline = @Landline, 
                             Email = @Email, 
                             CurrentBalance = @CurrentBalance, 
                             Active = @Active, 
                             ModifiedDate = @ModifiedDate, 
                             ModifiedBy = @ModifiedBy
                         WHERE UId = @UId";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UId", Customer.UId),
                new SqlParameter("@CutomerName", Customer.CutomerName),
                new SqlParameter("@CompanyName", Customer.CompanyName),
                new SqlParameter("@HomeAddress", Customer.HomeAddress),
                new SqlParameter("@OfficeAddress", Customer.OfficeAddress),
                new SqlParameter("@MobileNo", Customer.MobileNo),
                new SqlParameter("@Landline", Customer.Landline),
                new SqlParameter("@Email", Customer.Email),
                new SqlParameter("@CurrentBalance", Customer.CurrentBalance),
                new SqlParameter("@Active", Customer.Active),
                new SqlParameter("@ModifiedDate", Customer.ModifiedDate),
                new SqlParameter("@ModifiedBy", Customer.ModifiedBy),
            };

            return ExecuteNonQuery(query, parameters);
        }

        // Get by UId method
        public Customer GetById(int id)
        {
            string query = "SELECT * FROM Customer WHERE UId = @UId";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@UId", id)
            };

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Customer
                            {
                                UId = Convert.ToInt32(reader["UId"]),
                                CutomerName = reader["CutomerName"].ToString(),
                                CompanyName = reader["CompanyName"].ToString(),
                                HomeAddress = reader["HomeAddress"].ToString(),
                                OfficeAddress = reader["OfficeAddress"].ToString(),
                                MobileNo = reader["MobileNo"].ToString(),
                                Landline = reader["Landline"].ToString(),
                                Email = reader["Email"].ToString(),
                                Active = Convert.ToBoolean(reader["Active"]),
                                CurrentBalance = reader["CurrentBalance"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["CurrentBalance"]),
                                CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                                CreatedBy = reader["CreatedBy"].ToString(),
                                ModifiedBy = reader["ModifiedBy"].ToString()
                            };
                        }
                    }
                }
            }
            return null; // Return null if no record is found
        }

        // Update Active to false method
        public int DeactivateById(int id, string modifiedBy)
        {
            string query = @"UPDATE Customer
                         SET Active = 0, 
                             ModifiedDate = @ModifiedDate, 
                             ModifiedBy = @ModifiedBy
                         WHERE UId = @UId";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@ModifiedDate", DateTime.Now),
            new SqlParameter("@ModifiedBy", modifiedBy),
            new SqlParameter("@UId", id)
            };

            return ExecuteNonQuery(query, parameters);
        }

        public DataTable LoadDataTable(SqlParameter[] parameters = null)
        {
            string query = "SELECT * FROM Customer WHERE Active='TRUE'";
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters if provided
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    // Open the database connection
                    connection.Open();

                    // Use SqlDataAdapter to fill the DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }
    }
}
