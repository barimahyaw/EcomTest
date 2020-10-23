using System;
using System.ComponentModel.DataAnnotations;

namespace EcomTest_Business.DTO.Request
{
    public class DisbursementRequest
    {
        [Required(ErrorMessage = "Customer Name is Required.")]
        [Display(Name = "Customer Name")]
        public string Cust_Name { get; set; }
        [Required(ErrorMessage = "Disbursement date is Required.")]
        [Display(Name = "Disbursement Date")]
        public DateTime Disb_Date { get; set; }
        [Required(ErrorMessage = "Disbursement amount is Required.")]
        [Display(Name = "Disbursement Amount")]
        public float Disb_Amount { get; set; }
        [Required(ErrorMessage = "Interest rate is Required.")]
        [Display(Name = "Interest Rate")]
        public float Int_Rate { get; set; }
        [Required(ErrorMessage = "Specify the number of Months")]
        [Display(Name = "No. of Months")]
        public int Months { get; set; }
        [Required(ErrorMessage = "Specify EMI Start date")]
        [Display(Name = "EMI Start date")]
        public DateTime EMS_St_Date { get; set; }
    }
}
