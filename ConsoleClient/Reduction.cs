using DataModel;
using DataModel.Input;
using DataModel.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleClient
{
    class Reduction
    {
        public OutputSchema GetReduction(InputSchema requests)
        {
            var response = new OutputSchema();

            requests.SellEntries = requests.BuyEntries.OrderBy(b => b.Value).ThenByDescending(b => b.IsMarket).ToList();
            requests.BuyEntries = requests.BuyEntries.OrderByDescending(b => b.Value).ThenBy(b => b.IsMarket).ToList();

            while(requests.SellEntries.Count() > 0 || requests.BuyEntries.Count() > 0)
            {
                var sell = requests.SellEntries.FirstOrDefault();
                var buy = requests.BuyEntries.FirstOrDefault();
                var output = new OutputEntry();
                output.BuyOrderId = buy.Id;
                output.SellOrderId = sell.Id;

                if (sell.Volume > buy.Volume)
                {
                    output.Value = buy.Value;
                    output.Volume = buy.Volume;
                    sell.Volume -= buy.Volume;

                    response.OutputEnties.Add(output);

                    requests.BuyEntries.Remove(buy);
                }
                else
                {
                    output.Value = buy.Value;
                    output.Volume = sell.Volume;
                    buy.Volume -= sell.Volume;

                    response.OutputEnties.Add(output);

                    requests.SellEntries.Remove(sell);
                }
            }

            response.IsOk = true;
            return response;
        }
    }
}
