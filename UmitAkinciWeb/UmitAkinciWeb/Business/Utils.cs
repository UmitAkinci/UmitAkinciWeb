using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace UmitAkinciWeb.Business
{
    public class Utils
    {
        public static void BindMenu(Menu menu, DataTable dt, string displayColumnName, string valueColumnName)
        {

            foreach (DataRow dr in dt.Rows)
            {

                var item = new MenuItem();
                item.Text = dr[displayColumnName].ToString();
                item.Value = dr[valueColumnName].ToString();
                menu.Items.Add(item);
            }
        }
        public static void BindLabel(Label label, DataTable dt,string displayColumnName,string valueColumnName)
        {
            foreach (DataRow dr in dt.Rows)
            {
                ArrayList item = new ArrayList();
                item.Add(dr[displayColumnName].ToString());
                item.Add(dr[valueColumnName].ToString());
                foreach (string eleman in item)
                {
                    label.Text = eleman;
                }

            }

        }
        public static void BindDdl(DropDownList ddl, DataTable dt, string displayColumnName, string valueColumnName, bool addSeciniz = false)
        {
            ddl.Items.Clear();
            if (addSeciniz)
            {
                ddl.Items.Add(new ListItem("Seçiniz", "-1"));
            }

            foreach (DataRow dr in dt.Rows)
            {
                var item = new ListItem();
                item.Text = dr[displayColumnName].ToString();
                item.Value = dr[valueColumnName].ToString();

                ddl.Items.Add(item);
            }
        }
        public static int ConvertToInt(string strInt, int defaultValue = -1)
        {
            try
            {
                return Convert.ToInt32(strInt);
            }
            catch
            {
                return defaultValue;

            }
        }
    }
}