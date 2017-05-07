using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace DAL
{
    public class IO
    {

        public static void Add(string input, params string[] OutputOpt)
        {
            string com = "insert into Input (Inputs";
            for (int i = 0; i < OutputOpt.Length; i++)
            {
                com = com + "," + "OutputOpt" + i;
            }
            com = com + ") VALUES ('" + input + "'";
            for (int i = 0; i < OutputOpt.Length; i++)
            {
                com = com + ",'" + OutputOpt[i] + "'";
            }
            com += ")";
            oledbhelper.Execute(com);
        }
        public static DataTable GetAllInputs()
        {
            string com = "select * from Inputs";
            return oledbhelper.GetTable(com);
        }

        #region Update
        public static void Update(int code, string Fname, string Lname, string Phone)
        {
            string com = "update Inputs set FirstName='" + Fname + "',LastName='" + Lname + "',Phone='" + Phone + "' where  num=" + code;
            oledbhelper.Execute(com);
        }
        #endregion

        public static void Delete(int id)
        {
            string com = "DELETE FROM Inputs WHERE ID=" + id + "";
            oledbhelper.Execute(com);

        }
    }
}
