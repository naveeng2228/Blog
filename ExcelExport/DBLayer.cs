namespace ExcelExport
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data.Common;
    using System.Data;

    public class MyDataBaseLayer<TParameter, TDataReader, TConnection,
           TTransaction, TDataAdapter, TCommand> : DataBase<TParameter,
           TDataReader, TConnection, TTransaction, TDataAdapter, TCommand>
    where TParameter : DbParameter, IDataParameter, new()
    where TDataReader : DbDataReader, IDataReader
    where TConnection : DbConnection, IDbConnection, new()
    where TTransaction : DbTransaction, IDbTransaction
    where TDataAdapter : DbDataAdapter, IDataAdapter, new()
    where TCommand : DbCommand, IDbCommand, new()
    {
        protected List<TParameter> _params;
        public MyDataBaseLayer(string ConnectionString) : base(ConnectionString)
        { }
        public Guid InsertNeMember(string MemberName)
        {
            TParameter paramMemberName = new TParameter();
            paramMemberName.ParameterName = "@memberName";
            paramMemberName.Value = MemberName;
            paramMemberName.DbType = System.Data.DbType.VarNumeric;
            _params = new List<TParameter>();
            _params.Add(paramMemberName);
            return ExecuteScalar<Guid>("proc_Member_Insert", _params);
        }
        public override bool RollBackTransaction(string SavePointName)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override bool SaveTransactionPoint(string SavePointName)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
namespace ExcelExport
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data.SqlClient;
    using System.Data;

    public class SqlDataBase : DataBase<SqlParameter, SqlDataReader,
           SqlConnection, SqlTransaction, SqlDataAdapter, SqlCommand>
    {
        public SqlDataBase(string ConnectionString)
        : base(ConnectionString)
        {
        }
        public override bool RollBackTransaction(string SavePointName)
        {
            if (_conn != null && _conn.State == ConnectionState.Open && _trans != null)
            {
                _trans.Rollback(SavePointName);
                return true;
            }
            return false;
        }
        public override bool SaveTransactionPoint(string SavePointName)
        {
            if (_conn != null && _conn.State == ConnectionState.Open && _trans != null)
            {
                _trans.Save(SavePointName);
                return true;
            }
            return false;
        }
    }
}

namespace ExcelExport
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data.Odbc;
    using System.Data;

    public class OdbcDataBase : DataBase<OdbcParameter, OdbcDataReader,
                 OdbcConnection, OdbcTransaction, OdbcDataAdapter, OdbcCommand>
    {
        public OdbcDataBase(string ConnectionString)
        : base(ConnectionString)
        {
        }
        public override bool RollBackTransaction(string SavePointName)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override bool SaveTransactionPoint(string SavePointName)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}


namespace ExcelExport
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data.OleDb;
    using System.Data;

    class OleDbDataBase : DataBase<OleDbParameter, OleDbDataReader,
          OleDbConnection, OleDbTransaction, OleDbDataAdapter, OleDbCommand>
    {
        public OleDbDataBase(string ConnectionString)
        : base(ConnectionString)
        {
        }
        public override bool RollBackTransaction(string SavePointName)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override bool SaveTransactionPoint(string SavePointName)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}