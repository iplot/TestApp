using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class FolderController : ApiController
    {
        private FolderService _service;

        public FolderController()
        {
            _service = new FolderService();
        }

        [HttpGet]
        public IHttpActionResult GetFolderInfo(string path = "")
        {
            try
            {
                //bad solution, but I don't know how to do this differently
                string hostName = HttpContext.Current.Request.Url.Host;

                return Ok(_service.GetFolderInfo(path, hostName));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
