using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UmitAkinciWeb.Helpers;

namespace UmitAkinciWeb.Business
{
    public class YorumContext
    {
        private DbHelper _dbHelper;
        public YorumContext()
        {
            _dbHelper = new DbHelper();
        }
        public int Insert(string yorumMetni,string adsoyad,string eposta,DateTime yorumTarihi,string yorumOnay,int id)
        {
            var pars = new Dictionary<string, object>();
            pars.Add("@YorumMetni", yorumMetni);
            pars.Add("@YorumAdSoyad", adsoyad);
            pars.Add("@YorumEmail", eposta);
            pars.Add("@YorumTarihi", yorumTarihi);
            pars.Add("@YorumOnay", yorumOnay);
            pars.Add("@MakaleID", id);
            string sql = "Insert Into Yorum(YorumMetni,YorumAdSoyad,YorumEmail,YorumTarihi,YorumOnay,MakaleID) values (@YorumMetni,@YorumAdSoyad,@YorumEmail,@YorumTarihi,@YorumOnay,@MakaleID)";
            _dbHelper = new DbHelper();
            var d = _dbHelper.Execute(sql,pars);
            return d;
        }
        public DataTable GetYorumList()
        {
            string sql = "Select * from Yorum Order By YorumTarihi desc";
            var dt = _dbHelper.GetDataTable(sql);
            return dt;
        }
       /* public DataTable GetMakaleYorumList(int makaleId)
        {
            string sql = "Select * from Yorum where YorumOnay='Onaylandi' and where MakaleID="+makaleId;
            var dt = _dbHelper.GetDataTable(sql);
            return dt;
        }*/
        public DataRow SelectItem(int yorumId)
        {
            var pars = new Dictionary<string, object>();
            pars.Add("@YorumID", yorumId);

            string sql = "Select * from Yorum where YorumID=@YorumID";
            _dbHelper = new DbHelper();
            return _dbHelper.GetDataRow(sql, pars);
        }
        public int Update(int yorumId,string yorumOnay)
        {
            var pars = new Dictionary<string, object>();
            pars.Add("@YorumID", yorumId);
            pars.Add("@YorumOnay", yorumOnay);
            string sql = "UPDATE Yorum SET YorumOnay=@YorumOnay Where YorumID=@YorumID";
            _dbHelper = new DbHelper();
            return _dbHelper.Execute(sql, pars);
        }
        public DataRow GetYorumCount()
        {
            string sql = "Select Count(YorumID) as YorumSayisi from Yorum ";
            var d = _dbHelper.GetDataRow(sql);
            return d;
        }

    }
}