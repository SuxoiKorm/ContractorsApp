using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace ContractorsApp.Controllers
{
    public class FileController : ApiController
    {

        [HttpPost]
        public void Post()
        {
            string folderPath = HttpContext.Current.Server.MapPath("~/Files/");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            var file = HttpContext.Current.Request.Files[0];     
            file.SaveAs(folderPath+file.FileName);
        }
    }
}