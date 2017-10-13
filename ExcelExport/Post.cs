using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ExcelExport
{
    public class Post
    {
        public string PostID { get; set; }
        public string PostTitle { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public string UniqueURL { get { return GetUniqueURL(); } }
        public bool Status { get; set; }
        public string SEOTitle { get; set; }
        public string SEODescription { get; set; }
        public string SEOKeywords { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedTime { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedTime { get; set; }
        public int ModifiedBy { get; set; }

        private string GetUniqueURL()
        {
            string Path = CategoryName != string.Empty ? CategoryName : "" + "/" 
                + SubCategoryName != string.Empty ? SubCategoryName : "" + "/" 
                + PostTitle != string.Empty ? PostTitle : "";
            Regex re = new Regex("[;\\\\/:*?\"<>|&']");
            string outputString = re.Replace(Path, " ");
            outputString = System.Text.RegularExpressions.Regex.Replace(outputString, @"\s+", "-");

            return outputString.Trim();
        }
        PostController ObjPostCtrl;
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        public DataSet GetAllActivePosts()
        {
            ObjPostCtrl = new PostController(ConnectionString);
            return ObjPostCtrl.GetAllActivePosts();
        }

        public DataSet GetAllPosts()
        {
            ObjPostCtrl = new PostController(ConnectionString);
            return ObjPostCtrl.GetAllPosts();
        }

        public DataSet GetAllDeletedPosts()
        {
            ObjPostCtrl = new PostController(ConnectionString);
            return ObjPostCtrl.GetAllDeletedPosts();
        }

        public DataSet GetPostById()
        {
            ObjPostCtrl = new PostController(ConnectionString);
            return ObjPostCtrl.GetPostById(this.PostID);
        }

        public bool SavePost()
        {
            ObjPostCtrl = new PostController(ConnectionString);
            return ObjPostCtrl.SavePost(this);
        }

        public bool UpdatePost()
        {
            ObjPostCtrl = new PostController(ConnectionString);
            return ObjPostCtrl.UpdatePost(this);
        }

        public bool DeletePost()
        {
            ObjPostCtrl = new PostController(ConnectionString);
            return ObjPostCtrl.DeletePost(this);
        }
    }
}