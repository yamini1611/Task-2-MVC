using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task_2.Models
{
    public class Product
    {
       

        [Required(ErrorMessage ="Enter Product id")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Enter Product name")]
     
        public string PName { get; set; }

        [Required(ErrorMessage ="Price is required")]
        [Range(20 ,4500 ,ErrorMessage ="Price is not in a range for valid purchase")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Customer name  is required")]
        public  string Cusname { get; set; }
        [MaxLength(10, ErrorMessage = "Mobile Number must be 10 digits")]
        [MinLength(10, ErrorMessage = "Mobile Number must be 10 digits")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Mobile Number must be numeric")]
        [Required(ErrorMessage = "Mobile Number is required")]
        public string CustomerPhoneNumber { get; set; }

        //[ DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; }
    }
}