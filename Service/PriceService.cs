using Domain;
using System;
using System.Collections.Generic;

namespace Service
{
    public class PriceService: IPriceService
    {
        private double CalculateFinalPrice(InputFormat item)
        {
            var price = item.Category != Category.Clothing && item.Status == Status.Discounted ? item.Price * 0.85 : item.Price;
            if (item.Category == Category.Clothing)
            {
                if (item.Status == Status.Discounted)
                {
                    price = item.Price * 0.8;
                }
                else if (item.Status == Status.Wholesale)
                {
                    price = item.Price;
                }
                else
                {
                    price = item.Price * 0.9;
                }
            }

            return Math.Round(price, 2);
        }

        public List<OutputFormat> processInputRecords(List<InputFormat> inputRecords)
        {
            var outputRecords = new List<OutputFormat>();
            inputRecords.ForEach(inputRecord =>
            {
                if(inputRecord.Status != Status.Discontinued)
                {
                    outputRecords.Add(new OutputFormat { Description = inputRecord.Description, Id = inputRecord.Id, Price = CalculateFinalPrice(inputRecord) });
                }
            });
            return outputRecords;
        }
    }
}
