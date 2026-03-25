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
    public class ProductService: CoreService
    {
        private readonly string _connectionString;

        public ProductService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        }
        public List<Product> GetAll()
        {
            string query = "SELECT * FROM Product where Active='TRUE' order by CutomerName ASC";
            List<Product> categories = new List<Product>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(new Product
                            {
                                UId = Convert.ToInt32(reader["UId"]),
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString(),
                                CategoryId = Convert.ToInt16(reader["CategoryId"]),
                                SubCatUId = Convert.ToInt16(reader["SubCatUId"]),
                                BrandUId = Convert.ToInt16(reader["BrandUId"]),
                                CostPrice = reader["CostPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["CostPrice"]),
                                SellingPrice = reader["SellingPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["SellingPrice"]),
                                MRPPrice = reader["MRPPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["MRPPrice"]),
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
        public int Insert(Product Product)
        {
            string query = @"INSERT INTO Product (Name,Description,CostPrice,SellingPrice,MRPPrice,BrandUId,SubCatUId,CategoryId, Active, CreatedDate, CreatedBy)
                         VALUES (@Name,@Description,@CostPrice,@MRPPrice,@BrandUId,@BrandUId,@SubCatUId,@CategoryId, @Active, @CreatedDate, @CreatedBy);
                         SELECT SCOPE_IDENTITY();";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Name", Product.Name),
            new SqlParameter("@Description", Product.Description),
            new SqlParameter("@CostPrice", Product.CostPrice),
            new SqlParameter("@SellingPrice", Product.SellingPrice),
            new SqlParameter("@MRPPrice", Product.MRPPrice),
            new SqlParameter("@BrandUId", Product.BrandUId),
            new SqlParameter("@SubCatUId", Product.SubCatUId),
            new SqlParameter("@CategoryId", Product.CategoryId),
            new SqlParameter("@Active", Product.Active),
            new SqlParameter("@CreatedDate", Product.CreatedDate),
            new SqlParameter("@CreatedBy", Product.CreatedBy),
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
        public int Update(Product Product)
        {
            string query = @"UPDATE Product
                         SET Name = @Name, 
                             Description = @Description, 
                             BrandUId = @BrandUId, 
                             CategoryId = @CategoryId, 
                             SubCatUId = @SubCatUId, 
                             CostPrice = @CostPrice, 
                             SellingPrice = @SellingPrice, 
                             MRPPrice = @MRPPrice, 
                             Active = @Active, 
                             ModifiedDate = @ModifiedDate, 
                             ModifiedBy = @ModifiedBy
                         WHERE UId = @UId";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UId", Product.UId),
                new SqlParameter("@Name", Product.Name),
                new SqlParameter("@Description", Product.Description),
                new SqlParameter("@BrandUId", Product.BrandUId),
                new SqlParameter("@CategoryId", Product.CategoryId),
                new SqlParameter("@SubCatUId", Product.SubCatUId),
                new SqlParameter("@CostPrice", Product.CostPrice),
                new SqlParameter("@SellingPrice", Product.SellingPrice),
                new SqlParameter("@MRPPrice", Product.MRPPrice),
                new SqlParameter("@Active", Product.Active),
                new SqlParameter("@ModifiedDate", Product.ModifiedDate),
                new SqlParameter("@ModifiedBy", Product.ModifiedBy),
            };

            return ExecuteNonQuery(query, parameters);
        }

        // Get by UId method
        public Product GetById(int id)
        {
            string query = "SELECT * FROM Product WHERE UId = @UId";
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
                            return new Product
                            {
                                UId = Convert.ToInt32(reader["UId"]),
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString(),
                                CostPrice = reader["CostPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["CostPrice"]),
                                SellingPrice = reader["SellingPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["SellingPrice"]),
                                MRPPrice = reader["MRPPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["MRPPrice"]),
                                BrandUId = Convert.ToInt16(reader["BrandUId"].ToString()),
                                CategoryId = Convert.ToInt16(reader["CategoryId"].ToString()),
                                SubCatUId = Convert.ToInt16(reader["SubCatUId"].ToString()),
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
            string query = @"UPDATE Product
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
            string query = "SELECT P.*,PC.Category as ProductCategory,PS.Category AS Category,B.BrandName AS Brand FROM Product AS P,ProductCategory AS PC,ProductSubCategory PS,Brand AS B WHERE P.Active='TRUE' and P.BrandUId=B.UId and P.CategoryId=PC.UId and P.SubCatUId=PS.UId";
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
        public DataTable LoadDataTableBySearch(string searchStr,SqlParameter[] parameters = null)
        {
            string query = "SELECT P.*,PC.Category as ProductCategory,PS.Category AS Category,B.BrandName AS Brand FROM Product AS P,ProductCategory AS PC,ProductSubCategory PS,Brand AS B WHERE P.Active='TRUE' and P.BrandUId=B.UId and P.CategoryId=PC.UId and P.SubCatUId=PS.UId and P.Name like '%"+ searchStr + "%'";
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
