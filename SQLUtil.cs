using System;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;

namespace AutoRun
{
    public partial class SQLUtil : Object
    {
        private OleDbCommand command;
        private static SQLUtil instance;

        static SQLUtil()
        {
            SQLUtil.instance = new SQLUtil();

            return;
        }

        private SQLUtil()
        {
            return;
        }

        public static SQLUtil Instance
        {
            get
            {
                return SQLUtil.instance;
            }
        }

        public void Connect(String Host, String Port, String Service, String Login, String Password)
        {
            this.command = new OleDbCommand();
            this.command.Connection = new OleDbConnection();
            this.command.Connection.ConnectionString = String.Format("Provider=MSDAORA;Data Source=(DESCRIPTION = (LOAD_BALANCE = ON) (ADDRESS = (PROTOCOL = TCP) (HOST = {0}) (PORT = {1})) (CONNECT_DATA = (SERVICE_NAME = {2})));User ID={3};Password={4}", Host, Port, Service, Login, Password);
            this.command.Connection.Open();

            return;
        }

        public DataTable Execute(String sql)
        {
            DataTable Result;

            this.command.CommandText = String.Format("{0}", sql);
            Result = new DataTable();
            Result.Load(this.command.ExecuteReader());

            return Result;
        }

        public void Disconnect()
        {
            this.command.Connection.Close();
            this.command.Connection.ConnectionString = String.Empty;
            this.command.Connection = null;
            this.command = null;

            return;
        }
    }
}
