using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UmitAkinciWeb.Business;

namespace UmitAkinciWeb
{
    public partial class Kategori : System.Web.UI.Page
    {
        KategoriContext kc = new KategoriContext();
        MakaleContext mc = new MakaleContext();
        YorumContext yc = new YorumContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCategoryData();
                if(Session["KategoriInfo"]!=null)
                {
                    string secilenKategori = Session["KategoriInfo"].ToString();
                    lbl_kategoriAdi.Text = secilenKategori+ " MAKALELERİ";
                    GetMakaleBaslikData(secilenKategori);
                    SonMakaleBaslikGetir(secilenKategori);
                    SonMakaleIcerikGetir(secilenKategori);
                    SonMakaleTarihGetir(secilenKategori);
                    BindDataList();

                }
                else
                {
                    Response.Redirect("Anasayfa.aspx");
                }
            }
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            string secilenMakale = Menu1.SelectedItem.Text;
            MakaleIcerikGetir(secilenMakale);
            MakaleEklenmeTarihiGetir(secilenMakale);
            MakaleBaslikGetir(secilenMakale);
        }
        public void GetCategoryData()
        {
            var dt = kc.GetCategoryList();
            Utils.BindMenu(Menu2, dt, "KategoriAdi", "KategoriAdi");
        }
        private void GetMakaleBaslikData(string secilenKategori)
        {

            DataTable dt = kc.GetMakaleBaslikList(secilenKategori);
            Utils.BindMenu(Menu1, dt, "MakaleBaslik", "MakaleBaslik");
        }
        private void MakaleBaslikGetir(string secilenMakale)
        {
            DataTable dt = kc.GetMakaleBaslik(secilenMakale);
            Utils.BindLabel(lbl_makaleBaslik, dt, "MakaleBaslik", "MakaleBaslik");
        }
        private void MakaleIcerikGetir(string secilenMakale)
        {
            var dt = mc.GetSelectMakaleIcerik(secilenMakale);
            Utils.BindLabel(lbl_makaleIcerik, dt, "MakaleIcerik", "MakaleIcerik");
        }
        private void MakaleEklenmeTarihiGetir(string secilenMakale)
        {
            var dt = mc.GetSelectMakaleIcerik(secilenMakale);
            Utils.BindLabel(lbl_makaleTarih, dt, "MakaleEklenmeTarihi", "MakaleEklenmeTarihi");
        }
        private bool AlanlariKontorlEt()
        {
            if (txt_adi.Text.Trim() == "" || txt_eposta.Text.Trim() == "" || txt_yorum.Text.Trim() == "")
            {
                return false;
            }
            return true;
        }

        protected void btn_gonder_Click(object sender, EventArgs e)
        {
            bool kontrol = AlanlariKontorlEt();
            string metin = Convert.ToString(txt_eposta.Text);
            int i = metin.IndexOf("@");//indexof,aranan karakterin indeksini döndürür                      //eğer yoksa -1 döndürür
            if (i == -1)                         //eğer yoksa -1 döndürür
            {
                Response.Write("<script language='javascript'>alert('Lütfen geçerli bir e-posta giriniz!');</script>");
            }

            else
            {
                if (kontrol)
                {

                    DateTime yorumTarihi = DateTime.Now;
                    String.Format("{0:d dd ddd dddd}", yorumTarihi);
                    DataRow dr = mc.GetSelectedMakaleId(lbl_makaleBaslik.Text);
                    int makaleId = Utils.ConvertToInt(dr["MakaleID"].ToString());
                    yc.Insert(txt_yorum.Text, txt_adi.Text, txt_eposta.Text, yorumTarihi,"Onaylanmadi",makaleId);
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('Lütfen alanları kontrol ediniz!');</script>");
                }
            }
        }

        protected void Menu2_MenuItemClick(object sender, MenuEventArgs e)
        {
            Menu1.Items.Clear();
            string secilenKategori = Menu2.SelectedItem.Text;
            lbl_kategoriAdi.Text = Menu2.SelectedItem.Text + " MAKALELERİ";
            GetMakaleBaslikData(secilenKategori);;
            SonMakaleBaslikGetir(secilenKategori);
            SonMakaleIcerikGetir(secilenKategori);
            SonMakaleTarihGetir(secilenKategori);
        }
        public void SonMakaleBaslikGetir(string secilenKategori)
        {
            DataTable dt = mc.GetSonMakaleBaslik(secilenKategori);
            Utils.BindLabel(lbl_makaleBaslik, dt, "MakaleBaslik", "MakaleBaslik");
        }
        public void SonMakaleIcerikGetir(string secilenKategori)
        {
            DataTable dt = mc.GetSonMakaleIcerik(secilenKategori);
            Utils.BindLabel(lbl_makaleIcerik, dt, "MakaleIcerik", "MakaleIcerik");
        }
        public void SonMakaleTarihGetir(string secilenKategori)
        {
            DataTable dt = mc.GetSonMakaleTarih(secilenKategori);
            Utils.BindLabel(lbl_makaleTarih, dt, "MakaleEklenmeTarihi", "MakaleEklenmeTarihi");
        }
       public void BindDataList()
        {
            DataTable dt = yc.GetYorumList();
            DataList1.DataSource = dt;
            DataList1.DataBind();
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