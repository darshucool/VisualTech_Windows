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
    public class ProductCategoryService:CoreService
    {
        private readonly string _connectionString;

        public ProductCategoryService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        }
        public int Insert(ProductCategory productCategory)
        {
            string query = @"INSERT INTO ProductCategory (Category, Active, CreatedDate, CreatedBy)
                         VALUES (@Category, @Active, @CreatedDate, @CreatedBy);
                         SELECT SCOPE_IDENTITY();";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Category", productCategory.Category),
            new SqlParameter("@Active", productCategory.Active),
            new SqlParameter("@CreatedDate", productCategory.CreatedDate),
            new SqlParameter("@CreatedBy", productCategory.CreatedBy),
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
        public int Update(ProductCategory productCategory)
        {
            string query = @"UPDATE ProductCategory
                         SET Category = @Category, 
                             Active = @Active, 
                             ModifiedDate = @ModifiedDate, 
                             ModifiedBy = @ModifiedBy
                         WHERE UId = @UId";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Category", productCategory.Category),
            new SqlParameter("@Active", productCategory.Active),
            new SqlParameter("@ModifiedDate", productCategory.ModifiedDate),
            new SqlParameter("@ModifiedBy", productCategory.ModifiedBy),
            new SqlParameter("@UId", productCategory.UId)
            };

            return ExecuteNonQuery(query, parameters);
        }

        // Get by UId method
        public ProductCategory GetById(int id)
        {
            string query = "SELECT * FROM ProductCategory WHERE UId = @UId";
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
                            return new ProductCategory
                            {
                                UId = Convert.ToInt32(reader["UId"]),
                                Category = reader["Category"].ToString(),
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
        public List<ProductCategory> GetAll()
        {
            string query = "SELECT * FROM ProductCategory where Active='TRUE' order by Category ASC";
            List<ProductCategory> categories = new List<ProductCategory>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(new ProductCategory
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
        // Update Active to false method
        public int DeactivateById(int id, string modifiedBy)
        {
            string query = @"UPDATE ProductCategory
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
        public List<ProductCategoryCombo> GetCategorySubCategoryCombo()
        {
            string query = @"
        SELECT 
    PC.UId,
    NULL AS MainCategoryUId,
    PC.Category AS MainCategory,
    NULL AS SubCategory,
    PC.Category AS DisplayName,
    'MAIN' AS CategoryType
FROM ProductCategory PC

UNION ALL

SELECT 
    PSC.UId,
    PSC.MainCategoryUId,
    PC.Category AS MainCategory,
    PSC.Category AS SubCategory,
    PC.Category + ' - ' + PSC.Category AS DisplayName,
    'SUB' AS CategoryType
FROM ProductSubCategory PSC
INNER JOIN ProductCategory PC ON PC.UId = PSC.MainCategoryUId

ORDER BY DisplayName ASC;";

            List<ProductCategoryCombo> list = new List<ProductCategoryCombo>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ProductCategoryCombo
                        {
                            UId = reader["UId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["UId"]),
                            MainCategoryUId = reader["MainCategoryUId"] == DBNull.Value
        ? (int?)null
        : Convert.ToInt32(reader["MainCategoryUId"]),
                            MainCategory = reader["MainCategory"] == DBNull.Value ? "" : reader["MainCategory"].ToString(),
                            SubCategory = reader["SubCategory"] == DBNull.Value ? "" : reader["SubCategory"].ToString(),
                            DisplayName = reader["DisplayName"] == DBNull.Value ? "" : reader["DisplayName"].ToString(),
                            CategoryType = reader["CategoryType"] == DBNull.Value ? "" : reader["CategoryType"].ToString()
                        });
                    }
                }
            }

            return list;
        }
        public DataTable LoadDataTable(SqlParameter[] parameters = null)
        {
            string query = "SELECT PSC.*,PC.Category AS ParentCategory FROM ProductCategory AS PC, ProductSubCategory AS PSC WHERE PSC.Active='TRUE' AND PC.UId=PSC.MainCategoryUId";
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
