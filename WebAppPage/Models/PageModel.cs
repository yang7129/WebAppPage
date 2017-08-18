using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppPage.Models
{
    public class PageModel
    {
        public string Num { get; set; }
        public List<DataQuery> DataQueryList { get; set; }
        public int nextPage { get; set; }
        public int TotalPageCount { get; set; }
        public PageModel()
        {
            Num = "";
            DataQueryList = new List<DataQuery>();
            nextPage = 0;
            TotalPageCount = 0;
        }
    }
    public class DataQuery
    {
        public string BuyNum { get; set; }
        public string ProductName { get; set; }
        public string BuyCount { get; set; }
        public string BuyAmount { get; set; }
        public string BuyPhoneNum { get; set; }
    }
}