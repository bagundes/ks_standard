using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace KS_Standard.LogSystem
{
    public class KSLog
    {


        private void CreateDB(string name)
        {
            var sql = @"
CREATE TABLE [Log] (
    [id] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT,
    [user] NVARCHAR(150)  NULL,
    [machine] NVARCHAR(150)  NULL,
    [type] NVARCHAR(10)  NOT NULL,
    [created] TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,
    [code] INTEGER  NOT NULL,
    [friendlymsg] NVARCHAR(250)  NOT NULL,
    [technicalmsg] NVARCHAR(250)  NOT NULL,
    [track] TEXT  NULL
)
";

        }

        //private void Connect()
        //{
        //    DataTable dt = new DataTable();

        //    String insSQL = "select * from Alunos";
        //    String strConn = @"Data Source=C:\dados\MacorattiSQLite.db";

            
        //    SQLiteConnection conn = new SQLiteConnection(strConn);

        //    SQLiteDataAdapter da = new SQLiteDataAdapter(insSQL, strConn);
        //    da.Fill(dt);
        //    gdvAlunos.DataSource = dt.DefaultView;
        //}
    }
}