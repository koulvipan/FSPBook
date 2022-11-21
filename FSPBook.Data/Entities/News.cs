using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSPBook.Data.Entities
{
    public class News
    {
        public datas[] data { get; set; }
    }
    public class datas
    {
        public string title { get; set; }
        public string published_at { get; set; }
        public string url { get; set; }
    }
}
