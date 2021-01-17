using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DongHoCasio.Models
{
    public class TinhTrangModel
    {
        public string tinhTrang { get; set; }
        public SelectList TinhTrangList { get; set; }
    }
}