using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UmitAkinciWeb.Helpers;

namespace UmitAkinciWeb
{
    public class KullaniciContext
    {
        private DbHelper _dbHelper;
        public KullaniciContext()
        {
            _dbHelper = new DbHelper();
        }
        public DataRow GetKullanici(string kullaniciAdi,string sifre)
        {
            var pars = new Dictionary<string, object>();
            pars.Add("@KullaniciAdi",kullaniciAdi);
            pars.Add("@KullaniciSifre", sifre);
            string sql = "Select * from Kullanici where KullaniciAdi=@KullaniciAdi and KullaniciSifre=@KullaniciSifre";
            _dbHelper = new DbHelper();
            return _dbHelper.GetDataRow(sql,pars);
        }
    }
}