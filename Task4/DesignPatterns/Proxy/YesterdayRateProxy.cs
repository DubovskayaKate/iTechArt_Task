﻿using System.Collections.Generic;
using System.IO;

namespace Proxy
{
    public class YesterdayRateProxy : IYesterdayRate
    {
        private readonly YesterdayRate _yesterdayRate;
        private readonly string _filePath = "rate.log";

        public YesterdayRateProxy(YesterdayRate yesterdayRate)
        {
            _yesterdayRate = yesterdayRate;
        }
        public List<string> GetRate()
        {
            List<string> result = _yesterdayRate.GetRate();
            File.AppendAllLines(_filePath, result);
            return result;
        }
    }
}