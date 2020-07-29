using DataModel.Input;

using System;
using System.IO;
using System.Text;

namespace CsvHelper
{
    public static class InputDeserialization
    {
        public static InputSchema DeserializeFile(string filePath)
        {
            var result = new InputSchema
            {
                BuyEntries = new System.Collections.Generic.List<InputEntry>(),
                SellEntries = new System.Collections.Generic.List<InputEntry>()
            };

            using StreamReader sr = new StreamReader(filePath);
            int id = 1;
            while (!sr.EndOfStream)
            {                
                var line = sr.ReadLine();
                var array = line.Split(',');
                var entry = new InputEntry
                {
                    Id = id,
                    IsBuy = true,
                    IsMarket = array[1].Trim().ToLower() == "m",
                    Volume = long.Parse(array[2].Trim().ToLower())
                };
                entry.Value = entry.IsMarket ? -1 : long.Parse(array[3].Trim().ToLower());

                if (entry.IsBuy)
                    result.BuyEntries.Add(entry);
                else
                    result.SellEntries.Add(entry);
                
                id++;
            }

            return result;
        }
    }
}
