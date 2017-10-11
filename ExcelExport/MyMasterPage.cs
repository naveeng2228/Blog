using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ExcelExport
{
    public class MyMasterPage : MasterPage
    {
        public Page Content { get; set; }

        public MyMasterPage() : base()
        {

        }
    }
}