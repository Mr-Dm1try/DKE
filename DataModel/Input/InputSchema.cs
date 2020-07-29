using DataModel.Input;
using System;
using System.Collections.Generic;

namespace DataModel
{
    public class InputSchema
    {
        public List<InputEntry> BuyEntries { get; set; }
        public List<InputEntry> SellEntries { get; set; }
    }
}
