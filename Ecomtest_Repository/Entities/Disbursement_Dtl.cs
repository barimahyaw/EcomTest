using System;

namespace Ecomtest_Repository.Entities
{
    public class Disbursement_Dtl
    {
        public int Cust_Code { get; set; }
        public string Cust_Name { get; set; }
        public DateTime Disb_Date { get; set; }
        public float Disb_Amount { get; set; }
        public float Int_Rate { get; set; }
        public int Months { get; set; }
        public DateTime EMS_St_Date { get; set; }
    }
}
