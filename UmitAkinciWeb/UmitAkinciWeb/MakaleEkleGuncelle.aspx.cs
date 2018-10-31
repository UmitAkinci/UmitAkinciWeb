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
    public partial class MakaleEkleGuncelle : System.Web.UI.Page
    {
        MakaleContext mc = new MakaleContext();
        KategoriContext kc = new KategoriContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid(0);
            KategoriDoldur();
            string valueDropDown = Request.Form["DropDownList1"];
            DropDownList1.Text = valueDropDown;
            if(!IsPostBack)
            {
                if(Session["UserInfo"]==null)
                {
                    Response.Redirect("Login.aspx");
                }
                var id = Utils.ConvertToInt(Request.QueryString["MakaleID"]);
                if (id > 0)
                {
                    btn_ekleGuncelle.Text = "Güncelle";
                    DataRow dr = mc.SelectItem(id);
                    txt_makaleBaslik.Text = dr["MakaleBaslik"].ToString();
                    txt_makaleIcerik.Text = dr["MakaleIcerik"].ToString();
                }
            }
        }

        protected void btn_ekleGuncelle_Click(object sender, EventArgs e)
        {
            if(txt_makaleBaslik.Text.Trim()==""||txt_makaleIcerik.Text.Trim()==""|| DropDownList1.SelectedValue=="-1")
            {
                Response.Write("<script language='javascript'>alert('Lütfen alanları kontrol ediniz.');</script>");
            }
            else
            {
                if (btn_ekleGuncelle.Text == "EKLE")
                {
                    DateTime dateTime = DateTime.Now;
                    mc.Insert(txt_makaleBaslik.Text, txt_makaleIcerik.Text, dateTime);
                    DataRow drMakale = mc.GetSonMakaleId();
                    int sonMakaleId = Utils.ConvertToInt(drMakale["MakaleID"].ToString());
                    DataRow drKategori = kc.GetKategoriId(DropDownList1.Text);
                    int kategoriId = Utils.ConvertToInt(drKategori["KategoriID"].ToString());
                    mc.InsertMakaleKategori(sonMakaleId, kategoriId);
                    Response.Write("<script language='javascript'>alert('Ekleme işlemi başarıyla gerçekleşti.');</script>");
                }
                else
                {
                    var id = Utils.ConvertToInt(Request.QueryString["MakaleID"]);
                    DateTime dateTime = DateTime.Now;
                    mc.Update(id, txt_makaleBaslik.Text, txt_makaleIcerik.Text, dateTime);
                    Response.Write("<script language='javascript'>alert('Güncelleme işlemi başarıyla gerçekleşti.');</script>");

                    btn_ekleGuncelle.Text = "EKLE";
                }
                BindGrid(0);
                txt_makaleIcerik.Text = "";
                txt_makaleBaslik.Text = "";
            }

        }
        public void BindGrid(int pageIndex)
        {
            DataTable dt = mc.GetOrderByMakaleList();
            GridView1.PageIndex = pageIndex;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        public void KategoriDoldur()
        {
            DataTable dt = kc.GetCategoryList();
            Utils.BindDdl(DropDownList1, dt, "KategoriAdi", "KategoriAdi",true);
        }
    }
}