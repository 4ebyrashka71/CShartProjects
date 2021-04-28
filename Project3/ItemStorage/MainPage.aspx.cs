using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static DataProvider;

namespace ItemStorage
{
    class DeliveryInfo
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int SizeDeliveries { get; set; }
        public double Price { get; set; }
    }

    public partial class MainPage : System.Web.UI.Page
    {
        /// <summary>
        /// we check if this page was loaded before
        /// we call the method from out database to parse the data from files
        /// we set default value of the pricebox to zero and select the data from the Goods
        /// after that we go through the List and set data to the new list with structure for out table
        /// after that we set values to our dropdownlists
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ReadData())
                {
                    priceBox.Text = "0";
                    ItemsGridView.DataSource = Goods.Values;
                    var deliveryInfo = new List<DeliveryInfo>();
                    var ids = new SortedSet<int>();
                    foreach (var deliver in Deliveries)
                    {
                        deliveryInfo.Add(new DeliveryInfo
                        {
                            Id = deliver.Id,
                            Date = deliver.Date,
                            Name = deliver.Name,
                            SizeDeliveries = deliver.SizeDeliveries,
                            Price = deliver.Price,
                        });
                        ids.Add(deliver.Id);
                    }
                    DeliveriesGridView.DataSource = deliveryInfo;
                    ItemsGridView.DataBind();
                    DeliveriesGridView.DataBind();
                    idDropDownList.Items.Clear();
                    foreach (var selected in ids)
                    {
                        idDropDownList.Items.Add(selected.ToString());
                    }
                    foreach (var name in Goods)
                    {
                        NameDropDownList.Items.Add(name.Value.Name.ToString());
                    }
                }
            }
        }
        /// <summary>
        /// We read the chosen values  and check if it's not empty
        /// if no exeption raised we go to the resultpage1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Session["id"] = idDropDownList.SelectedValue;
                Session["price"] = priceBox.Text.Trim();
                int trying = Convert.ToInt32(Session["price"]);
                Response.Redirect("ResultPage1.aspx");
            }
            catch
            {
                Response.Write(@"<script>alert('Price not entered')</script>");
            }
        }
        /// <summary>
        /// We set the chosen value and go to the page resultpage2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["name"] = NameDropDownList.SelectedValue;
            Response.Redirect("ResultPage2.aspx");
        }

    }
}