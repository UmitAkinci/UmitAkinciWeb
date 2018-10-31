using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UmitAkinciWeb.Helpers;

namespace UmitAkinciWeb.Business
{
    public class MakaleContext
    {
        private DbHelper _dbHelper;
        public MakaleContext()
        {
            _dbHelper = new DbHelper();
        }
        public DataTable GetSelectMakaleIcerik(string makaleBaslik)
        {
            string sql = "SELECT * FROM Makale Where MakaleBaslik=" + "'" + makaleBaslik + "'";
            var d = _dbHelper.GetDataTable(sql);
            return d;
        }
        public DataRow GetSelectedMakaleId(string makaleBaslik)
        {
            string sql = "SELECT MakaleID FROM Makale Where MakaleBaslik=" + "'" + makaleBaslik + "'";
            var dr = _dbHelper.GetDataRow(sql);
            return dr;
        }
        public DataTable GetSonMakaleBaslik()
        {
            string sql = "select MakaleBaslik from VwMakaleKategori where MakaleEklenmeTarihi = (select max(MakaleEklenmeTarihi) from VwMakaleKategori)";
            var d = _dbHelper.GetDataTable(sql);
            return d;
        }
        public DataTable GetSonMakaleIcerik()
        {
            string sql = "select MakaleIcerik from VwMakaleKategori where MakaleEklenmeTarihi = (select max(MakaleEklenmeTarihi) from VwMakaleKategori)";
            var d = _dbHelper.GetDataTable(sql);
            return d;
        }
        public DataTable GetSonMakaleTarih()
        {
            string sql = "select MakaleEklenmeTarihi from VwMakaleKategori where MakaleEklenmeTarihi = (select max(MakaleEklenmeTarihi) from VwMakaleKategori)";
            var d = _dbHelper.GetDataTable(sql);
            return d;
        }
        public DataTable GetSonOnMakaleBaslikList()
        {
            string sql = "Select TOP 10 MakaleBaslik from VwMakaleKategori order by MakaleEklenmeTarihi desc";
            var d = _dbHelper.GetDataTable(sql);
            return d;
        }
       public DataTable GetOrderByMakaleList()
        {
            string sql = "Select*from Makale order by MakaleID desc";
            var dt = _dbHelper.GetDataTable(sql);
            return dt;
        }
        public int Insert(string makaleBaslik,string makaleIcerik,DateTime dateTime)
        {
            var pars = new Dictionary<string, object>();
            pars.Add("@MakaleBaslik", makaleBaslik);
            pars.Add("@MakaleIcerik", makaleIcerik);
            pars.Add("@MakaleEklenmeTarihi", dateTime);
            string sql = "Insert Into Makale(MakaleBaslik,MakaleIcerik,MakaleEklenmeTarihi) values (@MakaleBaslik,@MakaleIcerik,@MakaleEklenmeTarihi)";
            _dbHelper = new DbHelper();
            var d = _dbHelper.Execute(sql, pars);
            return d;
        }
        public int InsertMakaleKategori(int makaleId,int kategoriId)
        {
            var pars = new Dictionary<string, object>();
            pars.Add("MakaleID", makaleId);
            pars.Add("KategoriID", kategoriId);
            string sql = "Insert Into MakaleKategori(MakaleID,KategoriID) values (@MakaleID,@KategoriID)";
            _dbHelper=new DbHelper();
            var d = _dbHelper.Execute(sql, pars);
            return d;
        }
        public int Update(int makaleId,string makaleBaslik,string makaleIcerik,DateTime dateTime)
        {
            var pars = new Dictionary<string, object>();
            pars.Add("@MakaleID", makaleId);
            pars.Add("@MakaleBaslik", makaleBaslik);
            pars.Add("@MakaleIcerik", makaleIcerik);
            pars.Add("@MakaleEklenmeTarihi", dateTime);
            string sql = "Update Makale Set MakaleBaslik=@MakaleBaslik,MakaleIcerik=@MakaleIcerik,MakaleEklenmeTarihi=@MakaleEklenmeTarihi where MakaleID=@MakaleID";
            _dbHelper = new DbHelper();
            var d = _dbHelper.Execute(sql, pars);
            return d;
        }
        public DataRow SelectItem(int makaleId)
        {
            var pars = new Dictionary<string, object>();
            pars.Add("@MakaleID", makaleId);

            string sql = "Select * from Makale where MakaleID=@MakaleID";
            _dbHelper = new DbHelper();
            return _dbHelper.GetDataRow(sql, pars);
        }
        public DataTable SecilenMakaleBaslikAl(string makaleBaslik)
        {
            string sql = "Select MakaleBaslik From VwMakaleKategori Where MakaleBaslik=" + "'" + makaleBaslik + "'";
            _dbHelper = new DbHelper();
            return _dbHelper.GetDataTable(sql);
        }
        public DataTable SecilenMakaleIcerikAl(string makaleBaslik)
        {
            string sql = "Select MakaleIcerik From VwMakaleKategori Where MakaleBaslik=" + "'" + makaleBaslik + "'";
            _dbHelper = new DbHelper();
            return _dbHelper.GetDataTable(sql);
        }
        public DataTable SecilenMakaleTarihAl(string makaleBaslik)
        {
            string sql = "Select MakaleEklenmeTarihi From VwMakaleKategori Where MakaleBaslik=" + "'" + makaleBaslik + "'";
            _dbHelper = new DbHelper();
            return _dbHelper.GetDataTable(sql);
        }
        public DataTable GetSonMakaleBaslik(string secilenKategori)
        {
            string sql = "SELECT TOP 1 MakaleBaslik from VwMakaleKategori where KategoriAdi="+"'"+secilenKategori+"'"+"ORDER BY MakaleEklenmeTarihi desc";
            var d = _dbHelper.GetDataTable(sql);
            return d;
        }
        public DataTable GetSonMakaleIcerik(string secilenKategori)
        {
            string sql = "SELECT TOP 1 MakaleIcerik from VwMakaleKategori where KategoriAdi=" + "'" + secilenKategori + "'" + "ORDER BY MakaleEklenmeTarihi desc";
            var d = _dbHelper.GetDataTable(sql);
            return d;
        }
        public DataTable GetSonMakaleTarih(string secilenKategori)
        {
            string sql = "SELECT TOP 1 MakaleEklenmeTarihi from VwMakaleKategori where KategoriAdi=" + "'" + secilenKategori + "'" + "ORDER BY MakaleEklenmeTarihi desc";
            var d = _dbHelper.GetDataTable(sql);
            return d;
        }
        public DataRow GetSonMakaleId()
        {
            string sql= "SELECT TOP 1 MakaleID from Makale ORDER BY MakaleEklenmeTarihi desc";
            var d = _dbHelper.GetDataRow(sql);
            return d;
        }
        public DataRow GetMakaleCount()
        {
            string sql = "Select Count(MakaleID) as MakaleSayisi from Makale ";
            var d = _dbHelper.GetDataRow(sql);
            return d;
        }
    }
}