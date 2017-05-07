using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DAL
{
    public class oledbhelper
    {
        public static string CONECTIONSTRING
        {
            get
            {
                return @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\JanisDB.accdb";
            }
        }
        public static void Execute(string com)
        {
            OleDbConnection cn = new OleDbConnection(CONECTIONSTRING);
            cn.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = cn;
            command.CommandText = com;
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }
        public static DataTable GetTable(string com)
        {
            //Connection  יצירת אובייקט מסוג 
            OleDbConnection cn = new OleDbConnection(CONECTIONSTRING);
            // command יצירת אובייקט מסוג 
            OleDbCommand command = new OleDbCommand();
            command.Connection = cn;
            command.CommandText = com;
            //יצירת אובייקט מסוג דטהסט - אוסף טבלאות בזיכרון המחשב

            DataTable dt = new DataTable();
            dt.TableName = "tbl";
            //יצירת אובייקט אדפטר מטרתו לתאם בין הדטהסט לדטהבייס
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);

            try
            {
                //הפעולה פותחת את הדטהבייס ומחזירה את כל הנתונים לתוך טבלה חדשה בדטהסט
                adapter.Fill(dt);
            }
            catch
            {

            }
            finally
            {

            }
            return dt;
        }
    }
}
