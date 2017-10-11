using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace ExcelExport
{
    public abstract class DataBase<TParameter, TDataReader, TConnection, TTransaction, TDataAdapter, TCommand> : IDisposable
    where TParameter : DbParameter, IDataParameter
    where TDataReader : DbDataReader, IDataReader
    where TConnection : DbConnection, IDbConnection, new()
    where TTransaction : DbTransaction, IDbTransaction
    where TDataAdapter : DbDataAdapter, IDataAdapter, new()
    where TCommand : DbCommand, IDbCommand, new()
    {
        protected TConnection _conn;
        protected TTransaction _trans;
        public DataBase(string ConnectionString)
        {
            _conn = new TConnection();
            _conn.ConnectionString = ConnectionString;
        }

        public void Dispose()
        {
            
        }

        protected DataSet ExecuteDataSet(string StoreProcName, List<TParameter> Params)
        {
            bool internalOpen = false;
            DataSet ds = null;
            TDataAdapter da;
            TCommand cmd;

            try
            {
                ds = new DataSet();
                da = new TDataAdapter();
                cmd = new TCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = StoreProcName;
                if (_trans != default(TTransaction))
                    cmd.Transaction = _trans;
                else
                    cmd.Connection = (TConnection)_conn;
                if (Params != null || Params.Count > 0)
                {
                    foreach (DbParameter param in Params)
                        cmd.Parameters.Add(param);
                }
                da.SelectCommand = cmd;
                if (_conn.State == ConnectionState.Closed)
                {
                    _conn.Open();
                    internalOpen = true;
                }
                da.Fill(ds);
                return ds;
            }
            catch (DbException DbEx)
            {
                throw DbEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (internalOpen)
                    _conn.Close();
            }
        }

        protected T ExecuteScalar<T>(string StoreProcName, List<TParameter> Params)
        {
            bool internalOpen = false;
            TCommand cmd;
            try
            {
                cmd = new TCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = StoreProcName;
                if (_trans != default(TTransaction))
                    cmd.Transaction = _trans;
                else
                    cmd.Connection = _conn;
                if (Params != null || Params.Count > 0)
                {
                    foreach (DbParameter param in Params)
                        cmd.Parameters.Add(param);
                }
                if (_conn.State == ConnectionState.Closed)
                {
                    _conn.Open();
                    internalOpen = true;
                }

                object retVal = cmd.ExecuteScalar();
                if (retVal is T)
                    return (T)retVal;
                else if (retVal == DBNull.Value)
                    return default(T);
                else
                    throw new Exception("Object returned was of the wrong type.");
            }
            catch (DbException DbEx)
            {
                throw DbEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (internalOpen)
                    _conn.Close();
            }
        }

        protected int ExecuteNonQuery(string StoreProcName, List<TParameter> Params)
        {
            bool internalOpen = false;
            TCommand cmd;

            try
            {
                cmd = new TCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = StoreProcName;
                if (_trans != default(TTransaction))
                    cmd.Transaction = _trans;
                else
                    cmd.Connection = _conn;
                if (Params != null || Params.Count > 0)
                {
                    foreach(DbParameter param in Params)
                        cmd.Parameters.Add(param);
                }
                if (_conn.State == ConnectionState.Closed)
                {
                    _conn.Open();
                    internalOpen = true;
                }
                return cmd.ExecuteNonQuery();
            }
            catch (DbException DbEx)
            {
                throw DbEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (internalOpen)
                    _conn.Close();
            }
        }

        protected TDataReader ExecuteReader(string StoreProcName, List<TParameter> Params)
        {
            bool internalOpen = false;
            TCommand cmd;

            try
            {
                cmd = new TCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = StoreProcName;
                if (_trans != default(TTransaction))
                    cmd.Transaction = _trans;
                else
                    cmd.Connection = _conn;
                if (Params != null || Params.Count > 0)
                {
                    foreach (DbParameter param in Params)
                        cmd.Parameters.Add(param);
                }
                if (_conn.State == ConnectionState.Closed)
                {
                    _conn.Open();
                    internalOpen = true;
                }
                return (TDataReader)cmd.ExecuteReader();
            }
            catch (DbException DbEx)
            {
                throw DbEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (internalOpen)
                    _conn.Close();
            }
        }

        public bool BeginTransaction()
        {
            if (_conn != null && _conn.State == ConnectionState.Closed && _trans == null)
            {
                _conn.Open();
                _trans = (TTransaction)_conn.BeginTransaction();
                return true;
            }
            return false;
        }

        public bool RollBackTransaction()
        {
            if (_conn != null && _conn.State == ConnectionState.Open && _trans != null)
            {
                _trans.Rollback();
                _conn.Close();

                _trans.Dispose();
                _trans = default(TTransaction);
                return true;
            }
            return false;
        }

        public bool CommitTransaction()
        {
            if (_conn != null && _conn.State == ConnectionState.Open && _trans != null)
            {
                _trans.Commit();
                _conn.Close();
                _trans.Dispose();
                _trans = default(TTransaction);
                return true;
            }
            return false;
        }

        public abstract bool RollBackTransaction(string SavePointName);
        public abstract bool SaveTransactionPoint(string SavePointName);
    }
}