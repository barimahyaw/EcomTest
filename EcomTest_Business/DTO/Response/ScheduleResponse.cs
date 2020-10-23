using System;
using System.Collections.Generic;
using System.Text;

namespace EcomTest_Business.DTO.Response
{
    public class ScheduleResponse
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
