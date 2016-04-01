using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace WebLibrary.Controllers.Utility
{
    public class ImpedanceBaseController : Controller
    {
        public ActionResult SuccessJsonResponse(object data)
        {
            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(new { Success = true, Data = data }),
                ContentType = "application/json"
            };
        }

        public ActionResult SuccessMessageJsonResponse(string message)
        {
            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(new { Success = true, Message = message }),
                ContentType = "application/json"
            };
        }

        public ActionResult FailureMessageJsonResponse(string message)
        {
            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(new { Success = false, Message = message }),
                ContentType = "application/json"
            };
        }

    }
}