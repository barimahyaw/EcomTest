using System;

namespace Ecomtest_Repository.Entities
{
    public class Schedule_Dtl
    {
        public int Cust_Code { get; set; }
        public int SL_NO { get; set; }
        public DateTime EMI_Date { get; set; }
        public float Total_Amount { get; set; }
        public float Prn_Amount { get; set; }
        public float Int_Amount { get; set; }
        public float Balance { get; set; }
        public DateTime EMS_St_Date { get; set; }
    }
}
