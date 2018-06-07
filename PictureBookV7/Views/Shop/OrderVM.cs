using PictureBookV7.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PictureBookV7.Views.Shop
{
    public class OrderVM
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }

        public OrderVM()
        {
        }

        public OrderVM(OrderDTO row)
        {
            OrderId = row.OrderId;
            UserId = row.UserId;
            DateCreated = row.DateCreated;
        }
    }
}