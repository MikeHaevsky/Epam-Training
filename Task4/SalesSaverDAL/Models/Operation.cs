using System;
using System.Collections.Generic;

namespace SalesSaverDAL.Models
{
    public partial class Operation
    {
        public int Id { get; set; }
        public System.DateTime Data { get; set; }
        public int ManagerId { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public int Cost { get; set; }
        public virtual Client Client { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Product Product { get; set; }
    }
}
