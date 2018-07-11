using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR
{
    class UserControl
    {
        public static int userID;
        public static string userName;

        public static void UserRecord(string tableName,string status,string recordID,DateTime date, MySqlConnection conn)
        {
            conn.Close();
            conn.Open();
            string query = "insert into usercontrol (UserControl_UserID,UserControl_TableName,UserControl_Status,UserControl_RecordID,UserControl_Date)values (@UserControl_UserID,@UserControl_TableName,@UserControl_Status,@UserControl_RecordID,@UserControl_Date)";
            MySqlCommand com = new MySqlCommand(query, conn);
            com.Parameters.Add("@UserControl_UserID", MySqlDbType.Int16);
            com.Parameters["@UserControl_UserID"].Value = userID;
            com.Parameters.Add("@UserControl_TableName", MySqlDbType.VarChar, 255);
            com.Parameters["@UserControl_TableName"].Value = tableName;
            com.Parameters.Add("@UserControl_Status", MySqlDbType.VarChar, 255);
            com.Parameters["@UserControl_Status"].Value = status;

            com.Parameters.Add("@UserControl_RecordID", MySqlDbType.VarChar);
            com.Parameters["@UserControl_RecordID"].Value = recordID;
            com.Parameters.Add("@UserControl_Date", MySqlDbType.DateTime);
            com.Parameters["@UserControl_Date"].Value = date;

            com.ExecuteNonQuery();
            conn.Close();
        }

    }
}
