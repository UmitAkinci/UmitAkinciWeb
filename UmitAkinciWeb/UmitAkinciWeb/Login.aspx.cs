using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UmitAkinciWeb
{
    public partial class Login : System.Web.UI.Page
    {
        KullaniciContext kc = new KullaniciContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label3.Visible = false;
            if (!IsPostBack)
            {
                var act = Request.QueryString["act"] == null ? "" : Request.QueryString["act"];
                if (act.ToLower() == "loggoff")
                {
                    Session["UserInfo"] = null;
                }
            }
        }
        protected void txt_sifre_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btn_giris_Click1(object sender, EventArgs e)
        {
            var user = kc.GetKullanici(txt_kullaniciAdi.Text, txt_sifre.Text);
            if (user != null)
            {
                Session["UserInfo"] = user;
                Session["KullaniciAdi"] = txt_kullaniciAdi.Text;
                Response.Redirect("YoneticiPaneli.aspx");

            }
            else
            {
                Label3.ForeColor = System.Drawing.Color.Red;
                Label3.Text = "Kullanıcı adı veya şifre geçersiz!";
                Label3.Visible = true;
                Session["UserInfo"] = null;
            }

        }
    }
}