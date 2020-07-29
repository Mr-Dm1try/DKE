using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Output
{
    public class OutputEntry
    {
        public int BuyOrderId { get; set; }
        public int SellOrderId { get; set; }
        public long Volume { get; set; }
        public long Value { get; set; }
    }
}
