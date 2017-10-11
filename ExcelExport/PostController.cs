using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExcelExport
{
    public class PostController : DataBase<SqlParameter, SqlDataReader,
           SqlConnection, SqlTransaction, SqlDataAdapter, SqlCommand>
    {
        public PostController(string ConnectionString)
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
        public bool SavePost(Post post)
        {
            _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@PostID", post.PostID));
            _params.Add(new SqlParameter("@PostTitle", post.PostTitle));
            _params.Add(new SqlParameter("@ShortDescription", post.ShortDescription));
            _params.Add(new SqlParameter("@FullDescription", post.FullDescription));
            _params.Add(new SqlParameter("@CategoryID", post.CategoryID));
            _params.Add(new SqlParameter("@SubCategoryID", post.SubCategoryID));
            _params.Add(new SqlParameter("@UniqueURL", post.UniqueURL));
            _params.Add(new SqlParameter("@Status", post.Status));
            _params.Add(new SqlParameter("@SEOTitle", post.SEOTitle));
            _params.Add(new SqlParameter("@SEODescription", post.SEODescription));
            _params.Add(new SqlParameter("@SEOKeywords", post.SEOKeywords));
            _params.Add(new SqlParameter("@CreatedDate", post.CreatedDate));
            _params.Add(new SqlParameter("@CreatedTime", post.CreatedTime));
            _params.Add(new SqlParameter("@ModifiedDate", post.ModifiedDate));
            _params.Add(new SqlParameter("@ModifiedTime", post.ModifiedTime));
            _params.Add(new SqlParameter("@Flag", Flags.SavePost));
            return ExecuteNonQuery("sp_post", _params) > 0 ? true : false;
        }

        public bool UpdatePost(Post post)
        {
            _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@PostID", post.PostID));
            _params.Add(new SqlParameter("@PostTitle", post.PostTitle));
            _params.Add(new SqlParameter("@ShortDescription", post.ShortDescription));
            _params.Add(new SqlParameter("@FullDescription", post.FullDescription));
            _params.Add(new SqlParameter("@CategoryID", post.CategoryID));
            _params.Add(new SqlParameter("@SubCategoryID", post.SubCategoryID));
            _params.Add(new SqlParameter("@UniqueURL", post.UniqueURL));
            _params.Add(new SqlParameter("@Status", post.Status));
            _params.Add(new SqlParameter("@SEOTitle", post.SEOTitle));
            _params.Add(new SqlParameter("@SEODescription", post.SEODescription));
            _params.Add(new SqlParameter("@SEOKeywords", post.SEOKeywords));
            _params.Add(new SqlParameter("@CreatedDate", post.CreatedDate));
            _params.Add(new SqlParameter("@CreatedTime", post.CreatedTime));
            _params.Add(new SqlParameter("@ModifiedDate", post.ModifiedDate));
            _params.Add(new SqlParameter("@ModifiedTime", post.ModifiedTime));
            _params.Add(new SqlParameter("@Flag", Flags.UpdatePost));
            return ExecuteNonQuery("sp_post", _params) > 0 ? true : false;
        }

        public bool DeletePost(Post post)
        {
            _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@PostID", post.PostID));
            _params.Add(new SqlParameter("@Flag", Flags.DeletePost));
            return ExecuteNonQuery("sp_post", _params) > 0 ? true : false;
        }

        public DataSet GetAllActivePosts()
        {
            _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@Flag", Flags.GetAllActivePosts));
            return ExecuteDataSet("sp_post", _params);
        }

        public DataSet GetAllPosts()
        {
            _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@Flag", Flags.GetAllPosts));
            return ExecuteDataSet("sp_post", _params);
        }

        public DataSet GetAllDeletedPosts()
        {
            _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@Flag", Flags.GetAllDeletedPosts));
            return ExecuteDataSet("sp_post", _params);
        }

        public DataSet GetPostById(string PostID)
        {
            _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@PostID", PostID));
            _params.Add(new SqlParameter("@Flag", Flags.GetPostById));
            return ExecuteDataSet("sp_post", _params);
        }

        public enum Flags
        {
            SavePost = 0,
            UpdatePost = 1,
            DeletePost = 2,
            GetAllActivePosts = 3,
            GetAllPosts = 4,
            GetAllDeletedPosts = 5,
            GetPostById = 6
        }
    }
}