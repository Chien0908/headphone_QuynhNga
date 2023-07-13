using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace test.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Information { get; set; }
        public Nullable<float> Price { get; set; }
        public Nullable<System.DateTime> DateOfPurChase { get; set; }
        public string AvailabilityStatus { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<int> BrandID { get; set; }
        public string Image { get; set; }
        public Nullable<int> Active { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        
    }
}