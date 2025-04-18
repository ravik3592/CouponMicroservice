﻿using System.ComponentModel.DataAnnotations;

namespace Mango.Services.CouponApi.Models
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }

        [Required]
        public string CouponCode { get; set; }

        [Required]  
        public string CouponDescription { get; set; }

        [Required]
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
