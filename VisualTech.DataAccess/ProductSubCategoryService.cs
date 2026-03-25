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
    public class ProductSubCategoryService:CoreService
    {
        private readonly string _connectionString;

        public ProductSubCategoryService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        }
        public List<ProductSubCategory> GetAll()
        {
            string query = "SELECT * FROM ProductSubCategory where Active='TRUE' order by Category ASC";
            List<ProductSubCategory> categories = new List<ProductSubCategory>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(new ProductSubCategory
                            {
                                UId = Convert.ToInt32(reader["UId"]),
                                Category = reader["Category"].ToString(),
                                Active = Convert.ToBoolean(reader["Active"]),
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
        public int Insert(ProductSubCategory ProductSubCategory)
        {
            string query = @"INSERT INTO ProductSubCategory (MainCategoryUId,Category, Active, CreatedDate, CreatedBy)
                         VALUES (@MainCategoryUId,@Category, @Active, @CreatedDate, @CreatedBy);
                         SELECT SCOPE_IDENTITY();";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@MainCategoryUId", ProductSubCategory.MainCategoryUId),
            new SqlParameter("@Category", ProductSubCategory.Category),
            new SqlParameter("@Active", ProductSubCategory.Active),
            new SqlParameter("@CreatedDate", ProductSubCategory.CreatedDate),
            new SqlParameter("@CreatedBy", ProductSubCategory.CreatedBy),
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
        public int Update(ProductSubCategory ProductSubCategory)
        {
            string query = @"UPDATE ProductSubCategory
                         SET MainCategoryUId = @MainCategoryUId, 
                             Category = @Category, 
                             Active = @Active, 
                             ModifiedDate = @ModifiedDate, 
                             ModifiedBy = @ModifiedBy
                         WHERE UId = @UId";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MainCategoryUId", ProductSubCategory.MainCategoryUId),
                new SqlParameter("@Category", ProductSubCategory.Category),
                new SqlParameter("@Active", ProductSubCategory.Active),
                new SqlParameter("@ModifiedDate", ProductSubCategory.ModifiedDate),
                new SqlParameter("@ModifiedBy", ProductSubCategory.ModifiedBy),
                new SqlParameter("@UId", ProductSubCategory.UId)
            };

            return ExecuteNonQuery(query, parameters);
        }

        // Get by UId method
        public ProductSubCategory GetById(int id)
        {
            string query = "SELECT * FROM ProductSubCategory WHERE UId = @UId";
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
                            return new ProductSubCategory
                            {
                                UId = Convert.ToInt32(reader["UId"]),
                                Category = reader["Category"].ToString(),
                                MainCategoryUId = Convert.ToInt32(reader["MainCategoryUId"].ToString()),
                                Active = Convert.ToBoolean(reader["Active"]),
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
            string query = @"UPDATE ProductSubCategory
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
            string query = "SELECT * FROM ProductSubCategory WHERE Active='TRUE'";
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
