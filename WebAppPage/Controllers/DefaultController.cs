using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppPage.Models;

namespace WebAppPage.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {

            PageModel mode = new PageModel();
            return View(mode);
        }
        [HttpPost]
        public ActionResult Index(PageModel mode)
        {
            Page_WCF.Service1Client KisokService = new Page_WCF.Service1Client();
            Page_WCF.InQuerykisokBuy InQuerykisokBuy = new Page_WCF.InQuerykisokBuy() { kisokBuyNum = mode.Num, row = 11, nextpage = mode.nextPage };
            Page_WCF.QuerykisokBuy QuerykisokBuy = new Page_WCF.QuerykisokBuy();
            try
            {
                QuerykisokBuy = KisokService.TESTData(InQuerykisokBuy);
            }
            catch (Exception ex)
            {

                throw;
            }
            List<DataQuery> kisokDataQueryList = new List<DataQuery>();
            if (QuerykisokBuy.kisokDataQueryList.Length > 0)
            {
                foreach (var item in QuerykisokBuy.kisokDataQueryList)
                {
                    kisokDataQueryList.Add(new DataQuery() { BuyNum = item.BuyNum, ProductName = item.ProductName, BuyCount = item.BuyCount, BuyAmount = item.BuyAmount, BuyPhoneNum = item.BuyPhoneNum });
                }
            }
            mode.DataQueryList = kisokDataQueryList;
            mode.nextPage = QuerykisokBuy.nowpage;
            mode.TotalPageCount = QuerykisokBuy.TotalPageCount;
            return View(mode);
        }
    }
}