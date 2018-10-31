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
    public partial class KategoriEkleGuncelle : System.Web.UI.Page
    {
        KategoriContext kc = new KategoriContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid(0);
            if(!IsPostBack)
            {
               if( Session["UserInfo"]== null)
                {
                    Response.Redirect("Login.aspx");
                }
                var id = Utils.ConvertToInt(Request.QueryString["KategoriID"]);
                if (id > 0)
                {
                    btn_ekleGuncelle.Text = "Güncelle";
                    DataRow dr = kc.SelectItem(id);
                    txt_kategoriAdi.Text = dr["KategoriAdi"].ToString();
                    txt_kategoriAciklama.Text = dr["KategoriAciklama"].ToString();
                }
            }

        }

        protected void btn_ekleGuncelle_Click(object sender, EventArgs e)
        {
            if(txt_kategoriAdi.Text.Trim()=="" || txt_kategoriAciklama.Text.Trim()=="")
            {
                Response.Write("<script language='javascript'>alert('Lütfen alanları kontrol ediniz.');</script>");
            }
            else
            {
                if (btn_ekleGuncelle.Text == "EKLE")
                {
                    kc.Insert(txt_kategoriAdi.Text, txt_kategoriAciklama.Text);
                    Response.Write("<script language='javascript'>alert('Ekleme işlemi başarıyla gerçekleşti.');</script>");
                }
                else
                {
                    var id = Utils.ConvertToInt(Request.QueryString["KategoriID"]);
                    kc.Update(txt_kategoriAdi.Text, txt_kategoriAciklama.Text, id);
                    Response.Write("<script language='javascript'>alert('Güncelleme işlemi başarıyla gerçekleşti.');</script>");
                    btn_ekleGuncelle.Text = "EKLE";
                }
                txt_kategoriAdi.Text = "";
                txt_kategoriAciklama.Text = "";
                BindGrid(0);
            }

        }
        private void BindGrid(int pageIndex)
        {
            DataTable dt = kc.GetOrderByCategoryList();
            grd_kategori.PageIndex = pageIndex;
            grd_kategori.DataSource = dt;
            grd_kategori.DataBind();
        }
    }
}