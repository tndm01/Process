﻿using System;
using System.Data;
using System.Data.SqlClient;
using ITD.Monitor.Common.NLogHelper;

namespace ITD.Monitor.Common.DBHelper
{
    public class DataBaseHelper
    {
        #region Fiels

        private const string CONN_STRING = "Server={0}; Database={1}; User={2}; Password={3};Connect Timeout={4};";
        private string connectionString;

        #endregion Fiels

        #region Constructor

        public DataBaseHelper(string strConnection)
        {
            connectionString = strConnection;
            _instance = this;
        }

        private static DataBaseHelper _instance;

        public static DataBaseHelper GetInstance()
        {
            return _instance;
        }

        #endregion Constructor

        #region Method

        /// <summary>
        /// Hàm th?c thi command
        /// </summary>
        /// <param name="pCommand"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(SqlCommand pCommand)
        {
            int numRows = 0;
            try
            {
                if (pCommand == null)
                    return 0;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    pCommand.Connection = connection;
                    numRows = pCommand.ExecuteNonQuery();
                }
                //return numRows;
            }
            catch (Exception ex)
            {
                NLogHelper.NLogHelper.Error("DbLibrary.ExecuteNonQuery(DbCommand)", ex);
                //throw ex;
            }
            finally
            {
                // CloseConnection();
                //if (pCommand != null) pCommand.Dispose();
            }
            return numRows;
        }

        /// <summary>
        /// Hàm th?c thi command tr? v? DataTable
        /// </summary>
        /// <param name="pCommand"></param>
        /// <returns></returns>
        public DataTable GetDataTable(SqlCommand pCommand)
        {
            DataTable table = null;
            try
            {
                if (pCommand == null)
                    return null;

                //OpenConnection();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //pCommand.Connection = connection;
                    connection.Open();
                    pCommand.Connection = connection;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = pCommand;
                    table = new DataTable();
                    adapter.Fill(table);

                    //CloseConnection();
                    //if (ds != null && ds.Tables.Count > 0)
                    //    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                NLogHelper.NLogHelper.Error("DbLibrary.GetDataTable(DbCommand)", ex);
            }
            finally
            {
                //CloseConnection();
                if (pCommand != null) pCommand.Dispose();
            }

            return table;
        }

        /// <summary>
        /// Hàm th?c thi SqlCommand
        /// </summary>
        /// <param name="pCommand"></param>
        /// <returns></returns>
        public object ExecuteScalar(SqlCommand pCommand)
        {
            object value = null;
            try
            {
                if (pCommand == null)
                    return null;

                //OpenConnection();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    pCommand.Connection = connection;

                    value = pCommand.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                NLogHelper.NLogHelper.Error("DbLibrary.ExecuteScalar(DbCommand)", ex);
                //throw ex;
            }
            finally
            {
                //CloseConnection();
                if (pCommand != null) pCommand.Dispose();
            }

            return value;
        }

        public string GetParamValue(string pParamID)
        {
            string retValue = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select dbo.SYNC_fnGetCodeValue(@KeyID) as RetValue";
                cmd.Parameters.AddWithValue("KeyID", pParamID);

                retValue = ExecuteScalar(cmd).ToString();
            }
            catch (Exception ex)
            {
                NLogHelper.NLogHelper.Error(string.Format("GetParamValue('{0}')", pParamID), ex);
            }

            return retValue;
        }

        public bool CheckOpenConnection()
        {
            bool value = false;
            try
            {
                // Open connection
                using (var connection = new SqlConnection(connectionString))
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    value = connection.State == ConnectionState.Open;
                }
            }
            catch (Exception ex)
            {
                NLogHelper.NLogHelper.Error("DbLibrary.OpenConnection()", ex);
            }

            return value;
        }

        #endregion Method

        public static string GetConnectionString(string server, string database, string userID, string password, string timeout)
        {
            return string.Format(CONN_STRING, server, database, userID, password, timeout);
        }

        internal DataTable GetDataTable(string p)
        {
            throw new NotImplementedException();
        }
    }
}