using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Silverzone.Web
{

    public class MyClassController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage myMethodNew()
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Hello Divya");
        }

        /* IHttpActionResult contains return type for controller > 
           like it we can pass a redirect View URL and Json data type + http status codes
        */
        [HttpGet]      
        public IHttpActionResult myMethod()
        {
            //return Request.CreateResponse(HttpStatusCode.BadRequest, "Hello Divya");
            //  return Ok("Hello Divya");
            //  return BadRequest
            //  return Created()
            //  return Conflict()
            //  return NotFound()
            //  return Ok()
            return Json(new { result = "Hello" });
        }

        [HttpPut]
        public IHttpActionResult myMethod(int id)
        {
            return Ok("Hello Divya ur id is  " + id.ToString());
        }


    }
}
