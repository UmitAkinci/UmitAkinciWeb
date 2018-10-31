using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UmitAkinciWeb.Business;

namespace UmitAkinciWeb
{
    public partial class Yorumlar : System.Web.UI.Page
    {
        YorumContext yc = new YorumContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid(0);
            if (!IsPostBack)
            {
                if (Session["UserInfo"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                int id = Utils.ConvertToInt(Request.QueryString["YorumID"]);
                if (id > 0)
                {
                    DataRow dr = yc.SelectItem(id);
                    DropDownList1.SelectedValue = dr["YorumOnay"].ToString();
                }
            }
        }
        private void BindGrid(int pageIndex)
        {
            DataTable dt = yc.GetYorumList();
            GridView1.PageIndex = pageIndex;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btn_tamam_Click(object sender, EventArgs e)
        {
            var id = Utils.ConvertToInt(Request.QueryString["YorumID"]);
            yc.Update(id, DropDownList1.SelectedValue);
            Response.Write("<script language='javascript'>alert('Güncelleme işlemi başarıyla gerçekleşti.');</script>");
            BindGrid(0);
        }
    }
}