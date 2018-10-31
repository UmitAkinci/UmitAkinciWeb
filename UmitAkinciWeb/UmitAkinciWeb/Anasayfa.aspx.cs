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
    public partial class Anasayfa : System.Web.UI.Page
    {
        KategoriContext kc = new KategoriContext();
        MakaleContext mc = new MakaleContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetCategoryData();
                SonMakaleBaslikGetir();
                SonMakaleIcerikGetir();
                SonMakaleTarihGetir();
                GetSonOnMakaleBaslikData();
            }

        }
        public void GetCategoryData()
        {
            var dt = kc.GetCategoryList();
            Utils.BindMenu(Menu1, dt, "KategoriAdi", "KategoriAdi");
        }
        public void GetSonOnMakaleBaslikData()
        {
            var dt = mc.GetSonOnMakaleBaslikList();
            Utils.BindMenu(Menu2, dt, "MakaleBaslik", "MakaleBaslik");
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            string secilenKategori = Menu1.SelectedItem.Text;
            if(secilenKategori != null)
            {
                Session["KategoriInfo"] = secilenKategori;
                Response.Redirect("Makale.aspx");
            }
        }
        public DataTable GetSelectedCategoryData(string kategoriAdi)
        {
            var dt = kc.GetSelectedCategory(kategoriAdi);
            return dt;
        }
        public void SonMakaleBaslikGetir()
        {
            var dt = mc.GetSonMakaleBaslik();
            Utils.BindLabel(lbl_makaleBaslik, dt, "MakaleBaslik", "MakaleBaslik");
        }
        public void SonMakaleIcerikGetir()
        {
            var dt = mc.GetSonMakaleIcerik();
            Utils.BindLabel(lbl_makaleIcerik, dt, "MakaleIcerik", "MakaleIcerik");
        }
        public void SonMakaleTarihGetir()
        {
            var dt = mc.GetSonMakaleTarih();
            Utils.BindLabel(lbl_makaleTarih, dt, "MakaleEklenmeTarihi", "MakaleEklenmeTarihi");
        }
        public void SecilenMakaleBaslikGetir(string secilenMakale)
        {
            var dt = mc.SecilenMakaleBaslikAl(secilenMakale);
            Utils.BindLabel(lbl_makaleBaslik, dt, "MakaleBaslik", "MakaleBaslik");
        }
        public void SecilenMakaleTarihGetir(string secilenMakale)
        {
            var dt = mc.SecilenMakaleTarihAl(secilenMakale);
            Utils.BindLabel(lbl_makaleTarih, dt, "MakaleEklenmeTarihi", "MakaleEklenmeTarihi");
        }
        public void SecilenMakaleIcerikGetir(string secilenMakale)
        {
            var dt = mc.SecilenMakaleIcerikAl(secilenMakale);
            Utils.BindLabel(lbl_makaleIcerik, dt, "MakaleIcerik", "MakaleIcerik");
        }

        protected void Menu2_MenuItemClick(object sender, MenuEventArgs e)
        {
            string secilenMakale = Menu2.SelectedItem.Text;
            SecilenMakaleBaslikGetir(secilenMakale);
            SecilenMakaleIcerikGetir(secilenMakale);
            SecilenMakaleTarihGetir(secilenMakale);

        }
        protected void btn_hakkimda_Click(object sender, EventArgs e)
        {
            Response.Redirect("Hakkimda.aspx");
        }

        protected void btn_iletisim_Click(object sender, EventArgs e)
        {
            Response.Redirect("Iletisim.aspx");
        }
    }
}