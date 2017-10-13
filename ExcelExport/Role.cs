using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ExcelExport
{
    public class Role
    {
        public int RoleID { get; set; }
        public string Title { get; set; }
        public string Role_Description { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedTime { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedTime { get; set; }
        public int Status_Ind { get; set; }

        UserController ObjUserCtrl;
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        public DataSet GetAllActivePosts()
        {
            ObjUserCtrl = new UserController(ConnectionString);
            return ObjUserCtrl.GetAllActiveUsers();
        }

        public DataSet GetAllPosts()
        {
            ObjUserCtrl = new UserController(ConnectionString);
            return ObjUserCtrl.GetAllUsers();
        }

        public DataSet GetAllDeletedPosts()
        {
            ObjUserCtrl = new UserController(ConnectionString);
            return ObjUserCtrl.GetAllDeletedUsers();
        }

        public DataSet GetPostById()
        {
            ObjUserCtrl = new UserController(ConnectionString);
            return ObjUserCtrl.GetUserById(this.UserID.ToString());
        }

        public bool SavePost()
        {
            ObjUserCtrl = new UserController(ConnectionString);
            return ObjUserCtrl.SaveUser(this);
        }

        public bool UpdatePost()
        {
            ObjUserCtrl = new UserController(ConnectionString);
            return ObjUserCtrl.UpdateUser(this);
        }

        public bool DeletePost()
        {
            ObjUserCtrl = new UserController(ConnectionString);
            return ObjUserCtrl.DeleteUser(this);
        }
    }
}