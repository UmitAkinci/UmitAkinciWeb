using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UmitAkinciWeb.Helpers;

namespace UmitAkinciWeb.Business
{
    public class KategoriContext
    {
        private DbHelper _dbHelper;
        public KategoriContext()
        {
            _dbHelper = new DbHelper();
        }
        public DataTable GetCategoryList()
        {
            string sql = "Select KategoriAdi From Kategori";
            var d = _dbHelper.GetDataTable(sql);
            return d;
        }
        public DataTable GetOrderByCategoryList()
        {
            string sql = "Select KategoriID,KategoriAdi,KategoriAciklama from Kategori order by KategoriID desc";
            var d = _dbHelper.GetDataTable(sql);
            return d;
        }
        public DataTable GetSelectedCategory(string kategoriAdi)
        {
            string sql = "Select * From VwMakaleKategori where KategoriAdi=" + "'" +kategoriAdi+ "'";
            var d = _dbHelper.GetDataTable(sql);
            return d;
        }
        public DataTable GetMakaleBaslikList(string kategoriAdi)
        {
            string sql = "Select MakaleBaslik From VwMakaleKategori where KategoriAdi=" + "'" + kategoriAdi + "'";
            var d = _dbHelper.GetDataTable(sql);
            return d;
        }
        public DataTable GetMakaleBaslik(string makaleBaslik)
        {
            string sql = "Select MakaleBaslik From VwMakaleKategori where MakaleBaslik=" + "'" + makaleBaslik + "'";
            var d = _dbHelper.GetDataTable(sql);
            return d;
        }
        public int Insert(string kategoriAdi,string kategoriAciklama)
        {
            var pars = new Dictionary<string, object>();
            pars.Add("@KategoriAdi", kategoriAdi);
            pars.Add("@KategoriAciklama", kategoriAciklama);
            string sql = "Insert Into Kategori(KategoriAdi,KategoriAciklama) values (@KategoriAdi,@KategoriAciklama) ";
            _dbHelper = new DbHelper();
            var d = _dbHelper.Execute(sql, pars);
            return d;
        }
        public int Update(string kategoriAdi, string kategoriAciklama, int kategoriId)
        {
            var pars = new Dictionary<string, object>();
            pars.Add("@KategoriID", kategoriId);
            pars.Add("@KategoriAdi", kategoriAdi);
            pars.Add("@KategoriAciklama", kategoriAciklama);    
            string sql = "UPDATE Kategori SET KategoriAdi=@KategoriAdi,KategoriAciklama=@KategoriAciklama where KategoriID=@KategoriID";
            _dbHelper = new DbHelper();
            var d = _dbHelper.Execute(sql, pars);
            return d;
        }
        public DataRow SelectItem(int kategoriId)
        {
            var pars = new Dictionary<string, object>();
            pars.Add("@KategoriID", kategoriId);

            string sql = "Select * from Kategori where KategoriID=@KategoriID";
            _dbHelper = new DbHelper();
            return _dbHelper.GetDataRow(sql, pars);
        }
        public DataRow GetKategoriId(string kategoriAdi)
        {
            string sql = "Select KategoriID from Kategori Where KategoriAdi=" + "'" + kategoriAdi + "'";
            _dbHelper = new DbHelper();
            return _dbHelper.GetDataRow(sql);
        }
        public DataRow GetKategoriCount()
        {
            string sql = "Select Count(KategoriID) as KategoriSayisi from Kategori ";
            var d = _dbHelper.GetDataRow(sql);
            return d;
        }

    }
}