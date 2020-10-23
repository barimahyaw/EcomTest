using Ecomtest_Repository.Entities;
using Ecomtest_Repository.IRepositories;
using System.Data;
using System.Threading.Tasks;
namespace Ecomtest_Repository.Repositories
{
    public class ScheduleRepository : ConnectionString, IScheduleRepository
    {
        /// <summary>
        /// Saves disbursement too database
        /// </summary>
        /// <param name="disbursement"></param>0
        /// <returns>number of roles affected</returns>
        public async Task<int> SaveAsync(Schedule_Dtl schedule)
        {
            using (Cmd.Connection = Conn)
            {
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "Insert Into Schedule_Dtl (SL_NO, Cust_Code,EMI_Date,Total_Amount,Prn_Amount,Int_Amount,Balance,EMI_St_Date)" +
                        "Values(@SL_NO,@Cust_Code,@EMI_Date,@Total_Amount,@Prn_Amount,@Int_Amount,@Balance,@EMI_St_Date)";

                Cmd.Parameters.AddWithValue("@SL_NO", schedule.SL_NO);
                Cmd.Parameters.AddWithValue("@Cust_Code", schedule.Cust_Code);
                Cmd.Parameters.AddWithValue("@EMI_Date", schedule.EMI_Date);
                Cmd.Parameters.AddWithValue("@Total_Amount", schedule.Total_Amount);
                Cmd.Parameters.AddWithValue("@Prn_Amount", schedule.Prn_Amount);
                Cmd.Parameters.AddWithValue("@Int_Amount", schedule.Int_Amount);
                Cmd.Parameters.AddWithValue("@Balance", schedule.Balance);
                Cmd.Parameters.AddWithValue("@EMI_St_Date", schedule.EMS_St_Date);

                await Conn.OpenAsync();
                return await Cmd.ExecuteNonQueryAsync();
            }
        }
    }
}
