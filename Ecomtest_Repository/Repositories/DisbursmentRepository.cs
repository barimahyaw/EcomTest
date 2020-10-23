using Ecomtest_Repository.Entities;
using Ecomtest_Repository.IRepositories;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Ecomtest_Repository.Repositories
{
    public class DisbursmentRepository : ConnectionString, IDisbursementRepository
    {
        /// <summary>
        /// Saves disbursement too database
        /// </summary>
        /// <param name="disbursement"></param>
        /// <returns>number of roles affected</returns>
        public async Task<int> AddDisbursementAsync(Disbursement_Dtl disbursement)
        {
            using (var con = new System.Data.SqlClient.SqlConnection(Cs))
            {
                Cmd.Connection = con;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "Insert Into Disbursement_Dtl (Cust_Code, Cust_Name,Disb_Date,Disb_Amount,Int_Rate,Months,EMS_St_Date)" +
                        "Values(@Cust_Code,@CustomerName,@DisbursementDate,@DisbursementAmount,@InterestRate,@Months,@EMS_St_Date)";

                Cmd.Parameters.AddWithValue("@Cust_Code", disbursement.Cust_Code);
                Cmd.Parameters.AddWithValue("@CustomerName", disbursement.Cust_Name);
                Cmd.Parameters.AddWithValue("@DisbursementDate", disbursement.Disb_Date);
                Cmd.Parameters.AddWithValue("@DisbursementAmount", disbursement.Disb_Amount);
                Cmd.Parameters.AddWithValue("@InterestRate", disbursement.Int_Rate);
                Cmd.Parameters.AddWithValue("@Months", disbursement.Months);
                Cmd.Parameters.AddWithValue("@EMS_St_Date", disbursement.EMS_St_Date);

                await con.OpenAsync();
                return await Cmd.ExecuteNonQueryAsync();
            }
        }
        /// <summary>
        /// Gets the last Customer Code from database
        /// </summary>
        /// <returns>Customer Code as integer value</returns>
        public async Task<int> GetCustomerCodeAsync()
        {
            using (var con = new System.Data.SqlClient.SqlConnection(Cs))
            {
                Cmd.Connection = con;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "Select top(1) Cust_Code From Disbursement_Dtl Order By Cust_Code desc";

                await con.OpenAsync();
                var rdr = await Cmd.ExecuteReaderAsync();

                var i = 0;
                if(await rdr.ReadAsync())
                {
                    i = Convert.IsDBNull(rdr["Cust_Code"]) ? 0 : Convert.ToInt32(rdr["Cust_Code"]);
                }
                ConnectionDispose();
                return i;
            }
        }
    }
}