using DynatraceService.Model.QueryResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynatraceService.Model
{
    //If the column type is 'timeofday', the value is an array of four numbers: [hour, minute, second, milliseconds].
    public class TimeSeries
    {
        public List<string> DayRequestCountSeries(EntityResult e)
        {
            var result = new List<string>();

            for (int i = 0; i < e.timestamps.Count; i++)
            {
                result.Add(LineSeries(e.timestamps[i], e.values[i]));
            }
            return result;
        }

        private string LineSeries(long timestamp, int value)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(timestamp);
            DateTime dt = dateTimeOffset.LocalDateTime;
            var dateString = $"[{dt.Hour},{dt.Minute},{dt.Second},{dt.Millisecond}]";
            var result = $"{dateString}, {value.ToString()}";
            return result;
        }
    }
}
