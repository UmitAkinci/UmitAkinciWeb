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
    public partial class YoneticiPaneli : System.Web.UI.Page
    {
        YorumContext yc = new YorumContext();
        MakaleContext mc = new MakaleContext();
        KategoriContext kc = new KategoriContext();
        KullaniciContext kuc = new KullaniciContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["UserInfo"]==null)
                {
                    Response.Redirect("Login.aspx");
                }
                DataRow drYorum = yc.GetYorumCount();
                Label1.Text = drYorum["YorumSayisi"].ToString();
                DataRow drMakale = mc.GetMakaleCount();
                Label2.Text = drMakale["MakaleSayisi"].ToString();
                DataRow drKategori = kc.GetKategoriCount();
                Label3.Text = drKategori["KategoriSayisi"].ToString();
                Label4.Text = "HOŞGELDİN,  "+Session["KullaniciAdi"].ToString();

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}