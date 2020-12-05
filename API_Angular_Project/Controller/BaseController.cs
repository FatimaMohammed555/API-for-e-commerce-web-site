using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;



namespace API_Angular_Project.Controller
{
    public class BaseController : ApiController
    {
        public string GetUserId()
        {

            return User.Identity.GetUserId();
        }
    }
}
