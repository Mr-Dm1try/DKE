using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Output
{
    public class OutputSchema
    {
        public bool IsOk { get; set; }
        public long Price { get; set; }
        public long FullPrice { get; set; }
        public List<OutputEntry> OutputEnties { get; set; }
    }
}
