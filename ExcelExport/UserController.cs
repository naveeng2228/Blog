using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExcelExport
{
    public class UserController : DataBase<SqlParameter, SqlDataReader,
           SqlConnection, SqlTransaction, SqlDataAdapter, SqlCommand>
    {
        public UserController(string ConnectionString)
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

        protected static List<SqlParameter> _params;
        public bool SaveUser(User user)
        {
            _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@UserID", user.UserID));
            _params.Add(new SqlParameter("@Username", user.Username));
            _params.Add(new SqlParameter("@Password_nme", user.Password_nme));
            _params.Add(new SqlParameter("@RoleID", user.RoleID));
            _params.Add(new SqlParameter("@Full_Name", user.Full_Name));
            _params.Add(new SqlParameter("@CreatedDate", user.CreatedDate));
            _params.Add(new SqlParameter("@CreatedTime", user.CreatedTime));
            _params.Add(new SqlParameter("@CreatedBy", user.CreatedBy));
            _params.Add(new SqlParameter("@ModifiedDate", user.ModifiedDate));
            _params.Add(new SqlParameter("@ModifiedTime", user.ModifiedTime));
            _params.Add(new SqlParameter("@ModifiedBy", user.ModifiedBy));
            _params.Add(new SqlParameter("@Status_ind", user.Status_ind));
            _params.Add(new SqlParameter("@Flag", Flags.SaveUser));
            return ExecuteNonQuery("sp_user", _params) > 0 ? true : false;
        }

        public bool UpdateUser(User user)
        {
            _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@UserID", user.UserID));
            _params.Add(new SqlParameter("@Username", user.Username));
            _params.Add(new SqlParameter("@Password_nme", user.Password_nme));
            _params.Add(new SqlParameter("@RoleID", user.RoleID));
            _params.Add(new SqlParameter("@Full_Name", user.Full_Name));
            _params.Add(new SqlParameter("@ModifiedDate", user.ModifiedDate));
            _params.Add(new SqlParameter("@ModifiedTime", user.ModifiedTime));
            _params.Add(new SqlParameter("@ModifiedBy", user.ModifiedBy));
            _params.Add(new SqlParameter("@Status_ind", user.Status_ind));
            _params.Add(new SqlParameter("@Flag", Flags.UpdateUser));
            return ExecuteNonQuery("sp_user", _params) > 0 ? true : false;
        }

        public bool DeleteUser(User user)
        {
            _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@UserID", user.UserID));
            _params.Add(new SqlParameter("@ModifiedDate", user.ModifiedDate));
            _params.Add(new SqlParameter("@ModifiedTime", user.ModifiedTime));
            _params.Add(new SqlParameter("@ModifiedBy", user.ModifiedBy));
            _params.Add(new SqlParameter("@Status_ind", user.Status_ind));
            _params.Add(new SqlParameter("@Flag", Flags.DeleteUser));
            return ExecuteNonQuery("sp_user", _params) > 0 ? true : false;
        }

        public DataSet GetAllActiveUsers()
        {
            _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@Flag", Flags.GetAllActiveUsers));
            return ExecuteDataSet("sp_user", _params);
        }

        public DataSet GetAllUsers()
        {
            _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@Flag", Flags.GetAllUsers));
            return ExecuteDataSet("sp_user", _params);
        }

        public DataSet GetAllDeletedUsers()
        {
            _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@Flag", Flags.GetAllDeletedUsers));
            return ExecuteDataSet("sp_user", _params);
        }

        public DataSet GetUserById(string UserID)
        {
            _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@UserID", UserID));
            _params.Add(new SqlParameter("@Flag", Flags.GetUserById));
            return ExecuteDataSet("sp_user", _params);
        }

        public enum Flags
        {
            SaveUser = 0,
            UpdateUser = 1,
            DeleteUser = 2,
            GetAllActiveUsers = 3,
            GetAllUsers = 4,
            GetAllDeletedUsers = 5,
            GetUserById = 6
        }
    }
}