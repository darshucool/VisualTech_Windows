using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using VisualTech.Domain;

namespace VisualTech.DataAccess
{
    public class InvoiceDetailService : CoreService
    {
        private readonly string _connectionString;

        public InvoiceDetailService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        }
        public DataTable GetInvoiceDetailsByInvoiceId(int invoiceId)
        {
            string query = @"
        SELECT 
            InvoiceId,
            ProductId,
            ItemName,
            Warranty,
            UnitPrice,
            TotalPrice,
            BarcodeDetail,
            Qty
        FROM InvoiceDetail
        WHERE InvoiceId = @InvoiceId";

            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@InvoiceId", invoiceId);
                connection.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }
        public int Insert(InvoiceDetail detail)
        {
            string query = @"
                INSERT INTO InvoiceDetail
                (
                    InvoiceId,
                    ProductId,
                    ItemName,
                    Warranty,
                    UnitPrice,
                    TotalPrice,
                    BarcodeDetail,
                    Active,
                    CreatedDate,
                    CreatedBy,
                    Quantity,
                    Qty
                )
                VALUES
                (
                    @InvoiceId,
                    @ProductId,
                    @ItemName,
                    @Warranty,
                    @UnitPrice,
                    @TotalPrice,
                    @BarcodeDetail,
                    @Active,
                    @CreatedDate,
                    @CreatedBy,
                    @Quantity,
                    @Qty
                );
                SELECT SCOPE_IDENTITY();";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@InvoiceId", detail.InvoiceId),
                new SqlParameter("@ProductId", detail.ProductId),
                new SqlParameter("@ItemName", detail.ItemName ?? ""),
                new SqlParameter("@Warranty", detail.Warranty ?? ""),
                new SqlParameter("@UnitPrice", detail.UnitPrice),
                new SqlParameter("@TotalPrice", detail.TotalPrice),
                new SqlParameter("@BarcodeDetail", detail.BarcodeDetail ?? ""),
                new SqlParameter("@Active", detail.Active),
                new SqlParameter("@CreatedDate", detail.CreatedDate),
                new SqlParameter("@CreatedBy", detail.CreatedBy ?? ""),
                new SqlParameter("@Quantity", detail.Quantity),
                new SqlParameter("@Qty", detail.Qty)
            };

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddRange(parameters);
                connection.Open();
                object result = command.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }
    }
}