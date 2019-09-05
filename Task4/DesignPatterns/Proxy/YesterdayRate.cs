using System;
using System.Collections.Generic;

namespace Proxy
{
    public class YesterdayRate : IYesterdayRate
    {
        public List<string> GetRate()
        {
            var random = new Random();
            return new List<string>()
            {
                $"Dollar - {random.Next(200, 230) / (double) 100}",
                $"Euro - {random.Next(220, 250) / (double) 100}",
                $"Pound - {random.Next(250, 280) / (double) 100}"
            };
        }
    }
}
