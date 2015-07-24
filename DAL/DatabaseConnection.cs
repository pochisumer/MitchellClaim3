using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    class DatabaseConnection
    {
        SqlConnection connection;

        public DatabaseConnection()
        {
            try
            {
                OpenConnection("server=192.168.100.18; uid=spochi; pwd=Anam@786s; database=NationalRegistry;min pool size=1;max pool size=100");
            }
            catch (Exception ex)
            {
            }
        }

        private void OpenConnection(string conString)
        {
            connection = new SqlConnection(conString);
            connection.Open();
        }

        public int ExecuteNonQuery(string sQuery, SqlParameter[] parameter)
        {
            int iReturn = 0;
            SqlTransaction sqlTransaction = BeginTransaction("Transaction");
            try
            {
                if (String.Empty != sQuery)
                {
                    SqlCommand command = new SqlCommand(sQuery, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Transaction = sqlTransaction;
                    if (parameter != null)
                    {
                        foreach (SqlParameter p in parameter)
                        {
                            command.Parameters.Add(p);
                        }
                    }
                    iReturn = command.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
            }
            catch (Exception ex)
            {
                iReturn = -1;
                sqlTransaction.Rollback();
            }

            return iReturn;
        }

        public DataTable ExecuteReader(string sQuery, SqlParameter[] parameter)
        {
            SqlTransaction sqlTransaction = BeginTransaction("Transaction");
            DataTable table = new DataTable();
            try
            {
                if (String.Empty != sQuery)
                {
                    SqlCommand command = new SqlCommand(sQuery, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Transaction = sqlTransaction;
                    if (parameter != null)
                    {
                        foreach (SqlParameter p in parameter)
                        {
                            command.Parameters.Add(p);
                        }
                    }
                    table.Load(command.ExecuteReader());
                    sqlTransaction.Commit();
                    return table;
                }
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();

                return table;
            }
            return null;
        }

        public SqlTransaction BeginTransaction(String transactionName)
        {
            return connection.BeginTransaction(transactionName);
        }
    }
}
