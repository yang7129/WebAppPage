using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PageWcfService
{
    // 注意: 您可以使用 [重構] 功能表上的 [重新命名] 命令同時變更程式碼、svc 和組態檔中的類別名稱 "Service1"。
    // 注意: 若要啟動 WCF 測試用戶端以便測試此服務，請在 [方案總管] 中選取 Service1.svc 或 Service1.svc.cs，然後開始偵錯。
    public class Service1 : IService1
    {
        public QuerykisokBuy TESTData(InQuerykisokBuy Input)
        {
            QuerykisokBuy QuerykisokBuy = new QuerykisokBuy();

            QuerykisokBuy.ReturnMsgNo = 1;
            QuerykisokBuy.ReturnMsg = Input.kisokBuyNum;

            List<kisokDataQuery> kisokDataQueryList = new List<kisokDataQuery>();
            for (int i = 0; i < 76; i++)
            {
                kisokDataQueryList.Add(new kisokDataQuery()
                {
                    BuyNum = Convert.ToString(i).PadLeft(5, '0'),
                    ProductName = "BuyPhoneNum" + i,
                    BuyCount = Convert.ToString(10 + i),
                    BuyAmount = Convert.ToString((i + 1) * 100),
                    BuyPhoneNum = "0987654321"
                });
            }
            int row = Input.row;
            int page = Input.nextpage ?? 1;
            page = page == 0 ? 1 : page;

            QuerykisokBuy.kisokDataQueryList = kisokDataQueryList.Skip(page == 1 ? 0 : ((page - 1) * row)).Take(row).ToList();
            if ((kisokDataQueryList.Count % row) == 0)
            {
                QuerykisokBuy.TotalPageCount = (kisokDataQueryList.Count / row);
            }
            else
            {
                QuerykisokBuy.TotalPageCount = (kisokDataQueryList.Count / row) + 1;
            }
            QuerykisokBuy.nowpage = page;


            return QuerykisokBuy;
        }
    }
}
