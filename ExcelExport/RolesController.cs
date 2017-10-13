using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExcelExport
{
    public class RolesController : DataBase<SqlParameter, SqlDataReader,
           SqlConnection, SqlTransaction, SqlDataAdapter, SqlCommand>
    {
        public RolesController(string ConnectionString)
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
        public bool SaveRole(Role role)
        {
            _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@RoleID", role.RoleID));
            _params.Add(new SqlParameter("@Title", role.Title));
            _params.Add(new SqlParameter("@Role_Description", role.Role_Description));
            _params.Add(new SqlParameter("@CreatedDate", role.CreatedDate));
            _params.Add(new SqlParameter("@CreatedTime", role.CreatedTime));
            _params.Add(new SqlParameter("@ModifiedDate", role.ModifiedDate));
            _params.Add(new SqlParameter("@ModifiedTime", role.ModifiedTime));
            _params.Add(new SqlParameter("@Status_Ind", role.Status_Ind));
            _params.Add(new SqlParameter("@Flag", Flags.SaveRole));
            return ExecuteNonQuery("sp_role", _params) > 0 ? true : false;
        }

        public bool UpdateRole(Role role)
        {
            _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@RoleID", role.RoleID));
            _params.Add(new SqlParameter("@Title", role.Title));
            _params.Add(new SqlParameter("@Role_Description", role.Role_Description));
            _params.Add(new SqlParameter("@CreatedDate", role.CreatedDate));
            _params.Add(new SqlParameter("@CreatedTime", role.CreatedTime));
            _params.Add(new SqlParameter("@ModifiedDate", role.ModifiedDate));
            _params.Add(new SqlParameter("@ModifiedTime", role.ModifiedTime));
            _params.Add(new SqlParameter("@Status_Ind", role.Status_Ind));
            _params.Add(new SqlParameter("@Flag", Flags.UpdateRole));
            return ExecuteNonQuery("sp_role", _params) > 0 ? true : false;
        }

        public bool DeleteRole(Role role)
        {
            _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@RoleID", role.RoleID));
            _params.Add(new SqlParameter("@ModifiedDate", role.ModifiedDate));
            _params.Add(new SqlParameter("@ModifiedTime", role.ModifiedTime));
            _params.Add(new SqlParameter("@Status_Ind", role.Status_Ind));
            _params.Add(new SqlParameter("@Flag", Flags.DeleteRole));
            return ExecuteNonQuery("sp_role", _params) > 0 ? true : false;
        }

        public DataSet GetAllActiveRoles()
        {
            _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@Flag", Flags.GetAllActiveRoles));
            return ExecuteDataSet("sp_role", _params);
        }

        public DataSet GetAllRoles()
        {
            _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@Flag", Flags.GetAllRoles));
            return ExecuteDataSet("sp_role", _params);
        }

        public DataSet GetAllDeletedRoles()
        {
            _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@Flag", Flags.GetAllDeletedRoles));
            return ExecuteDataSet("sp_role", _params);
        }

        public DataSet GetRoleById(string RoleID)
        {
            _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@RoleID", RoleID));
            _params.Add(new SqlParameter("@Flag", Flags.GetRoleById));
            return ExecuteDataSet("sp_role", _params);
        }

        public enum Flags
        {
            SaveRole = 0,
            UpdateRole = 1,
            DeleteRole = 2,
            GetAllActiveRoles = 3,
            GetAllRoles = 4,
            GetAllDeletedRoles = 5,
            GetRoleById = 6
        }
    }
}