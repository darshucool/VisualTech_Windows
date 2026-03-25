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
    public class BrandService:CoreService
    {
        private readonly string _connectionString;

        public BrandService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        }
        //public int Insert(ProductCategory productCategory)
        //{
        //    string query = @"INSERT INTO ProductCategory (Category, Active, CreatedDate, CreatedBy)
        //                 VALUES (@Category, @Active, @CreatedDate, @CreatedBy);
        //                 SELECT SCOPE_IDENTITY();";

        //    SqlParameter[] parameters = new SqlParameter[]
        //    {
        //    new SqlParameter("@Category", productCategory.Category),
        //    new SqlParameter("@Active", productCategory.Active),
        //    new SqlParameter("@CreatedDate", productCategory.CreatedDate),
        //    new SqlParameter("@CreatedBy", productCategory.CreatedBy),
        //    };

        //    using (SqlConnection connection = new SqlConnection(_connectionString))
        //    {
        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddRange(parameters);
        //            connection.Open();

        //            // ExecuteScalar to get the newly inserted UId
        //            object result = command.ExecuteScalar();
        //            return Convert.ToInt32(result);
        //        }
        //    }
        //}

        //// Update method
        //public int Update(ProductCategory productCategory)
        //{
        //    string query = @"UPDATE ProductCategory
        //                 SET Category = @Category, 
        //                     Active = @Active, 
        //                     ModifiedDate = @ModifiedDate, 
        //                     ModifiedBy = @ModifiedBy
        //                 WHERE UId = @UId";

        //    SqlParameter[] parameters = new SqlParameter[]
        //    {
        //    new SqlParameter("@Category", productCategory.Category),
        //    new SqlParameter("@Active", productCategory.Active),
        //    new SqlParameter("@ModifiedDate", productCategory.ModifiedDate),
        //    new SqlParameter("@ModifiedBy", productCategory.ModifiedBy),
        //    new SqlParameter("@UId", productCategory.UId)
        //    };

        //    return ExecuteNonQuery(query, parameters);
        //}

        // Get by UId method
        public Brand GetById(int id)
        {
            string query = "SELECT * FROM Brand WHERE UId = @UId";
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
                            return new Brand
                            {
                                UId = Convert.ToInt32(reader["UId"]),
                                BrandName = reader["BrandName"].ToString(),
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
        public List<Brand> GetAll()
        {
            string query = "SELECT * FROM Brand where Active='TRUE' order by BrandName ASC";
            List<Brand> Brands = new List<Brand>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Brands.Add(new Brand
                            {
                                UId = Convert.ToInt32(reader["UId"]),
                                BrandName = reader["BrandName"].ToString(),
                                Active = Convert.ToBoolean(reader["Active"]),
                                CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                                CreatedBy = reader["CreatedBy"].ToString(),
                                ModifiedBy = reader["ModifiedBy"].ToString()
                            });
                        }
                    }
                }
            }
            return Brands; // Return the list of categories
        }
        // Update Active to false method
        //public int DeactivateById(int id, string modifiedBy)
        //{
        //    string query = @"UPDATE ProductCategory
        //                 SET Active = 0, 
        //                     ModifiedDate = @ModifiedDate, 
        //                     ModifiedBy = @ModifiedBy
        //                 WHERE UId = @UId";

        //    SqlParameter[] parameters = new SqlParameter[]
        //    {
        //    new SqlParameter("@ModifiedDate", DateTime.Now),
        //    new SqlParameter("@ModifiedBy", modifiedBy),
        //    new SqlParameter("@UId", id)
        //    };

        //    return ExecuteNonQuery(query, parameters);
        //}

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
