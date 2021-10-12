using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingWeb.Models
{
    public class tOrderDetail
    {
        [DisplayName("訂單明細編號")]
        [Required]
        public int fId { get; set; }

        [DisplayName("產品編號")]
        [Required]
        public int fPId { get; set; }

        [DisplayName("會員帳號")]
        [Required]
        public string fUserId { get; set; }

        [DisplayName("品名")]
        [Required]
        public string fName { get; set; }

        [DisplayName("單價")]
        [Required]
        public int fPrice { get; set; }

        [DisplayName("訂購數量")]
        [Required]
        public int fQty { get; set; }

        [DisplayName("是否為訂單")]
        [Required]
        public bool fIsApproved { get; set; }
    }
}