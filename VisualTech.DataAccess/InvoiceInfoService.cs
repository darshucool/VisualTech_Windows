using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using VisualTech.Domain;

namespace VisualTech.DataAccess
{
    public class InvoiceInfoService : CoreService
    {
        private readonly string _connectionString;

        public InvoiceInfoService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        }
        public DataTable GetInvoiceHeaderById(int invoiceId)
        {
            string query = @"
        SELECT 
            UId,
            CustomerId,
            InvoiceDate,
            InvoiceNo,
            Discount,
            Total,
            GrandTotal,
            CustomerName,
            PaidAmount,
            InvoiceTypeId   
        FROM InvoiceInfo
        WHERE UId = @InvoiceId";

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
        public InvoiceHeaderReportModel GetInvoiceHeaderModelById(int invoiceId)
        {
            string query = @"
SELECT 
    I.UId,
    I.CustomerId,
    I.InvoiceDate,
    I.InvoiceNo,
    I.Discount,
    I.Total,
    I.GrandTotal,
    I.CustomerName,
    I.PaidAmount,
    I.InvoiceTypeId,
    ISNULL(C.CurrentBalance, 0) AS DueAmount
FROM InvoiceInfo I
LEFT JOIN Customer C ON I.CustomerId = C.UId
WHERE I.UId = @InvoiceId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@InvoiceId", invoiceId);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new InvoiceHeaderReportModel
                        {
                            UId = Convert.ToInt32(reader["UId"]),
                            CustomerId = reader["CustomerId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["CustomerId"]),
                            InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"]),
                            InvoiceNo = Convert.ToString(reader["InvoiceNo"]),
                            Discount = reader["Discount"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Discount"]),
                            Total = reader["Total"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Total"]),
                            GrandTotal = reader["GrandTotal"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["GrandTotal"]),
                            CustomerName = Convert.ToString(reader["CustomerName"]),
                            PaidAmount = reader["PaidAmount"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["PaidAmount"]),
                            InvoiceTypeId = reader["InvoiceTypeId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["InvoiceTypeId"]),
                            DueAmount = reader["DueAmount"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["DueAmount"])
                        };
                    }
                }
            }

            return null;
        }
        public int Insert(InvoiceInfo invoice)
        {
            string query = @"
                INSERT INTO InvoiceInfo
                (
                    CustomerId,
                    InvoiceDate,
                    Status,
                    Active,
                    CreatedDate,
                    CreatedBy,
                    InvoiceTypeId,
                    InvoiceNo,
                    InvoiceLine1,
                    InvoiceLine2,
                    Discount,
                    Total,
                    GrandTotal,
                    CustomerName,
                    PaidAmount
                )
                VALUES
                (
                    @CustomerId,
                    @InvoiceDate,
                    @Status,
                    @Active,
                    @CreatedDate,
                    @CreatedBy,
                    @InvoiceTypeId,
                    @InvoiceNo,
                    @InvoiceLine1,
                    @InvoiceLine2,
                    @Discount,
                    @Total,
                    @GrandTotal,
                    @CustomerName,
                    @PaidAmount
                );
                SELECT SCOPE_IDENTITY();";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CustomerId", (object)invoice.CustomerId ?? DBNull.Value),
                new SqlParameter("@InvoiceDate", invoice.InvoiceDate),
                new SqlParameter("@Status", invoice.Status),
                new SqlParameter("@Active", invoice.Active),
                new SqlParameter("@CreatedDate", invoice.CreatedDate),
                new SqlParameter("@CreatedBy", invoice.CreatedBy ?? ""),
                new SqlParameter("@InvoiceTypeId", invoice.InvoiceTypeId),
                new SqlParameter("@InvoiceNo", invoice.InvoiceNo ?? ""),
                new SqlParameter("@InvoiceLine1", invoice.InvoiceLine1 ?? ""),
                new SqlParameter("@InvoiceLine2", invoice.InvoiceLine2 ?? ""),
                new SqlParameter("@Discount", invoice.Discount),
                new SqlParameter("@Total", invoice.Total),
                new SqlParameter("@GrandTotal", invoice.GrandTotal),
                new SqlParameter("@CustomerName", invoice.CustomerName ?? ""),
                new SqlParameter("@PaidAmount", invoice.PaidAmount)
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

        public int GetNextInvoiceNo()
        {
            string query = "SELECT ISNULL(MAX(InvoiceNo), 0) + 1 FROM InvoiceInfo";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                object result = command.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }
    }
}