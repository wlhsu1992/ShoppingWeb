using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ShoppingWeb.Models
{
    public class tProduct
    {
        [DisplayName("產品編號")]
        public int fId { get; set; }

        [DisplayName("品名")]
        public string fName { get; set; }

        [DisplayName("單價")]
        public int fPrice { get; set; }

        [DisplayName("圖示")]
        public string fImg { get; set; }
    }
}