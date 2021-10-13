using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingWeb.Models
{
    public class tOrder
    {
        [DisplayName("訂單編號")]
        [Required]
        public int fId { get; set; }

        [DisplayName("會員帳號")]
        [Required]
        public string fUserId { get; set; }

        [DisplayName("收件人姓名")]
        [Required]
        public string fReceiver { get; set; }

        [DisplayName("收件人信箱")]
        [EmailAddress]
        [Required]
        public string fEmail { get; set; }

        [DisplayName("收件人地址")]
        [Required]
        public string fAddress { get; set; }

        [DisplayName("訂單日期")]
        [Required]
        public DateTime fDate { get; set; }
    }
}