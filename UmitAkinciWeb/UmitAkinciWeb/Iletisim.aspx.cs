using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UmitAkinciWeb.Business;

namespace UmitAkinciWeb
{
    public partial class Iletisim : System.Web.UI.Page
    {
        KategoriContext kc = new KategoriContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetCategoryData();
            }
        }

        protected void btn_hakkimda_Click(object sender, EventArgs e)
        {
            Response.Redirect("Hakkimda.aspx");
        }

        protected void btn_iletisim_Click(object sender, EventArgs e)
        {
            Response.Redirect("Iletisim.aspx");
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {

        }
        public void GetCategoryData()
        {
            var dt = kc.GetCategoryList();
            Utils.BindMenu(Menu1, dt, "KategoriAdi", "KategoriAdi");
        }
    }
}