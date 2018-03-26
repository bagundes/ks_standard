using System;

namespace KS_Standard.db
{
    public class Sqlite : ISql
    {
        private static string source;

        public static void Connect(string source)
        {
            using (var comm = new System.Data.SQLite.SQLiteCommand(source))
            {
                
            }
                throw new NotImplementedException();
        }

        //public static int Execute(string sql, params object[] args)
        //{
        //    throw new NotImplementedException();
        //}

        //public static void Reader(string sql, params object[] args)
        //{
        //    throw new NotImplementedException();
        //}
    }
}