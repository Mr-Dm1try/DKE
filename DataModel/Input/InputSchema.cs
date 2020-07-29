using System;
using System.Collections.Generic;

namespace DataModel
{
    public class InputSchema
    {
        List<InputEntry> BuyEntries { get; set; }
        List<InputEntry> SellEntries { get; set; }
    }
}
