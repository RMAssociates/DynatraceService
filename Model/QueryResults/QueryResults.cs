using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynatraceService.Model.QueryResults
{
    //public class QueryResults
    //{
    //}
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class EntityResult
    {
        public List<string> dimensions { get; set; }
        public List<long> timestamps { get; set; }
        public List<int> values { get; set; }
    }

    public class Result
    {
        public string metricId { get; set; }
        public List<EntityResult> data { get; set; }
    }

    public class QueryResults
    {
        public int totalCount { get; set; }
        public object nextPageKey { get; set; }
        public List<Result> result { get; set; }
    }
}
