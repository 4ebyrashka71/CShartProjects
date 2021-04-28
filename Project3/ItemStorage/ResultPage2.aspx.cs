using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static DataProvider;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        class ResultItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Provider { get; set; }
            public int DeliverySize { get; set; }
        }
        /// <summary>
        /// We check values, find id by name that was selected,
        /// after that we go throgh deliveries by id and find minimum deliveries,
        /// we find provider that has minimum deliveries and set values to the table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Deliveries?.Count > 0 && Goods?.Count > 0)
            {
                if (!IsPostBack && Session.Keys.OfType<string>().Contains("name"))
                {
                    var difId = new List<int>();
                    string sentName = Session["name"].ToString();
                    int minimum = 1000000000;
                    foreach (var finder in Goods)
                    {
                        if (finder.Value.Name == sentName)
                        {
                            difId.Add(finder.Key);

                        }
                    }
                    var least = new Dictionary<string, int>();
                        foreach (var item in Deliveries)
                        {
                            if (difId.Contains(item.Id))
                            {
                                if (least.ContainsKey(item.Name))
                                {
                                    least[item.Name] += 1;
                                }
                                else least[item.Name] = 1;
                        }
                        }
                    string foundName = "";
                    foreach (var item in least)
                    {
                        if(item.Value < minimum)
                        {
                            minimum = item.Value;
                            foundName = item.Key;
                        }
                    }
                    var resultList = new List<ResultItem>();
                    Label2.Text += minimum.ToString();
                        foreach (var item in Deliveries)
                        {
                            if (difId.Contains(item.Id) && item.Name == foundName)
                            {
                                resultList.Add(new ResultItem
                                {
                                    Id = item.Id,
                                    Name = sentName,
                                    Provider = item.Name,
                                    DeliverySize = item.SizeDeliveries
                                }) ;
                            }

                            leastGridView.DataSource = resultList;
                            leastGridView.DataBind();
                        }
                }
            }
            else
                Response.Write("<script>alert('Data are missing')</script>");
        }
    }
}