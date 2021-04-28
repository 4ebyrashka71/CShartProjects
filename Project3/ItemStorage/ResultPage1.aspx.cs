using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static DataProvider;

namespace ItemStorage
{
    public partial class ResultPage1 : System.Web.UI.Page
    {
        class ResultItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Average { get; set; }
        }
        /// <summary>
        /// we check if out lists and dictionaries are not empty,
        /// after that we check if values was chosen, convert then and go through dictionary
        /// if we found the right id, date and price we add deliveries to the sum
        /// after that we set the table with found values and count average of the deliveries
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Deliveries?.Count > 0 && Goods?.Count > 0)
            {
                if (!IsPostBack && Session.Keys.OfType<string>().Contains("id") && Session.Keys.OfType<string>().Contains("price"))
                {
                    int sentId = Convert.ToInt32(Session["id"]);
                    int price = Convert.ToInt32(Session["price"]);
                    int sum = 0;
                    int counter = 0;
                    foreach (var el in Deliveries)
                    {
                        if (el.Id == sentId && el.Date.Year == 2020 && el.Date.Month > 6 && el.Price >= price)
                        {
                            sum += el.SizeDeliveries;
                            counter++;
                        }
                    }
                    if (counter > 0)
                    {
                        var resultList = new List<ResultItem>();
                        resultList.Add(new ResultItem
                        {
                            Id = sentId,
                            Name = Goods[sentId].Name,
                            Average = sum / counter
                        });
                        ResultGridView.DataSource = resultList;
                        ResultGridView.DataBind();
                    }
                    else
                        Response.Write(@"<script>alert('No solution')</script>");
                }
                else
                    Response.Write(@"<script>alert('Undefined sentId')</script>");
            }
            else
                Response.Write("<script>alert('Data are missing')</script>");

        }
    }
}