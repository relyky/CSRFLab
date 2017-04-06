using CSRFLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace CSRFLab.Controllers
{
    public class MyFormController : ApiController
    {
        public Student Post(Student st)
        {
            return st;
        } 
    }
}
