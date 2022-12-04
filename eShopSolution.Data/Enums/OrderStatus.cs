using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eShopSolution.Data.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "Phòng trống")]
        InProgress,
        [Display(Name = "Phòng đầy")]
        Confirmed,
        Shipping,
        Success,
        Canceled
    }
}
